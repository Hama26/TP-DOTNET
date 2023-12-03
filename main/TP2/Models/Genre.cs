namespace WebApplication2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

            // Navigation property
        public ICollection<Movie> Movies { get; set; }


    }
}
