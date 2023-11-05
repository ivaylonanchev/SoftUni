namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> playlist = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                List<string> line = Console.ReadLine()
                    .Split('_')
                    .ToList();
                string type = line[0];
                string name = line[1];
                string time = line[2];

                Song song = new Song(type, name, time);
                playlist.Add(song);
            }
            string filter = Console.ReadLine();

            if( filter == "all")
            {
                foreach (Song song in playlist)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                for (int i = 0; i < playlist.Count; i++)
                {
                    Song currentSong = playlist[i];
                    if(currentSong.Type == filter)
                    {
                        Console.WriteLine(currentSong.Name);
                    }
                }
            }
        }
    }
    class Song
    {
        public Song()
        {
            
        }
        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}