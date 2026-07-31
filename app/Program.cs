using System;
using System.Diagnostics;
using System.Text;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 01: StringBuilder & Stopwatch Benchmark
            // (a) Explanation:
            // Strings in C# are immutable. Concatenating strings using '+' inside a loop 
            // creates a new string object in heap memory on every iteration. 
            // This causes excessive memory allocation and heavy Garbage Collection overhead.

            const int count = 5000;

            // Version 1: String Concatenation
            Stopwatch sw1 = Stopwatch.StartNew();
            string productList1 = "";
            for (int i = 1; i <= count; i++)
            {
                productList1 += i.ToString() + (i < count ? "," : "");
            }
            sw1.Stop();

            // (b) Version 2: StringBuilder
            Stopwatch sw2 = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= count; i++)
            {
                sb.Append(i);
                if (i < count) sb.Append(",");
            }
            string productList2 = sb.ToString();
            sw2.Stop();

            // (c) Timing Results:
            Console.WriteLine($"String Concatenation Time: {sw1.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"StringBuilder Time       : {sw2.Elapsed.TotalMilliseconds} ms\n");
            #endregion

            #region Question 02: Cinema Ticket Pricing System
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter day of week (1-7, where 6=Fri, 7=Sat): ");
            int day = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("Do you have a valid student ID? (yes/no): ");
            bool isStudent = (Console.ReadLine() ?? "").Trim().ToLower() == "yes";

            double price = 0;
            string breakdown = "";

            if (age < 5)
            {
                price = 0;
                breakdown = "Age under 5: Free (0 LE)";
            }
            else
            {
                if (age <= 12)
                {
                    price = 30;
                    breakdown += "Child Rate: 30 LE\n";
                }
                else if (age >= 60)
                {
                    price = 30;
                    breakdown += "Senior Rate: 30 LE\n";
                }
                else
                {
                    price = 50;
                    breakdown += "Standard Rate: 50 LE\n";
                }

                // Weekend Surcharge
                if (day == 6 || day == 7)
                {
                    price += 10;
                    breakdown += "Weekend Surcharge: +10 LE\n";
                }

                // Student Discount (applied after surcharge)
                if (isStudent)
                {
                    double discount = price * 0.20;
                    price -= discount;
                    breakdown += $"Student Discount (20%): -{discount} LE\n";
                }
            }

            Console.WriteLine("\n--- Price Breakdown ---");
            Console.WriteLine(breakdown);
            Console.WriteLine($"Final Ticket Price: {price} LE\n");
            #endregion

            #region Question 03: Switch Conversions
            string userRole = "Manager";

            // (a) Traditional Switch Statement
            string access1;
            switch (userRole)
            {
                case "Admin":
                    access1 = "Full Control";
                    break;
                case "Manager":
                    access1 = "Moderate Control";
                    break;
                case "Guest":
                    access1 = "Read Only";
                    break;
                default:
                    access1 = "Access Denied";
                    break;
            }

            // (b) Switch Expression (C# 8+)
            string access2 = userRole switch
            {
                "Admin" => "Full Control",
                "Manager" => "Moderate Control",
                "Guest" => "Read Only",
                _ => "Access Denied"
            };

            Console.WriteLine($"Access Level: {access2}\n");
            #endregion

            #region Question 04: Ternary Operator Conversion
            int score = 85;

            // Ternary Version
            string grade = score >= 90 ? "Excellent" : (score >= 50 ? "Pass" : "Fail");

            Console.WriteLine($"Grade: {grade}");
            /*
            Readability Answer:
            The ternary version is NOT more readable when nested. 
            I would use the ternary operator for short, single-line conditional assignments.
            For complex or nested conditions, standard if-else or switch is better for readability.
            */
            Console.WriteLine();
            #endregion

            #region Question 05: Password Validation with Do-While
            int attempts = 0;
            bool isValid = false;

            do
            {
                attempts++;
                Console.Write($"Attempt {attempts}/5 - Enter Password: ");
                string password = Console.ReadLine() ?? "";

                bool hasMinLength = password.Length >= 8;
                bool hasUpper = false;
                bool hasDigit = false;
                bool hasSpace = false;

                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpper = true;
                    if (char.IsDigit(c)) hasDigit = true;
                    if (char.IsWhiteSpace(c)) hasSpace = true;
                }

                isValid = hasMinLength && hasUpper && hasDigit && !hasSpace;

                if (isValid)
                {
                    Console.WriteLine("Password accepted!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Password violates rules:");
                    if (!hasMinLength) Console.WriteLine(" - Must be at least 8 characters.");
                    if (!hasUpper) Console.WriteLine(" - At least one uppercase letter required.");
                    if (!hasDigit) Console.WriteLine(" - At least one digit required.");
                    if (hasSpace) Console.WriteLine(" - No spaces allowed.");
                    Console.WriteLine();
                }

            } while (attempts < 5);

            if (!isValid)
            {
                Console.WriteLine("Account locked.\n");
            }
            #endregion

            #region Question 06: Array Processing
            int[] examScores = { 45, 92, 38, 88, 74, 55, 95, 62, 81, 35, 100, 49 };

            // (a) Find and display all failing scores (< 50)
            Console.Write("Failing scores (< 50): ");
            foreach (int s in examScores)
            {
                if (s < 50) Console.Write(s + " ");
            }
            Console.WriteLine();

            // (b) First score above 90 (Stop searching immediately)
            foreach (int s in examScores)
            {
                if (s > 90)
                {
                    Console.WriteLine($"First score above 90: {s}");
                    break;
                }
            }

            // (c) Class average excluding < 40 (absent)
            int sum = 0;
            int validCount = 0;
            foreach (int s in examScores)
            {
                if (s >= 40)
                {
                    sum += s;
                    validCount++;
                }
            }
            double average = validCount > 0 ? (double)sum / validCount : 0;
            Console.WriteLine($"Class Average (excluding < 40): {average:F2}");

            // (d) Count students in grade ranges
            int countA = 0, countB = 0, countC = 0, countD = 0, countF = 0;
            foreach (int s in examScores)
            {
                if (s >= 90) countA++;
                else if (s >= 80) countB++;
                else if (s >= 70) countC++;
                else if (s >= 60) countD++;
                else countF++;
            }
            Console.WriteLine($"Grade Count - A: {countA}, B: {countB}, C: {countC}, D: {countD}, F: {countF}");
            #endregion
        }
    }
}