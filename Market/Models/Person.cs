using System.ComponentModel.DataAnnotations;

namespace Market.Models;

public class Person : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [StringLength(50)]
    public string SurName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
}