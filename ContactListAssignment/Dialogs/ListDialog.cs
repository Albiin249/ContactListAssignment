using Business.Services;

namespace ContactListAssignment.Dialogs;

public class ListDialog
{
    private readonly ContactService _contactService;

    public ListDialog()
    {
        var fileService = new FileService();
        _contactService = new ContactService(fileService);
    }

    public void ViewAllContactsDialog()
    {
        Console.Clear();

        foreach (var contact in _contactService.GetAll())
        {
            Console.WriteLine($"{"Id:",-15}{contact.Id}");
            Console.WriteLine($"{"Name:",-15}{contact.FirstName}{contact.LastName}");
            Console.WriteLine($"{"Email:",-15}{contact.Email}");
            Console.WriteLine($"{"Phone number:",-15}{contact.PhoneNumber}");
            Console.WriteLine($"{"Street address:",-15}{contact.StreetAddress}");
            Console.WriteLine($"{"Postal code:",-15}{contact.PostalCode}");
            Console.WriteLine($"{"City:",-15}{contact.City}");
            Console.WriteLine("");

        }
        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the main menu.");

        Console.ReadKey();

    }
}
