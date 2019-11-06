# C# Infos and Exercises
by Pascal Schmiedjell

## Constructors
```csharp
// static constructor- initializes static fields before object is created
static Test() {}

// calls another constructor overload of same class
public Test() : this() {}

// calls constructor of superclass, should be done in every child class
public Test() : base() {}

// destructor, called before object is garbagecollected
~Test() {}
```

## Properties
```csharp
// 1, can also be static
private string test;
public string Test
{
    set
    {
        test = value;
    }
    get
    {
        return test;
    }
}

// 2
public string Test { set; get; }
```

## Inheritance
```csharp
public class Test : TestSuper {}

public abstract class TestAb {}

public interface TestInt<T> {}
```

 * **virtual** - can be overwritten
 * **abstract** - must be overwritten
 * **sealed** class/method - same as **final** in Java
 
## Linq
```csharp
var sol = from a in coll
          group a by a.Something into x
          where a.Something
          orderby a.Something
          select new { a.Something, a.Something1 };
		  
// ORDERBY
foreach (var nameGroup in queryLastNames)
{
    Console.WriteLine($"Key: {nameGroup.Key}");
    foreach (var student in nameGroup)
    {
        Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
    }
}

foreach (IGrouping<char, Student> studentGroup in studentQuery2)
{
    Console.WriteLine(studentGroup.Key);
    // Explicit type for student could also be used here
    foreach (var student in studentGroup)
    {
        Console.WriteLine($"{student.Last}, {student.First}");
    }
}
```

## XML
```csharp
var sol = 
 new XElement("Publishers",
  from p in SampleData.Publishers
  select new XElement("Publisher",
   new XAttribute("Name", p.Name), 
    from r in SampleData.Reviews
    where r.Movie.Publisher == p
    orderby r.Movie.Title
    select new XElement("Review",
     new XAttribute("Title", r.Movie.Title),
     new XAttribute("Review", r.Comments),
     new XAttribute("Rating", r.Rating))));

// load files
var xlin = XElement.Load(@"..\..\something.xml");

var sol = from e in xlin.XPathSelectElements("//Kunden")
          orderby e.Attribute("Country").Value
          select new { Country = e.Attribute("Country").Value,
                       Company = e.Attribute("Company").Value };

// XPath querying
var sol = from e in xlin.Descendants("Name")
          select new { Ename = e.Name.ToString(), e.Value };
```

## XPath
```xml
Select the document node
/

Select the 'root' element
/root

Select all 'member' elements that are direct children of the 'bands' element.
/root/bands/member

Select all 'member' elements that are descendants of 'root' element.
/root//member

Select all 'member' elements regardless of their positions in the document.
//member

Select the 'id' attributes of the 'member' elements regardless of their positions in the document.
//member/@id

Select all 'member' elements which include an 'id' element
//member[id]

Select first 'actor' element.
//actor[1]

Select the textual value of first 'actor' element.
//actor[1]/text()

Select the last 'actor' element.
//actor[last()]

Select the first and second 'actor' elements using their position.
//actor[position() < 3]

Select all 'actor' elements that have an 'id' attribute.
//actor[@id]

Select the 'actor' element with the 'id' attribute value of '3'.
//actor[@id='3']

Select all 'actor' nodes with the 'id' attribute value lower or equal to '3'.
//actor[@id<=3]

Select all 'actor' elements with the element 'movie' where the content is 'something'.
//actor[movie = "something"]

Select all 'price' elements with text content < 150.
//price[text() < 150]

Select all the children of the 'singers' node.
/root/singers/*

Select all the elements in the document.
//*

Select all the 'actor' elements AND the 'singer' elements.
//actor|//singer

Select the name of the first element in the document.
name(//*[1])

Select the numeric value of the 'id' attribute of the first 'actor' element.
number(//actor[1]/@id)

Select the string representation value of the 'id' attribute of the first 'actor' element.
string(//actor[1]/@id)

Select the length of the first 'actor' element's textual value.
string-length(//actor[1]/text())

Select the local name of the first 'singer' element, i.e. without the namespace.
local-name(//singer[1])

Select the number of 'singer' elements.
count(//singer)

Select the sum of the 'id' attributes of the 'singer' elements.
sum(//singer/@id)
```

## Sorting
```csharp
// with a method
public int Compare(Student x, Student y)
{
    if(x == null) return y == null ? 0 : 1;
    return x.Name.Length.CompareTo(y?.Name.Length);
}

// with IComparable
list.Sort();

public class Student : IComparable(Student) {}

public int CompareTo(Student st)
{
    return (this.Name.CompareTo(st?.Name));
}

// with IComparer
list.Sort(new MyComparer);

public class MyComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if(x == null) return y == null ? 0 : 1;
        return x.Name.Length.CompareTo(y?.Name.Length);
    }
}

// with Comparison
static int CompareLength(string a, string b)
{
    // return result of CompareTo with length
    return a.Length.CompareTo(b.Length);
}

Comparison<string> comparison = new Comparison<string>(CompareLength);
Array.Sort(array, comparison);
//or
list.Sort((x, y) => x.Name.Length.CompareTo(y?.Name.Length));
```

## Own Collection
```csharp
class MyColl<T> : List<T> where T:Student
{
    public void StudentList()
    {
        foreach (var item in this)
        {
            Console.Write($"{item} is called {item.Name}");
        }
    }
}
```

## Collection performance
Collection | Ordering | Contiguous Storage | Direct Access | Lookup Efficiency | Notes
------------ | ------------- | ------------- | ------------- | ------------- | -------------
Dictionary | Unordered | Yes | Via Key | Key: O(1); Value: O(n) | Best for high performance lookups
List | User controls | Yes | Via Index | Index: O(1); Value: O(n); Bsearch: O(log n) | Best for smaller lists where direct access required and no sorting
LinkedList | User controls | No | No | Value: O(1) | Best for lists where inserting/deleting in middle is common and no direct access required

## String output
`"{" n ["," width] [":" format [precision]] "}"`
 * *width* - field width (exceeded if too small)
   * positive = right-aligned
   * negative = left-aligned
 * *format* - formatting code
   * `d, D` - integer number with leading zeroes
     * precision = number of digits
	 * xxxxx
   * `f, F` - fixed-point format
     * precision = number of fractional digits (default = 2)
	 * xxxxx.xx
   * `n, N` - number format (with separator for thousands)
     * precision = number of fractional digits (default = 2)
	 * xx,xxx.xx
   * `e, E` - floating-point format
     * precision = number of fractional digits
	 * x.xxxE+xxx
   * `c, C` - currency format
     * precision = number of fractional digits (default = 2)
	 * negative values are enclosed in brackets
	 * $xx,xxx.xx
   * `x, X` - hexadecimal format
     * precision = number of hex digits (maybe leading 0)
	 * xxx
   * `g, G` - general (most compact format for the given value; default)
* *precision* - number of fractional digits (sometimes number of digits)

## Integer Overflow check
```csharp
x = checked(x * x); // OverflowException
checked
{
	...
	x = x * x; // OverflowException
	...
}
```

## Indexer
Allows positional access to object
```csharp
public string this[int index] { set; get; }
```