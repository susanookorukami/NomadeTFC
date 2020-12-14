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

            var ville2Async = Vmds.GetItemAsync(ville.Id);
            ville2Async.Wait();
            Ville ville2 = ville2Async.Result;
            Assert.AreEqual(ville.Nom, ville2.Nom);
        }

        [Test]
        public void TestDataStoreItem_delete()
        {
            Ville ville = new Ville();
            ville.Id = new Guid().ToString();
            ville.Nom = "test01";
            ville.Description = "ville de test01";
            ville.CP = "00001";
            Vmds.AddItemAsync(ville).Wait();

            var ville1Async = Vmds.GetItemAsync(ville.Id);
            ville1Async.Wait();
            Ville ville1 = ville1Async.Result;
            var ville2Async = Vmds.DeleteItemAsync(ville.Id);
            var ville3Async = Vmds.GetItemAsync(ville.Id);
            ville3Async.Wait();
            Ville ville2 = ville3Async.Result;
            Assert.IsNull(ville2);
        }

        [Test]
        public void TestDataStoreItem_Update()
        {
            //verifie les emplacement memoire; donneé un valeur fix pour le test
            Ville ville = new Ville();
            ville.Id = "1";
            

            var ville1Async = Vmds.GetItemAsync(ville.Id);
            ville1Async.Wait();
            Ville ville1 = ville1Async.Result;
            var call = Vmds.UpdateItemAsync(ville1);
            call.Wait();
            Assert.AreNotEqual(ville1, call.Result);
        }

    }
}