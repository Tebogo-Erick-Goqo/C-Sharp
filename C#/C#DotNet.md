# INTRO
## C#
C# (pronounced "See Sharp") is a modern, object-oriented, and type-safe programming language.

C# is just a simple, secure, robust, portable, platform-independent, architectural neutral, multithreaded, object-oriented programming language 
with a strong type exception handling mechanism for developing different kinds of applications such as Web, Windows Form, Console, Web Services, 
Mobile Apps, etc.

Several C# features help create robust and durable applications. [Garbage collection](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/) 
automatically reclaims memory occupied by unreachable unused objects. [Nullable types](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references) 
guard against variables that don't refer to allocated objects. [Exception handling](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/) 
provides a structured and extensible approach to error detection and recovery. [Lambda expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions) 
support functional programming techniques. [Language Integrated Query (LINQ)](https://learn.microsoft.com/en-us/dotnet/csharp/linq/) syntax 
creates a common pattern for working with data from any source. Language support for [asynchronous operations](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) 
provides syntax for building distributed systems. C# has a [unified type system](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/). 
All C# types, including primitive types such as int and double, inherit from a single root object type.


## Types of Applications Developed using C#:

**With the help of the C# programming language, we can develop different types of secured and robust applications:**

1. Window Applications
2. Web Applications
3. Distributed Applications
4. Web Service Applications
5. Database Applications
6. Mobile Applications, Etc.

## Features of C#

Although C# constructs closely follow traditional high-level languages, C and C++ and being an object-oriented programming languages. It has a strong resemblance with Java, it has numerous strong programming features that make it endearing to a number of programmers worldwide. Following is the list of a few important features of C# −

1. **Simple:** C# is a simple language in the sense that it provides a structured approach (to break the problem into parts), a rich set of 
	library functions, data types, etc.
2. **Modern Programming Language:** C# programming is based upon the current trend and it is very powerful and simple for building scalable, 
	interoperable, and robust applications.
3. **Object-Oriented:** C# is an object-oriented programming language. OOPs makes development and maintenance easier whereas in Procedure-oriented 
	programming language it is not easy to manage if code grows as the project size grows.
4. **Type-Safe:** C# type safe code can only access the memory location that it has permission to execute. Therefore, it improves the security of 
	the program.
5. **Interoperability:** The interoperability process enables the C# programs to do almost anything that a native C++ application can do.
6. **Scalable and Updateable:** C# is an automatic scalable and updateable programming language. For updating our application, we delete the old 
	files and update them with new ones.
7. **Component Oriented:** C# is a component-oriented programming language. It is the predominant software development methodology used to develop 
	more robust and highly scalable applications.
8. **Structured Programming Language:** C# is a structured programming language in the sense that we can break the program into parts using 
	functions. So, it is easy to understand and modify.
9. **Rich Library:** C# provides a lot of inbuilt functions that make development fast.
10. **Fast Speed:** The compilation and execution time of the C# language is fast.

## Basic Structure of C# Program
### What is C#.NET?

1. C#.NET is one of the Microsoft Programming Languages to work with the .NET Framework, .NET Core, or .NET to develop different kinds of 
	applications such as Web, Console, Windows, Restful Services, etc. 
2. It is the most powerful programming language among all programming languages available in the .NET framework because it contains all the 
	features of C++, VB.NET, and JAVA, and also has some additional features. As we progress in this course, you will come to know the additional features.
3. C#.NET is a completely Object-Oriented Programming Language. It means it supports all 4 OOPs Principles i.e. Abstraction, Encapsulation, 
	Inheritance, and Polymorphism.

Based on the features, we can define **C# as just a Simple, Secure, Robust, Portable, Platform-Independent, Architectural Neutral, Multithreaded, Automatic Memory Management, Object-Oriented Programming Language with a strong type Exception Handling mechanism for developing different kinds of applications such as Web, Windows Form, Console, Web Services, Mobile Apps, etc. which can be run on different Operating Systems such as Windows, Linus, and Mac.**


# Different types of Applications Developed using C#.NET
1. Windows Applications
2. Web Applications
3. Restful Web Services
4. SOAP BAsed Services
5. Console Applications
6. Class Library, etc.


**For the whole of my learning journey here, I will use Visual Studio**
## Visual Studio Features:
1. Editor
2. Compiler
3. Interpreters, etc.

# Console Application.
1. A console application is an application that can be run in the command prompt.


# Basic Structure of C# Proram.

![Basic structure](https://dotnettutorials.net/wp-content/uploads/2022/07/word-image-27425-1.png)

The above process is shown below:

![structure C#](https://dotnettutorials.net/wp-content/uploads/2022/07/word-image-27425-2-1.png)

**Note:** C# is case sensetive and every statement in C# should end with a semicolon.

# Creating our first Console App on VS:

## Step 1
First, open Visual Studio 2022 (the latest version at this point in time) and then click on the **Create a New Project** option as shown in the below image.

![VS](https://dotnettutorials.net/wp-content/uploads/2022/07/creating-the-first-console-application-using-visua-1024x518.png)

## Step 2
The next step is to choose the project type as a Console Application.Here, I am selecting Console App (.NET Framework) using C# Language and then clicking on the Next button as shown in the below image.

![VS1](https://dotnettutorials.net/wp-content/uploads/2022/07/creating-first-console-application-using-visual-st-1024x611.png)

## Step 3
The next step is to configure the new project. Here, you also need to provide the .NET Framework version that you want to use in this application. The latest version of the .NET Framework is 4.8. So, I am selecting .NET Framework 4.8 and then clicking on the Create button as shown in the below image.

![VS2](https://dotnettutorials.net/wp-content/uploads/2022/07/creating-first-console-application-using-visual-st-1-1024x698.png)

Once you click on the **Create** button, the following project structure will be created

![VS3](https://dotnettutorials.net/wp-content/uploads/2022/07/word-image-27425-6-1.png)

The **solution name** will contain all necessary required files (Properties, Reference, App.Config files) to run the Console application.
The Main program **Program.cs** is the default code file that is creared when a new console application is created in VS, it contains the **Main Method** by default and that where the execution will start at. The **Program.cs** file will look like below:

![VS4](https://dotnettutorials.net/wp-content/uploads/2022/07/console-application-program-file.png)

## Step 4
In the **Main method** put the below code snippet:
```cs
            Console.WriteLine("Welcome to C#.NET");
            Console.ReadKey();
```

## Step 5
The next step is to run the .NET Application. To run any program in Visual Studio, you just need to click on the Start button or you can press **CTRL+F5** as shown in the below image.

![VS](https://dotnettutorials.net/wp-content/uploads/2022/07/word-image-27425-9-1.png)



# Let’s understand each of the above sections in detail.
## Importing Namespace Section:
This section contains importing statements that are used to import the BCL (Base Class Libraries) as well as user-defined namespaces if required.
Suppose you want to use some classes and interfaces in your code, then you have to include the namespace(s) from where these classes and interfaces are defined.
For example, if you are going to use the Console class in your code, then you have to include the System namespace as the Console class belongs to the System namespace.

**Syntax:** using NamespaceName;

**Example:** using System;

If the required namespace is a member of another namespace, we have to specify the parent and child namespaces separated by a dot as follows:

**using System.Data;**

**using System.IO;**

**Note: A namespace is a container that contains a group of related classes and interfaces, as well as, a namespace can also contain other namespaces.**

## Namespace Declaration Section:
Here a user-defined namespace is declared. In .NET applications, all classes and interfaces or any type related to the project should be declared inside some namespace. Generally, we put all the related classes under one namespace and in a project, we can create multiple namespaces.

**Syntax:** namespace NamespaceName {}

**Example:** namespace MyFirstProject {}

Generally, the namespace name will be the same as the project name but it is not mandatory, you can give any user-defined name to the namespace.


## Class Declaration Section:
When we create a Console Application using Visual Studio, by default, Visual Studio will Create the Start-Up class file with the name Program.cs which will have a class with the name Program that contains the Main method. A start-up class is nothing but a class that contains a Main() method from which the program execution is going to start.

**Syntax:**
```cs
	class ClassName
	{
	}
```

**Example:**
```cs
	class Program
	{
	}
```


## Main() Method Section:
The main() method is the entry point or starting point of the application to start its execution. When the application starts executing, the main method will be the first block of the application to be executed. The Main method contains the main logic of the application.


## What is using?
Using is a keyword. Using this keyword, we can refer to .NET BCL in C# Applications i.e. including the BCL namespaces as well as we can also include user-defined namespaces.



# Data Types in C#

## What is a Data Type in C#?
The Datatypes are something that gives information about

1. **Size** of the memory location.
2. The **Range of data** that can be stored inside that memory location.
3. Possible **Legal Operations** that can be performed on that memory location.
4. What **Types of Results** come out from an expression when these types are used inside that expression?

The keyword which gives all the above information is called the data type in C#.


## Diffrent types of data types in C#
A data type in C# specifies the type of data that a variable can store such as integer, floating, boolean, character, string, etc. The following diagram shows the different types of data types available in C#.

![VS5](https://dotnettutorials.net/wp-content/uploads/2022/07/data-types-in-c.jpeg)

There are 3 types of data types available in the C# language.

1. Value Data Types
2. Reference Data Types
3. Pointer Data Types


## Value Data Type in C#
The data type  which stores the value directly in the memory is called the Value Data Type in C#. The examples are int, char, boolean, and float which store numbers, alphabets, true/false, and floating-point numbers respectively. If you check the definition of these data types then you will see that the type of all these data types is going to be a struct. And struct is a value type in C#. The value data types in C# again classified into two types are as follows.

1. Predefined Data Types – Example includes Integer, Boolean, Boolean, Long, Double, Float, etc.
2. User-defined Data Types – Example includes Structure, Enumerations, etc


## How Data is Represented in a Computer?
**Before going and discussing how to use data types, first, we need to understand How data is represented on a computer? Let us understand this. Please have a look at the below diagram. See, on your computer’s hard disk, you have some data, let’s say A. The data can be in different formats, it can be an image, it can be an alphabet, it can be digits, it can be a PDF File, etc. Let us assume that you have some data called A. Now, we know the computer can only understand binary numbers i.e. 0’s and 1’s. So, the letter A is represented in the computer as 8 bits i.e. 01000001 (65 is the ASCII Value is A and hence the decimal number 65 is converted to its binary equivalent binary representation which is 01000001). So, the 0’s and 1’s are called bits. So, to store any data on the computer we need this 8-bit format. And this complete 8-bit is called a Byte. Now, as a dot net developer, it is very difficult for us to represent the data in binary format i.e. using 0s and 1s. So, here, in C# language we can use the decimal format. So, what we can do is, we will convert binary to decimal format, and internally the computer will map the decimal format to byte format (binary format), and then by using the byte we can represent the data. So, you can observe the byte representation of decimal number 65 is 01000001.**

![VS6](https://dotnettutorials.net/wp-content/uploads/2018/07/How-Data-is-Represented-in-a-Computer-768x634.jpg)

## What is a Byte Data Type in C#
