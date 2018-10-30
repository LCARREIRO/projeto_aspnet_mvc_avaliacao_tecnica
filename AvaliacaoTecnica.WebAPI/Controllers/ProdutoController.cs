using AvaliacaoTecnica.AcessoDados.Dados;
using AvaliacaoTecnica.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AvaliacaoTecnica.WebAPI.Controllers
{
    //Cors habilitado para qualquer tipo de 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutoController : ApiController
    {
        protected readonly DadosJson _massaDadosJson = new DadosJson();

        // GET: api/Produto
        public IHttpActionResult Get()
        {
            try
            {
                ProdutoServico servico = new ProdutoServico();
                return Ok(servico.OrdernaPorMarca(_massaDadosJson.RetornaDadosJson()).Take(10));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Produto
        public IHttpActionResult Get(string nome)
        {
            try
            {
                return Ok(_massaDadosJson.RetornaDadosJson().Where(c => c.Nome.ToLower().Contains(nome.ToLower())));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
