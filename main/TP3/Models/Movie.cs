using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace TP3.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public DateTime MovieAdded { get; set; }

        // Add the Photo property
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
