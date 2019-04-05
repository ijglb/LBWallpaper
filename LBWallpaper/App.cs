using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LBWallpaper
{
    public static class App
    {
        public static Config Config;

        private static Notify _Notify;

        private static System.Timers.Timer _Timer;

        private static string _CachePath = Path.Combine(Application.UserAppDataPath, "Cache");
        private static string _LogFile = Path.Combine(Application.UserAppDataPath, "logs.txt");
        private static string _OldFile = "";

        public static void Run()
        {
            if (!Directory.Exists(_CachePath))
            {
                Directory.CreateDirectory(_CachePath);
            }
            if (Config == null)
            {
                Config = new Config();
                Config.ReadConfig();
            }
            if (_Notify == null)
            {
                _Notify = new Notify();
                _Notify.Creat();
            }
            if (_Timer == null)
            {
                _Timer = new System.Timers.Timer(Config.ChangeInterval);
                _Timer.Elapsed += _Timer_Elapsed;
                _Timer.Start();
            }
        }

        public static void RefreshInterval()
        {
            if (Config.ChangeInterval != (int)_Timer.Interval)
            {
                _Timer.Interval = Config.ChangeInterval;
            }
        }

        public static void StopTimer() => _Timer.Stop();
        public static void StartTimer() => _Timer.Start();

        public static bool GetNewWallpaper()
        {
            string file;
            if (Config.IsSpecailWallpaper && !string.IsNullOrEmpty(Config.SpecailWallpaper) && File.Exists(Config.SpecailWallpaper))
                file = Config.SpecailWallpaper;
            else
                file = CheckAndDownloadWallpaper();

            if (string.IsNullOrEmpty(file))
                return false;
            if (!Config.IsSpecailWallpaper && (file == _OldFile))
                return GetNewWallpaper();

            _OldFile = file;

            Wallpaper.Set(file, Wallpaper.Style.Fill);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    long len = 0;
                    DirectoryInfo dir = new DirectoryInfo(_CachePath);
                    var files = dir.GetFiles();
                    foreach (var fileInfo in files)
                    {
                        len += fileInfo.Length;
                    }

                    var maxSize = 1048576 * Config.CacheSize;
                    if (len > maxSize)
                    {
                        var fileList = files.OrderBy(m => m.CreationTime).ToList();
                        while (len > maxSize)
                        {
                            var deletefile = fileList.FirstOrDefault();
                            deletefile.Delete();
                            len -= deletefile.Length;
                            fileList.Remove(deletefile);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            });
            return true;
        }

        private static void _Timer_Elapsed(object sender, ElapsedEventArgs e) => GetNewWallpaper();

        private static string CheckAndDownloadWallpaper()
        {
            try
            {
                if (PingIpOrDomainName("www.baidu.com"))
                {
                    HttpWebRequest myHttpWebRequest = WebRequest.CreateHttp("https://img.ijglb.com/api.php?v=123456");
                    myHttpWebRequest.AllowAutoRedirect = false;
                    myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
                    using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                    {
                        string imgUrl = myHttpWebResponse.Headers.Get("Location");
                        myHttpWebResponse.Close();
                        myHttpWebRequest.Abort();
                        if (string.IsNullOrEmpty(imgUrl))
                            return GetLocalRandomWallpaper();

                        var groups = Regex.Match(imgUrl, @"http[s]?://.+?/(.+?)\.(jpg|png)$").Groups;
                        string file = MD5Encrypt16(groups[1].Value) + "." + groups[2].Value;
                        string filePath = Path.Combine(_CachePath, file);
                        if (File.Exists(filePath))
                        {
                            return filePath;
                        }
                        else
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(imgUrl, filePath);
                                return filePath;
                            }
                        }
                    }
                }
                else
                {
                    return GetLocalRandomWallpaper();
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                return GetLocalRandomWallpaper();
            }
        }

        private static string GetLocalRandomWallpaper()
        {
            DirectoryInfo dir = new DirectoryInfo(_CachePath);
            var files = dir.GetFiles();
            if (files.Length == 0)
                return null;

            int r = new Random().Next(files.Length);
            return Path.Combine(_CachePath, files[r].ToString());
        }

        private static string MD5Encrypt16(string password)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败
        /// </summary>
        /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
        /// <returns></returns>
        private static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 5 * 1000;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                return false;
            }
        }

        private static void Log(string msg)
        {
            try
            {
                File.AppendAllLines(_LogFile, new string[] { string.Format("{0}  {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg) });
            }
            catch (Exception)
            {
            }
        }
    }
}
