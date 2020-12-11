using Newtonsoft.Json;
using StatWorks.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace StatWorks.Services
{
    [Preserve(AllMembers = true)]
    public class BMIApiClient
    {
        private readonly HttpClient httpClient = new HttpClient();

        static BMIApiClient _instance;
        public static BMIApiClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BMIApiClient();
                }

                return _instance;
            }
        }

        private BMIApiClient()
        {
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "5f12d11e9cmsh3deee811aed8d50p1c23c4jsnc804fe5cd4b0");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "bmi.p.rapidapi.com");
        }
        
        public async Task<BMIApiResponse> PostBMI(BodyMetrics bodyMetrics)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(bodyMetrics), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync("https://bmi.p.rapidapi.com/", content);
            string responseString = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BMIApiResponse>(responseString);
        }
    }
}
