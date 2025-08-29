using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Data.models;

public class CreateUserRequest
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(2)]
    public string MiddleInitial { get; set; }

    [StringLength(50)]
    public string LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [Required]
    [StringLength(40)]
    public string UserName { get; set; }

    [Required]
    [StringLength(255)]
    public string EMailAddress { get; set; }

    [StringLength(50)]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(256)]
    public string NewUserPassword { get; set; }
}
