using Business.Dtos;
using Business.Factories;
using Business.Models;
using Business.Services;
using System.ComponentModel.DataAnnotations;

namespace ContactListAssignment.Dialogs;

public class CreateDialog
{
    private readonly ContactFactory _contactFactory;
    private readonly ContactService _contactService;
   

    public CreateDialog(ContactFactory contactFactory, ContactService contactService)
    {
        _contactFactory = contactFactory;
        _contactService = contactService;
    }

    public void CreateContact()
    {
        Console.Clear();
        var crf = new ContactRegistrationForm();

        crf.FirstName = PromptAndValidate("Enter first name: ", nameof(crf.FirstName));
        crf.LastName = PromptAndValidate("Enter last name: ", nameof(crf.LastName));
        crf.Email = PromptAndValidate("Enter email: ", nameof(crf.Email));
        crf.PhoneNumber = PromptAndValidate("Enter phone number: ", nameof(crf.PhoneNumber));
        crf.StreetAddress = PromptAndValidate("Enter street address: ", nameof(crf.StreetAddress));
        crf.City = PromptAndValidate("Enter city: ", nameof(crf.City));
        crf.PostalCode = PromptAndValidate("Enter postal code: ", nameof(crf.PostalCode));

        Console.WriteLine("");
        Console.WriteLine("User registration successful");
        Console.WriteLine("Press any key to return to the main menu.");

        Console.ReadKey();

        var contact = _contactFactory.CreateContact(crf);

        _contactService.Add(contact);   

    }
    public string PromptAndValidate(string prompt, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write(prompt);
            var input = Console.ReadLine() ?? string.Empty;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(new ContactRegistrationForm()) { MemberName = propertyName };

            if (Validator.TryValidateProperty(input, context, results))
            {
                return input;
            }

            Console.WriteLine($"{results[0].ErrorMessage}. Please try again.");
        }
    }
}
