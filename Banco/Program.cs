using Banco.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {

            string opcaoDoUsuario = "1";
            while (opcaoDoUsuario.ToUpper() != "X")
            {
                opcaoDoUsuario = ObterOpcaoUsuario();
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }




            }




        }



        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoDeConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            Conta novaConta = new Conta(
                                        tipoDeConta: entradaTipoDeConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Digite uma opção:");
            Console.WriteLine("1-  LISTAR CONTAS");
            Console.WriteLine("2- INSERIR UMA NOVA CONTA");
            Console.WriteLine("3- TRANSFERIR ");
            Console.WriteLine("4- SACAR");
            Console.WriteLine("5- DEPOSITAR");
            Console.WriteLine("X- SAIR");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
