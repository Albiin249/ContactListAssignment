namespace ContactListAssignment.Dialogs;

public class QuitDialog
{
    public void QuitOption()
    {
        Console.Clear();
        Console.Write("Do you want to exit this application (y/n): ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }
}
