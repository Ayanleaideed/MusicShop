// File: Models/BrowseMusicViewModel.cs
using System.Collections.Generic;

namespace MusicShop.Models
{
    public class BrowseMusicViewModel
    {
        public List<Music> Songs { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Performers { get; set; }

        // Add a property for the new song
        public Music NewSong { get; set; }
    }



}


