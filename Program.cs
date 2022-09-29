using propiedadesNetC.Models;
using Newtonsoft.Json;

/*  MUDANDO A CONFIGURAÇÃO DE CULTURA DO SISTEMA!
    using System.Globalization;
    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US"); */

// O construtor permite passarmos o valor de forma mais fácil e legível
    People p1 = new People(nome: "Maduh", sobrenome: "Silva");
    People p2 = new People("Luana", "Laceloti");

    Course course = new Course();
    course.Nome = "Inglês";
    course.Alunos = new List<People>();

    course.AdicionarAluno(p1);
    course.AdicionarAluno(p2);
    course.ListarAlunos();


// FORMATANDO VALORES MONETÁRIOS
    decimal valorMonetario = 1234.5M;           // :C Vai exibir o tipo da moeda de acordo com a
     Console.WriteLine($"{valorMonetario:C}"); // configuração de localização do sistema.

// PORCENTAGEM
    double porcentagem = .3421;
    Console.WriteLine(porcentagem.ToString("P"));

// SEPARAÇÃO
    int tel = 555345236;
    Console.WriteLine(tel.ToString("###-###-###"));

// DATA
    DateTime date = DateTime.Now;
    Console.WriteLine(date.ToString("dd-MM-yyyy HH:mm")); //Você define o formato do jeito que quiser

// LENDO UM ARQUIVO 
    string[] linhas = File.ReadAllLines("Arquivos/arquivoLeitura.txt") ;

    foreach (string linha in linhas){
        Console.WriteLine(linha);
    } 


// TRATANDO UM EXCEÇÃO
        try{
            //CÓDIGO COM ALGUM ERRO QUE TRAVA O SISTEMA
        } 
        catch (Exception error){ 
            //Exception é um termo genérico existem vários outros e você pode fazer vário catch para tratá-lo
            Console.WriteLine($"Ocorreu uma exceção genérica: {error.Message} ");
            //RETORNA UMA MENSAGEM MAIS AMIGAVÉL 
        }
        finally{
            Console.Write("Será executado em qualquer situação, com ou sem erro!");
        } 


//CRIANDO UMA FILA (primeiro a entrar, primeiro a sair)
    Queue<int> fila = new Queue<int>();

    fila.Enqueue(1); //para adicionar
    fila.Enqueue(2);
    //fila.Dequeue(); para remover, remove sempre o primeiro

    foreach(int item in fila){
        Console.WriteLine(item);
    }

//CRIANDO PILHAS (ultimo a entrar, primeiro a sair)
    Stack<int> pilha = new Stack<int>();

    pilha.Push(1);
    pilha.Push(2);
    pilha.Push(3);
    //pilha.Pop(); remove o ultimo elemento adiciona

    foreach(int item in pilha){
        Console.WriteLine(item);
    }


//DICTIONARY    KEY     VALUE
    Dictionary<string, string> estados = new Dictionary<string, string>();

//              KEY    VALUE
    estados.Add("GO", "Goiás");   //a KEY é única não pode estar duplicada
    estados.Add("MT", "Mato Grosso");
    estados.Add("PR", "Paraná");
//  estados.Remove("PR"); para remover você usa apenas a chave pq ela é o identificador

    foreach(var item in estados){
        Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value} ");
    }

    Console.WriteLine(estados["GO"]); //Acessa um item do dictionary



//TUPLA, COMO DECLARAR

    (int, string, string, decimal) tupla = (1, "Maduh", "Silva", 1.65M);
   /* ValueTuple<int, string, string, decimal> outraForma = (1, "Maduh", "Silva", 1.65M);
    var outroExemplo = Tuple.Create(1, "Maduh", "Silva", 1.65M);*/

    Console.WriteLine($"ID: {tupla.Item1}");
    Console.WriteLine($"Nome: {tupla.Item2}");
    Console.WriteLine($"Sobrenome: {tupla.Item3}");
    Console.WriteLine($"Altura: {tupla.Item4}");


