using AppSimpleTest;
using NomadeTFC.Models;
using NomadeTFC.Services;
using NomadeTFC.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NomadeTFCTest
{
    public class VilleDetailViewModelTest
    {
        VilleMockDataStore Vmds;
        VilleDetailViewModel Vdvm;

        [SetUp]
        public void Setup()
        {
            Vdvm = new VilleDetailViewModel();
            Device.Info = new MockDeviceInfo();
            Device.PlatformServices = new MockPlatformServices();
            ////DependencyService.Register<MockResourcesProvider>();
            ////DependencyService.Register<MockDeserializer>();
            DependencyService.Register<VilleMockDataStore>();
            Vmds = DependencyService.Get<VilleMockDataStore>();
            this.Vdvm = new VilleDetailViewModel();
        }

        [Test]
        public void LoadID()
        {
            Ville ville = new Ville();
            ville.Id = "1";
            ville.Nom = "First item";
            string exepted = ville.Nom;

            Vdvm.LoadVilleId(ville.Id).Wait();

            string n = Vdvm.Nom;
            Assert.AreEqual(exepted, n);
        }
    }
}
