using System;
using System.Text;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Question01();

        Console.WriteLine("\n==============================\n");

        Question02();

        Console.WriteLine("\n==============================\n");

        Question03();

        Console.WriteLine("\n==============================\n");

        Question04();

        Console.WriteLine("\n==============================\n");

        Question05();

        Console.WriteLine("\n==============================\n");

        Question06();
    }


    // ==========================================
    // Question 01
    // ==========================================
    static void Question01()
    {
        Console.WriteLine("Question 01");

        // (a)
        // Strings in C# are immutable.
        // Every time += is used, a new string object is created
        // in memory and the old content is copied.
        // Repeating this many times creates temporary objects,
        // uses more memory, and makes execution slower.
        // StringBuilder is more efficient because it uses
        // a mutable buffer.

        // (b)
        StringBuilder productList = new StringBuilder();

        for (int i = 1; i <= 5000; i++)
        {
            productList.Append("PROD-");
            productList.Append(i);
            productList.Append(",");
        }

        Console.WriteLine("StringBuilder list created successfully.");


        // (c) Stopwatch comparison

        Stopwatch sw = new Stopwatch();

        sw.Start();

        string normalString = "";

        for (int i = 1; i <= 5000; i++)
        {
            normalString += "PROD-" + i + ",";
        }

        sw.Stop();

        double stringTime = sw.Elapsed.TotalMilliseconds;


        sw.Restart();

        StringBuilder builder = new StringBuilder();

        for (int i = 1; i <= 5000; i++)
        {
            builder.Append("PROD-");
            builder.Append(i);
            builder.Append(",");
        }

        string result = builder.ToString();

        sw.Stop();

        double builderTime = sw.Elapsed.TotalMilliseconds;

        Console.WriteLine("Normal String Time: "
                          + stringTime + " ms");

        Console.WriteLine("StringBuilder Time: "
                          + builderTime + " ms");

        Console.WriteLine("Time Difference: "
                          + (stringTime - builderTime) + " ms");

        Console.WriteLine(
            "StringBuilder is usually faster and uses less memory.");
    }


    // ==========================================
    // Question 02
    // Ticket Pricing System
    // ==========================================
    static void Question02()
    {
        Console.WriteLine("Question 02");

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write(
            "Enter day of week (1-7, 6=Fri, 7=Sat): ");

        int day = int.Parse(Console.ReadLine());

        Console.Write(
            "Do you have a valid student ID? (yes/no): ");

        string student =
            Console.ReadLine().Trim().ToLower();

        double basePrice = 30;
        double weekendSurcharge = 30;
        double discount = 0;
        double finalPrice;

        Console.WriteLine("\n--- Price Breakdown ---");

        if (age < 5)
        {
            finalPrice = 0;

            Console.WriteLine("Age below 5: Free");
            Console.WriteLine("Final Price: 0 LE");
        }
        else
        {
            finalPrice = basePrice;

            Console.WriteLine(
                "Base Price: " + basePrice + " LE");

            if (day == 6 || day == 7)
            {
                finalPrice += weekendSurcharge;

                Console.WriteLine(
                    "Weekend Surcharge: +" +
                    weekendSurcharge + " LE");
            }
            else
            {
                Console.WriteLine(
                    "Weekend Surcharge: 0 LE");
            }

            if (student == "yes")
            {
                discount = finalPrice * 0.20;

                finalPrice -= discount;

                Console.WriteLine(
                    "Student Discount (20%): -" +
                    discount.ToString("F2") + " LE");
            }
            else
            {
                Console.WriteLine(
                    "Student Discount: 0 LE");
            }

            Console.WriteLine(
                "Final Price: " +
                finalPrice.ToString("F2") + " LE");
        }
    }


    // ==========================================
    // Question 03
    // ==========================================
    static void Question03()
    {
        Console.WriteLine("Question 03");

        string fileExtension = ".pdf";
        string fileType;


        // (a) Traditional switch statement

        switch (fileExtension)
        {
            case ".pdf":
                fileType = "PDF Document";
                break;

            case ".docx":
            case ".doc":
                fileType = "Word Document";
                break;

            case ".xlsx":
            case ".xls":
                fileType = "Excel Spreadsheet";
                break;

            case ".jpg":
            case ".png":
            case ".gif":
                fileType = "Image File";
                break;

            default:
                fileType = "Unknown File Type";
                break;
        }

        Console.WriteLine(
            "Traditional Switch: " + fileType);


        // (b) Switch expression

        string fileTypeExpression =
            fileExtension switch
            {
                ".pdf" => "PDF Document",

                ".docx" or ".doc"
                    => "Word Document",

                ".xlsx" or ".xls"
                    => "Excel Spreadsheet",

                ".jpg" or ".png" or ".gif"
                    => "Image File",

                _ => "Unknown File Type"
            };

        Console.WriteLine(
            "Switch Expression: " +
            fileTypeExpression);
    }


    // ==========================================
    // Question 04
    // Ternary Operator
    // ==========================================
    static void Question04()
    {
        Console.WriteLine("Question 04");

        int temperature = 35;

        string weatherAdvice =
            temperature < 0
                ? "Freezing! Stay indoors."
            : temperature < 15
                ? "Cold. Wear a jacket."
            : temperature < 25
                ? "Pleasant weather."
            : temperature < 35
                ? "Warm. Stay hydrated."
            : "Hot! Avoid sun exposure.";

        Console.WriteLine(weatherAdvice);

        // Answer:
        // The ternary version is shorter, but it is not always
        // more readable when there are many conditions.
        // I would use ternary operators for simple conditions
        // and if-else statements for complex conditions.
    }


    // ==========================================
    // Question 05
    // Password Validation
    // ==========================================
    static void Question05()
    {
        Console.WriteLine("Question 05");

        int attempts = 0;
        bool valid = false;

        do
        {
            Console.Write("Enter password: ");

            string password =
                Console.ReadLine() ?? "";

            attempts++;

            bool hasUppercase = false;
            bool hasDigit = false;
            bool hasSpace = false;

            foreach (char character in password)
            {
                if (char.IsUpper(character))
                {
                    hasUppercase = true;
                }

                if (char.IsDigit(character))
                {
                    hasDigit = true;
                }

                if (char.IsWhiteSpace(character))
                {
                    hasSpace = true;
                }
            }

            valid =
                password.Length >= 8 &&
                hasUppercase &&
                hasDigit &&
                !hasSpace;

            if (!valid)
            {
                Console.WriteLine(
                    "Invalid password:");

                if (password.Length < 8)
                {
                    Console.WriteLine(
                        "- Minimum 8 characters required.");
                }

                if (!hasUppercase)
                {
                    Console.WriteLine(
                        "- At least one uppercase letter required.");
                }

                if (!hasDigit)
                {
                    Console.WriteLine(
                        "- At least one digit required.");
                }

                if (hasSpace)
                {
                    Console.WriteLine(
                        "- Spaces are not allowed.");
                }

                if (attempts < 5)
                {
                    Console.WriteLine(
                        "Attempts remaining: " +
                        (5 - attempts));
                }
            }

        } while (!valid && attempts < 5);

        if (valid)
        {
            Console.WriteLine(
                "Password accepted!");
        }
        else
        {
            Console.WriteLine(
                "Account locked");
        }
    }


    // ==========================================
    // Question 06
    // Array Processing
    // ==========================================
    static void Question06()
    {
        Console.WriteLine("Question 06");

        int[] scores =
        {
            85, 42, 91, 67, 55, 78,
            39, 88, 72, 95, 60, 48
        };


        // (a) Find failing scores below 50

        Console.WriteLine(
            "\n(a) Failing Scores:");

        foreach (int score in scores)
        {
            if (score < 50)
            {
                Console.WriteLine(score);
            }
        }


        // (b) Find first score above 90

        Console.WriteLine(
            "\n(b) First Score Above 90:");

        foreach (int score in scores)
        {
            if (score > 90)
            {
                Console.WriteLine(score);

                break;
            }
        }


        // (c) Calculate class average
        // excluding scores below 40

        int sum = 0;
        int count = 0;

        foreach (int score in scores)
        {
            if (score >= 40)
            {
                sum += score;
                count++;
            }
        }

        double average =
            (double)sum / count;

        Console.WriteLine(
            "\n(c) Class Average: " +
            average.ToString("F2"));


        // (d) Count grade ranges

        int gradeA = 0;
        int gradeB = 0;
        int gradeC = 0;
        int gradeD = 0;
        int gradeF = 0;

        foreach (int score in scores)
        {
            if (score >= 90 && score <= 100)
            {
                gradeA++;
            }
            else if (score >= 80)
            {
                gradeB++;
            }
            else if (score >= 70)
            {
                gradeC++;
            }
            else if (score >= 60)
            {
                gradeD++;
            }
            else
            {
                gradeF++;
            }
        }

        Console.WriteLine(
            "\n(d) Grade Distribution:");

        Console.WriteLine(
            "A: " + gradeA);

        Console.WriteLine(
            "B: " + gradeB);

        Console.WriteLine(
            "C: " + gradeC);

        Console.WriteLine(
            "D: " + gradeD);

        Console.WriteLine(
            "F: " + gradeF);
    }
}