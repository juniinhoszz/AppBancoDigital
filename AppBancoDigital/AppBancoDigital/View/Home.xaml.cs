using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoDigital.Model;
using AppBancoDigital.Service;
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
                    saldo.Text = "R$ " + App.DadosContaC.Saldo.ToString("C").Replace("$", "").Replace(".",",");
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
            Conta contaC = await DataServiceConta.GetCorrenteByIdCorrentista(App.DadosCorrentista.Id);

            if(contaC.Id != null) 
            {
                App.DadosContaC = contaC;
            }
            /*Conta ContaP = await DataServiceConta.GetPoupancaByIdCorrentista(App.DadosCorrentista.Id);
            if(ContaP.Id != null)
            {
                ContaPoupanca.IsVisible = false;
                poupancaMostrar.IsVisible = true;
                saldoP.Text = "R$ " + App.DadosContaP.Saldo.ToString("C");
            }*/
        }

        private async void ContaPoupanca_Clicked(object sender, EventArgs e)
        {
            await DataServiceConta.CriarPoupanca(App.DadosCorrentista.Id);
            Model.Conta contaP = await DataServiceConta.GetPoupancaByIdCorrentista(App.DadosCorrentista.Id);
            Console.WriteLine("tipo "+contaP.Tipo);

            if(contaP.Id != null)
            {
                App.DadosContaP = contaP;
                DisplayAlert("Sucesso!", "Conta Poupança Criada!", "OK");
                //ContaPoupanca.IsVisible = false; certo
                ContaPoupanca.IsVisible = false;
                poupancaMostrar.IsVisible = true;
                saldoP.Text = "R$ " + App.DadosContaP.Saldo.ToString("C");
            }
            else
            {
                DisplayAlert("Ops!", "Não foi possivel criar sua Conta Poupança!\n Tente Novamente.", "OK");
            }
        }
    }
}