using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propiedadesNetC.Models
{
    public class Venda
    {
        public Venda(int id, string produto, decimal preco, DateTime dataVenda){
            Id = id;
            Produto = produto;
            Preco = preco;
            DataVenda = dataVenda;
        }
/* JsonProperty: se os dados vierem com uma sintexe diferente da usada em C# ele irá 
   ter o representar um comportamento diferente, exemplo se no arquivo Json o atributo ID tiver o
   nome id_cliente podemos fazer da segunte forma: [JsonProperty("id_cliente")] acima do atributo Id
*/
        public int Id { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataVenda { get; set; }

    }
}