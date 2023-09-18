using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Correntista
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Data_nasc { get; set;}
        public string Senha { get; set; }
        public string TipoContaC { get; set; }
        public double SaldoContaC { get; set; }
        public double LimiteContaC { get; set; }
    }
}
