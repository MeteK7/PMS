using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectsLayer
{
    public class UserBO
    {
        public int UserId { get; set; }


        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name is required.")]
        [Display(Name ="First Name: ")]
        public string FirstName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password confirmation is required.")]
        [Display(Name = "Pasword Confirmation: ")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password confirmation failed.")]//Password confirmation is done by comparing Password and ConfirmPassword properties.
        public string ConfirmPassword { get; set; }
        public DateTime CreatedOn { get; set; }

        public string SuccessMessage { get; set; }
    }
}
