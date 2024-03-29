﻿using AppBancoDigital.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBancoDigital.View;

namespace AppBancoDigital
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        /**
         * Armazena os dados do Correntista após o login.
         */
        public static Model.Correntista DadosCorrentista { get; set; }
        public static Model.Conta DadosContaC { get; set; }

        public static Model.Conta DadosContaP { get; set; }

        public static ImageSource FotoCorrentista { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
