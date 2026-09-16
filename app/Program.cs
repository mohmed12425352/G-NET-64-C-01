using System;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 01
            // Q1: What will this print and explain what happens?
            // Output: 9
            // Explanation: Casting a double to an int (int)d performs explicit truncation.
            double d = 9.99;
            int x1 = (int)d;
            Console.WriteLine($"Q1 Output: {x1}");
            #endregion

            #region Question 02
            // Q2: Fix the code with the smallest change to get 2.5?
            // Smallest change: Append .0 to 2 (making it a double literal) -> 5 / 2.0
            int n = 5;
            double d2 = n / 2.0;
            Console.WriteLine($"Q2 Output: {d2}");
            #endregion

            #region Question 03
            // Q3: You read a number from user input. Write the correct line to get age as int.
            string inputAge = "25";
            int age = int.Parse(inputAge);
            Console.WriteLine($"Q3 Output: Age is {age}");
            #endregion

            #region Question 04
            // Q4: What happens here and why?
            // Result: System.FormatException because "12a" contains the non-numeric character 'a'.
            try
            {
                string s = "12a";
                int x4 = int.Parse(s);
                Console.WriteLine(x4);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Q4 Output (Caught as expected): {ex.GetType().Name}");
            }
            #endregion

            #region Question 05
            // Q5: Rewrite using int.TryParse so it does not crash on invalid input.
            string s5 = "12a";
            if (int.TryParse(s5, out int result5))
            {
                Console.WriteLine($"Parsed successfully: {result5}");
            }
            else
            {
                Console.WriteLine("Q5 Output: Invalid number format (Handled safely without crash)");
            }
            #endregion

            #region Question 06
            // Q6: What is this concept called and what happens under the hood?
            // Concept: Boxing (wrapping a value type inside an object instance on the heap).
            int x6 = 10;
            object obj6 = x6; // Boxing
            Console.WriteLine($"Q6 Output: {obj6}");
            #endregion

            #region Question 07
            // Q7: What is this concept called and what happens under the hood?
            // Concept: Unboxing (extracting the value type from the boxed object reference).
            object obj7 = 10;
            int x7 = (int)obj7; // Unboxing
            Console.WriteLine($"Q7 Output: {x7}");
            #endregion

            #region Question 08
            // Q8: What happens here and why?
            // Result: System.InvalidCastException because boxed string cannot be unboxed to int.
            try
            {
                object obj8 = "Hello";
                int x8 = (int)obj8;
                Console.WriteLine(x8);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Q8 Output (Caught as expected): {ex.GetType().Name}");
            }
            #endregion

            #region Question 09
            // Q9: Rewrite safely using pattern matching 'is'
            object obj9 = "Hello";
            if (obj9 is int x9)
            {
                Console.WriteLine($"Value: {x9}");
            }
            else
            {
                Console.WriteLine("Q9 Output: Safe unboxing check: obj is not an int.");
            }
            #endregion

            #region Question 10
            // Q10: What will this print and explain?
            // Output: -1 (Null-coalescing operator ?? returns right-hand side when left is null)
            int? x10 = null;
            int y10 = x10 ?? -1;
            Console.WriteLine($"Q10 Output: {y10}");
            #endregion

            #region Question 11
            // Q11: What will this print and why?
            // Output: Blank / empty string (null). Null-conditional operator ?. short-circuits on null.
            string s11 = null;
            Console.WriteLine($"Q11 Output: '{s11?.Length}'");
            #endregion

            #region Question 12
            // Q12: What happens here and why?
            // Result: NullReferenceException. The null-forgiving operator ! only silences compiler warnings.
            try
            {
                string s12 = null;
                Console.WriteLine(s12!.Length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Q12 Output (Caught as expected): {ex.GetType().Name}");
            }
            #endregion

            #region Question 13
            // Q13: What happens when casting a null Nullable<int> to int?
            // Result: InvalidOperationException ('Nullable object must have a value').
            try
            {
                int? x13 = null;
                int y13 = (int)x13;
                Console.WriteLine(y13);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Q13 Output (Caught as expected): {ex.GetType().Name}");
            }
            #endregion

            #region Question 14
            // Q14: Difference between 'as' operator and explicit casting '(T)'?
            // 'as' returns null on failure without throwing; (T) throws InvalidCastException on failure.
            object testObj = "Route Academy";
            string strResult = testObj as string;
            Console.WriteLine($"Q14 Output: 'as' cast succeeded -> {strResult}");
            #endregion

            #region Question 15
            // Q15: Using GetValueOrDefault()
            int? x15 = null;
            int y15 = x15.GetValueOrDefault(10);
            Console.WriteLine($"Q15 Output: {y15}");
            #endregion

            Console.WriteLine("\nAssignment 02 completed successfully!");
        }
    }
}
