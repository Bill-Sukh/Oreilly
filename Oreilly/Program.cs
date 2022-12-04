using System;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
using Oreilly.Models;

namespace Oreilly
{
    class Program
    {
        public static int MethodInvokeCount = 0;

        public static void RepeatedString()
        {
            string tabs = new string('\t', 5);
        }

        public static void stopWatch()
        {
            int num = 0;
            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            for (int x = 0; x < 10000; x++)
            {
                num += num;
                num++;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(ts);
        }

        public static void envTick()
        {
            int num = 0;
            int start = Environment.TickCount;
            for (int x = 0; x < 10000; x++)
            {
                num += num;
                num++;
            }
            int end = Environment.TickCount;
            int totalTicks = end - start;
            Console.WriteLine(totalTicks);
        }

        public static void CheckedKeyword()
        {
            int overFlownInt = 0;
            try
            {
                int maxIntegerVal = 2_147_483_647;
                overFlownInt = checked (maxIntegerVal + 3);
                Console.WriteLine(overFlownInt);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is out of range for Integer type");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WeirdCode()
        {
            BigInteger i1 = 1;
            BigInteger i2 = 1;
            Console.WriteLine(i1);
            int count = 0;
            while (true)
            {
                if (count++ % 100000 == 0)
                {
                    Console.WriteLine(i2);
                    Console.WriteLine("Divisible");
                    Thread.Sleep(6000);
                }
                Console.WriteLine(count);
                //BigInteger next = i1 + i2;
                //i1 = i2;
                //i2 = next;
            }
        }

        public static void WeirdCodeOrig()
        {
            BigInteger i1 = 1;
            BigInteger i2 = 1;
            Console.WriteLine(i1);
            int count = 0;
            while (true)
            {
                if (count++ % 100000 == 0)
                {
                    Console.WriteLine(i2);
                    Console.WriteLine("Divisible");
                    Thread.Sleep(6000);
                }
                Thread.Sleep(100);
                BigInteger next = i1 + i2;
                Console.WriteLine($"{i1} + {i2} = {next}");
                i1 = i2;
                i2 = next;
            }
        }

        public static void InlineIncrement()
        {
            int count = 0;

            while (true)
            {
                if (count == 1000)
                {
                    Console.WriteLine("Max number hit");
                }
                count++;
            }
        }

        public static void StringInterpolation()
        {
            string dummyStr = "somestr";
            double dummyDbl = 34.000001;

            string interpolation = $"This is interpolated string - {dummyStr}";
            string withFormatSpecifier = $"With custom decimal places: {dummyDbl:f4}";

            Console.WriteLine(withFormatSpecifier);
            Console.WriteLine(interpolation);
        }

        public static void VerbatimStringLiterals()
        {
            // With normal string you have use two backlashes to use backslashes, it can get ugly. 
            string normalStr = "C:\\Users\\eclai\\Desktop\\Bilguut\\Bill\\Programming\\WebDevelopment\back-end\\C#\\Oreilly\\Oreilly\\Oreilly.csproj";
            
            // With verbatim string you can use backslashes literally. 
            string verbatStr = @"C:\Users\eclai\Desktop\Bilguut\Bill\Programming\WebDevelopment\back-end\C#\Oreilly\Oreilly\Oreilly.csproj";

            // With normal string you can't use quotes without backslashes  
            string normalStrWQuote = "Stephen King \"Bag of Bones\"";

            // With verbatim string you can use quotes literally. But you have to write two quotes in a row to use one.
            string verbatimStrWQuote = @"Stephen King ""Bag of Bones""";

            // With verbatim its possible to write multiline string 
            string verbatimMultilineStr = @"Number is out of range for Integer type Number is out of range for Integer typeNumber is out of range for Integer typeNumber is out of range for Integer type
                                            Number is out of range for Integer type
                                            Number is out of range for Integer typeNumber is out of range for Integer type Number is out of range for Integer type";
            Console.WriteLine(normalStr);
            Console.WriteLine(verbatStr);
            Console.WriteLine(normalStrWQuote);
            Console.WriteLine(verbatimStrWQuote);
            Console.WriteLine(verbatimMultilineStr);
            
        }

        public static void Tuples()
        {
            // Tuple with values of same type and doesn't have variable name.
            (int x, int y) = (12, 11);

            // Tuple with values of different type. 
            (int z, double w) diffType = (12, 4.00);

            // Tuple with no item names
            (int, int) noNameItems = (22, 24);
            (int, int) noNameItemsTwo = (22, 24);

            // Assigning tuple to tuple
            (x, y) = noNameItems; // This one is calling tuple in line 161. Since it doesn't have a variable name, we just identify them by item names. 
            (int, int) someIntegers = noNameItems;

            // Triple tuple
            (int O, int U, int L) triples = (12, 1, 2);

            // Quadruple tuple
            (int O, int U, int L, int B) quadruple = (12, 1, 2, 99);

            // Tuple comparison is possible.
            if(noNameItems == noNameItemsTwo)
            {
                Console.WriteLine("Equal");
            } 

            Console.WriteLine($"{x},  {y}");
            Console.WriteLine($"{diffType.z}, {diffType.w}");
            Console.WriteLine($"{noNameItems.Item1}, {noNameItems.Item2}");
            Console.WriteLine($"{triples.O} {triples.U} {triples.L}");
            Console.WriteLine($"{quadruple.O} {quadruple.U} {quadruple.L} {quadruple.B}");
        }

        public static void Dynamics()
        {
            dynamic dynamicString = "Some dynamic string";
            Console.WriteLine($"Type is {dynamicString.GetType()} & Value is {dynamicString}");

            // At runtime, dotnet figures out the type of this variable. 
            dynamic dynamicInt = 5005;
            Console.WriteLine($"Type is {dynamicInt.GetType()} & Value is {dynamicInt}");

            // Use this example to demonstrate compile-time type check 
            string regularString = "Some str";
            //Console.WriteLine($"{regularString.SomeMethod()}"); // 

            // We can convert any type into dynamic
            Employee employee = new Employee(2, "Loop", "Employee");

            dynamic dynObject = employee;
            Console.WriteLine($"Employee Id: {dynObject.Id}, Name: {dynObject.Name}");
            Console.WriteLine(dynObject.GetType());
        }

        public static void TypeConversions()
        {
            // Implicit conversion
            int i = 100;
            double d = i;
            Console.WriteLine(d);

            // Explicit convesrion
            // Only when you are sure that to double variable is going to be within the range of Integer type 
            double n = 200;
            int ne = (int)n;

            // Parsing - used for converting string to numeric type. 
            string someStr = "32";
            string floatStr = "23.00";
            int s = Int32.Parse(someStr);
            double e = Double.Parse(floatStr);

            Console.WriteLine(s);
            Console.WriteLine(e);

            // Explicit conversion with dynamic variable
            double dbbl = 20.00;
            dynamic dynDbbl = dbbl;
            // This will cause an error. Since we are trying to convert larger type to smaller type. It requires explicit conversion. 
            int intNum = dynDbbl;
            // This will work.
            int castedDbbl = (int)dynDbbl;

            Console.WriteLine(castedDbbl);
        }

        public static void Operators()
        {
            int i = 1;

            // Preincrement
            if(++i == 2)
            {
                Console.WriteLine("equals two");
            }

            i = 1;

            // Postincrement 
            if(i++ == 2)
            {
                Console.WriteLine("equals two");
            }

            i = 12; 

            // Less than or equal to - any number that is less than or equals to specified number on the condition. 
            if(i <= 26)
            {
                Console.WriteLine("Less than or equals to");
            }

            i = 102;

            // Greater than or equal to 
            if(i >= 100)
            {
                Console.WriteLine($"Greater than or equals to {i}");
            }

            if(i < 102)
            {
                Console.WriteLine($"Less than {i}");
            }

        }

        public static void NullCheckingPattern()
        {
            string s = null;

            // This will throw error. (Null reference error)
            //if (s.Length > 10)
            //{
            //    Console.WriteLine("Not null");
            //}

            // This will work. 
            if (s?.Length > 10)
            {
                Console.WriteLine("Not null");
            }

            // Null coalescing
            string stringVal = s ?? "str is null";
            Console.WriteLine(stringVal);

            // Combining nullable with null coalescing
            // First the ? on the variable will prevent from exception. 
            // If there is length then coalesing operator evalutes the value. 
            int strVal = s?.Length ?? 0;
            Console.WriteLine(strVal);
        }

        public static void PassingNullCheckedParam()
        {
            int? id = 2;
            string name = "Zoro";
            name = null;
            id = null;
            Employee emp = new(id ?? 0, name ?? "", null);

            Console.WriteLine($"Name: {emp.Name}, id: {emp.Id}");
        }

        public static void FallThroughCaseStudy()
        {
            // Objective: I'd like to execute two block of codes for one input. 

            // Input 
            int input = 23;

            // Using goto
            switch (input)
            {
                case 0:
                    Console.WriteLine("Case 0 hit");
                    goto case 23;
                case 23:
                    Console.WriteLine("Case 23 hit");
                    break;
                case 40:
                    Console.WriteLine("Case 40 hit");
                    break;
            }

            input = 12;

            // Alternative method
            switch (input)
            {
                case 0:
                case 23:
                    if(input == 0)
                    {
                        Console.WriteLine("Case 0 hit");
                    }
  
                    Console.WriteLine("Case 23 hit");
                    break;
                case 40:
                    Console.WriteLine("Case 40 hit");
                    break;
                default:
                    if (input == 12)
                    {

                    }
                    break;
            }


            // Do same logic with if statement
            if (input == 0)
            {
                Console.WriteLine("Case 0 hit");
                Console.WriteLine("Case 23 hit");
            }


            // Do same logic with if statement
            if (input == 0)
            {
                Console.WriteLine("Case 0 hit");
                Console.WriteLine("Case 23 hit");

              
            }

            // Do same logic with if statement
            if (input == 0)
            {
                Console.WriteLine("Case 0 hit");
                Console.WriteLine("Case 23 hit");
            }

            {
                if (input == 0)
                {
                    Console.WriteLine("Case 0 hit");
                    Console.WriteLine("Case 23 hit");
                }

                if (input == 23)
                {
                    Console.WriteLine("Case 23 hit");
                }
            }

            // Do same logic with if statement

            if(input == 40)
            {
                Console.WriteLine("Case 40 hit");
            }
        }

        public static void FlowControl()
        {
            // Input
            string input = "fish";

            // Put this one in block, so it won't treat our second example as part of it. 
            // This will execute all blocks
            {
                if (input == "fish")
                {
                    Console.WriteLine("Make sushi/ fish is special");
                }
                if (input != "tiger")
                {
                    Console.WriteLine("not tiger");
                }
                if (input != "elephant")
                {
                    Console.WriteLine("not elaphant");
                }
                if (input != "bear")
                {
                    Console.WriteLine("not bear");
                }
                if (!String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Animal is huntable by human");
                }
            }

            // Same logic isn't applicable with else if 
            // Only hits one of the condition and then stops. 
            if (input == "fish")
            {
                Console.WriteLine("Make sushi/ fish is special");
            }
            else if (input != "tiger")
            {
                Console.WriteLine("not tiger");
            }
            else if (input != "elephant")
            {
                Console.WriteLine("not elaphant");
            }
            else if (input != "bear")
            {
                Console.WriteLine("not bear");
            }
            else
            {
                Console.WriteLine("Animal is huntable by human");
            }
        }

        public static void ForEach()
        {
            List<Employee> employees = new List<Employee>();
            for(int x = 0; x < 10; x++)
            {
                employees.Add(new Employee(x, "Laura", "Employee"));
            }

            // Foreach can access each item in collection of same type.
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.Id} Employee name: {employee.Name}");
            }

            Console.WriteLine(new String('-', 40));

            // With regular for loop, we can do something like:
            for (int g = 0; g < 10; g++)
            {
                // This only works for pattern Employee. 
                if (employees.ElementAt(g) is Employee emp)
                {
                    Console.WriteLine($"Employee ID: {emp.Id} Employee name: {emp.Name}");
                }
                else
                {
                    Console.WriteLine("Pattern isn't Employee");
                }
            }

            // 1. Remove all the employees with even Id use foreach, for, while 
            // 2. Do work 1 with LINQ

        }

        public static void Patterns()
        {
            Data data = new(20);
            var people = data.People;
            // Simple tuple pattern checking with (int, int) 
            (int, int) p = (0, 0);
            switch (p)
            {
                case (0, 0):
                    Console.WriteLine("How original");
                    break;
                case (0, 1):
                case (1, 0):
                    Console.WriteLine("What an absolute unit");
                    break;
                case (1, 1):
                    Console.WriteLine("Be there and be square");
                    break;
            }

            Console.WriteLine(new String('-', 40));

            // Filter the list of person by derived class types
            for(int i = 0; i < people.Count; i++)
            {
                if(people[i] is Employee emp)
                {
                    Console.WriteLine($"{emp.Position} - Id: {emp.Id}, Name: {emp.Name}");
                }
                else if (people[i] is CEO ceo)
                {
                    Console.WriteLine($"{ceo.Position} - Id: {ceo.Id}, Name: {ceo.Name}");
                }
            }

            Console.WriteLine(new String('-', 40));

            // Foreach will throw error since its only looking for one specific pattern. 
            try
            {
                foreach (Employee emp in people)
                {
                    Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}");
                }
            }
            catch (Exception ex)
            {

            }

            // Switch case cannot check for custom types but can with primitive types using Dynamic.
            dynamic pattern = 0;
            Console.WriteLine("Pattern is");
            switch (pattern)
            {         
                case int:
                    Console.WriteLine("is int");
                    break;
                case string:
                    Console.WriteLine("is string");
                    break;
                case double:
                    Console.WriteLine("is double");
                    break;
            }

            Console.WriteLine(new String('-', 40));

            // Switch case cannot check for custom types but can with primitive types using type of Object.
            Object patternTwo = 2;
            Console.WriteLine("Pattern is");
            switch (patternTwo)
            {
                case int i:                   
                    Console.WriteLine($"is int, and the value is {i}");
                    break;
                case string s:
                    Console.WriteLine($"is string, and the value is {s}");
                    break;
                case double d:
                    Console.WriteLine($"is double, and the value is {d}");
                    break;
            }

            Console.WriteLine(new String('-', 40));

            // Positional pattern with switch operators. This will recognize any pattern with int value as long as the variable is the pattern of types (int, int). 
            (int, int)  positionalPattern = (6, 4);
            switch (positionalPattern)
            {
                // Case for when first item is zero, but care less about the item2.
                case (0, int s):
                    Console.WriteLine($"Item1 is an int and the value is {positionalPattern.Item1}{Environment.NewLine}" +
                    $"Item2 is an int and the value is {s}");
                    break;

                // You can use when keyword combined with tuple, to check more specific conditions more than just patterns. 
                case (int x, int y) when x > y:
                    Console.WriteLine($"{x} is greater than {y}");
                    break;
                case (int x, int y):
                    Console.WriteLine($"Item1 is an int and the value is {x}{Environment.NewLine}" +
                                      $"Item2 is an int and the value is {y}");
                    break;
            }

            Console.WriteLine(new String('-', 40));

            // Pattern checking wiht Switch Expressions
            var WhoIsIt = data.SwitchExpressions();
            Console.WriteLine($"The Person with ID {WhoIsIt.Item1} is {WhoIsIt.Item2}");
        }

