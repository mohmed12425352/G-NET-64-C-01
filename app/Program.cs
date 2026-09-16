using System;

namespace CSharpAssignment
{
    public enum DayType
    {
        Workday,
        Weekend
    }

    public enum WeekDay
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Question 01: Enums and Day Type
            Console.WriteLine("=== Question 01: Enum & Day Classification ===");
            WeekDay day = WeekDay.Friday;
            DayType type = GetDayType(day);
            Console.WriteLine($"{day} is a {type}\n");
            #endregion

            #region Question 02: Array Statistics & 2D Matrix
            Console.WriteLine("=== Question 02: 1D & 2D Array Processing ===");
            
            int[] numbers = new int[] { 12, 45, 7, 89, 23, 56 };
            GetArrayStats(numbers, out int min, out int max, out double avg);
            Console.WriteLine($"1D Array Stats -> Min: {min}, Max: {max}, Avg: {avg:F2}");
            
            int[,] studentGrades = new int[3, 4]
            {
                { 85, 90, 78, 92 },
                { 70, 65, 80, 75 },
                { 95, 88, 92, 98 }
            };

            Console.WriteLine("\n--- 2D Student Grades Matrix [3 Students, 4 Subjects] ---");
            for (int i = 0; i < studentGrades.GetLength(0); i++)
            {
                int studentTotal = 0;
                for (int j = 0; j < studentGrades.GetLength(1); j++)
                {
                    studentTotal += studentGrades[i, j];
                }
                double studentAvg = (double)studentTotal / studentGrades.GetLength(1);
                Console.WriteLine($"Student {i + 1} -> Total: {studentTotal}, Average: {studentAvg:F2}");
            }
            Console.WriteLine();
            #endregion

            #region Question 03: Calculator Methods
            Console.WriteLine("=== Question 03: Calculator Functions ===");
            double a = 15, b = 3;
            Console.WriteLine($"Add: {a} + {b} = {Add(a, b)}");
            Console.WriteLine($"Subtract: {a} - {b} = {Subtract(a, b)}");
            Console.WriteLine($"Multiply: {a} * {b} = {Multiply(a, b)}");
            Console.WriteLine($"Divide: {a} / {b} = {Divide(a, b)}");
            Console.WriteLine($"Power: {a} ^ 2 = {Power(a, 2)}\n");
            #endregion

            #region Question 04: Circle Properties with out Parameters
            Console.WriteLine("=== Question 04: Circle Properties (out params) ===");
            double radius = 7.0;
            CalculateCircle(radius, out double area, out double circumference);
            Console.WriteLine($"Radius: {radius} -> Area: {area:F2}, Circumference: {circumference:F2}\n");
            #endregion

            #region Question 05: Mini Student Grade Manager
            Console.WriteLine("=== Question 05: Mini Student Grade Manager ===");
            string[] studentNames = new string[] { "Ahmed", "Mohamed", "Sara", "Fatma" };
            int[] scores = new int[] { 92, 85, 76, 95 };
            
            PrintStudentReport(studentNames, scores);
            #endregion

            Console.WriteLine("\nAssignment 05 completed successfully!");
        }

        static DayType GetDayType(WeekDay day) => day switch
        {
            WeekDay.Friday or WeekDay.Saturday => DayType.Weekend,
            _ => DayType.Workday
        };

        static void GetArrayStats(int[] arr, out int min, out int max, out double avg)
        {
            min = arr[0];
            max = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
                sum += arr[i];
            }
            avg = (double)sum / arr.Length;
        }

        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;
        static double Divide(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return x / y;
        }
        static double Power(double baseNum, int exp) => Math.Pow(baseNum, exp);

        static void CalculateCircle(double r, out double area, out double circumference)
        {
            area = Math.PI * r * r;
            circumference = 2 * Math.PI * r;
        }

        static void PrintStudentReport(string[] names, int[] grades)
        {
            int topIndex = 0;
            int total = 0;
            Console.WriteLine("Student Grade Report:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($" - {names[i]}: {grades[i]}%");
                total += grades[i];
                if (grades[i] > grades[topIndex]) topIndex = i;
            }
            double classAvg = (double)total / names.Length;
            Console.WriteLine($"Top Student: {names[topIndex]} ({grades[topIndex]}%)");
            Console.WriteLine($"Class Average: {classAvg:F2}%");
        }
    }
}
