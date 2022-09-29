using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propiedadesNetC.Models
{
    public class People
    {

        //CONSTRUUTOR
        public People() { 

        }
        public People(string nome, string sobrenome) {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        //DESCONSTRUTOR
        public void Deconstruct(out string nome, out string sobrenome) {
            nome = Nome;
            sobrenome = Sobrenome;
        }

        private string _nome;
        private int _idade;
        
        public string Nome { //classe com verificação
            get => _nome; //BODY EXPRESSIONS usado quando só temos uma linha de código
            set { 
                if(value == ""){ 
                    throw new ArgumentException("O campo nome deve ser preenchido!"); }
                    _nome = value; 
                }
            }

        public string Sobrenome { get; set; } //sem verificação
        public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
        //Propriedade de leitura, ele só será lido não pode ser atribuído 
        public int Idade { 
            get => _idade; 
            set {
                if(value <= 0) {
                    throw new ArgumentException("A idade deve ser maior que zero!");}
                    _idade = value;
            }
            }

        public void Apresentar(){
        Console.WriteLine($"Nome: {NomeCompleto}, Idade: {Idade}");
    }

    }
}