using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using AppBancoDigital.Service;
using Xamarin.Essentials;
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
            txt1.Text = "Saldo em conta\n";



        }
        bool Vendo = false;
        //string saldoCorrente = App.DadosConta.Saldo.ToString("C").Replace("$", "");

        private void vendo_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE MOSTRAR SENHA -- OK
            try
            {
                if (Vendo == false)
                {
                    vendo.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOff.png");
                    Vendo = true;
                    saldo.Text = "R$ " + App.DadosContaC.Saldo.ToString().Replace("$", "").Replace(".", ",");
                }
                else
                {
                    vendo.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
                    Vendo = false;
                    saldo.Text = "━━━━━━";
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }

        }

        private void CorrentistaImage_Clicked(object sender, EventArgs e)
        {

        }


        private void pix_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Funcoes.Pix.AreaPix());
        }

        protected override async void OnAppearing()
        {
            Conta contaC = await DataServiceConta.GetContaByTipoeIdCorrentista(new Model.Conta
            {
                Id_correntista = (int)App.DadosCorrentista.Id,
                Tipo = "C",
            });

            if (contaC.Id != null)
            {
                App.DadosContaC = contaC;
            }

            Conta contaP = await DataServiceConta.GetContaByTipoeIdCorrentista(new Model.Conta
            {
                Id_correntista = (int)App.DadosCorrentista.Id,
                Tipo = "P",
            });
            Console.WriteLine(contaP.Saldo);

            if (contaP.Id != null)
            {
                App.DadosContaP = contaP;
                ContaPoupanca.IsVisible = false;
                poupancaMostrar.IsVisible = true;
                string saldo;
                if (App.DadosContaC.Saldo.HasValue)
                {
                    saldo = App.DadosContaC.Saldo.ToString().Replace("$", "").Replace(".", ",");
                }
                else
                {
                    saldo = 0.ToString("C");
                }
                saldoP.Text = "R$ " + saldo;
            }
        }

        private async void ContaPoupanca_Clicked(object sender, EventArgs e)
        {
            await DataServiceConta.CriarPoupanca(App.DadosCorrentista.Id);
            Model.Conta contaP = await DataServiceConta.GetContaByTipoeIdCorrentista(new Model.Conta
            {
                Id_correntista = (int)App.DadosCorrentista.Id,
                Tipo = "P",
            });
            Console.WriteLine("tipo " + contaP.Tipo);

            if (contaP.Id != null)
            {
                App.DadosContaP = contaP;
                DisplayAlert("Sucesso!", "Conta Poupança Criada!", "OK");
                ContaPoupanca.IsVisible = false;
                //ContaPoupanca.BackgroundColor = Color.Red;
                poupancaMostrar.IsVisible = true;
                string saldo;
                if (App.DadosContaC.Saldo.HasValue)
                {
                    saldo = App.DadosContaC.Saldo.ToString().Replace("$", "").Replace(".", ",");
                }
                else
                {
                    saldo = 0.ToString("C");
                }
                saldoP.Text = "R$ " + saldo;
            }
            else
            {
                DisplayAlert("Ops!", "Não foi possivel criar sua Conta Poupança!\n Tente Novamente.", "OK");
            }
        }
    }
}