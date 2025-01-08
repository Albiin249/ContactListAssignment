

using Business.Models;

namespace Business.Services;

public class ContactService
{
    private List<Contact> _contacts = [];
    private readonly FileService _fileService = new();

    public void Add(Contact contact)
    {
        _contacts = _fileService.LoadListFromFile();
        _contacts.Add(contact);
        _fileService.SaveListToFile(_contacts);
    }

    public IEnumerable<Contact> GetAll()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }
}
