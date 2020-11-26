﻿using System;
using System.Collections.Generic;
using NomadeTFC.ViewModels;
using NomadeTFC.Views;
using Xamarin.Forms;

namespace NomadeTFC
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewVillePage), typeof(NewVillePage));
            Routing.RegisterRoute(nameof(VilleDetailPage), typeof(VilleDetailPage));
            Routing.RegisterRoute(nameof(NewPaysPage), typeof(NewPaysPage));
            Routing.RegisterRoute(nameof(PaysDetailPage), typeof(PaysDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
