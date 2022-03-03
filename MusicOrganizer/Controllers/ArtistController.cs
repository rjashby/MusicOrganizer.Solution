using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {

    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Category> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist =Artist.Find(id);
      List<Item> artistRecords = selectedArtist.Records;
      model.Add("artist", selectedArtist);
      model.Add("record", categoryRecord);
      return View(model);
    }

    // This one creates new Items within a given Category, not new artists:
    [HttpPost("/artists/{artistId}/records")]
    public ActionResult Create(int artistId, string recordDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Record newRecord = new Record(recordDescription);
      foundArtist.AddRecord(newRecord);
      List<Record> artistRecords = foundArtist.Records;
      model.Add("records", artistRecords);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

  }
}