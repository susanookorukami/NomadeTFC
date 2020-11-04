using NomadeTFC.ViewModels;
using NUnit.Framework;
using NomadeTFC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NomadeTFCTest
{
    public class NVVMtest
    {
        NewVilleViewModel Nvvm;

        [SetUp]
        public void Setup()
        {
            Nvvm = new NewVilleViewModel();
        }

        [Test]
        public void NewVilleViewModelTest()
        {
            Nvvm.Nom = " ";
        }
    }
}
