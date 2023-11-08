using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public class Receipt : BaseEntity
{
    [Required]
    public DateTime OperationDate { get; set; }
    [Required]
    public bool IsCheckedOut { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public Customer Customer = new();

    public ICollection<ReceiptDetail> ReceiptDetfails = 
        new Collection<ReceiptDetail>();
}