using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Funcoes.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPix : ContentPage
    {
        public AreaPix()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TransferirPix.Source = ImageSource.FromResource("AppBancoDigital.Assets.transferir-dinheiro.png");
            PagarQRCode.Source = ImageSource.FromResource("AppBancoDigital.Assets.qr-code.png");
            PixCopiaeCola.Source = ImageSource.FromResource("AppBancoDigital.Assets.copiaEcola.png");
            CobrarPix.Source = ImageSource.FromResource("AppBancoDigital.Assets.cobrar.png");

            tipoChaveIcon.Source = ImageSource.FromResource("AppBancoDigital.Assets.cpfCard.png");
            copiarChave.Source = ImageSource.FromResource("AppBancoDigital.Assets.copiar.png");
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void CobrarPix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Funcoes.Pix.CobrarComQRCode());
        }
    }
}