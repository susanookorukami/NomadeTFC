using NomadeTFC.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NomadeTFC.Models;

namespace NomadeTFCTest
{
    public class VDVMTests
    {
        VilleDetailViewModel vdvmt;

        [SetUp]
        public void Setup()
        {
            vdvmt = new VilleDetailViewModel();
        }

        public void GetAndLoadVille()
        {
            Ville v = new Ville();

            v.Id = "01";
            v.Nom = "VDVMTest";
            v.Description = "Test de la class VDVMTest";
            v.CP = 00005;

            var Retour = vdvmt.LoadVilleId(v.Id);
            

        }

    }
}
