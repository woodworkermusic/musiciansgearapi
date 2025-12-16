using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusiciansGearRegistry.Data.models;

public class CreateUserRequest
{
    [Required]
    [StringLength(50)]
    [DefaultValue("fn")]
    public string FirstName { get; set; }

    [StringLength(2)]
    [DefaultValue("")]
    public string MiddleInitial { get; set; }

    [StringLength(50)]
    [DefaultValue("ln")]
    public string LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [Required]
    [StringLength(40)]
    [DefaultValue("un")]
    public string UserName { get; set; }

    [Required]
    [StringLength(255)]
    [DefaultValue("example@gmail.com")]
    public string EMailAddress { get; set; }

    [StringLength(50)]
    [DefaultValue("800-555-1212")]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(256)]
    [DefaultValue("")]
    public string NewUserPassword { get; set; }
}
