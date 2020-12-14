using NomadeTFC.Models;
using NomadeTFC.Services;
using NUnit.Framework;
using System;

namespace NomadeTFCTest
{
    public class Tests
    {
        VilleMockDataStore Vmds;
        
        [SetUp]
        public void Setup()
        {
            Vmds = new VilleMockDataStore();
        }

        [Test]
        public void TestDataStoreItem_AddGet()
        {
            Ville ville = new Ville();
            ville.Id = new Guid().ToString();
            ville.Nom = "test";
            ville.Description = "ville de test";
            ville.CP = "00000";
            Vmds.AddItemAsync(ville).Wait();

            var ville2Async =Vmds.GetItemAsync(ville.Id);
            ville2Async.Wait();
            Ville ville2 = ville2Async.Result;
            Assert.AreEqual(ville.Nom, ville2.Nom);
        }
    }
}