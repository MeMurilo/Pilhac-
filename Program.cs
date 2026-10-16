using System;

class Pilha
{
    private int[] elementos = new int[5];
    private int topo = -1;

    public bool Vazia()
    {
        return topo == -1;
    }

    public bool Cheia()
    {
        return topo == elementos.Length - 1;
    }

    public int Tamanho()
    {
        return topo + 1;
    }

    public void Empilhar(int valor)
    {
        if (Cheia())
            throw new Exception("Pilha cheia!");

        elementos[++topo] = valor;
    }

    public int Desempilhar()
    {
        if (Vazia())
            throw new Exception("Pilha vazia!");

        return elementos[topo--];
    }

    public int MostrarTopo()
    {
        if (Vazia())
            throw new Exception("Pilha vazia!");

        return elementos[topo];
    }

    public void MostrarPilha()
    {
        if (Vazia())
        {
            Console.WriteLine("Pilha vazia!");
            return;
        }

        for (int i = topo; i >= 0; i--)
            Console.WriteLine(elementos[i]);
    }
}

class Program
{
    static void Main()
    {
        Pilha p = new Pilha();
        int opcao;

        do
        {
            Console.WriteLine("\n1 - Empilhar números");
            Console.WriteLine("2 - Desempilhar");
            Console.WriteLine("3 - Mostrar topo");
            Console.WriteLine("4 - Mostrar pilha");
            Console.WriteLine("5 - Tamanho da pilha");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Digite uma opção válida!");
                continue;
            }

            try
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine(
                            "Digite os números separados por espaço:");

                        string entrada = Console.ReadLine();
                        string[] numeros = entrada.Split(
                            new char[] { ' ' },
                            StringSplitOptions.RemoveEmptyEntries);

                        foreach (string numero in numeros)
                        {
                            int valor = int.Parse(numero);
                            p.Empilhar(valor);
                        }

                        Console.WriteLine("Números adicionados!");
                        break;

                    case 2:
                        Console.WriteLine(
                            "Removido: " + p.Desempilhar());
                        break;

                    case 3:
                        Console.WriteLine(
                            "Topo: " + p.MostrarTopo());
                        break;

                    case 4:
                        p.MostrarPilha();
                        break;

                    case 5:
                        Console.WriteLine(
                            "Tamanho: " + p.Tamanho());
                        break;

                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

        } while (opcao != 0);
    }
}