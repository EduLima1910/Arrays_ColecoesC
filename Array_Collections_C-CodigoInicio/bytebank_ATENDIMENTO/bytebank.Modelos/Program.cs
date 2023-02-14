using Array_Collections_C_CodigoInicio.bytebank.Atendimento;
using Array_Collections_C_CodigoInicio.bytebank.Exceptions;
using Array_Collections_C_CodigoInicio.bytebank_ATENDIMENTO.bytebank.Modelos.bytebank.Util;
using bytebank.Modelos.Conta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplo de arrays em C#
int[] idades = new int[5];
idades[0] = 30;
idades[1] = 40;
idades[2] = 17;
idades[3] = 21;
idades[4] = 18;

//TestaArrayInt();

//TestaBuscarPalavra();

//TestaMediana(amostra);


void TestaArrayInt() 
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;

    for (int i = 0; i < idades.Length; i++)
    {

        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        acumulador += idade;

    }

    int media = acumulador / idades.Length;

    Console.WriteLine($"A média das idades é: {media}");

}

void TestaBuscarPalavra()
{

    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {

        Console.WriteLine($"Digite a {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();

    }

    Console.WriteLine("Digite palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {

        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada: {busca}.");
            break;
        }

    }

}

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);



void TestaMediana(Array array)

{
    if((array == null) || (array.Length == 0))
    {

        Console.WriteLine("Array para cálculo de mediana está vazio ou nulo.");

    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho%2 != 0) ? numerosOrdenados[meio]:
                                       (numerosOrdenados[meio] + numerosOrdenados[meio-1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana =  {mediana}");

}

double[] listaDeValores = new double[6];
listaDeValores[0] = 1.5;
listaDeValores[1] = 7.2;
listaDeValores[2] = 2;
listaDeValores[3] = 9;
listaDeValores[4] = 12.4;
listaDeValores[5] = 8;

// MediaDaAmostra(listaDeValores);


double MediaDaAmostra(double[] amostra)
{

    double media = 0;
    double acumulador = 0;

    if ((amostra == null) || (amostra.Length == 0))
    {

        Console.WriteLine("Amostra de dados nula ou vazia.");
        return 0;

    }

    else
    {

        for (int i = 0; i < amostra.Length; i++)
        {

            acumulador = acumulador + amostra[i];

        }

        media = acumulador / amostra.Length;
        Console.WriteLine(media);

    }
    return media;
}

void TestaArayDeContasCorrents()
{
    ContasCorrentes listaDeContas = new ContasCorrentes();

    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    var contaDoEduardo = new ContaCorrente(963, "123456-X");
    listaDeContas.Adicionar(contaDoEduardo);
    listaDeContas.ExibeLista();
    Console.WriteLine("=======================");
    //listaDeContas.Remover(contaDoEduardo);
    //listaDeContas.ExibeLista();
    //listaDeContas.ClienteMaiorSaldo();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

//TestaArayDeContasCorrents();
#endregion


new ByteBankAtendimento().AtendimentoCliente();

 
