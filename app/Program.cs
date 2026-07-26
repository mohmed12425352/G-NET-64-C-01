using System;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 01
            // Q1: What will this print and explain what happens?
            /*
            Output: 9

            Explanation:
            Casting a double to an int (int)d performs explicit truncation (explicit casting).
            It does not round to the nearest integer; instead, it simply drops all fractional digits (everything after the decimal point).
            */
            double d = 9.99;
            int x1 = (int)d;
            Console.WriteLine(x1);
            #endregion

            #region Question 02
            // Q2: This code doesn’t compile. Fix it with the smallest change?
            /*
            Note: The original code DOES compile in C#, but it prints 2 instead of 2.5 because 
            integer division (5 / 2) drops the remainder before assigning to d2.

            Smallest change to achieve accurate floating-point division (2.5):
            Append .0 to the constant 2 (making it a double, forcing double division).
            */
            int n = 5;
            double d2 = n / 2.0;
            Console.WriteLine(d2);
            #endregion

            #region Question 03
            // Q3: You read a number from user input .. Write the correct line to get age as int.
            /*
            Solution using int.Parse (or int.TryParse for safe parsing):
            */
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine()!);
            #endregion

            #region Question 04
            // Q4: What happens here and why?
            /*
            Result: Runtime Exception (FormatException).

            Explanation:
            int.Parse expects a string containing only valid numeric characters. 
            Because the string "12a" contains the non-numeric character 'a', int.Parse fails 
            and throws a System.FormatException at runtime.
            */
            // string s = "12a";
            // int x4 = int.Parse(s); // Throws FormatException
            // Console.WriteLine(x4);
            #endregion

            #region Question 05
            // Q5: Complete the code from the previous question so it prints Invalid if conversion into int fails, otherwise prints the number
            string s5 = "12a";
            if (int.TryParse(s5, out int result5))
            {
                Console.WriteLine(result5);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
            #endregion

            #region Question 06
            // Q6: What will this print and explain why?
            /*
            Output: 11

            Explanation:
            1. 'object o = 10;' boxes the integer value 10 into an object reference.
            2. '(int)o' unboxes the value back to an int.
            3. 'a + 1' evaluates to 10 + 1 = 11.
            */
            object o6 = 10;
            int a6 = (int)o6;
            Console.WriteLine(a6 + 1);
            #endregion

            #region Question 07
            // Q7: What will this print and explain why and if there is a problem handle it?
            /*
            Result: Runtime Exception (InvalidCastException).

            Explanation:
            When unboxing an object in C#, the target type must EXACTLY match the underlying boxed type. 
            Because 10 was boxed as an 'int', unboxing directly to a 'long' fails with an InvalidCastException.

            Fix: Unbox to 'int' first, then convert/implicitly cast to 'long'.
            */
            object o7 = 10;
            long x7 = (int)o7; // Unbox to int first, then implicitly cast to long
            Console.WriteLine(x7);
            #endregion

            #region Question 08
            // Q8: Fix this to avoid exceptions and print -1 if conversion isn’t possible?
            /*
            Solution using the pattern-matching 'is' operator:
            Checks if 'o' can be treated/converted as a long or int, otherwise defaults to -1.
            */
            object o8 = 10;
            long x8 = o8 is int i8 ? i8 : (o8 is long l8 ? l8 : -1);
            Console.WriteLine(x8);
            #endregion

            #region Question 09
            // Q9: What will this print and explain why?
            /*
            Output: (Blank line / empty output)

            Explanation:
            'name?.Length' uses the null-conditional operator (?.). 
            Since 'name' is null, short-circuiting occurs and the expression safely returns null 
            (as a Nullable<int>) without throwing a NullReferenceException. 
            Console.WriteLine handles null by printing nothing.
            */
            string? name9 = null;
            Console.WriteLine(name9?.Length);
            #endregion

            #region Question 10
            // Q10: What will this print and explain the process?
            /*
            Output: 0

            Explanation:
            1. 'name2?.Length' evaluates to null because name2 is null.
            2. The null-coalescing operator (??) checks if the left operand is null.
            3. Since it is null, it falls back to the right-hand value, which is 0.
            */
            string? name10 = null;
            int length10 = name10?.Length ?? 0;
            Console.WriteLine(length10);
            #endregion

            #region Question 11
            // Q11: What’s wrong with this “safe” code and how can we solve it?
            /*
            Problem:
            While using (s ?? "0") prevents ArgumentNullException when 's' is null, it does NOT 
            protect against cases where 's' contains non-numeric characters (e.g., "abc"), 
            which would still throw a FormatException.

            Solution:
            Use int.TryParse for fully safe conversion.
            */
            string? s11 = null;
            int x11 = int.TryParse(s11, out int parsedVal11) ? parsedVal11 : 0;
            Console.WriteLine(x11);
            #endregion

            #region Question 12
            // Q12: What happens here and if there is a problem, handle it
            /*
            Result: Runtime Exception (NullReferenceException).

            Explanation:
            The null-forgiving operator (!) tells the compiler to suppress null warnings, 
            promising that 's' won't be null. However, at runtime 's' IS null, leading to a NullReferenceException.

            Fix: Use the null-conditional operator (?.) with null-coalescing (??).
            */
            string? s12 = null;
            Console.WriteLine(s12?.Length ?? 0);
            #endregion

            #region Question 13
            // Q13: What will this print?
            /*
            Output: 0

            Explanation:
            Unlike int.Parse(null) which throws an ArgumentNullException, Convert.ToInt32(null) 
            is explicitly programmed to return 0 when passed a null reference.
            */
            string? s13 = null;
            int x13 = Convert.ToInt32(s13);
            Console.WriteLine(x13);
            #endregion

            #region Question 14
            // Q14: Compare results and explain each result:
            /*
            Result A (int.Parse(s)): 
            Throws ArgumentNullException. 
            int.Parse requires a non-null string containing valid digits. Passing null throws an exception immediately.

            Result B (Convert.ToInt32(s)): 
            Prints 0. 
            Convert.ToInt32 safely handles null inputs by returning the default value of 0.
            */
            string? s14 = null;

            // A (Will crash if uncommented)
            // int a14 = int.Parse(s14); 

            // B
            int b14 = Convert.ToInt32(s14);
            Console.WriteLine(b14);
            #endregion

            #region Question 15
            // Q15: Complete the line to print "Guest" when user is null, otherwise print the user name in uppercase
            string? user15 = null;
            Console.WriteLine(user15?.ToUpper() ?? "Guest");
            #endregion
        }
    }
}