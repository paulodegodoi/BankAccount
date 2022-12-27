using BancoCSharp.Enums;
using BancoCSharp.Models;

Console.WriteLine("***************************************");
Console.WriteLine("************* Banco CSharp ************");
Console.WriteLine("***************************************");
Console.WriteLine();
Console.WriteLine();

var titular01 = new Titular("Paulo Henrique", "12345678901", 11993665582);
var titular02 = new Titular("Maria Lucia", "12345678901", 11993665582);
var titular03 = new Titular("Rose Filha Lucia", "12345678901", 11993665582);

var conta01 = new ContaCorrente(titular01, 100.00);
var conta02 = new ContaPoupanca(titular02);
var conta03 = new ContaInvestimento(titular03, 0);

conta01.Depositar(50.00);
conta02.Depositar(500.00);
conta02.Sacar(50.00);
conta02.Transferir(conta03, 200.00);
conta03.Sacar(10);

conta01.ImprimirExtrato();
conta02.ImprimirExtrato();
conta03.ImprimirExtrato();

System.Console.WriteLine();