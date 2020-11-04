using NomadeTFC.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NomadeTFC.Models;
using AppSimpleTest;
using Xamarin.Forms;
using NomadeTFC.Services;
using System.Linq;

namespace NomadeTFCTest
{
    public class VDVMTests
    {
        VilleDetailViewModel vdvmt;

        [SetUp]
        public void Setup()
        {
            Device.Info = new MockDeviceInfo();
            Device.PlatformServices = new MockPlatformServices();
            DependencyService.Register<MockDataStore>();
            vdvmt = new VilleDetailViewModel();
        }

        public void GetAndLoadVille()
        {
            Ville v = new Ville();

            v.Id = "01";
            v.Nom = "VDVMTest";
            v.Description = "Test de la class VDVMTest";
            v.CP = 00005;


            var ds = DependencyService.Get<IDataStore<Ville>>();
            var result = ds.GetItemsAsync();
            result.Wait();
            var r = result.Result.Last();
            Assert.AreEqual(v.Nom, r.Nom);

        }

    }
}
