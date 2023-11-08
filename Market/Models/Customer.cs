using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public class Customer : BaseEntity
{
    public int DiscountValue { get; set; }

    [Required]
    public int PersonId { get; set; }
    public Person Person = new();
    public ICollection<Receipt> Receipts = 
        new Collection<Receipt>();
}