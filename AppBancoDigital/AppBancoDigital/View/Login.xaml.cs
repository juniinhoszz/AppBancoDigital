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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btn_acessar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (cpf_inserido.Text == "11111111111" & senha_inserida.Text == "123")
                {
                    //--criar página inicial para o usuario depois do login
                    await Navigation.PushAsync(new CadastroCliente());
                }
                else
                {
                    DisplayAlert("Erro!", "CPF ou senha Inválidos.\nTente Novamente", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private async void btn_novo_correntista_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new CadastroCliente());
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }
    }
}