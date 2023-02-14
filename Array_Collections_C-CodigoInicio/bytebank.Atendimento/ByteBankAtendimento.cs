using Array_Collections_C_CodigoInicio.bytebank.Exceptions;
using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Collections_C_CodigoInicio.bytebank.Atendimento
{
    internal class ByteBankAtendimento
    {

        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "123456-X") {Saldo=100, Titular = new Cliente{Cpf="1111111", Nome ="Henrique", Profissao = "Professor"}},
            new ContaCorrente(95, "963741-X") {Saldo=200, Titular = new Cliente{Cpf="2222222", Nome ="Pedro", Profissao = "Bancario"}},
            new ContaCorrente(94, "852369-W ") {Saldo=60, Titular = new Cliente{Cpf="3333333", Nome ="Cláudia", Profissao = "Atendente"}}
        };

        public void AtendimentoCliente()
        {
            try
            {

                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta      ===");
                    Console.WriteLine("===2 - Listar Contas        ===");
                    Console.WriteLine("===3 - Remover Conta        ===");
                    Console.WriteLine("===4 - Ordenar Contas       ===");
                    Console.WriteLine("===5 - Pesquisar Conta      ===");
                    Console.WriteLine("===6 - Sair do Sistema      ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new ByteBankException(excecao.Message);

                    }
                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            EncerraAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;
                    }
                }
            }
            catch (ByteBankException excecao)
            {

                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void EncerraAplicacao()
        {
            Console.WriteLine("... Encerrando aplicação ...");
            Console.ReadKey();
        }

        #region PesquisarContas
        private void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     PESQUISAR CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("Deseja pesquisar por (1) NUMERO DA CONTA,  (2)CPF TITULAR  ou (3)NÚEMRO DA AGÊNCIA? :");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine("Informe o número da Conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.WriteLine("\n");


                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCPF = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCPF.ToString());
                        Console.WriteLine("\n");
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Informe o Nº da Agência: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        var contasPorAgencia = ConsultaPorNumeroAgencia(_numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }
        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A consulta não retornou dados ...");
            }
            else
            {
                foreach (var item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private List<ContaCorrente> ConsultaPorNumeroAgencia(int numeroAgencia)
        {
            var consulta = (
                    from conta in _listaDeContas
                    where conta.Numero_agencia == numeroAgencia
                    select conta).ToList();
            return consulta;
        }

        private ContaCorrente ConsultaPorCPFTitular(string cpf)
        {
            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
        }

        private ContaCorrente ConsultaPorNumeroConta(string numeroConta)
        {
            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }
        #endregion

        private void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenadas ...");
            Console.ReadKey();
        }

        private void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     REMOVER CONTAS      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("Informe o número da Conta:");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;
            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoçao não encontrada ...");
            }
            Console.ReadKey();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    LISTA DE CONTAS      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadLine();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadLine();
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);

            Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Infome nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Infome CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Infome Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

    }
}
