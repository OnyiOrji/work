using System;

public class Letter
{
    public string RecipientName { get; set; }
    public string DateMailed { get; set; }

    public void PrintLetter()
    {
        Console.WriteLine("Dear {0},", RecipientName);
        Console.WriteLine("We are pleased to inform you that your letter was mailed on {0}.", DateMailed);
        Console.WriteLine("Sincerely,");
        Console.WriteLine("XYZ Company");
    }
}

public class CertifiedLetter : Letter
{
    public string TrackingNumber { get; set; }

    public void PrintCertifiedLetter()
    {
        Console.WriteLine("Dear {0},", RecipientName);
        Console.WriteLine("We are pleased to inform you that your certified letter was mailed on {0}.", DateMailed);
        Console.WriteLine("Your tracking number is {0}.", TrackingNumber);
        Console.WriteLine("Sincerely,");
        Console.WriteLine("XYZ Company");
    }
}

public class LetterDemo
{
    public static void Main()
    {
        // Create a Letter object
        Letter regularLetter = new Letter();
        regularLetter.RecipientName = "John Smith";
        regularLetter.DateMailed = "April 9, 2023";
        regularLetter.PrintLetter();

        Console.WriteLine();

        // Create a CertifiedLetter object
        CertifiedLetter certifiedLetter = new CertifiedLetter();
        certifiedLetter.RecipientName = "Jane Doe";
        certifiedLetter.DateMailed = "April 10, 2023";
        certifiedLetter.TrackingNumber = "123456789";
        certifiedLetter.PrintCertifiedLetter();

        Console.ReadLine();
    }
}