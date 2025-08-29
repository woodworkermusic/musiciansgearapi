using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.Entities
{
    [Table("UserToken")]
    public class UserToken : WebCoreEntity_Base
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserTokenId { get; set; }
        public int UserLoginId { get; set; }

        public string AccessToken { get; set; }
        public Nullable<System.DateTime> ExpiresOnUtc { get; set; }
        public byte[] SymmetricKey { get; set; }

        public string App { get; set; }

        public virtual UserLogin UserLogin { get; set; }
    }
}
