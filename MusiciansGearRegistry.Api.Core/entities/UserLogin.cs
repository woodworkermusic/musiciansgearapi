using MusiciansGearRegistry.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.Entities
{
    [Table("UserLogin")]
    public class UserLogin : WebCoreEntity_Base
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserLoginId { get; set; }
        public int LoginProviderId { get; set; }
        public int UserId { get; set; }
        public string AccountIdentifier { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }
        public virtual LoginProvider LoginProvider { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public UserLogin()
        {
            this.UserTokens = new List<UserToken>();
        }
    }
}
