using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propiedadesNetC.Models
{
    public class VendaDesserializada
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal? Desconto { get; set; } 
        //usamos interrogação para receber um valor que pode ser nullo
    }
}