using System;

namespace CSharpAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Question 01: #region and #endregion Directive
            // QUESTION 01: #REGION AND #ENDREGION DIRECTIVE
            // Q: What is the purpose of '#region' and '#endregion' in C#? Do they affect the execution of the code?
            // ANSWER:
            // '#region' and '#endregion' are preprocessor directives used to organize and collapse 
            // sections of code in IDEs like Visual Studio. They improve code readability.
            // They DO NOT affect the execution, performance, or compilation of the program at all; 
            // the compiler strips them out during compilation.
            #endregion

            #region Question 02: Single-Line vs Multi-Line Comments
            // QUESTION 02: SINGLE-LINE VS MULTI-LINE COMMENTS
            // Q: What is the difference between single-line (//) and multi-line comments?
            // ANSWER:
            // - Single-line comments (//): Comment out text from the double slash to the end of that specific line.
            // - Multi-line comments: Comment out everything enclosed between the opening and closing comment tags, 
            //   which can span across multiple lines or even be placed inline within a single statement.
            #endregion

            #region Question 03: Variable Declaration and Initialization
            // QUESTION 03: VARIABLE DECLARATION AND INITIALIZATION
            // Q: What is the difference between declaring a variable and initializing it?
            // ANSWER:
            // - Declaration: Specifying the variable name and data type to allocate space in memory (e.g., int age;).
            // - Initialization: Assigning an initial value to the declared variable for the first time (e.g., age = 25;).
            // - Both can be done together: int age = 25;
            int ageExample = 25;
            Console.WriteLine($"Age initialized: {ageExample}");
            #endregion

            #region Question 04: Variable Scope
            // QUESTION 04: VARIABLE SCOPE
            // Q: What is variable scope in C#? What happens if you try to access a variable outside its scope?
            // ANSWER:
            // Variable scope refers to the block of code (defined by curly braces {}) where a variable is 
            // visible and accessible. If you attempt to access a variable outside its defined scope, 
            // a compilation error occurs ('The name does not exist in the current context').
            #endregion

            #region Question 05: Variable Lifetime
            // QUESTION 05: VARIABLE LIFETIME
            // Q: What is the lifetime of a local variable inside a method?
            // ANSWER:
            // The lifetime of a local variable begins when the method/block starts execution and the variable is declared, 
            // and ends when the method/block finishes execution. Stack memory allocated for local variables is popped 
            // automatically when the method exits.
            #endregion

            #region Question 06: Garbage Collection
            // QUESTION 06: GARBAGE COLLECTION
            // Q: What is the role of the Garbage Collector (GC) in C#? Does it manage Stack or Heap memory?
            // ANSWER:
            // The Garbage Collector (.NET GC) is an automatic memory management tool that reclaims memory 
            // by destroying unused objects that are no longer referenced by the application.
            // It manages the HEAP memory only. Stack memory is self-managing and cleaned up automatically.
            #endregion

            #region Question 07: Variable Shadowing
            // QUESTION 07: VARIABLE SHADOWING
            // Q: What is variable shadowing (variable hiding) in C#? Give an example.
            // ANSWER:
            // Variable shadowing occurs when a variable declared in an inner scope (such as a method or parameter) 
            // shares the same name as a variable in an outer scope (such as a class field), hiding the outer variable.
            #endregion

            #region Question 08: Value of Uninitialized Variables
            // QUESTION 08: VALUE OF UNINITIALIZED VARIABLES
            // Q: What are the default values of uninitialized variables in C# (fields vs local variables)?
            // ANSWER:
            // - Class/Struct Fields: Automatically initialized to their type defaults (numeric: 0, bool: false, reference types: null).
            // - Local Variables: Must be explicitly assigned a value before use; otherwise, the C# compiler throws a compile-time error.
            #endregion

            #region Question 09: Syntax vs Runtime vs Logical Errors
            // QUESTION 09: SYNTAX VS RUNTIME VS LOGICAL ERRORS
            // Q: Explain the differences between: Syntax Errors, Runtime Errors, and Logical Errors.
            // ANSWER:
            // 1. Syntax Error: Code violates C# grammar rules (e.g., missing semicolon). Caught at compile time.
            // 2. Runtime Error: Occurs while the application is running (e.g., dividing by zero, null reference). Causes program crash if unhandled.
            // 3. Logical Error: Code compiles and runs without crashing, but produces incorrect results due to flawed logic.
            #endregion

            #region Question 10: try-catch Block
            // QUESTION 10: TRY-CATCH BLOCK
            // Q: What is the purpose of a 'try-catch' block? How does it prevent a program from crashing?
            // ANSWER:
            // A 'try-catch' block is used for structured exception handling. 
            // Code that might throw an exception is placed inside the 'try' block. If an error occurs, 
            // execution jumps to the 'catch' block where the error is handled gracefully.
            try
            {
                int zero = 0;
                int res = 10 / zero;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Handled error gracefully: {ex.Message}");
            }
            #endregion

            #region Question 11: try-catch-finally Block
            // QUESTION 11: TRY-CATCH-FINALLY BLOCK
            // Q: What is the role of the 'finally' block? When does it execute?
            // ANSWER:
            // The 'finally' block contains cleanup code (closing files, releasing database connections). 
            // It is GUARANTEED to execute regardless of whether an exception was thrown or not.
            #endregion

            #region Question 12: finally Block Execution
            // QUESTION 12: FINALLY BLOCK EXECUTION
            // Q: Is there any scenario where a 'finally' block will NOT execute?
            // ANSWER:
            // Yes, only in extreme scenarios:
            // 1. If Environment.FailFast() or Environment.Exit() is called.
            // 2. If an unrecoverable process crash happens (e.g., StackOverflowException, power failure).
            #endregion

            #region Question 13: Exception Class
            // QUESTION 13: EXCEPTION CLASS
            // Q: What is the base class for all exceptions in C#? What properties does it provide to get error information?
            // ANSWER:
            // The base class is System.Exception.
            // Key properties: Message, StackTrace, InnerException, Source.
            #endregion

            #region Question 14: Built-in Exception Types
            // QUESTION 14: BUILT-IN EXCEPTION TYPES
            // Q: Name 5 common built-in exception types in C# and describe scenarios when each would occur.
            // ANSWER:
            // 1. NullReferenceException: Accessing a member on a null reference.
            // 2. IndexOutOfRangeException: Accessing an invalid array index.
            // 3. DivideByZeroException: Dividing an integer by zero.
            // 4. FormatException: Converting an invalid string to a number (e.g., int.Parse("abc")).
            // 5. FileNotFoundException: Attempting to open a file that does not exist on disk.
            #endregion

            #region Question 15: Multiple catch Blocks
            // QUESTION 15: MULTIPLE CATCH BLOCKS
            // Q: Why is the order of catch blocks important when handling multiple exceptions?
            // ANSWER:
            // Catch blocks are evaluated sequentially from top to bottom. 
            // You must order them from the MOST specific exception type to the LEAST specific (base Exception class).
            #endregion

            #region Question 16: throw Keyword
            // QUESTION 16: THROW KEYWORD
            // Q: What is the difference between 'throw' and 'throw ex' when re-throwing an exception?
            // ANSWER:
            // - 'throw;': Preserves the original stack trace, showing the exact line where the error first originated.
            // - 'throw ex;': Resets the stack trace to the current catch line, destroying the original source context.
            #endregion

            #region Question 17: Stack and Heap Memory
            // QUESTION 17: STACK AND HEAP MEMORY
            // Q: Explain the differences between Stack and Heap memory in C#. What types of data are stored in each?
            // ANSWER:
            // - Stack: Fast, LIFO structured, self-managing. Stores Value Types (int, double, struct) and object reference pointers.
            // - Heap: Dynamically allocated, managed by Garbage Collector. Stores Reference Types (classes, strings, arrays, objects).
            #endregion

            #region Question 18: Value Types vs Reference Types
            // QUESTION 18: VALUE TYPES VS REFERENCE TYPES
            // Q: Write a code example showing how value types and reference types behave differently when assigned to another variable.
            // ANSWER:
            // - Value Types: Direct copy of the value is made. Modifying one copy does not affect the other.
            // - Reference Types: Copies the reference pointer, both point to the same memory location in heap.
            #endregion

            #region Question 19: Object in C#
            // QUESTION 19: OBJECT IN C#
            // Q: Why is 'object' considered the base type of all types in C#? What methods does every type inherit from System.Object?
            // ANSWER:
            // 'System.Object' is the ultimate root base class of the .NET type hierarchy. All types inherit from it.
            // Inherited methods: ToString(), Equals(), GetHashCode(), GetType().
            #endregion

            Console.WriteLine("Assignment 01 completed successfully!");
        }
    }
}
