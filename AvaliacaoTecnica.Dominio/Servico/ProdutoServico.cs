using AvaliacaoTecnica.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTecnica.Dominio.Servico
{
    public class ProdutoServico
    {
        public List<Produto> OrdernaPorMarca(List<Produto> listProdudo)
        {
            var nomeMarca = "";
            var codigoMarca = "";
            List<int> listCodigo = new List<int>();

            List<Produto> listOrdenada = new List<Produto>();
            foreach (var prod in listProdudo.OrderBy(p => p.PrecoDecimal))
            {
                List<Marca> listMarca = new List<Marca>();
                foreach (var marca in prod.Marca)
                {
                    Marca oMarca = new Marca()
                    {
                        Codigo = marca.Codigo,
                        Nome = marca.Nome
                    };

                    listMarca.Add(oMarca);
                    nomeMarca = marca.Nome;
                    codigoMarca = marca.Codigo;
                }
                Produto oProd = new Produto()
                {
                    Nome = prod.Nome,
                    Preco = prod.Preco,
                    Marca = listMarca,
                    CodigoMarca = Convert.ToInt32(codigoMarca)
                };

                if (!listCodigo.Contains(oProd.CodigoMarca))
                {
                    listOrdenada.Add(oProd);
                    listCodigo.Add(oProd.CodigoMarca);
                }
            }
            return listOrdenada;
        }
    }
}
