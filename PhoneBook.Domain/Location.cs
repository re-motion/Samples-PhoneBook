using System.Linq;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Globalization;
using Remotion.Reflection;
using Remotion.Utilities;

namespace PhoneBook.Domain
{
  [DBTable]
  [MultiLingualResources ("PhoneBook.Domain.Globalization.PhoneNumber")]
  public class Location : BindableDomainObject
  {
    [StringProperty(IsNullable = false, MaximumLength = 60)]
    public virtual string Street { get; set; }

    // On uncommenting, Location's table will have a "LocationNumber" instead a "Number" column
    // [DBColumn ("LocationNumber")] 
    [StringProperty(IsNullable = true, MaximumLength = 12)]
    public virtual string Number { get; set; }

    public virtual Country? Country { get; set; }

    [StringProperty(MaximumLength = 60)]
    public virtual string City { get; set; }

    public virtual int ZipCode { get; set; }

    public static Location NewObject()
    {
      return DomainObject.NewObject<Location>();
    }

    public static Location NewObject (string street, string number, string city, Country country, int zip)
    {
      return DomainObject.NewObject<Location> (ParamList.Create(street, number, city, country, zip));
    }

    protected Location ()
    {
    }

    protected Location (string street, string number, string city, Country country, int zip)
    {
      Street = street;
      Number = number;
      City = city;
      Country = country;
      ZipCode = zip;
    }

    public static Location GetObject(ObjectID objid)
    {
      return DomainObject.GetObject<Location>(objid);
    }

    public static Location[] GetLocations ()
    {
      var query = QueryFactory.CreateLinqQuery<Location> ();
               
      return query.ToArray ();
    }

    public Person[] FindPersons ()
    {
      var query = from p in QueryFactory.CreateLinqQuery<Person> ()
                  where p.Location == this
                  select p;
      return query.ToArray ();
    }

    public void DeleteLocation ()
    {
      var persons = FindPersons ();
      foreach (var p in persons)
      {
        p.Location = null;
      }
      Delete ();
      ClientTransaction.Current.Commit ();
    }

    public override string DisplayName
    {
      get
      {
        string country = Country == null ? string.Empty : " (" + EnumDescription.GetDescription(Country) + ")";
        return Street + country;
      }
    }
  }
}
