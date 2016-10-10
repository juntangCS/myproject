using System.ComponentModel.DataAnnotations;
using Granite.Resources;

namespace Granite.Models.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCreateModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "EmailIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "EmailTooLong")]
        [EmailAddress(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "EmailFormatInvalid")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "PasswordIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "PasswordTooLong")]
        [MinLength(6, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "PasswordTooShort")]
        public string Password { get; set; }


        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "UserNameIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "UserNameTooLong")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "UserNameIsRequired")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "UserNameTooLong")]
        public string LastName { get; set; }
    }
}