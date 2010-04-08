using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBook.Domain;
using Remotion.Data.DomainObjects;

namespace PhoneBook.Sample
{
  partial class Program
  {
    static void QueryManGetLocationsSample ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        foreach (var loc in Location.QueryManGetLocations ())
        {
          Console.WriteLine ("{0} {1} {2}", loc.Street, loc.Number, loc.City);
        }
      }
    }

    static void QueryManFindLocationsByCountrySample ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        foreach (var loc in Location.QueryManFindLocationsByCountry (Country.Austria))
        {
          Console.WriteLine ("{0} {1} {2}", loc.Street, loc.Number, loc.City);
        }
      }
    }

    static void QueryManFindPersonsByLocationsSample ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        foreach (var loc in Location.QueryManGetLocations ())
        {
          Console.WriteLine ("Location: {0} {1}, {2}", loc.Street, loc.Number, loc.City);
          foreach (var person in Person.QueryManFindPersonsByLocation (loc))
          {
            Console.WriteLine ("  Person: {0} {1}", person.FirstName, person.Surname);
          }
        }
      }
    }

    static void QueryManMain (string[] args)
    {
      Console.WriteLine ("All locations:");
      QueryManGetLocationsSample ();
      Console.WriteLine ();

      Console.WriteLine ("All Austrian locations:");
      QueryManFindLocationsByCountrySample ();
      Console.WriteLine ();

      Console.WriteLine ("Reporting all locations, and who lives there:");
      QueryManFindPersonsByLocationsSample ();
    }
  }
}
