using Business.Dtos;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public class ContactFactory
{
    public Contact CreateContact(ContactRegistrationForm form)
    {
        var contact = new Contact

        {
            Id = UniqueIdentifierGenerator.Generate(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            StreetAddress = form.StreetAddress,
            City = form.City,
            PostalCode = form.PostalCode
        };

        return contact;

    }
}
