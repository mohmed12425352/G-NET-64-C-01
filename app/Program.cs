using System;
using System.Diagnostics;
using System.Text;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 01: StringBuilder vs String Performance
            Console.WriteLine("=== Question 01: StringBuilder vs String Performance ===");
            int iterations = 30000;
            
            Stopwatch swString = Stopwatch.StartNew();
            string normalStr = "";
            for (int i = 0; i < iterations; i++)
            {
                normalStr += "a";
            }
            swString.Stop();
            Console.WriteLine($"String (+) Time for {iterations} iterations: {swString.ElapsedMilliseconds} ms");

            Stopwatch swSb = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("a");
            }
            string sbResult = sb.ToString();
            swSb.Stop();
            Console.WriteLine($"StringBuilder Time for {iterations} iterations: {swSb.ElapsedMilliseconds} ms");
            Console.WriteLine("Explanation: System.String is immutable, causing repeated allocations, while StringBuilder uses a mutable buffer.\n");
            #endregion

            #region Question 02: Cinema Ticket Pricing
            Console.WriteLine("=== Question 02: Cinema Ticket Pricing System ===");
            int customerAge = 22;
            int showTimeHour = 14;
            
            decimal basePrice;
            if (customerAge < 12)
                basePrice = 50m;
            else if (customerAge < 60)
                basePrice = 100m;
            else
                basePrice = 70m;

            decimal finalPrice = (showTimeHour < 17) ? basePrice * 0.80m : basePrice;
            
            Console.WriteLine($"Customer Age: {customerAge}, Show Time: {showTimeHour}:00");
            Console.WriteLine($"Base Price: {basePrice} EGP, Final Price: {finalPrice} EGP\n");
            #endregion

            #region Question 03: Switch Expressions
            Console.WriteLine("=== Question 03: Switch Expression ===");
            int dayNumber = 3;
            string dayName = dayNumber switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Invalid Day Number"
            };
            Console.WriteLine($"Day Number {dayNumber} is: {dayName}\n");
            #endregion

            #region Question 04: Nested Ternary Operator
            Console.WriteLine("=== Question 04: Nested Ternary Operator ===");
            int score = 85;
            string grade = score >= 90 ? "A (Excellent)" :
                           score >= 80 ? "B (Very Good)" :
                           score >= 70 ? "C (Good)" :
                           score >= 60 ? "D (Pass)" : "F (Fail)";
            Console.WriteLine($"Score: {score} -> Grade: {grade}\n");
            #endregion

            #region Question 05: Password Validation using do-while
            Console.WriteLine("=== Question 05: Password Validation ===");
            string[] testPasswords = new string[] { "short", "nouppercase123", "ValidPass123" };
            int passIndex = 0;
            string testedPassword;
            bool isValid;

            do
            {
                testedPassword = testPasswords[passIndex++];
                bool hasMinLength = testedPassword.Length >= 8;
                bool hasDigit = false;
                bool hasUpper = false;

                foreach (char c in testedPassword)
                {
                    if (char.IsDigit(c)) hasDigit = true;
                    if (char.IsUpper(c)) hasUpper = true;
                }

                isValid = hasMinLength && hasDigit && hasUpper;
                Console.WriteLine($"Testing password '{testedPassword}' -> Valid: {isValid}");

            } while (!isValid && passIndex < testPasswords.Length);

            Console.WriteLine($"Accepted Password: {testedPassword}\n");
            #endregion

            #region Question 06: Exam Scores Array Processing
            Console.WriteLine("=== Question 06: Exam Scores Array Processing ===");
            int[] scores = new int[] { 45, 78, 92, 60, 35, 88, 95, 52 };
            
            int sum = 0;
            int highest = scores[0];
            int lowest = scores[0];
            int passedCount = 0;
            int failedCount = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                int current = scores[i];
                sum += current;
                if (current > highest) highest = current;
                if (current < lowest) lowest = current;
                if (current >= 50) passedCount++;
                else failedCount++;
            }

            double average = (double)sum / scores.Length;

            Console.WriteLine($"Total Students: {scores.Length}");
            Console.WriteLine($"Sum: {sum}, Average: {average:F2}");
            Console.WriteLine($"Highest Score: {highest}, Lowest Score: {lowest}");
            Console.WriteLine($"Passed (>= 50): {passedCount}, Failed (< 50): {failedCount}");
            #endregion

            Console.WriteLine("\nAssignment 03 completed successfully!");
        }
    }
}
