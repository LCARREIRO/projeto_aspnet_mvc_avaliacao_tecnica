using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoTecnica.Dominio.Entidades
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Preco { get; set; }
        public List<Marca> Marca { get; set; }
        public int CodigoMarca { get; set; }

        public string PrecoFormatado
        {
            get
            {
                return $"R{Preco}";
            }
        }

        public decimal PrecoDecimal
        {
            get
            {
                return Convert.ToDecimal(Preco.Substring(1));
            }
        }
    }
}
