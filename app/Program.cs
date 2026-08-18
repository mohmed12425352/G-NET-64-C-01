using System;

enum DayOfWeek
{
    Saturday = 1,
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

class Program
{
    static void Main()
    {
        Console.Write("Enter a day number (1-7): ");
        int dayNumber = int.Parse(Console.ReadLine());

        if (dayNumber < 1 || dayNumber > 7)
        {
            Console.WriteLine("Invalid day number.");
            return;
        }

        DayOfWeek day = (DayOfWeek)dayNumber;

        Console.WriteLine("Day: " + day);

        switch (day)
        {
            case DayOfWeek.Friday:
            case DayOfWeek.Saturday:
                Console.WriteLine("It's the Weekend");
                break;

            default:
                Console.WriteLine("It's a Workday");
                break;
        }
    }
}