using AppBancoDigital.Model;
using AppBancoDigital.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroCliente : ContentPage
    {
        public CadastroCliente()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            VerNaover_senha.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
            VerNaover_senha2.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
            dtpck_dataNasc.MaximumDate = DateTime.Now;
            dtpck_dataNasc.MinimumDate = new DateTime(1900, 1, 1);
        }
        bool vendo = false;
        bool vendo2 = false;

        private void VerNaover_senha_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE MOSTRAR SENHA -- OK
            try
            {
                if (vendo == false)
                {
                    VerNaover_senha.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOff.png");
                    vendo = true;
                    senha_inserido.IsPassword = false;
                }
                else
                {
                    VerNaover_senha.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
                    vendo = false;
                    senha_inserido.IsPassword = true;
                }
                //VendoNaoVendo(vendo);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }

        }

        private void VerNaover_senha2_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE MOSTRAR SENHA -- OK
            try
            {
                if (vendo2 == false)
                {
                    VerNaover_senha2.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOff.png");
                    vendo2 = true;
                    senhaConfirm_inserido.IsPassword = false;
                }
                else
                {
                    VerNaover_senha2.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOn.png");
                    vendo2 = false;
                    senhaConfirm_inserido.IsPassword = true;
                }
                //VendoNaoVendo(vendo2);
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private async void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE CADASTRAR CORRENTISTA
            try
            {
                if (senhaConfirm_inserido.Text == senha_inserido.Text)
                {
                    string senha = senha_inserido.Text;

                    Correntista c = await DataServiceCorrentista.CadastrarCorrentistas(new Correntista
                    {
                        Nome = nome_inserido.Text,
                        CPF = onlynumber(cpf_inserido.Text),
                        Data_nasc = dtpck_dataNasc.Date.ToString("yyyy-MM-dd"),
                        Senha = senha
                    });

                    if (c.Id != null)
                    {
                        App.DadosCorrentista = c;

                        //Navegando para a Tela Inicial após cadastrar e definir os dados do Correntista.
                        //await Navigation.PushAsync(new View.TelaInicial());
                    }
                    else
                        throw new Exception("Ocorreu um erro ao realizar seu cadastro.\nTente Novamente!");
                }
                else
                {
                    await DisplayAlert("Senhas diferentes!", "Confirme a senha digitada inicialmente", "OK");
                }
                //Navigation.ShowPopup(new LoadingPoPup());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private void btn_voltar_Clicked(object sender, EventArgs e)
        {
            //VOLTAR PARA O LOGIN -- OK

            try
            {
                App.Current.MainPage = new NavigationPage(new Login());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }
        string onlynumber(string str)
        {
            var onlynumber = new Regex(@"[^\d]");
            return onlynumber.Replace(str, "");
        }

    }
}
