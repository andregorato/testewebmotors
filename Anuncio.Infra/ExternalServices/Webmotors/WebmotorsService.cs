using Domain.Dto;
using Domain.Interfaces.ExternalServices.Webmotors;
using Infra.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infra.ExternalServices.Webmotors
{
    public class WebmotorsService : IWebmotorsService
    {
        private WebmotorsConfiguration _webmotorsConfig { get; set; }
        public WebmotorsService(IOptions<WebmotorsConfiguration> webmotorsConfig)
        {
            _webmotorsConfig = webmotorsConfig.Value;
        }

        public async Task<IEnumerable<MarcaDto>> ObterMarcasAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_webmotorsConfig.UrlObterMarcas))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var marcas = JsonConvert.DeserializeObject<List<MarcaDto>>(apiResponse);

                    return marcas;
                }
            }
        }

        public async Task<IEnumerable<ModeloDto>> ObterModelosAsync(int marcaId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_webmotorsConfig.UrlObterModelos}?MakeID={marcaId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var modelos = JsonConvert.DeserializeObject<List<ModeloDto>>(apiResponse);

                    return modelos;
                }
            }
        }

        public async Task<IEnumerable<VersaoDto>> ObterVersoesAsync(int modeloId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_webmotorsConfig.UrlObterVersoes}?ModelID={modeloId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var versoes = JsonConvert.DeserializeObject<List<VersaoDto>>(apiResponse);

                    return versoes;
                }
            }
        }

    }
}
