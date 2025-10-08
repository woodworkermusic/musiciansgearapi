using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Data.dto;

public class dto_GearType
{
    public int GearTypeId { get; set; }

    [StringLength(100)]
    public string GearTypeName { get; set; }

    public bool? Active { get; set; }
    public string UpdatedBy { get; set; }
}
