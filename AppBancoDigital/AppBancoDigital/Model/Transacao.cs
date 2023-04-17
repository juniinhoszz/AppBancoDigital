using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Transacao
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime Data_transacao { get; set; }
        public int Id_conta_enviou { get; set; }
        public int Id_conta_recebeu { get; set; }
    }
}
