
//List<string> listaBandas = new List<string>();
//List<string> listaBandas = new List<string> { "Toque no altar", "Diante do trono"};
Dictionary<string, List<int>> listaBandas = new Dictionary<string, List<int>>();
//listaBandas.Add("Toque no altar", new List<int> { 10, 8, 9});
//listaBandas.Add("Diante do trono", new List<int> ());
const string retornarMenuPrincipal = "\n\n\nDigite uma tecla para voltar ao menu principal...";

ExibirLogo();
ExibirOpcoesDoMenu();


void ExibirLogo()
{
    Console.Clear();
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("Bem vindo ao Screen Sound!");
}
void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para exibir todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite 5 para atualizar o nome de uma banda");
    Console.WriteLine("Digite 6 para excluir uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite uma opcao: ");
    // Console.Read() retorna o valor do primeiro caracter lido como entrada do teclado, transformando num valor ASCII ou seja, retorna um valor numerico referente a tecla digitada por isso declaramos - int x = Console.Read() = se digitar 1 sera atribuido em x o valor 49
    // Console.ReadLine() retorna uma entrada no formato de string, ou seja, se digitarmos um unico valor ou uma frase todos os caracteres serao considerados como um string normal sem conversao para a tabela ASCII
    bool isNum = int.TryParse(Console.ReadLine(), out int opcao);
    do
    {
        if (isNum)
        {
            if ((opcao != 1) && (opcao != 2) && (opcao != 3) && (opcao != 4) && (opcao != 5) && (opcao != 6) && (opcao != -1))
            {
                Console.WriteLine("Opcao invalida! Entre com uma opcao valida... ");
                Thread.Sleep(2000);
                ExibirLogo();
                ExibirOpcoesDoMenu();
            }
            else
            {
                switch (Convert.ToInt32(opcao))
                {
                    case 1:
                        RegistrarBanda();
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                    case 2:
                        ExibirListaDeBandas();
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                    case 3:
                        AvaliarBanda();
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                    case 4:
                        ExibirMediaPorBanda();
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                    case 5:
                        AtualizarBanda();
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                    case 6:
                        ExcluirBanda();
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                    case -1:
                        ExibirSublinhado("\n\nSair da aplicacao...");
                        break;
                    default:
                        Console.WriteLine("Opcao invalida! Entre com uma opcao valida... ");
                        Thread.Sleep(2000);
                        ExibirLogo();
                        ExibirOpcoesDoMenu();
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Opcao invalida! Entre com uma opcao valida... ");
            Thread.Sleep(2000);
            ExibirLogo();
            ExibirOpcoesDoMenu();
        }

        break;
    }while (true);
}

void RegistrarBanda()
{
    string tituloCabecalho = (@"
▒█▀▀█ █▀▀ █▀▀▀ ░▀░ █▀▀ ▀▀█▀▀ █▀▀█ █▀▀█ █▀▀█ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ 
▒█▄▄▀ █▀▀ █░▀█ ▀█▀ ▀▀█ ░░█░░ █▄▄▀ █▄▄█ █▄▄▀ 　 █▀▀▄ █▄▄█ █░░█ █░░█ █▄▄█ ");

    string tituloRodape = ("▒█░▒█ ▀▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀ ░░▀░░ ▀░▀▀ ▀░░▀ ▀░▀▀ 　 ▀▀▀░ ▀░░▀ ▀░░▀ ▀▀▀░ ▀░░▀");

    string? banda;

    do
    {
        ExibirTituloSecao(tituloCabecalho, tituloRodape);
        Console.Write("\nDigite o nome da banda: ");
        banda = Console.ReadLine();
    } while (banda == "");

    //listaBandas.Add(banda); // adiciona na lista
    if (ValidarBanda(banda))
    {
        Console.WriteLine($"\n\n\nA banda {banda} ja esta cadastrada!");
        ExibirSublinhado(retornarMenuPrincipal);
        Console.ReadKey();
    }
    else
    {
        listaBandas.Add(banda, new List<int>()); // adiciona no dicionario
        Console.WriteLine($"\n\n\nA banda {banda} foi registrada com sucesso!");
        Thread.Sleep(3000);
    }
}

void ExibirTituloSecao(string cabecalho, string rodape)
{
    Console.Clear();
    Console.WriteLine(cabecalho);

    ExibirSublinhado(rodape);
}

void ExibirSublinhado(string titulo)
{
    string asteriscos = string.Empty.PadLeft(titulo.Length, '*');
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + '\n');
}

bool ValidarBanda(string banda)
{
    return listaBandas.ContainsKey(banda);
}

void ExibirListaDeBandas()
{
    string tituloCabecalho = (@"
▒█░░░ ░▀░ █▀▀ ▀▀█▀▀ █▀▀█ █▀▀█ 　 █▀▀▄ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ █▀▀ 
▒█░░░ ▀█▀ ▀▀█ ░░█░░ █▄▄█ █▄▄▀ 　 █▀▀▄ █▄▄█ █░░█ █░░█ █▄▄█ ▀▀█ ");

    string tituloRodape = ("▒█▄▄█ ▀▀▀ ▀▀▀ ░░▀░░ ▀░░▀ ▀░▀▀ 　 ▀▀▀░ ▀░░▀ ▀░░▀ ▀▀▀░ ▀░░▀ ▀▀▀");
    
    ExibirTituloSecao(tituloCabecalho, tituloRodape);

    if (listaBandas.Any())
    {
        int x = 1;
        foreach (var banda in listaBandas.Keys) // retorna apenas os valores da chave do dicionario
        {
            Console.WriteLine(x + " - " + banda);
            x++;
        }
    }
    else
    {
        Console.WriteLine("\nAinda nao existem bandas cadastradas!\n");
    }

    ExibirSublinhado(retornarMenuPrincipal);
    Console.ReadKey();
}

void AvaliarBanda()
{
    string tituloCabecalho = (@"
░█▀▀█ ▀█░█▀ █▀▀█ █░░ ░▀░ █▀▀█ █▀▀█ 　 ▒█▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ 
▒█▄▄█ ░█▄█░ █▄▄█ █░░ ▀█▀ █▄▄█ █▄▄▀ 　 ▒█▀▀▄ █▄▄█ █░░█ █░░█ █▄▄█ ");

    string tituloRodape = ("▒█░▒█ ░░▀░░ ▀░░▀ ▀▀▀ ▀▀▀ ▀░░▀ ▀░▀▀ 　 ▒█▄▄█ ▀░░▀ ▀░░▀ ▀▀▀░ ▀░░▀");

    string validaBanda;

    do
    {
        ExibirTituloSecao(tituloCabecalho, tituloRodape);
        Console.Write("\nDigite o nome da banda: ");
        validaBanda = Console.ReadLine()!;

    } while (validaBanda == "");

    //Verificar se a banda existe
    if (ValidarBanda(validaBanda))
    {
        string nota;
        int notaAvaliacao;
        do
        {
            Console.Write($"\nDigite uma nota de 0 a 10 para a avaliacao: ");
            nota = Console.ReadLine();
            bool isNumeric = int.TryParse(nota, out notaAvaliacao);

            if (!isNumeric || (notaAvaliacao < 0) || (notaAvaliacao > 10))
            {
                Console.WriteLine("\n\n\nOpcao invalida! Entre com uma opcao valida... ");
                Thread.Sleep(2000);

                ExibirTituloSecao(tituloCabecalho, tituloRodape);
                Console.WriteLine($"\nDigite o nome da banda: {validaBanda}");
                notaAvaliacao = -1;
            }

        } while ((notaAvaliacao < 0) || (notaAvaliacao > 10));

        listaBandas[validaBanda].Add(notaAvaliacao); // utiliza [] com o nome da banda para buscar pela chave do dicionario e em seguida utiliza o metodo Add para adicionar a nota na lista de notas de avalizacoes que eh a uma lista de inteiros.
        Console.WriteLine($"\n\nA nota {notaAvaliacao} foi registrada com sucesso para a banda {validaBanda}.");
        Thread.Sleep(3000);
    }
    else
    {
        Console.WriteLine($"\nA banda {validaBanda} nao esta cadastrada!");
        ExibirSublinhado(retornarMenuPrincipal);
        Console.ReadKey();
    }
}

void ExibirMediaPorBanda()
{
    string tituloCabecalho = (@"
▒█▀▄▀█ █▀▀ █▀▀▄ ░▀░ █▀▀█ 　 █▀▀▄ █▀▀█ █▀▀ 　 █▀▀█ ▀█░█▀ █▀▀█ █░░ ░▀░ █▀▀█ █▀▀ █▀▀█ █▀▀ █▀▀ 
▒█▒█▒█ █▀▀ █░░█ ▀█▀ █▄▄█ 　 █░░█ █▄▄█ ▀▀█ 　 █▄▄█ ░█▄█░ █▄▄█ █░░ ▀█▀ █▄▄█ █░░ █░░█ █▀▀ ▀▀█ ");

    string tituloRodape = ("▒█░░▒█ ▀▀▀ ▀▀▀░ ▀▀▀ ▀░░▀ 　 ▀▀▀░ ▀░░▀ ▀▀▀ 　 ▀░░▀ ░░▀░░ ▀░░▀ ▀▀▀ ▀▀▀ ▀░░▀ ▀▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀");

    string validaBanda;

    do {
        ExibirTituloSecao(tituloCabecalho, tituloRodape);
        Console.Write("\nDigite o nome da banda: ");
        validaBanda = Console.ReadLine()!;
    } while (validaBanda == "");

    //Verificar se a banda existe
    if (ValidarBanda(validaBanda))
    {
        Console.Write($"\n\nMedia de avaliacoes: ");
        Console.WriteLine("{0:f2}", listaBandas[validaBanda].Average());
        ExibirSublinhado("\n\n\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"\nA banda {validaBanda} nao esta cadastrada!");
        ExibirSublinhado(retornarMenuPrincipal);
        Console.ReadKey();
    }
}

void AtualizarBanda()
{
    string tituloCabecalho = (@"
░█▀▀█ ▀▀█▀▀ █░░█ █▀▀█ █░░ ░▀░ ▀▀█ █▀▀█ █▀▀█ 　 ▒█▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ 
▒█▄▄█ ░░█░░ █░░█ █▄▄█ █░░ ▀█▀ ▄▀░ █▄▄█ █▄▄▀ 　 ▒█▀▀▄ █▄▄█ █░░█ █░░█ █▄▄█ ");

    string tituloRodape = ("▒█░▒█ ░░▀░░ ░▀▀▀ ▀░░▀ ▀▀▀ ▀▀▀ ▀▀▀ ▀░░▀ ▀░▀▀ 　 ▒█▄▄█ ▀░░▀ ▀░░▀ ▀▀▀░ ▀░░▀");

    string validaBanda;
    string novaBanda;

    do
    {
        ExibirTituloSecao(tituloCabecalho, tituloRodape);
        Console.Write("\nDigite o nome da banda para ser atualizado: ");
        validaBanda = Console.ReadLine()!;

    } while (validaBanda == "");

    if (ValidarBanda(validaBanda))
    {
        do
        {
            ExibirTituloSecao(tituloCabecalho, tituloRodape);
            Console.Write("\nDigite o novo nome da banda: ");
            novaBanda = Console.ReadLine()!;

        } while (novaBanda == "");

        List<int> valor = listaBandas[validaBanda];
        listaBandas.Remove(validaBanda);
        listaBandas[novaBanda] = valor;

        Console.WriteLine($"\n\nO nome da banda {validaBanda} foi atualizada com sucesso para o nome {novaBanda}.");
        Thread.Sleep(3000);
    }
    else
    {
        Console.WriteLine($"\nA banda {validaBanda} nao esta cadastrada!");
        ExibirSublinhado(retornarMenuPrincipal);
        Console.ReadKey();
    }
}

void ExcluirBanda()
{
    string validaBanda;

    string tituloCabecalho = (@"
▒█▀▀▀ █░█ █▀▀ █░░ █░░█ ░▀░ █▀▀█ 　 ▒█▀▀█ █▀▀█ █▀▀▄ █▀▀▄ █▀▀█ 
▒█▀▀▀ ▄▀▄ █░░ █░░ █░░█ ▀█▀ █▄▄▀ 　 ▒█▀▀▄ █▄▄█ █░░█ █░░█ █▄▄█ ");

    string tituloRodape = ("▒█▄▄▄ ▀░▀ ▀▀▀ ▀▀▀ ░▀▀▀ ▀▀▀ ▀░▀▀ 　 ▒█▄▄█ ▀░░▀ ▀░░▀ ▀▀▀░ ▀░░▀");

    do
    {
        ExibirTituloSecao(tituloCabecalho, tituloRodape);
        Console.Write("\nDigite o nome da banda para ser deletado: ");
        validaBanda = Console.ReadLine()!;

    } while (validaBanda == "");

    if (ValidarBanda(validaBanda))
    {
        string confirma;
        string upperCaseConfirma;
        do { 
            do {
                Console.WriteLine($"\nCerteza que deseja excluir a banda {validaBanda}?");
                Console.Write("\nDigite 'S' para Sim ou 'N' para Nao: ");
                confirma = Console.ReadLine()!;

                if(confirma == "")
                {
                    ExibirTituloSecao(tituloCabecalho, tituloRodape);
                    Console.WriteLine($"\nDigite o nome da banda para ser deletado: {validaBanda}");
                }

            } while (confirma == "");

            upperCaseConfirma = confirma.ToUpper();

            if ((upperCaseConfirma == "S") || (upperCaseConfirma == "N"))
            {
                if(upperCaseConfirma == "S")
                {
                    listaBandas.Remove(validaBanda);
                    Console.WriteLine($"\n\n\nA banda {validaBanda} foi removida com sucesso!");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine($"\n\n\nA exclusao da banda {validaBanda} foi cancelada!");
                    ExibirSublinhado(retornarMenuPrincipal);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\n\n\nOpcao invalida! Entre com uma opcao valida... ");
                Thread.Sleep(2000);

                ExibirTituloSecao(tituloCabecalho, tituloRodape);
                Console.WriteLine($"\nDigite o nome da banda para ser deletado: {validaBanda}");
                
            }
        } while((upperCaseConfirma != "S") && (upperCaseConfirma != "N"));
    }
    else
    {
        Console.WriteLine($"\nA banda {validaBanda} nao esta cadastrada!");
        ExibirSublinhado(retornarMenuPrincipal);
        Console.ReadKey();
    }
}