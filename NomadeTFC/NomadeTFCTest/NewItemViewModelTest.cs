using AppSimple.Models;
using AppSimple.Services;
using AppSimple.ViewModels;
using NomadeTFC.Models;
using NomadeTFC.Services;
using NomadeTFC.ViewModels;
using NUnit.Framework;
using System.Linq;
using Xamarin.Forms;

namespace NomadeTFCTest
{
    public class NewItemViewModelTest {
        private NewItemViewModel _vm;

        [SetUp]
        public void SetUp() {

            Device.Info = new MockDeviceInfo();
            Device.PlatformServices = new MockPlatformServices();
            ////DependencyService.Register<MockResourcesProvider>();
            ////DependencyService.Register<MockDeserializer>();
            DependencyService.Register<MockDataStore>();
            this._vm = new NewItemViewModel();
        }
        [Test]
        public void TestSave() {
            _vm.Text = "toto";
            // j'ai créé une méthode SaveItem qui sera appelée par OnSave
             _vm.SaveItem().Wait();

            // je récupère le service DataStore utilisé par NewItemViewModel
            var ds = DependencyService.Get<IDataStore<Item>>();
            var result = ds.GetItemsAsync();
            result.Wait();
            // je prends le dernier élément de ma liste
            var r = result.Result.Last();
            // je fais ma comparaison
            Assert.AreEqual(_vm.Text, r.Text);
        }
    }
}
