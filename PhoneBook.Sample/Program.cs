using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBook.Domain;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Infrastructure;

namespace PhoneBook.Sample
{
  partial class Program
  {
    static void EnterFreud ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Berggasse";
        loc.Number = "19";
        loc.City = "Vienna";
        loc.Country = Country.Austria;
        loc.ZipCode = 1090;

        var person = Person.NewObject ();
        person.FirstName = "Sigmund";
        person.Surname = "Freud";
        person.Location = loc;

        var pn = PhoneNumber.NewObject ();
        pn.CountryCode = "0043";
        pn.AreaCode = "1";
        pn.Number = "3191596";

        person.PhoneNumbers.Add (pn);

      }
    }

    static void EnterHabsburgs ()
    {
      using (ClientTransaction.CreateRootTransaction ()
                              .EnterDiscardingScope ())
      {
        Location loc = Location.NewObject ();
        loc.Street = "Schönbrunner Schloßstraße";
        loc.Number = "1";
        loc.City = "Vienna";
        loc.ZipCode = 1130;
        loc.Country = Country.Austria;

        Person theEmperor = Person.NewObject ();
        theEmperor.FirstName = "Franz-Josef";
        theEmperor.Surname = "Habsburg";
        theEmperor.Location = loc;

        PhoneNumber phone = PhoneNumber.NewObject ();
        phone.CountryCode = "43";
        phone.AreaCode = "1";
        phone.Number = "555-0001";

        theEmperor.PhoneNumbers.Add (phone);

        Person theEmpress = Person.NewObject ();
        theEmpress.FirstName = "Sisi";
        theEmpress.Surname = "Eugenie";
        theEmpress.Location = loc;

        phone = PhoneNumber.NewObject ();
        phone.CountryCode = "43";
        phone.AreaCode = "1";
        phone.Number = "555-0002";

        theEmpress.PhoneNumbers.Add (phone);

        // the empress has two phones -- one for 
        // the left ear, one for the right
        phone = PhoneNumber.NewObject ();
        phone.CountryCode = "43";
        phone.AreaCode = "676";
        phone.Number = "555-0003";

        theEmpress.PhoneNumbers.Add (phone);

        ClientTransaction.Current.Commit ();
      }
    } 


    static void Report (Location[] locations)
    {
      int iter = 0;
      foreach (Location loc in locations)
      {
        Console.WriteLine ("{0} {1}", iter, loc.Street);
        iter++;
      }
    }

    static void ReportWrap ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        Report (Location.GetLocations ());
      }
    }

    static void RunInputMask ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        bool goOn = true;
        while (goOn)
        {
          var locations = Location.GetLocations ();
          Report (locations);

          var cmdLine = Console.ReadLine ();
          cmdLine.Trim ();
          if (!String.IsNullOrEmpty (cmdLine))
          {
            switch (cmdLine[0])
            {
              case 'd':
              case 'D':
                try
                {
                  var item = int.Parse (cmdLine.Substring (1));
                  locations[item].DeleteMakeHomeless ();
                }
                catch (FormatException)
                {
                  Console.WriteLine ("Can't parse integer: {0}", cmdLine);
                }

                break;
              case 'q':
              case 'Q':
                goOn = false;
                break;
            }
          }

        }
      }
    }

    static void DeleteFirstPhoneNumberOfFirstPerson ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        Person.GetPersons()[0].PhoneNumbers[0].Delete();
        ClientTransaction.Current.Commit ();
      }
    }

    static void DeleteLastPerson ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var persons = Person.GetPersons ();
        persons[persons.Length - 1].Delete ();
        ClientTransaction.Current.Commit ();
      }
    }

    static void DeleteDesireeDeletee ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        Person.GetFirstPersonByFirstName ("Desiree").Delete ();
        ClientTransaction.Current.Commit ();
      }
    }

    static void ReportAll ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        foreach (var location in Location.GetLocations ())
        {
          Console.WriteLine (location.DisplayName);
          foreach (var person in location.FindPersons ())
          {
            if (person.FirstName != null)
            {
              Console.WriteLine ("  {0}", person.DisplayName);
            }
            else
            {
              Console.WriteLine (person.Surname);
            }

            foreach (var phoneNumber in person.PhoneNumbers)
            {
              Console.WriteLine ("    {0}", phoneNumber.DisplayName);
            }
          }
        }
      }
      Console.ReadLine ();
    }

    static void FreudsFirstNameDemo ()
    {
      using (ClientTransaction.CreateRootTransaction().EnterDiscardingScope())
      {
        var person = Person.NewObject();
        person.FirstName = "Anna";
        person.Surname = "Freud";

        // This is the sub-transaction, with the root-TX
        // created above as its parent transaction
        using (ClientTransaction.Current.CreateSubTransaction().EnterDiscardingScope())
        {
          // At this time, it's still "Anna"
          Console.WriteLine (person.FirstName);
          // Now it is "Stacey", but we havn't committed
          // anything yet
          person.FirstName = "Stacey";
          Console.WriteLine (person.FirstName);
          // At this time we have "Stacey" in the sub-TX
          // but since we don't commit anything to the
          // parent transaction, "Stacey" is put to digital
          // nirvana together with the sub-TX.
        }

        // At this point, in the parent transaction, we 
        // still have "Anna". So we commit "Anna".
        Console.WriteLine (person.FirstName);
        ClientTransaction.Current.Commit ();

      }

      // No the same again, this time with a commit
      // in the sub-tx. We will create a Martha Freud.
      using (ClientTransaction.CreateRootTransaction().EnterDiscardingScope())
      {
        var person = Person.NewObject ();
        person.FirstName = "Martha";
        person.Surname = "Freud";

        // This is the sub-transaction, with the root-TX
        // created above as its parent transaction
        using (ClientTransaction.Current.CreateSubTransaction ().EnterDiscardingScope ())
        {
          // At this time, it's still "Martha"
          Console.WriteLine (person.FirstName);
          // Now it is "Stacey", but we havn't committed
          // anything yet
          person.FirstName = "Stacey";
          Console.WriteLine (person.FirstName);
          // NOW we commit "Stacey" to the parent transaction.
          ClientTransaction.Current.Commit ();
        }
        // In contrast to the previous transaction/subtransaction
        // sample, we DO have "Stacey" in the parent tx.
        Console.WriteLine (person.FirstName);
        // This root tx is now committed.
        ClientTransaction.Current.Commit ();
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

      QueryManFindPersonsByLocationsSample ();
      Console.WriteLine ("Reporting all locations, and who lives there:");

    }

    static void Main (string[] args)
    {
      // ReportAll ();
      // DeleteFirstPhoneNumberOfFirstPerson ();
      // DeleteLastPerson ();
      // DeleteDesireeDeletee ();
      QueryManMain (args);
      Console.ReadLine ();
    }
  }
}
