using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public class ProductCategory : BaseEntity
{
    [Required, StringLength(50)]
    public string CategoryName { get; set; } = string.Empty;

    public ICollection<Product> Products = new Collection<Product>();
}