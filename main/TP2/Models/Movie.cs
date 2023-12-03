using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }


          // Foreign key
            public int GenreId { get; set; }

    // Navigation property
            public Genre Genre { get; set; }
        public Movie()
        {
        }
    }
}
