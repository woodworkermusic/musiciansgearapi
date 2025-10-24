using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Data.dto;

public abstract class dto_ImageBase
{
    [Required]
    [StringLength(512)]
    public string ImageFile { get; set; }

    public byte[] ImageData { get; set; }

    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; }
}
