using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propiedadesNetC.Models
{
    public class Course
    {
        public string Nome { get; set; }
        public List<People> Alunos { get; set; }

        public void AdicionarAluno(People aluno) { //VOID é uma propriedade que não retorna nada
            Alunos.Add(aluno);
        }
        public int AlunosMatriculados(){
           int quantidade = Alunos.Count; //COUNT retorna o número de elementos da lista
           return quantidade;
        }
        public void RemoverAluno(People aluno){
            Alunos.Remove(aluno);
        }
        public void ListarAlunos(){
            Console.WriteLine($"Alunos do curso de: {Nome} ");

            for(int count = 0; count < Alunos.Count; count++){
                //string texto = "Nª" + count + " - " + Alunos[count].NomeCompleto;
                string texto = $"Nº {count + 1}- {Alunos[count].NomeCompleto}"; //interpolação de string
                Console.WriteLine(texto);
            }
        }
    }
}