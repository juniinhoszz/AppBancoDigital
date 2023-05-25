using AppBancoDigital.Model;
using AppBancoDigital.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        }
        bool vendo = false;
        bool vendo2 = false;
        string senha;
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
            }catch (Exception ex)
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
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }
        
        private async void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE CADASTRAR CORRENTISTA
            
            try
            {
                if(senhaConfirm_inserido != senha_inserido)
                {
                    DisplayAlert("Senhas diferentes!", "Confirme a senha digitada inicialmente", "OK");
                }
                else if(senhaConfirm_inserido == senha_inserido)
                {
                    senha = senha_inserido.Text;
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
            try
            {
                //Navigation.ShowPopup(new LoadingPoPup());

                //Correntista c = await DataServiceCorrentista.CadastrarCorrentistas(new Correntista
                //{
                //    Nome = nome_inserido.Text,
                //    CPF= cpf_inserido.Text,
                //    Data_nasc = DateTime.ParseExact(dataNasc_inserido.Text, "dd-MM-yyyy",
                //                       System.Globalization.CultureInfo.InvariantCulture),
                //    Senha = senha
                //});
                Console.WriteLine(cpf_inserido.Text + "\n" +
                                  nome_inserido.Text + "\n" +
                                  senha_inserido.Text);
                                  //arrumar a data para Cadastrar um correntista
                


            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private void btn_voltar_Clicked(object sender, EventArgs e)
        {
            //VOLTAR PARA O LOGIN -- OK

            try
            {
                App.Current.MainPage = new Login();
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }
    }
}