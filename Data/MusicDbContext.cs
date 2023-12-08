// File: Data/MusicDbContext.cs
using MusicShop.Models;
using System.Collections.Generic;
using System.Reflection;

namespace MusicShop.Data
{
    public class MusicDbContext
    {
        public List<Music> Songs { get; set; }

        public MusicDbContext()
        {
            
            // Add some real songs
            Songs = new List<Music>
            {
                new Music { Title = "Bad Guy", Genre = "Pop", Performer = "Billie Eilish" },
                new Music { Title = "Bohemian Rhapsody", Genre = "Rock", Performer = "Queen" },
                new Music { Title = "Lose Yourself", Genre = "Hip-Hop", Performer = "Eminem" },
                new Music { Title = "Superstition", Genre = "R&B", Performer = "Stevie Wonder" },
                new Music { Title = "Get Lucky", Genre = "Electronic", Performer = "Daft Punk" },
                new Music { Title = "Jolene", Genre = "Country", Performer = "Dolly Parton" },
                new Music { Title = "Take Five", Genre = "Jazz", Performer = "Dave Brubeck" },
                new Music { Title = "Imagine", Genre = "Pop", Performer = "John Lennon" },
                new Music { Title = "Smells Like Teen Spirit", Genre = "Rock", Performer = "Nirvana" },
                new Music { Title = "Empire State of Mind", Genre = "Hip-Hop", Performer = "Jay-Z ft. Alicia Keys" },
                new Music { Title = "I Will Always Love You", Genre = "R&B", Performer = "Whitney Houston" },
                new Music { Title = "Strobe", Genre = "Electronic", Performer = "Deadmau5" },
                new Music { Title = "Ring of Fire", Genre = "Country", Performer = "Johnny Cash" },
                new Music { Title = "So What", Genre = "Jazz", Performer = "Miles Davis" },
                new Music { Title = "Let It Be", Genre = "Pop", Performer = "The Beatles" }
            };

        }
        // Method to add a new song
        public void addNew(string title, string genre, string performer)
        {
            var newSong = new Music { Title = title, Genre = genre, Performer = performer };
            Songs.Add(newSong);
        }

        // Example of how to use the AddNewSong method
        public void SampleTest()
        {
            var sampleTest = new Music { Title = "Test", Genre = "Test", Performer = "Test" };
            addNew(sampleTest.Title, sampleTest.Genre, sampleTest.Performer);
        }
    
    }
}