﻿using NomadeTFC.Models;
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
    public partial class NewVillePage : ContentPage
    {
        public Ville ville { get; set; }
        public NewVillePage()
        {
            InitializeComponent();
        }
    }
}