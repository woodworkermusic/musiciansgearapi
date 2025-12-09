using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Data.infrastructure;

public interface INewImage
{
    [Required]
    public int ParentId { get; set; }

    [Required]
    [StringLength(512)]
    public string ImageFile { get; set; }

    [Required]
    [StringLength(32)]
    public string ImageType { get; set; }

    [Required]
    public byte[] ImageData { get; set; }

    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; }
}
