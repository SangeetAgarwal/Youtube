using Microsoft.VisualBasic;

namespace LinqDotNet9;

public record Person(string FirstName, string LastName, int Age);
class Program
{
  public static void Main()
  {
    var people = new List<Person>
    {
      new("John", "Doe", 30),
      new("Jane", "Doe", 40),
      new("John", "Smith", 45),
      new("Jane", "Smith", 72)
    };

    // GroupBy, existed in previous versions of .NET
    var peopleGroupedByAge = people.GroupBy(p => p.Age > 40);
    foreach (var group in peopleGroupedByAge)
    {
      Console.WriteLine($"People with age > 40: {group.Count()}");
    }

    // CountBy, new to.NET 9
    var peopleCountByAge = people.CountBy(p => p.Age > 40);
    foreach (var (key, value) in peopleCountByAge)
    {
      Console.WriteLine($"People with age > 40: {value}");
    }

    // AggregateBy
    var aggregateByAge = people.AggregateBy(p => p.FirstName, 0, (acc, p) => acc + p.Age);
    foreach (var (key, value) in aggregateByAge)
    {
      Console.WriteLine($"The total age of all people with first name {key} is {value}");
    }

    // Index
    var peopleWithIndex = people.Index();
    foreach (var (index, person) in peopleWithIndex)
    {
      Console.WriteLine($"Person at index {index} is {person.FirstName} {person.LastName}");
    }
  }
}
