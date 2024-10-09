# What are delegates?
Delagates are simply a type safe function pointer. A variable defined as a delegate is a referance type variable that can hod a reference to a method.
In order for a delegate to reference a method, it must define parameters with types that match.

```cs
public class Program
{
    delegate int CalculateDel(int operand1, int operand2);

    static void Main (string[] args)
    {
        //Perform addition calculation
        CalculateDel addCalculationDel = new(AddIntegerValues);
        int resultAddition = addCalculationDel(10, 5);

        Console.WriteLine($"Addition result: {resultAddition}");

        //Perform subtraction
        CalculateDel subtractCalculationDel = new(SubtractIntegerValues);
        int resultSubtract = subtractCalculationDel(10, 5);

        Console.WriteLine($"Subtract result: {resultSubtract}");
    }

    static int AddIntegerValues(int operand1, int operand2)
    {
        return operand1 + operand2;
    }

    static int SubtractIntegerValues(int operand1, int operand2)
    {
        return operand1 - operand2;
    }
}
```

    Note
    A delegate can reference both a static method and an instance method.


## Delegates referencing static methods.
Let's say we want to encapsulate functionality that logs text and includes a date-time stamp that is followed by the expected text. We want the solution to:
* Be able to display date-time stamp and text in the console screen.
* Be able to log the date-time stamp and text in a text file.

First in our application:
1. We will define a delegate that reference a method that does not return a value (`void`) and accepts one string argument (`parameter`):
```cs 
    delegate void LogDel(string text);
```

2. Next we define the method that will be passed to our delegate to desplay text using the console screen:
```cs
    static void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }
```

3. We now create an instance for our `LogDel` type to use within the `Main` method scope:
```cs
    LogDel logDel = new(LogTextToScreen);
```

4. We can now use the instance object `logDel` to pass in the appropriate string value to display on the screen:
```cs
    logDel("Wola Tebza");
```

5. The final solution:
```cs
    public class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            LogDel logDel = new(LogTextToScreen);

            Console.WriteLine("Please Enter Your Name and Surname");
            var saveNameSurname = Console.ReadLine();
            logDel($"Your name is {saveNameSurname}!");
        }

        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }
```
```output
    Please Enter Your Name and Surname
    Tebogo Goqo
    2023/11/19 15:12:01: Your name is Tebogo Goqo!
```


## What happens if we decide to include the date-time stamp as a parameter?
The C# compiler will complain at `LogDel logDel = new(LogTextToScreen);` with the below error:
```output
    No overload for 'LogTextToScreen' matches delegate 'Program.LogDel'
```

This means that the `overload` which is the passing of the DateTime type parameter at the `LogTextToScreen` method does not match the the delegate `LogDel` which only accepts one ocerload parameter which is `string text`.

So in order to fix this we must make sure that the `LogDel` delegate also accepts two overload parameters:
```cs
    delegate void LogDel(string text, DateTime dateTime);
```

Also make sure that the created instanceon the `Main` method passes the same type of parameters used on `LogDel` delegate:
```cs
    logDel($"Your name is {saveNameSurname}!", DateTime.Now);
```

Final solution:
```cs
    public class Program
    {
        delegate void LogDel(string text, DateTime dateTime);

        static void Main(string[] args)
        {
            LogDel logDel = new(LogTextToScreen);

            Console.WriteLine("Please Enter Your Name and Surname");
            string? saveNameSurname = Console.ReadLine();
            logDel($"Your name is {saveNameSurname}!", DateTime.Now);
        }

        static void LogTextToScreen(string text, DateTime dateTime)
        {
            Console.WriteLine($"{dateTime}: {text}");
        }
    }
```

Now that we got a basic picture of how delegates work, let's set our program back to how it was before we passed the date-time type as a parameter:
```cs
    public class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            LogDel logDel = new(LogTextToScreen);

            Console.WriteLine("Please Enter Your Name and Surname");
            var saveNameSurname = Console.ReadLine();
            logDel($"Your name is {saveNameSurname}!");
        }

        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }
```

Now we want to to log the text to a text file rather than displaying it on the screen.To implement this functionality we will:
1. Create a method that doesn't return any value and contains a string parameter.
```cs
    static void LogTextToFile(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
```

2. Next we pass the `LogToTextFile` method as a parameter to the instance of delegate `LogDel`:
```cs
    LogDel logDel = new(LogTextToFile);
```

3. After running the application, check `0. Delegates/0. Delegates Basics example/bin/Debug/net8.0/Log.txt`
```output
    2023/11/19 15:35:01: Your name is Tebogo Goqo!
```

--------------------
## Delegates referencing instance method.
1. Let's create a class called `Log` and move all static methods to the `Log` class:
```cs
    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
```
    Note
    Remove the static keyword from both methods and usethe public keyword.

2. Create an instance for the `Log` class and use it to access the methods inside the `Log` class:
```cs
    static void Main(string[] args)
    {
        Log log = new();
        LogDel logDel = new(log.LogTextToFile);

        Console.WriteLine("Please Enter Your Name and Surname");
        string? saveNameSurname = Console.ReadLine();
        logDel($"Your name is {saveNameSurname}!");
    }
```
```output
    2023/11/19 16:43:18: Your name is Tebogo Goqo!
```


```cs
    static void Main(string[] args)
    {
        Log log = new();
        LogDel logDel = new(log.LogTextToScreen);

        Console.WriteLine("Please Enter Your Name and Surname");
        string? saveNameSurname = Console.ReadLine();
        logDel($"Your name is {saveNameSurname}!");
    }
```
```output
    Please Enter Your Name and Surname
    Tebogo Goqo
    2023/11/19 16:53:16: Your name is Tebogo Goqo!
```

## Now let's call both methods through one delegate call.
To achieve this we can use **Multicast Delegates**, this is where multiple object are assigned to one delegate instance by using the plus `+` operator.

1. Let's create a `LogDel` instance for the `LogTextToScreen` method:
```cs
    LogDel logTextToScreenDel = new(log.LogTextToScreen);
```

2. Create a `LogDel` instance for the `LogTextToFile` method
```cs
    LogDel logTextToFile = new(log.LogTextToFile);
```

3. Now let's create a multicast delegate which we will use to combine both delegates into one:
```cs
    LogDel multicastDel = logTextToScreenDel + logTextToFileDel;
```

4. Final code:
```cs
    public class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Log log = new();
            //LogDel logDel = new(log.LogTextToScreen);

            LogDel logTextToScreenDel = new(log.LogTextToScreen);

            LogDel logTextToFileDel = new(log.LogTextToFile);

            LogDel multicastDel = logTextToScreenDel + logTextToFileDel;

            Console.WriteLine("Please Enter Your Name and Surname");
            string? saveNameSurname = Console.ReadLine();
            multicastDel($"Your name is {saveNameSurname}!");
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
```
```output
    //For the LogTextToScreen method
    Please Enter Your Name and Surname
    Tebogo Goqo
    2023/11/19 17:15:40: Your name is Tebogo Goqo!

    //For the LogTextToFile method
    2023/11/19 17:15:40: Your name is Tebogo Goqo!
```



            
