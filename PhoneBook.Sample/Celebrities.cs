using Remotion.Data.DomainObjects;
using PhoneBook.Domain;

namespace PhoneBook.Sample
{
  partial class Program
  {
    static void EnterBenita ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Brahmsplatz";
        loc.Number = "4";
        loc.City = "Vienna";
        loc.Country = Country.Austria;
        loc.ZipCode = 1040;

        var p = Person.NewObject ();
        p.FirstName = "Benita";
        p.Surname = "Ferrero-Waldner";
        p.Location = loc;

        var pn = PhoneNumber.NewObject ();
        pn.CountryCode = "0043";
        pn.AreaCode = "664";
        pn.Number = "13";

        pn.Person = p;

        ClientTransaction.Current.Commit ();
      }
    }

    static void EnterMausi ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Gablenzgasse";
        loc.Number = "5 - 13";
        loc.City = "Vienna";
        loc.Country = Country.Austria;
        loc.ZipCode = 1150;

        var p = Person.NewObject ();
        p.FirstName = "Mausi";
        p.Surname = "Lugner";
        p.Location = loc;

        var pn = PhoneNumber.NewObject ();
        pn.CountryCode = "0043";
        pn.AreaCode = "676";
        pn.Number = "888-7777";

        pn.Person = p;

        ClientTransaction.Current.Commit ();
      }
    }

    static void EnterJeannine ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Hietzinger Hauptstraße";
        loc.Number = "133";
        loc.City = "Vienna";
        loc.Country = Country.Austria;
        loc.ZipCode = 1130;

        var p = Person.NewObject ();
        p.FirstName = "Jeannine";
        p.Surname = "Schiller";
        p.Location = loc;

        var pn = PhoneNumber.NewObject ();
        pn.CountryCode = "0043";
        pn.AreaCode = "650";
        pn.Number = "555-6729";

        pn.Person = p;

        ClientTransaction.Current.Commit ();
      }
    }

    static void EnterElvisAndOsama ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Hasenleitengasse";
        loc.Number = "4";
        loc.City = "Vienna";
        loc.Country = Country.Austria;
        loc.ZipCode = 1110;

        var p1 = Person.NewObject ();
        p1.FirstName = "Elvis";
        p1.Surname = "Presley";
        p1.Location = loc;

        var pn1 = PhoneNumber.NewObject ();
        pn1.CountryCode = "0043";
        pn1.AreaCode = "1";
        pn1.Number = "555-4780";
        pn1.Person = p1;

        var p2 = Person.NewObject ();
        p2.FirstName = "Osama";
        p2.Surname = "bin Laden";
        p2.Location = loc;

        var pn2 = PhoneNumber.NewObject ();
        pn2.CountryCode = "0043";
        pn2.AreaCode = "1";
        pn2.Number = "555-4781";
        pn2.Person = p2;

        ClientTransaction.Current.Commit ();
      }
    }

    static void EnterGünter ()
    {
      using (ClientTransaction.CreateRootTransaction ().EnterDiscardingScope ())
      {
        var loc = Location.NewObject ();
        loc.Street = "Aspangstr";
        loc.Number = "53";
        loc.City = "Vienna";
        loc.Country = Country.Austria;

        var p = Person.NewObject ();
        p.FirstName = "Günther";
        p.Surname = "Tolar";
        p.Location = loc;

        var pn = PhoneNumber.NewObject ();
        pn.CountryCode = "0043";
        pn.AreaCode = "0664";
        pn.Number = "101 6666";

        pn.Person = p;

        ClientTransaction.Current.Commit ();
      }
    }

    static void EnterProminente ()
    {
      EnterBenita ();
      EnterGünter ();
      EnterJeannine ();
      EnterMausi ();
      EnterElvisAndOsama ();
    }
  }
}