using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bot72.repository
{
    public class CepModel
    {
        public CepModel()
        { }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
    }




    public class CepRepository
    {

        HttpClient _cep = new HttpClient();


        public CepRepository()
        {
            _cep.BaseAddress = new Uri("https://viacep.com.br/ws/");
            _cep.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<CepModel> GetCep(String cep)
        {
            HttpResponseMessage response = await _cep.GetAsync(cep + "/json/");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CepModel>(dados);
            }

            return new CepModel();
        }


    }

}
