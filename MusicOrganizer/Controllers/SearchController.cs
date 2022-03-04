using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class SearchController : Controller
  {
    [HttpGet("/search_by_artist")]
    public ActionResult Index()
    {
      return View(allArtists);
    }
    
    [HttpGet("/search_by_artist/{searchString}")]
    public ActionResult Show(string searchString)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Search(searchString);
      List<Record> artistRecords = selectedArtist.Records;
      model.Add("artist", selectedArtist);
      model.Add("records", artistRecords);
      return View(model);
    }
  }
}