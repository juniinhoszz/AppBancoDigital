using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBancoDigital.Model
{
    public class Animacoes
    {
        public static async Task AnimacaoBtnClick(Button btn)
        {
            // Animação de escala
            await btn.ScaleTo(0.7, 100, Easing.Linear);
            Task.Delay(100);
            await btn.ScaleTo(1, 100, Easing.Linear);

            /*
            Manipule o clique do botão aqui
            Xamarin.Forms.Button button = (Xamarin.Forms.Button)sender;

            await Model.Animacoes.AnimacaoBotao(button);
            */
        }
    }
}
