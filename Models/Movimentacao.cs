using BancoCSharp.Enums;

namespace BancoCSharp.Models
{
  public class Movimentacao
  {
    private DateTime DataHoraMovimentacao { get; set; }
    private TipoMovimentacao TipoMovimentacao { get; set; }
    private double Valor { get; set; }

    public Movimentacao(TipoMovimentacao tipoMovimentacao, double valor)
    {
      DataHoraMovimentacao = DateTime.Now;
      TipoMovimentacao = tipoMovimentacao;
      Valor = valor;
    }

    public override string ToString()
    {
      var valor = TipoMovimentacao == TipoMovimentacao.DEPOSITO || TipoMovimentacao == TipoMovimentacao.ABERTURA_CONTA
          ? "+ R$ " + Valor : "- R$ " + Valor;

      return $"{DataHoraMovimentacao}hs | {TipoMovimentacao} | {valor}";
    }

    // 02/04/2022 as 19:09hs - SAQUE -R$ 10.00
  }
}