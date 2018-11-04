using PatternForCore.Model.Base;

namespace PatternForCore.Model.Common
{
    public class Movie :  ArchivableEntity<int>
    {
        public Movie()
        {
        }
        public int? Year { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Comments { get; set; }
    }
}
