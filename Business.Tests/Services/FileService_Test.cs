using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Tests.Moq_Tests;

public class FileService_Test
{
    [Fact]
    public void SaveListToFile_ShouldSaveListToAFile()
    {
        //Arrange
        var content = new List<Contact>
        {
            new Contact
            {
                Id = "1",
                FirstName = "Albin",
                LastName = "Test",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                StreetAddress = "Testgatan 1",
                City = "Teststad",
                PostalCode = "12345"
            }
        };
        var fileName = $"{Guid.NewGuid().ToString()}.json";
        IFileService fileService = new FileService(fileName);


        try
        {
            //Act
            fileService.SaveListToFile(content);

            //Assert
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

    }


    [Fact]
    public void LoadListFromFile_ShouldReturnListFromFile()
    { //Tog lite hjälp av ChatGPT, har kommenterat där nere, vad som jag tog hjälp med.
        // Arrange
        var content = new List<Contact>
    {
        new Contact
            {
                 Id = "1",
                 FirstName = "Albin",
                 LastName = "Test",
                 Email = "test@example.com",
                 PhoneNumber = "1234567890",
                 StreetAddress = "Testgatan 1",
                 City = "Teststad",
                 PostalCode = "12345"
            }
        };

        var jsonContent = JsonSerializer.Serialize(content);
        var fileName = "test.json";

        //Act 

        // Här mockas filoperationer
        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock.Setup(fs => fs.LoadListFromFile())
            .Returns(content); // Här mockas metoden så att den returnerar den serialiserade listan

        var fileService = new FileService(fileName);
        var result = fileService.LoadListFromFile();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(content.Count, result.Count);
        Assert.Equal(content[0].Id, result[0].Id);
    }

}