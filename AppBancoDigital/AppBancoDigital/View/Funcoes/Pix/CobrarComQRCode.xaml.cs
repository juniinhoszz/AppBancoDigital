using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace AppBancoDigital.View.Funcoes.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CobrarComQRCode : ContentPage
    {
        public CobrarComQRCode()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            copiarChave.Source = ImageSource.FromResource("AppBancoDigital.Assets.copiar.png");
            nome_user.Text = App.DadosCorrentista.Nome;

            //CHAVES PIX
            SelecaoChaves.Items.Add(App.DadosCorrentista.CPF);
            SelecaoChaves.Items.Add("teste");
            SelecaoChaves.Items.Add("teste");

            SelecaoChaves.SelectedIndex = 0;
            //falta arrumar o picker na tela

            //// Adicione os itens do array ao Picker
            //foreach (string item in meuArray)
            //{
            //    meuPicker.Items.Add(item);
            //}
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void valor_inserido_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void gerarComValor_Clicked(object sender, EventArgs e)
        {
            try
            {
                string str = "Chave da Transferência:" + App.DadosCorrentista.CPF + " & Valor: " + valor_inserido.Text;
                precoCobrado.Text = valor_inserido.Text;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qRCode.GetGraphic(20);
                QRGerado.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));

                PixCompleto_Gerado.IsVisible = true;
            }
            catch(Exception ex)
            {

            }
           
        }

        private void gerarSemValor_Clicked(object sender, EventArgs e)
        {
            string str = "Chave da Transferência:" + App.DadosCorrentista.CPF;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            QRGerado.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
            PixCompleto_Gerado.IsVisible = true;
        }

        private void copiarChave_Clicked(object sender, EventArgs e)
        {
            string str = "Chave da Transferência:" + App.DadosCorrentista.CPF;
            Clipboard.SetTextAsync(str);
            DisplayAlert("Copiado", "Chave Pix copiada para a área de transferência.", "OK");
        }
      
        private async void compartilharChave_Clicked(object sender, EventArgs e)
        {
            string str = "Chave da Transferência:" + App.DadosCorrentista.CPF;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = str,
                Title = "Compartilhar Pix Copia e Cola"
            });
        }
    }
}