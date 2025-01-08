using Business.Factories;
using Business.Models;

namespace ContactListAssignment.Dialogs;

public class MenuDialog
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            MainMenu();
        }

    }
    public void MainMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("1. Add a new contact.");
        Console.WriteLine("2. Show contact-list.");
        Console.WriteLine("Q. Quit.");
        Console.WriteLine("--------------------");
        Console.Write("Choose your option: ");
        string option = Console.ReadLine()!;
        Console.WriteLine("");

        var contactFactory = new ContactFactory();
        var contactService = new Business.Services.ContactService();

        /* Tog lite hjälp av ChatGPT här för att anropa metoderna */
        switch (option.ToLower())
        {
            case "1":
                var createDialog = new CreateDialog(contactFactory, contactService);
                createDialog.CreateContact(); 
                break;

            case "2":
                var viewList = new ListDialog();
                viewList.ViewAllContactsDialog();
                break;


            case "q":
                var quitDialog = new QuitDialog();
                quitDialog.QuitOption();
                break;

            default:
                break;
        }
    }
}
