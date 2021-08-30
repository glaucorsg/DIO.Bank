using System;

namespace DIO.Bank 
{
// Definindo os atributos da classe
    public class Conta
    {
       private TipoConta TipoConta { get; set;}

       private double Saldo { get; set; }

       private double Credito { get; set; }

       private string Nome { get; set; }
       
// Definindo o construtor
       public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
       {
           this.TipoConta = tipoConta;
           this.Saldo = saldo;
           this.Credito = credito;
           this.Nome = nome;
       }

        // Definindo os métodos

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo + " | ";
            retorno += "Credito: R$ " + this.Credito;
            return retorno;
        }

        public bool Sacar(double valorSaque)
        {
            // Validação do saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito*-1))
            {
                Console.WriteLine("Saldo insuficiente \n"+"O saldo de {0} é de R$ {1}. Valor solicitado de R$ {2} é superior ao disponível (Saldo + Crédito) de R$ {3}", this.Nome, this.Saldo, valorSaque, (this.Saldo+this.Credito));
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("\nSaldo atual de {0} é R$ {1}", this.Nome, this.Saldo);
            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Valor depositado: R$ {0}\n" + "O saldo atual de {1} é de R$ {2}", valorDeposito, this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                Console.WriteLine("O valor de R$ {0} foi transferido com sucesso para a conta de {1}", valorTransferencia, contaDestino.Nome);
            }                
        }
    }
}