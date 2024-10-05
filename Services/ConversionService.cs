using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Parcial_progra.Services
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
            try
            {
                var response = await _httpClient.GetAsync("https://api.coindesk.com/v1/bpi/currentprice/BTC.json");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonResponse);
                    double tasaCambio = data.bpi.USD.rate_float;
                    return tasaCambio;
                }
                else
                {
                    return 0.00003; // Valor fallback en caso de fallo
                }
            }
            catch
            {
                return 0.00003; // Valor fallback en caso de excepción
            }
        }
    }
}
