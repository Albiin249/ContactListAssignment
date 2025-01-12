

using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts = [];

    private readonly IFileService _fileService;  

    
    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void Add(Contact contact)
    {
        _contacts = _fileService.LoadListFromFile();
        _contacts.Add(contact);
        _fileService.SaveListToFile(_contacts);
    }

   

    //Tog hjälp utav ChatGPT här, för att spara ner den uppdatera kontakten till listan.
    //Koden kollar ifall det finns någon likadan kontakt med hjälp av ID och isåfall skriver över ifall det finns.
    //Ifall det inte finns, så returnas det och det debuggas ut att ingen kontakt med likadant ID hittas.
    public bool Update(Contact updatedContact)
    {
        if (updatedContact == null)
        {
            Debug.WriteLine("Den uppdaterade kontakten är null.");
            return false;
        }

        var contact = _contacts.FirstOrDefault(c => c.Id == updatedContact.Id);

        if (contact == null)
        {
            Debug.WriteLine($"Ingen kontakt hittades med ID: {updatedContact.Id}");
            return false;
        }

        contact.FirstName = updatedContact.FirstName ?? contact.FirstName;
        contact.LastName = updatedContact.LastName ?? contact.LastName;
        contact.Email = updatedContact.Email ?? contact.Email;
        contact.PhoneNumber = updatedContact.PhoneNumber ?? contact.PhoneNumber;
        contact.StreetAddress = updatedContact.StreetAddress ?? contact.StreetAddress;
        contact.City = updatedContact.City ?? contact.City;
        contact.PostalCode = updatedContact.PostalCode ?? contact.PostalCode;

        try
        {
            _fileService.SaveListToFile(_contacts);
            Debug.WriteLine("Kontaktlista har sparats.");
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Gick inte att spara kontaktlistan: {ex.Message}");
            return false;
        }
    }
    public void Delete(Contact contactToDelete)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == contactToDelete.Id);
        if (contact != null)
        {
            _contacts.Remove(contact);
            _fileService.SaveListToFile(_contacts);
            Debug.WriteLine("Lyckat");
        }
    }

    public IEnumerable<Contact> GetAll()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }


}
