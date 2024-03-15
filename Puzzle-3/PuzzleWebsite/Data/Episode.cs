using LINQtoCSV;

namespace PuzzleWebsite.Data;

public class Episode {

    public static IEnumerable<Episode> LoadEpisodes() {

        var ctx = new CsvContext();
        return ctx.Read<Episode>("Data/Episodes.csv");

    }

		public int Id { get; set; }

    public string Label { get; set; }

    public string ThumbnailUrl { get; set; }

    public string LinkUrl { get; set; }

    public string Description { get; set; }

    public DateTime PostDate { get; set; }

}