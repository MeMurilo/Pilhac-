using System;

public class Pilha
{
    private int[] item;
    private int topo;

    public Pilha(int maxTam)
    {
        item = new int[maxTam];
        topo = 0;
    }

    public bool vazia()
    {
        return topo == 0;
    }

    public bool cheia()
    {
        return topo == item.Length;
    }

    public int tamanho()
    {
        return topo;
    }

    public void empilha(int x)
    {
        if (cheia())
            throw new Exception("Erro: pilha cheia");

        item[topo] = x;
        topo++;
    }

    public int desempilha()
    {
        if (vazia())
            throw new Exception("Erro: pilha vazia");

        topo--;
        return item[topo];
    }

    public int consultaTopo()
    {
        if (vazia())
            throw new Exception("Erro: pilha vazia");

        return item[topo - 1];
    }

    public void mostra()
    {
        Console.Write("[");
        for (int i = 0; i < topo; i++)
        {
            if (i > 0)
                Console.Write(", ");

            Console.Write(item[i]);
        }
        Console.WriteLine("]");
    }
}
