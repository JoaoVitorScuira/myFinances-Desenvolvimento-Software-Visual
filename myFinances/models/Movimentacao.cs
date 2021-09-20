using System;
using myFinances.Data;
namespace myFinances.models{
public class Movimentacao{
    public Movimentacao(){
        DateTime criadoEm = DateTime.Now;
    }
    public int Id {get;set;}
    public double valor {get;set;}
    public string tipo {get;set;}
    public int data {get;set;}
    public DateTime criadoEm {get; set;}
}
}