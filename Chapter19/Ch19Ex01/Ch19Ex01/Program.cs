using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Newtonsoft.Json;

namespace Ch19Ex01
{
    public class Program
    {
        //public static Settings _settings;
        //public static Api _api;
        public static async Task Main()
        {
            string credentialsRelativePath = @"..\..\..\credentials.json";
            using StreamReader r = new StreamReader(credentialsRelativePath);
            string json = r.ReadToEnd();
            dynamic credentials = JsonConvert.DeserializeObject(json);
            string accessKey = credentials["accessKey"];
            string secretKey = credentials["secretKey"];

            string bucketName = "cards";
            string contentType = "image/png";

            string endpoint = "mioapi.eventifyofficial.com";
            string region = "eu-east-1";

            var minioClient = new MinioClient()
                              .WithEndpoint(endpoint)
                              //.WithCredentials("Book_Test_User", "Book_Test_User")
                              .WithCredentials(accessKey, secretKey)
                              .WithRegion(region)
                              .WithSSL(true)
                              .Build();

            try
            {
                //Create bucket if it doesn't exist.
                BucketExistsArgs bea = new BucketExistsArgs().WithBucket(bucketName);
                bool found = await minioClient.BucketExistsAsync(bea);
                Console.WriteLine($"Found buckets? - {found}");
                if (found)
                {
                    Console.WriteLine($"{bucketName} already exists");
                }
                else
                {
                    //Create bucket 'cards'.
                    await minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
                    Console.WriteLine($"{bucketName} is created successfully");
                }
            }
            catch (MinioException e)
            {
                Console.WriteLine("Error occurred: " + e);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            try
            {
                var progress = new Progress<ProgressReport>(progressReport =>
                {
                    Console.WriteLine($"Percentage: {progressReport.Percentage}% TotalBytesTransferred: {progressReport.TotalBytesTransferred} bytes");
                    if (progressReport.Percentage != 100)
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                    else Console.WriteLine();
                });

                string[] files = Directory.GetFiles(@"..\..\..\Cards", "*.png");
                foreach (string file in files)
                {
                    string objectName = Path.GetFileName(file);
                    string objectPath = "Cards/" + objectName;

                    PutObjectArgs poa = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(objectName)
                    .WithFileName(objectPath)
                    .WithContentType(contentType)
                    .WithProgress(progress)
                    ;

                    await minioClient.PutObjectAsync(poa);
                    //StatObjectArgs soa = new StatObjectArgs()
                    //    .WithBucket(bucketName)
                    //    .WithObject(objectName);

                    //ObjectStat state = await minioClient.StatObjectAsync(soa);
                    //Console.WriteLine(state.ObjectName);
                }
            }
            catch (ObjectNotFoundException onfe)
            {
                Console.WriteLine($"Error: {onfe.Message}");
            }
            catch (MinioException me)
            {
                Console.WriteLine($"Error: {me.Message}");
            }
        }
    }
}
