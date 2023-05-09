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
        }

        private void dtpck_dataNasc_DateSelected(object sender, DateChangedEventArgs e)
        {
            
        }

        private void VerNaover_senha_Clicked(object sender, EventArgs e)
        {
            //TERMINAR DE FAZER A FUNÇÃO DE MOSTRAR SENHA
            bool vendo = false;


            if (vendo = false)
            {
                VerNaover_senha.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOff.png");
                vendo = true;
            }
            else
            {
                VerNaover_senha.Source = ImageSource.FromResource("AppBancoDigital.Assets.eyeOff.png");
                vendo = false;
            }
        }
    }
}