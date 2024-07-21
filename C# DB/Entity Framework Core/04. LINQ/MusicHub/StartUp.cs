namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context = new MusicHubDbContext();


            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            // Console.WriteLine(ExportSongsAboveDuration(context,4));
            
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albums = context
                .Producers.First(p => p.Id == producerId)
                .Albums.Select(p => new
                {
                    p.Name,
                    p.ReleaseDate,
                    ProducerName = p.Producer.Name,
                    Songs = p.Songs.Select(s => new
                    {
                        s.Name,
                        s.Price,
                        SongWirterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.SongWirterName),
                    p.Price

                })
                .OrderByDescending(a => a.Price).ToList();

            foreach (var a in albums)
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine("-Songs:");
                int num = 1;
                if (a.Songs.Any())
                {
                    foreach (var s in a.Songs)
                    {
                        sb.AppendLine($"---#{num}");
                        sb.AppendLine($"---SongName: {s.Name}");
                        sb.AppendLine($"---Price: {s.Price:f2}");
                        sb.AppendLine($"---Writer: {s.SongWirterName}");

                        num++;
                    }
                }
                sb.AppendLine($"-AlbumPrice: {a.Price:f2}");
            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.Where(s => s.Duration.TotalSeconds > duration)
                .AsEnumerable()
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    Performers = s.SongPerformers.Select(sp => new
                    {
                        FullName = sp.Performer.FirstName + " " + sp.Performer.LastName
                    }).OrderBy(sp=>sp.FullName),
                    AlbumProducerName = s.Album.Producer.Name,
                    SongDuration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            var sb = new StringBuilder();

            int counter = 1;
            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {s.SongName}");
                sb.AppendLine($"---Writer: {s.WriterName}");
                if (s.Performers.Any())
                {
                    foreach(var p in s.Performers)
                    {
                        sb.AppendLine($"---Performer: {p.FullName}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducerName}");
                sb.AppendLine($"---Duration: {s.SongDuration}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
