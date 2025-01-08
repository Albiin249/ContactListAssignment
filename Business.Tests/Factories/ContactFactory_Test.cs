using Business.Dtos;
using Business.Factories;
using Business.Helpers;
using Business.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Test
{
    [Fact]
    public void CreateNewContact_FormShouldBeIdenticalToContact()
    {
        
        //arrange
        var contactRegistrationForm = new ContactRegistrationForm
        {
            FirstName = "Albin-Test",
            LastName = "Gadaan-Test",
            Email = "Albinjorgensen@hotmail.com",
            PhoneNumber = "1234567890",
            StreetAddress = "Bjärkegatan 10B",
            City = "Göteborg",
            PostalCode = "12345",
        };
        //act
        var _contactFactory = new ContactFactory();
        var contact = _contactFactory.CreateContact(contactRegistrationForm);

        //assert
        Assert.Equal(contactRegistrationForm.FirstName, contact.FirstName);
        Assert.Equal(contactRegistrationForm.LastName, contact.LastName);
        Assert.Equal(contactRegistrationForm.Email, contact.Email);
        Assert.Equal(contactRegistrationForm.PhoneNumber, contact.PhoneNumber);
        Assert.Equal(contactRegistrationForm.StreetAddress, contact.StreetAddress);
        Assert.Equal(contactRegistrationForm.City, contact.City);
        Assert.Equal(contactRegistrationForm.PostalCode, contact.PostalCode);
    }
}
