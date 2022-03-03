using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      string result = newArtist.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      int result = newArtist.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

      //Act
      List<Artist> result = Artist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);

      //Act
      Category result = Category.Find(2);

      //Assert
      Assert.AreEqual(newCategory2, result);
    }

    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      List<Item> newList = new List<Item> { newItem };
      string name = "Work";
      Category newCategory = new Category(name);
      newCategory.AddItem(newItem);

      //Act
      List<Item> result = newCategory.Items;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}