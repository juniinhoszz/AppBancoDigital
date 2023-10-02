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
    public partial class CobrarComQRCode : ContentPage
    {
        public CobrarComQRCode()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void valor_inserido_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}