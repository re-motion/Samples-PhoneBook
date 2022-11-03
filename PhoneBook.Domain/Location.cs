using System.Collections.Generic;
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
  [MultiLingualResources ("PhoneBook.Domain.Globalization.Location")]
  public class Location : BindableDomainObject
  {
    [StringProperty(IsNullable = false, MaximumLength = 60)]
    public virtual string Street { get; set; }

    // On uncommenting, Location's table will have a "LocationNumber" instead a "Number" column
    // [DBColumn ("LocationNumber")] 
    [StringProperty(IsNullable = true, MaximumLength = 12)]
    public virtual string Number { get; set; }
    
    [StringProperty(MaximumLength = 60)]
    public virtual string City { get; set; }

    public virtual Country? Country { get; set; }
    public virtual int ZipCode { get; set; }

    public static Location NewObject()
    {
      return NewObject<Location> ();
    }

    public static Location NewObject (string street, string number, string city, Country country, int zip)
    {
      return NewObject<Location> (ParamList.Create(street, number, city, country, zip));
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
      return GetObject<Location> (objid);
    }

    public static IEnumerable<Location> GetLocations ()
    {
      var query = QueryFactory.CreateLinqQuery<Location> ();
               
      return query.ToArray ();
    }

    public IEnumerable<Person> FindPeople ()
    {
      var query = from p in QueryFactory.CreateLinqQuery<Person> ()
                  where p.Location == this
                  select p;
      return query.ToArray();
    }

    public void DeleteLocation ()
    {
      var people = FindPeople ();
      foreach (var person in people)
      {
        person.Location = null;
      }
      Delete ();
      ClientTransaction.Current.Commit ();
    }

    public override string DisplayName
    {
      get
      {
        var country = Country == null ? string.Empty : string.Concat(" (", EnumDescription.GetDescription(Country), ")");
        return Street + country;
      }
    }
  }
}
