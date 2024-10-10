# What is LINQ?
The LINQ (**Language Integrated Query**) is a part of a language but not a complete language. It was introduced by Microsoft with .NET Framework 3.5 and C# 3.0 and is available in System.Linq 
namespace.

LINQ provides us with common query syntax which allows us to query the data from various data sources. That means using a single query we can get or set the data from various data sources such as 
SQL Server database, XML documents, ADO.NET Datasets, and any other in-memory objects such as Collections, Generics, etc.

![image linq](https://dotnettutorials.net/wp-content/uploads/2019/04/Linq-applying-on-different-data-sources.png)

## Why use LINQ?
So, LINQ provides a **uniform programming model which will make it easy to work with different data sources by using a standard coding style. That means we don't require different syntaxes to 
query different data sources.

Below we can see that you can write the LINQ quiries using any .NET-supported programming languages such as C#, VB.NET, J#, F#, etc.
![structure](https://dotnettutorials.net/wp-content/uploads/2019/04/Why-should-we-use-linq-in-C.png)


## What are LINQ Providers?
A LINQ provider is a software that implements the IQueryProvider and IQueryable interface for a particular data source. In other words, it allows us to write LINQ queries against that data source. 
Without LINQ Provider we cannot execute our LINQ Queries.

**Let us discuss some of the LINQ Providers and how they work internally.**

### LINQ to Objects:
The LINQ to Objects provider allows us to query an in-memory object such as an array, collection, and generics types. It provides many built-in functions that we can use to perform many useful 
operations such as filtering, ordering, and grouping with minimum code.

### LINQ to SQL (DLINQ):
The LINQ to SQL Provider is designed to work with only the SQL Server database. You can consider this as an object-relational mapping (ORM) framework which allows one-to-one mapping between the 
SQL Server database and related .NET Classes. These .NET classes are going to be created automatically by the wizard based on the database table.

### LINQ to Datasets:
The LINQ to Datasets provider provides us the flexibility to query data cached in a Dataset in an easy and faster way. It also allows us to do further data manipulation operations such as 
searching, filtering, sorting, etc. on the Dataset using the LINQ Syntax.

### LINQ to Entities:
The LINQ to Entities provider looks like LINQ to SQL. It means it is also an object-relational mapping (ORM) framework that allows one-to-one, one-to-many, and many-to-many mapping between the 
database tables and .NET Classes. The point that you need to remember is that it is used to query any database such as SQL Server, Oracle, MySQL, DB2, etc. Now, it is called ADO.NET Entity 
Framework.

### LINQ to XML (XLINQ):
The LINQ to XML provider is basically designed to work with an XML document. So, it allows us to perform different operations on XML data sources such as querying or reading, manipulating, 
modifying, and saving the changes to XML documents. The System.Xml.Linq namespace contains the required classes for LINQ to XML.

### Parallel LINQ (PLINQ):
The Parallel LINQ or PLINQ was introduced with .NET Framework 4.0. This provider provides the flexibility of parallel implementation of LINQ to Objects. The PLINQ was designed in such a way 
that it uses the power of parallel programming which targets the Task Parallel Library. So if you want to execute your LINQ query simultaneously or parallel on different processors then you 
need to write the query using PLINQ.


## What are the different things required to write a LINQ Query?
In order to write a LINQ query, we need the following three things

1. Data Source (in-memory objects, SQL, XML)
2. Query
3. Execution of the query


## What is a Query?
A query is a set of instructions that are applied to a data source (i.e. in-memory objects, SQL, XML, etc.) to perform certain operations (i.e. CRUD operations) and then tells the shape of the 
output from that query.

**Each query is a combination of three things. They are as follows:**

1. Initialization (to work with a particular data source)
2. Condition (where, filter, sorting condition)
3. Selection (single selection, group selection, or joining)

What are the different ways to write a LINQ query?

We can write the LINQ query in three different ways. They are as follows

1. Query Syntax
2. Method Syntax
3. Mixed Syntax (Query + Method)

*Note:* From the performance point of view there is no difference between the above three approaches. So, which you need to use, it totally depends on your personal preference. 
But the point that you need to keep in mind is, behind the scene, the LINQ queries written using query syntax are translated into their lambda expressions before they are compiled. Thus I will 
focus more only on **Method Query**

## LINQ Method Syntax:
Method syntax becomes most popular now a day to writing LINQ queries. It uses a lambda expression to define the condition for the query. Method syntaxes are easy to write simple queries to 
perform read-write operations on a particular data source. But for complex queries Method syntaxes are a little hard to write as compared to query syntax.

In this approach, the LINQ query is written by using multiple methods by combining them with a dot (.). The Syntax is given below:

![Method Syntax](https://dotnettutorials.net/wp-content/uploads/2019/04/c-users-pranaya-pictures-linq-method-syntax-png.png)


*Example:* We have an integer list and we need to write a LINQ query that will return all the integers which are greater than 5.

```
using System;
using System.Collections.Generic;
using System.Linq;
namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data Source
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            //LINQ Query using Method Syntax
            var MethodSyntax = integerList.Where(obj => obj > 5).ToList();
            //Execution
            foreach(var item in MethodSyntax)
            {
                Console.Write(item + " ");
            }
            
            Console.ReadKey();
        }
    }
}
```
Let us have a look at the following diagram to understand Method Syntax.

![Method Syntax Diagram](https://dotnettutorials.net/wp-content/uploads/2019/04/c-users-pranaya-pictures-method-syntax-png.png)














## Side LINQ Notes
A query expression in C# is, as you probably know, just a syntactic sugar for a bunch of method calls. For example,

```csharp
	from customer in customers
	where customer.City == "London"
	select customer.LastName
```

is a syntactic sugar for:

```csharp
	customers.
  		Where(customer => customer.City == "London").
  		Select(customer => customer.LastName)
```

A great many queries are straightforward variations on this pattern: **the query is translated into a series of method calls where the arguments are lambdas formed from the range variables and expressions in the query**. However, some of them are weird. This one is straightforward:

```csharp
	from parent in parents
	from child in parent.Children
	select child.LastName
```

The meaning here is **“take the sequence of parents, map each parent onto a sequence of children, concatenate all those sequences, and then project from the concatenation the sequence of last names”**. That’s equivalent to this method call:

```csharp
	parents.SelectMany(
  		parent => parent.Children, 
  		(parent, child) => child.LastName)
```

The first lambda maps each element of the original sequence onto a new sequence. The second lambda takes each element of the new sequence and the element from which it was created, and does the projection. Note that parent is in scope in the final **select** clause; we’re not using that fact here, but it is important.

Now let’s make a small variation, and we’ll see that things get very not-straightforward very quickly:

```csharp
	from parent in parents
	from child in parent.Children
	where child.Height > parent.Height
	select child.LastName
```
Query translation is a multi-step process where each step along the way turns some of the query elements into method calls and lambdas. Since progress is always made towards the goal of eliminating the query altogether, and there is never any ambiguity about what rule to apply next, we know that we can just keep on applying rules until we’re done. The C# specification says that the first step of the translation from this query into method calls is to translate it into this query:

```csharp
	from * in parents.
  		SelectMany(
    			parent => parent.Children, 
    			(parent, child) => new { parent, child })
	where child.Height > parent.Height
	select child.LastName
```
And the second step is to translate that into:

```csharp
	from * in parents.
  		SelectMany(
    			parent => parent.Children, 
    			(parent, child) => new { parent, child }).
  		Where(* => child.Height > parent.Height)
	select child.LastName
```
And the third step is to translate that into:

```csharp
	parents.
  		SelectMany(
    			parent => parent.Children, 
    			(parent, child) => new { parent, child }).
  		Where(* => child.Height > parent.Height).
  	Select(* => child.LastName)
```
Um. That’s not C#.

What on earth are those stars doing in there?

For the most part the query syntax can be transformed syntactically into the method call syntax, but in this query that breaks down. The * is a transparent identifier” and it means:

- I am a lambda formal parameter of anonymous type
- Members of my type are in scope in the body of the lambda
- If any of my members are themselves transparent identifiers, their members are in scope too, and so on, to any level of nesting

**(Recall once again as we have discussed many times on this blog, the scope of a particular programming language element is defined as the region of program text in which it may be referred to by its unqualified name. Scope is entirely about figuring out the meaning of names in C#.)**

In other words, the star means that there is one more stage of translation to go through, and it’s a semantic, not a syntactic transformation because we must understand the meanings of the identifiers in the lambda bodies. The final transformation is:

```csharp
	parents.
  		SelectMany(
    			parent => parent.Children, 
    			(parent, child) => new { parent, child }). 
  // We've selected a sequence where elements have anonymous type,
  // so "dummy" is of anonymous type in both lambdas:
  		Where(dummy => dummy.child.Height > dummy.parent.Height).
  		Select(dummy => dummy.child.LastName)
```
Think about what is going on here. The select-many query is essentially concatenating together many sequences of pairs of parents and children, and then running the remainder of the query on those pairs. Clearly this works but it seems absurdly complicated. Were the language designers crazy when this was added to the specification? Why is there this absolutely bizarre new scoping rule being introduced?

They were not crazy; there is a good reason for this. Let’s deduce what it is by first attempting to do things the naive way, and we’ll see what goes wrong.

We will start over and design a new query translation rule set and LINQ-to-objects implementation from scratch. We need to translate the query shown above somehow such that the following is true of the translated form:

- **parent** is in scope starting at the second **from** and continuing until the end of the query.
- **child** in in scope starting at the **where** and continuing until the end of the query.
- the semantics of a nested **from** query are: take a sequence, map each element to a new sequence, and concatenate all the resulting sequences.

This seems easily done with a very straightforward rule. Let’s suppose we have these very simple methods: (Error handling is removed for clarity.)

```csharp
public static IEnumerable<R> Select<A, R>(
  this IEnumerable<A> items, 
  Func<A, R> projection)
{
  foreach(A item in items)
    yield return projection(item);
}

public static IEnumerable<R> SelectMany<A, R>(
  this IEnumerable<A> items, 
  Func<A, IEnumerable<R>> map)
{
  foreach(A outerItem in items)
    foreach(R innerItem in map(outerItem))
      yield return innerItem;
}

public static IEnumerable<A> Where<A>(
  this IEnumerable<A> items, 
  Func<A, bool> predicate)
{
  foreach(A item in items)
    if (predicate(item)) 
      yield return item;
}
```
Very straightforward. Let’s now state the following translation rules:

### The Where Rule:

```csharp 
	from x in y 
	where z 
	... 
```

is translated to
```csharp
	from x in (y).Where(x => z)
	... 
```

### The Select rule:

```csharp
	from x in y 
	select z
```

is translated to
```csharp
	(y).Select(x => z)
```
(We’ll ignore optimizing away degenerate queries.)

### The Select Many rule:
```csharp
	from x in y 
	from q in r 
	...
```

is translated to
```csharp
	(y).SelectMany(x => from q in r ...)
```

These seem like reasonable rules. Let’s try them on our example:
```csharp
	from parent in parents
	from child in parent.Children
	where child.Height > parent.Height
	select child.LastName
```

We first apply the **SelectMany** rule to obtain:
```csharp
	(parents).
  		SelectMany( 
    			parent => 
      				from child in parent.Children
      				where child.Height > parent.Height
      				select child.LastName )
```

Seems reasonable. Now we apply the Where rule to that:
```csharp
	(parents).
  		SelectMany( 
    			parent => 
      				from child in (parent.Children).
        				Where(child => child.Height > parent.Height)
      				select child.LastName)
```

Then we apply the Select rule to that:
```csharp
	(parents).
  		SelectMany( 
    			parent => 
      				((parent.Children).
        				Where(child => child.Height > parent.Height)).
        				Select(child => child.LastName));
```

This looks great! If you actually compiled the methods, you’d end up with an expression that takes a sequence of parents and returns a sequence of last names, which is just what we want. **Why on earth then does the C# spec not do this very simple thing, instead of the crazy complicated nonsense where SelectMany takes multiple lambdas and introduces a “transparent identifier”**? I normally push back on “why not?” questions, but this one seems justified; there must be something wrong with the naive approach that prevented the C# design team from going for it, causing them to introduce a far more complicated mechanism. What could that reason be?
