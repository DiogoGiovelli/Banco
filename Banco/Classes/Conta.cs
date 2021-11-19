using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Classes
{
    class Conta
    {
        private int TipoDeConta { get; set; }
        public double Saldo { get; set; }
        public double Credito { get; set; }
        public string Nome { get; set; }

        public Conta(int tipoDeConta, double saldo, double credito, string nome)
        {
            this.TipoDeConta = tipoDeConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if ((this.Saldo - valorSaque) < (this.Credito * -1))
            {
            Console.WriteLine("Saldo insuficiente");
            return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}",this.Nome,this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta é de ", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoDeConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }



    }
}
