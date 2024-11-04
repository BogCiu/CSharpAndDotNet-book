using NextcloudApi;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Xml.Linq;
namespace Ch19Ex01
{
    internal class Program
    {
        public static Settings _settings;
        public static Api _api;
        static void Main()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"Cards");
                foreach(FileInfo f in dir.GetFiles("*.*"))
                {
                    using FileStream stream = File.OpenRead(@"Cards\" + f.Name);
                    {
                        Task<string> UploadTask = CloudFile.Upload(Api, Settings.Username + $"/C_Sharp_Book/{f.Name}", stream);
                        string taskResolution = RunTask(UploadTask);
                        //Console.WriteLine(f.Name);
                    }
                }

                Task<List<CloudInfo>> myNextCloudProjectFolderSearch = CloudFolder.List(Api, Settings.Username + "/C_Sharp_Book");
                List<CloudInfo> MyFolderCI = RunTask(myNextCloudProjectFolderSearch);
                Console.WriteLine(MyFolderCI.ToHumanReadableJson());


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Exception : {ex}");
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
        public static T RunTask<T>(Task<T> task)
        {
            T t = task.Result;
            //Console.WriteLine(t);
            return t;
        }
        public static Api Api
        {
            get
            {
                _api ??= new Api(Settings);
                return _api;
            }
        }
        public static Settings Settings
        {
            get
            {
                if (_settings == null)
                {
                    string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NextcloudApi");
                    Directory.CreateDirectory(dataPath);
                    string filename = Path.Combine(dataPath, "TestSettings.json"); // C:\Users\Administrator\AppData\Local\NextCloudAPI

                    _settings = new Settings();
                    _settings.Load(filename);
                    List<string> errors = _settings.Validate();
                    if (errors.Count > 0)
                    {
                        throw new ApplicationException(string.Join("\r\n", errors));
                    }
                }
                return _settings;
            }
        }

    }
}
