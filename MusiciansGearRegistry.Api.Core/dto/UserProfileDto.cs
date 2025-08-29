using MusiciansGearRegistry.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.dto;

public class UserProfileDto : UserProfile
{
    [JsonIgnore]
    public virtual ICollection<UserEquipment> UserGear { get; set; }
    [JsonIgnore]
    public virtual ICollection<LocationDto> Locations { get; set; }

    //[JsonIgnore]
    //public virtual webpages_Membership webpageMembership { get; set; }

    //[JsonIgnore]
    //public virtual ICollection<webpages_UsersInRoles> webpageRoleMembership { get; set; }

    public UserProfileDto()
    {
        this.UserGear = new List<UserEquipment>();
        this.Locations = new List<LocationDto>();
        //this.webpageRoleMembership = new List<webpages_UsersInRoles>();
    }
}

