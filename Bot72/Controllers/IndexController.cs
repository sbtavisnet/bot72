using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bot72.Controllers
{

    [Route("api/index")]
    [ApiController]
    public class IndexController : ControllerBase
    {

        private class DadosIndex
        {
            public string Nome { get; set; }
            public string Autor { get; set; }
            public string Email { get; set; }
            public string Data { get; set; }
            public string Hora { get; set; }


        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;

            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;

            DadosIndex dadosIndex = new DadosIndex();
          
            dadosIndex.Nome = "API Boot72 - Versão: 1.0.14";
            dadosIndex.Autor = "Sanderson Barbosa Torres";
            dadosIndex.Email = "sbt@avisnet.com.br";
            dadosIndex.Data = dia.ToString() + "/" + mes.ToString() + "/" + ano.ToString();
            dadosIndex.Hora =  hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();


            return Ok(dadosIndex);
        }
        

            
    
    }

        
}
