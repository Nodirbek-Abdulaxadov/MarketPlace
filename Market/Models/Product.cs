using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public class Product : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }

    [Required]
    public int ProductCategoryId { get; set; }
    public ProductCategory Category = new();
    public ICollection<ReceiptDetail> ReceiptDetails = 
        new Collection<ReceiptDetail>();
}