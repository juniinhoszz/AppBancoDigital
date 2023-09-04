using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            vendo.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.JotaBank_Logo.png");

            string nomeCompleto;
            if (App.DadosCorrentista != null)
            {
                nomeCompleto = App.DadosCorrentista.Nome;
            }
            else
            {
                nomeCompleto = "teste";
            }
            string[] PrimeiroNome = nomeCompleto.Split(' ');
            if (App.FotoCorrentista != null)
            {
                userPhoto.Source = App.FotoCorrentista;
            }
            else
            {
                userPhoto.Source = ImageSource.FromResource("AppBancoDigital.Assets.userPadrao.png");
            }

            // ICONS BOTOES
            pix.Source = ImageSource.FromResource("AppBancoDigital.Assets.pix-Icon.png");
            pagarComQRCode.Source = ImageSource.FromResource("AppBancoDigital.Assets.qr-code.png");
            cofrinho.Source = ImageSource.FromResource("AppBancoDigital.Assets.cofrinho.png");

            saldo.Text = "━━━━━━";
            nome_user.Text = "Olá, " + PrimeiroNome[0];
            ContaPoupanca.Text = "Iniciar\nConta\nPoupança";
            txt.Text = "Saldo em conta\n";
        }
        bool Vendo = false;

        private void vendo_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE MOSTRAR SENHA -- OK
            try
            {
                if (Vendo == false)
                {
                    vendo.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOff.png");
                    Vendo = true;
                    saldo.Text = "R$ 10,00";
                }
                else
                {
                    vendo.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
                    Vendo = false;
                    saldo.Text = "━━━━━━";
                }
                //VendoNaoVendo(vendo);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }

        }

        private void CorrentistaImage_Clicked(object sender, EventArgs e)
        {

        }

        private void Depositar_Clicked(object sender, EventArgs e)
        {

        }
    }
}