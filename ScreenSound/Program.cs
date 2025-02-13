// Permite registrar bandas, listar as cadastradas, avaliar e exibir a média das avaliações.

// Screen Sound
string mensagemBoasVindas = "Boas vindas ao Screen Sound";

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");

    Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistraBanda();
            break;
        case 2: MonstrarBandasRegistradas();
            break;
        case 3: AvalidarBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("\nTchau tchau :)");
            break;
        default: Console.WriteLine("\nOpção inválida");
            break;
    }
}

void RegistraBanda()
{
    Console.Clear();

    ExibirTituloOpcao("Registro das bandas");

    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;

    bandasRegistradas.Add(nomeBanda, new List<int>());

    Console.WriteLine($"\nA banda { nomeBanda } foi registrada com sucesso!");

    Thread.Sleep(4000);

    Console.Clear();

    ExibirOpcoesMenu();
}

void MonstrarBandasRegistradas()
{
    Console.Clear();

    ExibirTituloOpcao("Exibindo todas as bandas registradas na nossa aplicação");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: { banda }");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();

    ExibirOpcoesMenu();
}

void ExibirTituloOpcao(string titulo)
{
    int quantidadeLetras = titulo.Length;
    string astericos = string.Empty.PadLeft(quantidadeLetras, '*');

    Console.WriteLine(astericos);
    Console.WriteLine(titulo);
    Console.WriteLine(astericos + "\n");
}

void AvalidarBanda()
{
    Console.Clear();

    ExibirTituloOpcao("Avaliar banda");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"\nQual a nota que a banda { nomeBanda } merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota);

        Console.WriteLine($"\nA nota { nota } foi registrada com sucesso para a banda { nomeBanda }");

        Thread.Sleep(4000);
    }
    else
    {
        Console.WriteLine($"\nA banda { nomeBanda } não foi encontrada!");
        Console.Write("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
    }

    Console.Clear();

    ExibirOpcoesMenu();
}

void ExibirMedia()
{
    Console.Clear();

    ExibirTituloOpcao("Exibir média da banda");

    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        List<int> notasBanda = bandasRegistradas[nomeBanda];

        Console.WriteLine($"\nA média da banda { nomeBanda } é { notasBanda.Average() }.");
    }
    else
    {
        Console.WriteLine($"\nA banda { nomeBanda } não foi encontrada!");
    }

    Console.Write("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();

    ExibirOpcoesMenu();
}

ExibirOpcoesMenu();