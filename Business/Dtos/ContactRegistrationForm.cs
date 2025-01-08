using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ContactRegistrationForm
{
    [Required(ErrorMessage = "First name is required!")]
    [MinLength(2, ErrorMessage = "First name must contain atleast 2 characters.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[\s\-'][a-öA-Ö]+)*$", ErrorMessage = "First name can only contain letters, spaces, hyphens, or apostrophes.")]
    //Tog hjälp utav ChatGPT att skapa denna Regex, den kollar så att namnet inte innehåller siffror.

    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required!")]
    [MinLength(2, ErrorMessage = "Last name must contain atleast 2 characters.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[\s\-'][a-öA-Ö]+)*$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, or apostrophes.")]
    //Tog hjälp utav ChatGPT att skapa denna Regex, den kollar så att namnet inte innehåller siffror.

    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required!")]
    [RegularExpression(@"^[a-öA-Ö0-9._%+-]+@[a-öA-Ö0-9.-]+\.[a-öA-Ö]{2,}$", ErrorMessage = "Email must be in a valid format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phonenumber is required!")]

    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Street address is required!")]
    public string StreetAddress { get; set; } = null!;

    [Required(ErrorMessage = "City is required!")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required!")]

    public string PostalCode { get; set; } = null!;

}
