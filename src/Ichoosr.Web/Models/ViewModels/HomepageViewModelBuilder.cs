using Ichoosr.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ichoosr.Web.Models.ViewModels
{
    public class HomepageViewModelBuilder
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomepageViewModelBuilder(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HomepageViewModel> Build()
        {
            var model = new HomepageViewModel();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44366/Camera");
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                StreamReader reader = new StreamReader(responseStream);
                string text = reader.ReadToEnd();

                var cameras = JsonConvert.DeserializeObject<IEnumerable<Camera>>(text);
                model.Cameras = cameras;
                model.CamerasThree = cameras.Where(c => c.Number % 3 == 0);
                model.CamerasFive = cameras.Where(c => c.Number % 5 == 0);
                model.CamerasThreeAndFive = cameras.Where(c => c.Number % 3 == 0 && c.Number % 5 == 0);
                model.CamerasOther = cameras.Where(c => c.Number % 3 != 0 && c.Number % 5 != 0);
            }

            return model;
        }
    }
}
