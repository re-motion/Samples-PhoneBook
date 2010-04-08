using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBook.Domain;
using Remotion.Data.DomainObjects;

namespace PhoneBook.Sample
{
  public partial class Program
  {
    public static void DeleteFirstPhoneNumberOfFirstPerson ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        Person.GetPersons ()[0].PhoneNumbers[0].Delete ();
        ClientTransaction.Current.Commit ();
      }
    }

    public static void DeleteLastPerson ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var persons = Person.GetPersons ();
        persons[persons.Length - 1].Delete ();
        ClientTransaction.Current.Commit ();
      }
    }

    public static void DeleteDesireeDeletee ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        Person.GetFirstPersonByFirstName ("Desiree").Delete ();
        ClientTransaction.Current.Commit ();
      }
    }
  }
}
