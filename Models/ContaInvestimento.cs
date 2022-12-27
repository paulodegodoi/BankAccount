using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
  public class ContaInvestimento : ContaBancaria
  {
    public ContaInvestimento(Titular titular, double saldoAbertura) : base(titular, saldoAbertura)
    {
    }

    public override double Sacar(double valor)
    {
      Console.WriteLine("Não é possível sacar em conta Investimento");
      return Saldo;
    }
  }
}