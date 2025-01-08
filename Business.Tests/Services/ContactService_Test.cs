using Business.Helpers;
using Business.Models;
using Business.Services;

namespace Business.Tests.Services;

public class ContactService_Test
{
    [Fact]
    public void AddToList_ShouldReturnCorrespondingContactInList()
    {
        //arrange
        ContactService contactService = new ContactService();
        var contact = new Contact
        {
            Id = UniqueIdentifierGenerator.Generate(),
            FirstName = "Albin-Test",
            LastName = "Gadaan-Test",
            Email = "Albinjorgensen@hotmail.com",
            PhoneNumber = "1234567890",
            StreetAddress = "Bjärkegatan 10B",
            City = "Göteborg",
            PostalCode = "12345",
        };

        //act
        contactService.Add(contact);

        //assert - 
        // Tog hjälp av ChatGPT med denna kodsnipp, koden kontrollerar att listan innehåller den kontakt jag skapade i arrange delen.
        var contacts = contactService.GetAll(); 
        Assert.Contains(contacts, c =>
            c.Id == contact.Id &&
            c.FirstName == contact.FirstName &&
            c.LastName == contact.LastName &&
            c.Email == contact.Email &&
            c.PhoneNumber == contact.PhoneNumber &&
            c.StreetAddress == contact.StreetAddress &&
            c.City == contact.City &&
            c.PostalCode == contact.PostalCode
        );

    }
}
