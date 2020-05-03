using Bot72.Domain.Utils;
using Bot72.repository;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bot72.Controllers
{
    [ApiController]
    [Route("api/cep")]
    public class CepController : ControllerBase
    {
        private readonly CepRepository _repository;


        public CepController(CepRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ResultViewModel>> Get(string cep)
        {
            var acep = AvisnetUtils.OnlyNumber(cep);
            if (AvisnetUtils.GetSize(acep) != 8)
            {
              return ResultViewModel.Mensagem(false, "Cep Inválido !!", null);

            }
            if (!AvisnetUtils.IsConnected())
            {
                return ResultViewModel.Mensagem(false, 
                                               "Servidor sem conexão de Internet !!",
                                                null);

            }


            var dados =  await _repository.GetCep(acep);

            return ResultViewModel.Mensagem(true, "Sucesso", dados);
            
        }


    }
        
}
