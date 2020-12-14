using AppSimpleTest;
using NomadeTFC.Models;
using NomadeTFC.Services;
using NomadeTFC.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NomadeTFCTest
{
    class NewVilleViewModelTest
    {
        NewVilleViewModel Nvvm;
        [SetUp]
        public void Setup()
        {
            Device.Info = new MockDeviceInfo();
            Device.PlatformServices = new MockPlatformServices();
            ////DependencyService.Register<MockResourcesProvider>();
            ////DependencyService.Register<MockDeserializer>();
            DependencyService.Register<VilleMockDataStore>();
            Nvvm = new NewVilleViewModel();
        }

        [Test]
        public void Onsave()
        {
            Nvvm.Description = "toto";
            // j'ai créé une méthode SaveItem qui sera appelée par OnSave
            Nvvm.Save().Wait();

            // je récupère le service DataStore utilisé par NewItemViewModel
            var ds = DependencyService.Get<IDataStore<Ville>>();
            var result = ds.GetItemsAsync();
            result.Wait();
            // je prends le dernier élément de ma liste
            var r = result.Result.Last();
            // je fais ma comparaison
            Assert.AreEqual(Nvvm.Description, r.Description);
        }
    }
}
