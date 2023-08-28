using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string nome;
            if (App.DadosCorrentista != null)
            {
                nome = App.DadosCorrentista.Nome;
            } else
            {
                nome = "teste";
            }

            saldo.Text = "━━━━━━";
            nome_user.Text ="Olá, "+ nome;
            ContaPoupanca.Text = "Iniciar\nConta\nPoupança";
            //saldo.Text = "" + saldo.Text;
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