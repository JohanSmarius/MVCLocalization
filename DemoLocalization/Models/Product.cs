using System.ComponentModel.DataAnnotations;

namespace DemoLocalization.Models;

public class Product
{
    [Required]
    public string Name { get; set; }
    
    [DataType(DataType.Url)]
    public string PictureUrl { get; set; }

    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}