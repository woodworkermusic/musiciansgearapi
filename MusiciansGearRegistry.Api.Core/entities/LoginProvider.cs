using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusiciansGearRegistry.Api.Core.Entities
{
    [Table("LoginProvider")]
    public class LoginProvider
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LoginProviderId { get; set; }
        public string LoginProviderName { get; set; }

        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }
        public string AuthorizationEndPoint { get; set; }
        public string AccessEndPoint { get; set; }
        public string ProfileEndPoint { get; set; }
        public string LogoutEndPoint { get; set; }
        public string ReturnUrl { get; set; }
    }
}
