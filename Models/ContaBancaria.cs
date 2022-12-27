using BancoCSharp.Enums;

namespace BancoCSharp.Models
{
  public abstract class ContaBancaria
  {
    #region Atributos
    public Titular Titular { get; set; }
    public double Saldo { get; private set; }
    public DateTime DataAbertura { get; private set; }

    private List<Movimentacao> Movimentacoes { get; set; }
    protected readonly double VALOR_MINIMO = 10.0;

    #endregion

    #region Contrutores
    public ContaBancaria(Titular titular, double saldoAbertura)
    {
      Titular = titular;
      Saldo = saldoAbertura;
      DataAbertura = DateTime.Now;
      Movimentacoes = new List<Movimentacao>()
      {
        new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, saldoAbertura)
      };

    }

    public ContaBancaria(Titular titular)
    {
      Titular = titular;
      Saldo = 0;
      DataAbertura = DateTime.Now;
      Movimentacoes = new List<Movimentacao>()
      {
        new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, Saldo)
      };
    }
    #endregion

    #region Metodos

    public void Depositar(double valor)
    {
      if (valor < VALOR_MINIMO)
        throw new Exception($"O valor mínimo para depósito é: R$ {VALOR_MINIMO}");

      Movimentacoes.Add(new Movimentacao(TipoMovimentacao.DEPOSITO, valor));
      Saldo += valor;
    }

    public virtual double Sacar(double valor)
    {
      if (valor < VALOR_MINIMO)
        throw new Exception($"O valor mínimo para saque é: R$ {VALOR_MINIMO}");

      else if (valor > Saldo)
        throw new Exception($"O valor máximo para saque é: R$ {Saldo}");

      Movimentacoes.Add(new Movimentacao(TipoMovimentacao.SAQUE, valor));
      return Saldo -= valor;
    }

    public void Transferir(ContaBancaria contaDestino, double valor)
    {
      if (valor > Saldo)
        throw new Exception("Saldo insuficiente.");

      contaDestino.Depositar(valor);

      Movimentacoes.Add(new Movimentacao(TipoMovimentacao.TRANSFERENCIA, valor));
      Saldo -= valor;
    }

    public virtual void ImprimirExtrato()
    {
      Console.WriteLine("***************************************");
      Console.WriteLine("************* Extrato Conta ************");
      Console.WriteLine("***************************************");
      Console.WriteLine();

      Console.WriteLine("Gerado em: " + DateTime.Now);
      Console.WriteLine();

      foreach (var mov in Movimentacoes)
      {
        Console.WriteLine(mov);
      }

      Console.WriteLine($"Saldo: R$ {Saldo}");

      Console.WriteLine();
      Console.WriteLine("***************************************");
      Console.WriteLine("********* Fim Extrato Conta ***********");
      Console.WriteLine("***************************************");
    }

    #endregion

  }
}