using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace AppBancoDigital.Model
{
    public class Fotos
    {
        public ImageSource FotoEnviadaCorrentista { get; set; }
        //public ImageSource FotoPadraoCorrentista = new ImageSource.FromResource("AppBancoDigital.Assets.userPadrao.png");

        public static ImageSource FotoPadrao() 
        {
            return ImageSource.FromResource("AppBancoDigital.Assets.userPadrao.png");
        }
    }
}
