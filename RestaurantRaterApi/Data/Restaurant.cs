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
}
