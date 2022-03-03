using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class SearchController : Controller
  {
    [HttpGet("/search_by_artist")]
    public ActionResult New()
    {
      return View();
    }
  }
}


[HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist =Artist.Find(id);
      List<Record> artistRecords = selectedArtist.Records;
      model.Add("artist", selectedArtist);
      model.Add("records", artistRecords);
      return View(model);
    }

    List<Artist> list = new List<Artist>(Records);
        
        string result = list.Find(name => name == "input");
        
        Console.WriteLine(result);