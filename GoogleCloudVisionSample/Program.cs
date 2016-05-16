using System;
using System.IO;
using Newtonsoft.Json;

namespace GoogleCloudVisionSample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var apiKey = args[0];
            var gcv = new GoogleCloudVisionAPI(apiKey);
            var response = gcv.RequestAnotate(readImage());

            var resJSON = JsonConvert.SerializeObject(response.Result.Responses, Formatting.Indented);
            Console.WriteLine("Responses ==================================================");
            Console.WriteLine(resJSON);
            Console.WriteLine("==================================================");
        }

        /// <summary>
        /// Get base64 image.
        /// </summary>
        public static string readImage()
        {
            byte[] bs = null;

            using (var fs = File.Open("./image_in.jpg", FileMode.Open))
            {
                bs = new byte[fs.Length];
                fs.Read(bs, 0, bs.Length);
            }

            return Convert.ToBase64String(bs);
        }
    }
}
