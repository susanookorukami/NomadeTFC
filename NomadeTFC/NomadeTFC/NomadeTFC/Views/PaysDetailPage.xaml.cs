﻿using NomadeTFC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NomadeTFC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaysDetailPage : ContentPage
    {
        public PaysDetailPage()
        {
            InitializeComponent();
            BindingContext = new PaysDetailViewModel();
        }
    }
}