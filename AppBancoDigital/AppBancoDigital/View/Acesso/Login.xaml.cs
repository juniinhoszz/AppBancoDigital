﻿using System;
using AppBancoDigital.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.JotaBank_Logo.png");
        }

        private async void btn_acessar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.Correntista c = await DataServiceCorrentista.LoginAsync(new Model.Correntista
                {
                    CPF = onlynumber(cpf_inserido.Text),
                    Senha = senha_inserida.Text,
                });

                if (c.Id != null)
                {
                    App.DadosCorrentista = c;
                    //Console.WriteLine("Saldo "+c.Saldo + "\nCorrentista " + c.Nome);
                    App.Current.MainPage = new NavigationPage(new View.Home());
                }
                else
                    throw new Exception("CPF ou senha Inválidos.\nTente Novamente!");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private void btn_novo_correntista_Clicked(object sender, EventArgs e)
        {
            try
            {
                //App.Current.MainPage = new View.CadastroCliente();
                Navigation.PushAsync(new View.CadastroCliente());
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

        private void cpf_inserido_Focused(object sender, FocusEventArgs e)
        {
            cpf_inserido.Placeholder = "Digite seu CPF(sem pontos e traços)";
        }

        private void cpf_inserido_Unfocused(object sender, FocusEventArgs e)
        {
            cpf_inserido.Placeholder = "CPF";
        }

        private void senha_inserida_Focused(object sender, FocusEventArgs e)
        {
            senha_inserida.Placeholder = "Digite sua Senha";
        }

        private void senha_inserida_Unfocused(object sender, FocusEventArgs e)
        {
            senha_inserida.Placeholder = "SENHA";
        }
    }
}