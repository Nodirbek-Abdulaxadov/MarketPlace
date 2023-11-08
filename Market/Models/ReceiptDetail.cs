using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public class ReceiptDetail : BaseEntity
{
    [Required]
    public decimal DiscountUnitPrice { get; set; }
    [Required]  
    public decimal UnitPrice { get; set;}
    [Required]
    public int Quantity { get; set; }

    [Required]
    public int ReceiptId { get; set; }
    public Receipt Receipt = new();
    [Required]
    public int ProductId { get; set; }
    public Product Product = new();
}