using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propiedadesNetC.Models
{
    public class ExemploExcecao
    {
        public void Metodo1(){
            try{
                Metodo2();
            }
            catch (Exception error){
                Console.WriteLine($"Exeção tratada {error.Message}");
            }
        }
        public void Metodo2(){
            Metodo3();
        }
        public void Metodo3(){
            Metodo4();
        }
        public void Metodo4(){
            throw new Exception("Ocorreu uma exceção");
        }
    }
}