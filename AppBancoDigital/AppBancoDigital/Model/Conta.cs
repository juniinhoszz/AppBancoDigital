using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Conta
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public double Saldo { get; set;}
        public double Limite { get; set; }
        public int Id_correntista { get; set; }
    }
}