        public static void Discard()
        {
            Data data = new(10);

            // Let's say if we don't need the id just the name, we can simply discard it with _. 
            (_, string Name) = data.GetPersonById(2);
            Console.WriteLine($"I discareded the Id since I got the name: {Name}");
        }

        public static void BooleanOperators()
        {
            int methodInvokeCounter = 0;

            // AND 
            // Works only if both condition is true. 
            if (false && false)
            {
                // Won't reach.
            }
            if(true && true)
            {
                Console.WriteLine("true && true = true");
            }
            if(false && true)
            {
                // Won't reach.
            }

            // OR
            // Results true if at least one of the inputs are true.
            if (true || true)
            {
                Console.WriteLine("true || true = True");
            }
            if(true || false)
            {
                Console.WriteLine("true || false = true");
            }
            if(false || false)
            {
                // Won't reach
            }

            // XOR
            // Only results to true if one of the input is true.
            // Works same as inequality operator !=
            if(true ^ true)
            {
                // Won't reach
            }
            if(false ^ false)
            {
                // Won't reach
            }
            if(true ^ false)
            {
                Console.WriteLine("true ^ false = true");
            }

            // Logical OR
            // Evaluates all the true operands even if compiler already encountered one true operand.
            bool OR = true | GetSomeBool(true) | GetSomeBool() | GetSomeBool();
            bool OR_1 = false | GetSomeBool(true) | GetSomeBool() | GetSomeBool();
            bool OR_2 = false | GetSomeBool(true) | false | GetSomeBool();

            Console.WriteLine(new String('-', 50));

            // Logical AND
            // Evaluates operands even if first operand is false.
            bool AND = true & GetSomeBool(true) & GetSomeBool() & GetSomeBool();
            bool AND_1 = false & GetSomeBool(true) & GetSomeBool() & GetSomeBool();
            bool AND_2 = false & GetSomeBool(true) & false & GetSomeBool();
        }

        public static bool GetSomeBool(bool isFirstTime = false)
        {
            if (isFirstTime) MethodInvokeCount = 0;

            MethodInvokeCount++;
            Console.WriteLine($"{MethodInvokeCount} operand evaluated regardless of more than one operand being true.");

            return true;
        }

        static void Main() 
        {
            //envTick();
            //stopWatch();
            //CheckedKeyword();
            //WeirdCodeOrig();
            //StringInterpolation();
            //VerbatimStringLiterals();
            //Tuples();
            //Dynamics();
            //TypeConversions();
            //Operators();
            //NullCheckingPattern();
            //PassingNullCheckedParam();
            //FallThroughCaseStudy();
            //FlowControl();
            //ForEach();
            //Patterns();
            BooleanOperators();
   
        }

       

    }
}

