using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.DTOs.Accounts
{
    public class UpdateRequest : BaseModel<UpdateRequest>
    {
        private string _password;
        private string _confirmPassword;
        private string _role;
        private string _email;

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EnumDataType(typeof(Role), ErrorMessage = "Invalid Role was passed.")]
        public string Role
        {
            get => _role;
            set => _role = ReplaceEmptyWithNull(value);
        }

        [EmailAddress]
        public string Email
        {
            get => _email;
            set => _email = ReplaceEmptyWithNull(value);
        }

        [MinLength(6)]
        public string Password
        {
            get => _password;
            set => _password = ReplaceEmptyWithNull(value);
        }

        [Compare("Password")]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = ReplaceEmptyWithNull(value);
        }
    }
}