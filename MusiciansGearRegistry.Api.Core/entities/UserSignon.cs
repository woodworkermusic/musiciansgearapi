using MusiciansGearRegistry.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.Entities
{
    [Table("UserSignon")]
    public partial class UserSignon : WebCoreEntity_Base
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserSignonId { get; set; }

        public int UserId { get; set; }
        public string DeviceName { get; set; }
        public string DevicePlatform { get; set; }
        public string DeviceUuid { get; set; }
        public string DeviceVersion { get; set; }
        public string UuidType { get; set; }
        public string App { get; set; }
        public System.DateTime LoginTime { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }

}
