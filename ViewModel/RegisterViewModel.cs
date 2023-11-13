using System.ComponentModel.DataAnnotations;

namespace GraduaitionProjectITI.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name Is Requird ")]
        [MaxLength(50, ErrorMessage = "First Name Mustbe Less Than 50 Char ")]
        [MinLength(3,ErrorMessage = "First Name Mustbe Greate Than 50 Char ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Requird ")]
        [MaxLength(50, ErrorMessage = "Last Name Mustbe Less Than 50 Char ")]
        [MinLength(3, ErrorMessage = "Last Name Mustbe Greate Than 50 Char ")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Adress Name Is Requird ")]
        [MinLength(5, ErrorMessage = "Last Name Mustbe Greate Than 5 Char ")]
        [MaxLength(100, ErrorMessage = "Adress Mustbe Less Than 100 Char ")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Phone Number  Is Requird ")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "phone Number must Number And 11 Digit ")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
