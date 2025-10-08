using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Data.dto;

public class dto_Manufacturer
{
    public int ManufacturerId { get; set; }

    [StringLength(100)]
    public string ManufacturerName { get; set; }

    public bool? Active { get; set; }
    public int? PrimaryLocationId { get; set; }
    public string UpdatedBy { get; set; }
}
