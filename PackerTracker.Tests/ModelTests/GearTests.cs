using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PackerTracker.Models;
using System;

namespace PackerTracker.TestTools
{
    [TestClass]
    public class GearTests : IDisposable
  {

    public void Dispose()
    {
      Gear.ClearAll();
    }
    

        [TestMethod]
        public void GearConstructor_CreatesInsanceOfGear_Gear()
        {
            Gear newGear = new Gear("test");
            Assert.AreEqual(typeof(Gear), newGear.GetType());
        }

        [TestMethod]
        public void GetDescription_ReturnsDescription_String()
        {
            //Arrange
            string description = "tent";

            //Act
            Gear newGear = new Gear(description);
            string result = newGear.Description;

            //Assert
            Assert.AreEqual(description, result);
        }

        [TestMethod]
        public void GetAll_ReturnsGears_GearList()
        {
            //Arrange
            string description01 = "Tent";
            string description02 = "Sleeping bag";
            Gear newGear1 = new Gear(description01);
            Gear newGear2 = new Gear(description02);
            List<Gear> newList = new List<Gear> { newGear1, newGear2 };

            //Act
            List<Gear> result = Gear.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetId_GearsInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "Tent";
      Gear newGear = new Gear(description);

      //Act
      int result = newGear.Id;

      //Assert
      Assert.AreEqual(1, result);
    } 

    [TestMethod]
  public void Find_ReturnsCorrectGear_Gear()
  {
    //Arrange
    string description01 = "Tent";
    string description02 = "Ax";
    Gear newGear1 = new Gear(description01);
    Gear newGear2 = new Gear(description02);

    //Act
    Gear result = Gear.Find(2);

    //Assert
    Assert.AreEqual(newGear2, result);
  }

    }
}