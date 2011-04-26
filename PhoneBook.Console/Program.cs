using System.Linq;
using PhoneBook.Domain;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;

namespace PhoneBook.Console
{
  class Program
  {
    public static Person[] GetPersons ()
    {
      var query = from p in QueryFactory.CreateLinqQuery<Person> ()
                  select p;
      return query.ToArray ();
    }

    static void AddSampleData ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Microsoft Way";
        loc.Number = "4";
        loc.City = "Redmond";
        loc.Country = Country.USA;
        loc.ZipCode = 1110;

        var p1 = Person.NewObject ();
        p1.FirstName = "Steve";
        p1.LastName = "Ballmer";
        p1.Location = loc;

        var pn1 = PhoneNumber.NewObject ();
        pn1.CountryCode = "001";
        pn1.AreaCode = "425";
        pn1.Number = "705-1900";
        pn1.Person = p1;

        var p2 = Person.NewObject ();
        p2.FirstName = "Scott";
        p2.LastName = "Guthrie";
        p2.Location = loc;

        var pn2 = PhoneNumber.NewObject ();
        pn2.CountryCode = "001";
        pn2.AreaCode = "425";
        pn2.Number = "705-1901";
        pn2.Person = p2;

        // using parametrized constructors
        var locApple = Location.NewObject("Apple Way", "42", "Cupertino", Country.USA, 000);
        var personApple = Person.NewObject("Steve", "Jobs", locApple);
        var phoneApple = PhoneNumber.NewObject("001", "93", "123-4567", "666",personApple);

        ClientTransaction.Current.Commit ();
      }     
    }

    static void Main (string[] args)
    {
      // AddSampleData ();
      // LinqShowCase();
      System.Console.WriteLine (@"Hit any key to continue");
      System.Console.ReadKey();
    }

    private static void LinqShowCase()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var Persons = GetPersons ();
      }
    }
  }
}
