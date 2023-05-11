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

        private void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
            //FUNÇÃO DE CADASTRAR CORRENTISTA
            try
            {
                
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