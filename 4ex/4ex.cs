using System;
using System.Collections.Generic;
internal class Program
{
  class Song
    {
        private string artist;
        private string title;
        private int minutes;
        private int sec;

        public Song(string artist, string title, int minutes, int sec)
        {
            this.Artist = artist;
            this.Title = title;
            this.Minutes = minutes;
            this.Sec = sec;

        }

        public  string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                if (value.Length < 3 || value.Length>20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                artist = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                title = value;
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (value <0 || value>14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                minutes = value;
            }
        }

        public int Sec
        {
            get
            {
                return sec;
            }
            set
            {
                if (value < 1 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }
                sec = value;
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Vvedit kol pesen: ");
        int k = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();
        int kk = 0;
        for (int i = 0; i != k; i++)
        {
            Song temp;
            Console.WriteLine("\n\n");
            Console.WriteLine("[" + (i + 1) + "] Vvedit artist: ");
            string artist = Console.ReadLine();
            Console.WriteLine("Vvedit song name: ");
            string songname = Console.ReadLine();
            Console.WriteLine("Vvedit minutes: ");
            int minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Vvedit sec: ");
            int sec = int.Parse(Console.ReadLine());
            try
            {
                temp = new Song(artist, songname, minutes, sec);
                songs.Add(temp);
                Console.WriteLine("\nSong added\n");
                kk++;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine("\n\n\n\n\n");
        Console.WriteLine("Song aded - "+kk);
        int hours = 0;
        int min = 0;
        int secc = 0;
        foreach(Song s in songs)
        {
            min += s.Minutes;
            secc += s.Sec;
        }
        while (min >= 60 || secc >= 60)
        {
            if (secc >= 60)
            {
                secc -= 60;
                min += 1;
            }
            if (min >= 60)
            {
                min -= 60;
                hours++;
            }
        }
        Console.WriteLine("Playlist lenght: "+hours+"h "+min+"m "+secc+"s");
    }
}
