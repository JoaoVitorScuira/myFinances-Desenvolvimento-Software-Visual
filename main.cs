using System;
using System.Collections.Generic;
namespace myFinances
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaPessoa = new Pessoa();
            var pessoa1 = new Pessoa();
            pessoa1.Cpf = "202020";
            Console.WriteLine (pessoa1.Cpf);
            DateTime data = new DateTime();
            data = DateTime.Now;
            Console.WriteLine (data);
            Console.WriteLine ("Teste repositório");
        }   
    }
}
