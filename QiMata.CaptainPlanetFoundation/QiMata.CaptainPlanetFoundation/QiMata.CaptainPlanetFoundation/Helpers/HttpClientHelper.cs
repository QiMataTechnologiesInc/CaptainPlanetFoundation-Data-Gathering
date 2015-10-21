using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace QiMata.CaptainPlanetFoundation.Helpers
{
    static class HttpClientHelper
    {
        public static async Task<T> Post<T>(string url,string path, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(path, item);
                var result = await response.Content.ReadAsAsync<T>();

                return result;
            }
        }

        public static async Task<IEnumerable<T>> Get<T>(string url,string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(path);
                return await response.Content.ReadAsAsync<IEnumerable<T>>(new MediaTypeFormatter[] { new JsonMediaTypeFormatter() });
            }
        }
    }
}
