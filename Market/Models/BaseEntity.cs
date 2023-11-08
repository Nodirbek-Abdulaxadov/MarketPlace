using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public abstract class BaseEntity
{
    [Key, Required]
    public int Id { get; set; }
}