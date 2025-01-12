
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Tests.Moq_Tests;


public class ContactService_Test
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;
    private readonly ContactFactory _contactFactory;

    public ContactService_Test()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
        _contactFactory = new ContactFactory();
    }
    [Fact]
    public void Save_ShouldReturnTrue_AddUserToListAndSaveToFile()
    {
        //arrange
        var contactRegistrationForm = new ContactRegistrationForm()
        {
            FirstName = "Albin-Test",
            LastName = "Gadaan-Test",
            Email = "Albinjorgensen@hotmail.com",
            PhoneNumber = "1234567890",
            StreetAddress = "Bjärkegatan 10B",
            City = "Göteborg",
            PostalCode = "12345",
        };

        // Tog hjälp av ChatGPT här med att mocka LodListfromfile för att få en tom lista.
        _fileServiceMock.Setup(x => x.LoadListFromFile()).Returns(new List<Contact>());

        _fileServiceMock.Setup(x => x.SaveListToFile(It.IsAny<List<Contact>>())).Verifiable("SaveListToFile method was not called.");

        //act
        var result = _contactFactory.CreateContact(contactRegistrationForm);
        _contactService.Add(result);

        //assert
        var contacts = _contactService.GetAll();
        Assert.Contains(contacts, c =>
            c.FirstName == contactRegistrationForm.FirstName &&
            c.LastName == contactRegistrationForm.LastName &&
            c.Email == contactRegistrationForm.Email
        );

        _fileServiceMock.Verify(x => x.SaveListToFile(It.IsAny<List<Contact>>()), Times.Once);
    }

    [Fact]
    public void GetAll_ShouldReturnListOfUsers()
    {
        //arrange
        List<Contact> expected = [ new Contact {
            Id = "1",
            FirstName = "Albin-Test",
            LastName = "Gadaan-Test",
            Email = "Albinjorgensen@hotmail.com",
            PhoneNumber = "1234567890",
            StreetAddress = "Bjärkegatan 10B",
            City = "Göteborg",
            PostalCode = "12345",
        }];
        var json = JsonSerializer.Serialize(expected);


        _fileServiceMock.Setup(x => x.LoadListFromFile()).Returns(expected);
        //act
        var result = _contactService.GetAll();

        //assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expected[0].Id, result.First().Id);
        Assert.Equal(expected[0].FirstName, result.First().FirstName);
        Assert.Equal(expected[0].LastName, result.First().LastName);
        Assert.Equal(expected[0].Email, result.First().Email);
        Assert.Equal(expected[0].PhoneNumber, result.First().PhoneNumber);
        Assert.Equal(expected[0].StreetAddress, result.First().StreetAddress);
        Assert.Equal(expected[0].City, result.First().City);
        Assert.Equal(expected[0].PostalCode, result.First().PostalCode);

    }

    [Fact]
    public void Delete_ShouldRemoveContactFromListAndSaveToFile()
    {
        // Arrange
        var contactToDelete = new Contact
        {
            Id = "1",
            FirstName = "Albin",
            LastName = "Test",
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            StreetAddress = "Testgatan 1",
            City = "Teststad",
            PostalCode = "12345"
        };

        var tempFilePath = Path.GetTempFileName();


        var contacts = new List<Contact> { contactToDelete };
        var jsonContent = JsonSerializer.Serialize(contacts);
        File.WriteAllText(tempFilePath, jsonContent);


        var fileService = new FileService(tempFilePath);

        //act 
        var contactService = new ContactService(fileService);
        contactService.Delete(contactToDelete);


        var remainingContacts = fileService.LoadListFromFile();

        //Assert
        Assert.Empty(remainingContacts);


        if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
        }
    }
}
