namespace BancoCSharp.Models
{
  public class Titular
  {
    public string Nome { get; set; }
    public string CPF { get; set; }
    public long Telefone { get; set; }
    public Endereco Endereco { get; set; }

    public Titular(string nome, string cpf, long telefone)
    {
      Nome = nome;
      CPF = cpf;
      Telefone = telefone;
    }
  }
}