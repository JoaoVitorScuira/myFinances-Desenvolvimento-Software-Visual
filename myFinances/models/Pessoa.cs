using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using myFinances.Data;

namespace myFinances.models{


public class Pessoa{
   public Pessoa (){ //construtor dessa classe
      DateTime criadoEm = DateTime.Now;
   }
   public int idade {get; set; }
   public string Cpf {get; set;}
   public string sexo {get; set;}
   public string nick {get; set;}
   public string tipoUsuario {get;set;}
   public DateTime criadoEm {get; set;}
}
}