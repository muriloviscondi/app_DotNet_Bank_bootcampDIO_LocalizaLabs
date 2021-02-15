using System;
using System.Collections.Generic;

namespace app_DotNet_Bank_bootcampDIO_LocalizaLabs
{
  class Program
  {
    static List<Account> accountsList = new List<Account>();

    static void Main(string[] args)
    {
      string optionUser = GetUserOption();

      while (optionUser.ToUpper() != "X")
      {
        switch (optionUser)
        {
          case "1":
            AccountList();
            break;
          case "2":
            AddAccount();
            break;
          case "3":
            Transference();
            break;
          case "4":
            Withdraw();
            break;
          case "5":
            Deposit();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        optionUser = GetUserOption();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadKey();
    }

    private static void Deposit()
    {
      Console.WriteLine("Digite o número da conta: ");
      int accountNumber = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser depositado: R$ ");
      double depositedAmount = double.Parse(Console.ReadLine());

      accountsList[accountNumber].Deposit(depositedAmount);
    }

    private static void Transference()
    {
      Console.WriteLine("Digite o número da conta de origem: ");
      int transferredAmount = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o número da conta de destino: ");
      int targetAccount = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser transferido: R$ ");
      double depositedAmount = double.Parse(Console.ReadLine());

      accountsList[transferredAmount].Transference(transferredAmount, accountsList[targetAccount]);
    }

    private static void Withdraw()
    {
      Console.WriteLine("Digite o número da conta: ");
      int accountNumber = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o valor a ser sacado: R$ ");
      double withdrawalAmount = double.Parse(Console.ReadLine());

      accountsList[accountNumber].Withdraw(withdrawalAmount);
    }

    private static void AccountList()
    {
      Console.WriteLine("Listagem de contas");

      if (accountsList.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
      }

      foreach(var item in accountsList) 
      {
        Account account = item;
        Console.WriteLine($"{account}");
      }
    }

    private static void AddAccount()
    {
      Console.WriteLine("Inserir nova conta");

      int id;

      if (accountsList.Count > 0) {
        id = accountsList[accountsList.Count - 1].Id + 1;
      } else {
        id = 1;
      }

      Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
      int typeAccount = int.Parse(Console.ReadLine());

      while (typeAccount < 1 || typeAccount > 2) {
        Console.WriteLine();
        Console.WriteLine($"Valor digitado inválido!");

        Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
        typeAccount = int.Parse(Console.ReadLine());
      }

      Console.WriteLine("Digite o nome do cliente: ");
      string name = Console.ReadLine();

      Console.WriteLine("Digite o saldo incial: ");
      double balance = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o crédito incial: ");
      double credit = double.Parse(Console.ReadLine());

      var newAccount = new Account
      (
        id: id,
        name: name,
        typeAccount: (TypeAccount)typeAccount,
        credit: credit,
        balance: balance
      );

      accountsList.Add(newAccount);
    }

    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Bank a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1 - Lista contas");
      Console.WriteLine("2 - Inserir nova conta");
      Console.WriteLine("3 - Transferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();

      return userOption;
    }
  }
}
