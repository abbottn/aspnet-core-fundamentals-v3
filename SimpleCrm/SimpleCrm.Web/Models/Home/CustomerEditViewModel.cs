using System.ComponentModel.DataAnnotations;

namespace SimpleCrm.Web.Models.Home
{
    public class CustomerEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you must provide a first name")]
        [MinLength(2)]
        [MaxLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(2)]
        [MaxLength(25)]
        [Required(ErrorMessage = "you must provide a last name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "you must provide a phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Opt In Newsletter")]
        public bool OptInNewsletter { get; set; }

        [Display(Name = "Customer Type")]
        public CustomerType Type { get; set; }

    }
}
