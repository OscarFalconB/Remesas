using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nueva_carpeta.Services
{
    public class ConversionService
    {
        private readonly HttpClient _httpClient;

        public ConversionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> ObtenerTasaCambioUsdBtc()
        {
            var response = await _httpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice/USD.json");
            var jsonResult = JObject.Parse(response);

            var rate = jsonResult?["bpi"]?["USD"]?["rate_float"];
            if (rate != null)
            {
                return (double)rate;
            }

            return 0.0; // Devuelve 0.0 si no se puede obtener la tasa de cambio
        }
    }
}
