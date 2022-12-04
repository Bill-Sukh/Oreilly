
namespace Oreilly_ChapterTwo{
    public class Program
    {
        public static void FieldsAndPropertiesMethod()
        {
            FieldsAndProperties fieldsAndProperties = new()
            {
                Id = 2,
                Name = null,
                Address = "Hell st 232",
                City = "Hueco Mundo"
            };

            Console.WriteLine($"{fieldsAndProperties.Id} {fieldsAndProperties.Name}");
        }

        public static void ReferenceTypes()
        {
            FieldsAndProperties originalInstance = new()
            {
                Id = 3,
                Name = "Josh"
            };

            // This variable is not the copy of the original instance object. But a reference to it. 
            FieldsAndProperties copyOfReference = originalInstance;

            // This one also gets assigned reference to original instance. 
            FieldsAndProperties copyOfCopy = copyOfReference;

            Console.WriteLine($"Copy: {copyOfReference.Name}, Original: {originalInstance.Name}, Copy of Copy: {copyOfCopy.Name}");

            Console.WriteLine(new string('-', 30));

            // Even better example 
            // Even if we assign the orignal instance to different variables, it still pointing at the same original instance. 
            Counter counter = new();
            Counter counter1 = counter;
            Counter counter2 = counter;
            Counter counter3 = new();

            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter1.Increment());
            Console.WriteLine(counter1.Increment());

            // Setting Count field to zero, by using public property. We provide access to class private fields through properties. 
            counter.Count = 0;
            Console.WriteLine(counter2.Increment());

            // When we compare two reference types, == operator compares the identity instead of value.
            (bool, bool, bool, bool) referenceComparisonResult = (counter == counter1,
                                                                  counter1 == counter,
                                                                  counter2 == counter,
                                                                  counter3 == counter);

            Console.WriteLine(referenceComparisonResult);

            Console.WriteLine(new string('-', 30));

            int i = 0;
            int h = i;

            Console.WriteLine(object.ReferenceEquals(i, h));

        }

        public static void StaticMembers()
        {
            Counter counter = new();
            Counter counter2 = new();
            Counter counter3 = new();

            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());
            Console.WriteLine(counter.Increment());

            Console.WriteLine(counter2.Increment());
            Console.WriteLine(counter2.Increment());
            Console.WriteLine(counter2.Increment());

            Console.WriteLine(counter3.Increment());
            Console.WriteLine(counter3.Increment());
            Console.WriteLine(counter3.Increment());

            // This static field has the latest counter value. Mixing non-static members with static members isn't recommended. 
            Console.WriteLine(Counter.ConstantStaticNumber);
        }

        public static void Nullables()
        {
            // Raw syntax
            Nullable<int> age = null;

            // Shorter syntax
            int? personAge = 20;

            // Arithemtic operators treat nullable numeric types differently. 
            // Variable that is containing the result of arithmetic operation must be nullable as well. 
            int? result = age + personAge;

            // Result will be null, since one of them is null. 
            Console.WriteLine(result);

            // Using null forgiving operator to allow null, exclamation mark at the end.
            // If you remove forgiving operator you will see warning saying: assignment of possible null value to non-nullable type. 
            string willBeNull = (age == null ? null : age.ToString())!;

            // Alternatively, you can make the variable type nullable type, of course.
            string? willBeNull2 = (personAge == null ? null : personAge.ToString())!;

            Console.WriteLine(willBeNull);

            var d = new Dictionary<int, string>();
            d.Add(42, null);

            Console.WriteLine(TryGetMethod(d));

            // .NET creates empty slots with null values, initially. 
            string[] arr = new string[10];

            if (arr[0] == null) Console.WriteLine($"Item is null: {arr[0]}");
        }

        public static string TryGetMethod(IDictionary<int, string> d)
        {
            if (d.TryGetValue(42, out string? s))
            {
                return s;
            }
            return "Not found";
        }

        public static void Structs()
        {
            // Defined new meaning for == operator for the struct.
            // True if x, y values of both instances are even numbers           
            var firstInstance = new StructExample(20, 80);
            var secondInstance = new StructExample(40, 100);

            // NOTE: values of instances can be different, but still be true as long as they are even.
            if (firstInstance == secondInstance)
            {
                Console.WriteLine("Both have equal x, y points");
            }
        }

        public static void Hash()
        {
            Counter c = new Counter();
            c.Count = 12;

            Counter c2 = new Counter();
            c.Count = 12;

            c2 = c;

            Console.WriteLine(c.GetHashCode());
            Console.WriteLine(c2.GetHashCode());

        }

        public static void AccessibilityModifiers()
        {
            Counter c = new();
            Console.WriteLine($"Here is the default value for field Name: {c.Name}");

            c.Name = "Jigsaw";
            Console.WriteLine($"Changed the field value with setter: {c.Name}");

            Console.WriteLine($"This is a readonly field {c.ReadOnlyMember}");
            
            // Throws compiler error, because it is a readonly field. It can only be set with value through constructor of the class.
            //c.ReadOnlyMember = "Someh";
        }

        public static void ChainingConstructors()
        {
            // Example of runnig two constructors at the same time. 
            Counter c = new(23);
            Console.WriteLine($"{c.Count}, {c.Name}, {c.ReadOnlyMember}");

            // Three constructors at the same time. 
            Counter c2 = new("Id");
            Console.WriteLine($"{c2.Count}, {c2.Name}, {c2.ReadOnlyMember}, {c2.Id}");
        }

        public static void ClassDefaultState()
        {
            // If you don't define constructors and initialize all the fields, C# intializes them to their default values.
            // Although you didn't define empty contructor explicitly, C# creates one for you. So at compile time, there is invisible empty constructor. 
            NoConstructorClass ncc = new();
            Console.WriteLine($"{ncc.Id}, {ncc.ProductName}, {ncc.Description}, {ncc.Price}, {ncc.IsAvailable}");
        }
        static void Main()
        {
            //FieldsAndPropertiesMethod();
            //ReferenceTypes();
            //StaticMembers();
            //Nullables();
            //Structs();
            //Hash();
            //AccessibilityModifiers();
            //ChainingConstructors();
            //ClassDefaultState();
        }
    }
}


