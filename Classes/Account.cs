using System;

namespace app_DotNet_Bank_bootcampDIO_LocalizaLabs
{
  public class Account
  {
    public Account(int id, string name, TypeAccount typeAccount, double credit, double balance)
    {
      this.Id = id;
      this.Name = name;
      this.TypeAccount = typeAccount;
      this.Credit = credit;
      this.Balance = balance;
    }

    public int Id { get; set; }

    private string Name { get; set; }

    private TypeAccount TypeAccount { get; set; }

    private double Credit { get; set; }

    private double Balance { get; set; }

    public bool Withdraw(double withdrawalAmount)
    {
      // Validação de saldo suficiente
      if (this.Balance - withdrawalAmount < (this.Credit * -1))
      {
        Console.WriteLine("Saldo insuficiente!");
        return false;
      }

      this.Balance -= withdrawalAmount;

      Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Balance}");

      return true;
    }

    public bool Deposit(double depositedAmount)
    {
      this.Balance += depositedAmount;

      Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Balance}");

      return true;
    }

    public void Transference(double transferredAmount, Account targetAccount)
    {
      if (this.Withdraw(transferredAmount))
      {
        targetAccount.Deposit(transferredAmount);
      }
    }

    public override string ToString()
    {
      string newString = "";
      newString += $"Código: {this.Id} | ";
      newString += $"Tipo de Conta: {this.TypeAccount.GetDisplayValue()} | ";
      newString += $"Nome: {this.Name} | ";
      newString += $"Saldo: {this.Balance} | ";
      newString += $"Crédito: {this.Credit}";

      return newString;
    }
  }
}