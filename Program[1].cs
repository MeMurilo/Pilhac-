using System;

class Program
{
    static string inverte(string s)
    {
        Pilha p = new Pilha(s.Length);

        foreach (char c in s)
            p.empilha(c);

        string resultado = "";

        while (!p.vazia())
            resultado += (char)p.desempilha();

        return resultado;
    }

    static bool balanceado(string expr)
    {
        Pilha p = new Pilha(expr.Length);

        foreach (char c in expr)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                p.empilha(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (p.vazia())
                    return false;

                char abertura = (char)p.desempilha();

                if (c == ')' && abertura != '(')
                    return false;

                if (c == ']' && abertura != '[')
                    return false;

                if (c == '}' && abertura != '{')
                    return false;
            }
        }

        return p.vazia();
    }

    static int[] bubblePilhas(int[] v, out int comparacoes)
    {
        comparacoes = 0;

        if (v == null || v.Length <= 1)
            return v == null ? new int[0] : (int[])v.Clone();

        int n = v.Length;

        Pilha A = new Pilha(n);
        Pilha B = new Pilha(n);
        Pilha R = new Pilha(n);

        foreach (int valor in v)
            A.empilha(valor);

        for (int restantes = n; restantes >= 1; restantes--)
        {
            int carry = A.desempilha();

            for (int i = 1; i < restantes; i++)
            {
                int x = A.desempilha();
                comparacoes++;

                if (carry > x)
                {
                    B.empilha(x);
                }
                else
                {
                    B.empilha(carry);
                    carry = x;
                }
            }

            R.empilha(carry);

            Pilha temporaria = A;
            A = B;
            B = temporaria;
        }

        int[] resultado = new int[n];

        for (int i = 0; i < n; i++)
            resultado[i] = R.desempilha();

        return resultado;
    }

    static void Main()
    {
        Pilha p = new Pilha(5);

        p.empilha(1);
        p.empilha(3);
        p.empilha(5);
        p.empilha(7);

        p.mostra();
        Console.WriteLine(p.desempilha());
        Console.WriteLine(p.consultaTopo());

        p.empilha(8);
        p.empilha(9);

        p.mostra();
        Console.WriteLine(p.cheia());

        try
        {
            p.empilha(2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine(inverte("PUCMINAS"));

        Console.WriteLine(balanceado("(a+b)*[c-d]"));
        Console.WriteLine(balanceado("{[()]}"));
        Console.WriteLine(balanceado("((a)"));
        Console.WriteLine(balanceado("a+b)"));
        Console.WriteLine(balanceado("([)]"));

        int comparacoes;
        int[] vetor = { 5, 2, 9, 1, 7 };

        int[] ordenado = bubblePilhas(vetor, out comparacoes);

        Console.WriteLine(string.Join(", ", ordenado));
        Console.WriteLine("Comparacoes: " + comparacoes);

        int[] jaOrdenado = { 1, 2, 3, 4, 5 };

        ordenado = bubblePilhas(jaOrdenado, out comparacoes);

        Console.WriteLine(string.Join(", ", ordenado));
        Console.WriteLine("Comparacoes: " + comparacoes);
    }
}
