using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Questao1
{
    class ContaBancaria
    {

        public int NumeroConta { get; private set; }
        public string NomeTitular { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroConta, string nomeTitular, double depositoInicial)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = depositoInicial;
        }
        public ContaBancaria(int numeroConta, string nomeTitular)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor;
            Saldo -= 3.50; // Taxa de saque
        }

        public void MudancaDeNome (string nome)
        {
            NomeTitular = nome;
        }

        public override string ToString()
        {
            return $"Conta: {NumeroConta}, Titular: {NomeTitular}, Saldo: ${Saldo:F2}";
        }
    }
}
