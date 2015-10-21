using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using QiMata.CaptainPlanetFoundation.Helpers;
using QiMata.CaptainPlanetFoundation.Models;

namespace QiMata.CaptainPlanetFoundation.Client
{
    class HabitatRestorationClient
    {
        private readonly string _baseUrl;

        public HabitatRestorationClient()
        {
            _baseUrl = Constants.BaseApiClientUrl;
        }

        public HabitatRestorationClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<HabitatRestoration> PostHabitatRestoration(HabitatRestoration habitatRestoration)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/HabitatRestorations", habitatRestoration);
                var result = await response.Content.ReadAsAsync<HabitatRestoration>();

                return result;
            }
        }
    }
}
