using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicShop.Data;
using MusicShop.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


public class MusicController : Controller
{
    private MusicDbContext _context;


    public MusicController()
    {
        _context = new MusicDbContext();
    }

    public IActionResult BrowseMusic(string genre, string performer)
    {
        var genres = GetAllGenres();
        var performers = GetAllPerformers();

        ViewBag.Genres = new SelectList(genres);
        ViewBag.Performers = new SelectList(performers);

        var allSongs = GetAllSongs();

        var filteredSongs = FilterSongs(allSongs, genre, performer);

        var viewModel = new BrowseMusicViewModel
        {
            Songs = filteredSongs,
            Genres = genres,
            Performers = performers
        };

        return View(viewModel);
    }

    private List<Music> GetAllSongs()
    {
        var songs = _context.Songs;
        return songs;
    }

    private List<string> GetAllGenres()
    {
        return _context.Songs.Select(s => s.Genre).Distinct().ToList();
    }

    private List<string> GetAllPerformers()
    {
        return _context.Songs.Select(s => s.Performer).Distinct().ToList();
    }

    private List<Music> FilterSongs(List<Music> songs, string genre, string performer)
    {
        if (!string.IsNullOrEmpty(genre))
        {
            songs = songs.Where(s => s.Genre == genre).ToList();
        }

        if (!string.IsNullOrEmpty(performer))
        {
            songs = songs.Where(s => s.Performer == performer).ToList();
        }

        return songs;
    }
    [HttpPost]
    public IActionResult ShoppingCart(List<int> selectedSongs)
    {
        var selectedMusic = _context.Songs.Where((s, index) => selectedSongs.Contains(index)).ToList();

        // Store the selected music in TempData
        TempData["SelectedMusic"] = JsonConvert.SerializeObject(selectedMusic);

        // Redirect to the ShoppingCart view
        return RedirectToAction("ShoppingCart");
    }

    public IActionResult ShoppingCart()
    {
        var selectedMusicJson = TempData["SelectedMusic"] as string;
        var selectedMusic = new List<Music>();

        if (!string.IsNullOrEmpty(selectedMusicJson))
        {
            selectedMusic = JsonConvert.DeserializeObject<List<Music>>(selectedMusicJson);
        }

        return View(selectedMusic);

    }


    [HttpPost]
    public IActionResult AddNew(BrowseMusicViewModel model)
    {
        if (ModelState.IsValid)
        {
            _context.addNew(model.NewSong.Title, model.NewSong.Genre, model.NewSong.Performer);
            return RedirectToAction("BrowseMusic");
        }

        return View(model);
    }
    public IActionResult AddNew()
    {
        // add route
        return View();
    }
    public IActionResult Remove()
    {
        // add route
        return View();
    }


    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel model)
{
    // Check if the provided username and password are 
    if (model.Username == "admin" && model.Password == "admin")
    {
            // Redirect to home page
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("BrowseMusic", "music"); 
    }

    // If the credentials are not valid, show an error message 
    ModelState.AddModelError(string.Empty, "Invalid credentials");
    return View();
}




}


