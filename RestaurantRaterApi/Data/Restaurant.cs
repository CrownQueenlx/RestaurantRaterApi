// Data Model, or Data Entity

using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterApi.Data;

public class Restaurant // Entity -> Maps to our Restaurants table
{
    [Key] // Primary Key will line up with the data tables in the database
    public int Id { get; set; }

    [Required] // Same as NOT NULL, separate from types, must be specified
    [MaxLength(100)] // NVARCHAR(100) in sql
    public string Name { get; set; } = string.Empty; // types

    [Required, MaxLength(100)] // Attributes can go in the same brackets
    public string Location { get; set; } = string.Empty;

    public List<Rating> Ratings { get; set; } = new();

    public double? AverageRating
    {
        get
        {
            if (Ratings.Count == 0)
            {
                return null;
            }

            double total = 0;
            foreach (var rating in Ratings)
            {
                total += rating.Score;
            }
            return total / Ratings.Count;
        }
    }
}
