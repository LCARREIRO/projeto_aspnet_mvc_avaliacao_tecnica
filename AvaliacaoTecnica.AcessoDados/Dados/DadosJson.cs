using AvaliacaoTecnica.Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AvaliacaoTecnica.AcessoDados.Dados
{
    public class DadosJson
    {
        public List<Produto> RetornaDadosJson()
        {
            try
            {
                string json = new WebClient().DownloadString("http://www.json-generator.com/api/json/get/ceNjeWpWEO?indent=2");

                List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(json);

                return produtos.OrderBy(p => p.PrecoDecimal).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
