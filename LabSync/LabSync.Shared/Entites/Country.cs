using System.ComponentModel.DataAnnotations;

namespace LabSync.Shared.Entites;

public class Country
{
    public int Id { get; set; }

    //[Display(Name = "Country", ResourceType = typeof(Literals))]
    //[MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    //[Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;
}