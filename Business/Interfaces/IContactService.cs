
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    void Add(Contact contact);
    bool Update(Contact updatedContact);
    void Delete(Contact contactToDelete);
    IEnumerable<Contact> GetAll();
}