//TESTANDO O MÉTODO COMA TUPLA
    LeituraArquivo arquivo = new LeituraArquivo();
    //DESCARTES você pode usa o underlined no lugar de uma informção que não é relevante!
    var (sucesso, linhasArquivo, _ ) = arquivo.LerArquivo("Arquivos/arquivoLeitura.txt");

    if(sucesso){ 
        foreach(string linha in linhasArquivo){
            Console.WriteLine($"Aquantidade de linhas é {linhas}");
        }
    } else {
        Console.WriteLine("Não foi possivél ler o arquivo");
    }


//DESCONSTRUTOR faz o inverso do costrutor, separa em duas variáveis diferentes!
    People people = new People("Maduh", "Silva");
    (string nome, string sobrenome) = people;

    Console.WriteLine($"{nome} {sobrenome}");



//IF TERNÁRIO
    int num = 10;
    bool ePar = false;

    ePar = num % 2 == 0;
    Console.WriteLine($"o Número {num} é: " + (ePar ? "par" : "impar"));


// SERIALIZAÇÃO (JSON) convertendo um objeto em JSON
    List<Venda> listaVendas = new List<Venda>();
    DateTime dataAtual = DateTime.Now;

    Venda v1 = new Venda(1, "Material escritório", 32.00M, dataAtual);
    Venda v2 = new Venda(2, "Escrivaninha", 400.00M, dataAtual);
    Venda v3 = new Venda(3, "Cadeira Gamer", 700.00M, dataAtual);

    listaVendas.Add(v1);
    listaVendas.Add(v2);
    listaVendas.Add(v3);

    string serializado = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);
    Console.WriteLine(serializado);

    //cria um arquivo json no caminho especificado e com as informações convetidas anteriormente
    File.WriteAllText("Arquivos/venda.json", serializado);


//DESSERIALIZANDO UM OBJETO JSON
    string conteudoArquivo = File.ReadAllText("Arquivos/vendaDesserializada.json");
    List<VendaDesserializada> listaVenda = 
    JsonConvert.DeserializeObject<List<VendaDesserializada>>(conteudoArquivo);

    foreach (VendaDesserializada venda in listaVenda){
        Console.WriteLine($"Id: {venda.Id}, Produto: {venda.Produto}, " +
        $"Preço: {venda.Preco}, Data: {venda.DataVenda.ToString("dd/MM/yyyy")}, Desconto: {venda.Desconto}");
    }
//Usando tipo anonimo para pegar apenas o algumas informações da listaVendas
    var listaAnonimo = listaVenda.Select(x => (x.Produto, x.Preco));

    foreach (var venda in listaAnonimo){
        Console.WriteLine($"Produto: {venda.Produto}, Preco: {venda.Preco}");
    }



//TIPO NULOS DE DADOS 
    bool? receberEmail = null;

    if(receberEmail.HasValue && receberEmail.Value){
        Console.WriteLine("O cliente optou por receber e-mail");
    } else {
        Console.WriteLine("O cliente não respondeu o optou por não receber e-mail");
    }



//TIPO ANONIMO DE DADOS
    var anonimo = new { Nome = "Maduh", Sobrenome = "Silva", Altura = 1.65};

    Console.WriteLine($"Nome: {anonimo.Nome}");
    Console.WriteLine($"Sobrenome: {anonimo.Sobrenome}");                
    Console.WriteLine($"Altura: {anonimo.Altura}");




// Variável Dinamica
    dynamic variavelDinamica = 4;
    Console.WriteLine($"Tipo: {variavelDinamica.GetType()}, Valor: {variavelDinamica}");

    variavelDinamica = true;
    Console.WriteLine($"Tipo: {variavelDinamica.GetType()}, Valor: {variavelDinamica}");

    variavelDinamica = "Joãozinho";
    Console.WriteLine($"Tipo: {variavelDinamica.GetType()}, Valor: {variavelDinamica}");



//TESTANDADO A CLASSE GENÉRICA
    ClasseGenerica<int> arrayInteiro = new ClasseGenerica<int>();

    arrayInteiro.AdicionarElementoArray(10);
    Console.WriteLine(arrayInteiro[0]);



//MÉTODO DE EXTENSÃO
    int numeroExtend = 10;
    bool resultado = false;

    resultado = numeroExtend.EhPar();
    Console.WriteLine($"o Número {numeroExtend} é " + (resultado ? "par" : "impar"));



   





    





    

