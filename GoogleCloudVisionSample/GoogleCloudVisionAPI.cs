using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;

namespace GoogleCloudVisionSample
{
    public class GoogleCloudVisionAPI
    {
        private string apiKey;

        public GoogleCloudVisionAPI(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<BatchAnnotateImagesResponse> RequestAnotate(string base64Img)
        {
            var service = new VisionService(new BaseClientService.Initializer
            {
                ApiKey = apiKey
            });

            var request = service.Images.Annotate(new BatchAnnotateImagesRequest
            {
                Requests = new[]
                {
                    new AnnotateImageRequest
                    {
                        Image = new Image
                        {
                            Content = base64Img
                        },
                        Features = new[]
                        {
                            "TEXT_DETECTION"
                        }.Select(x=> new Feature { Type = x })
                         .ToArray()
                    }
                }
            });

            return await request.ExecuteAsync();
        }
    }
}

