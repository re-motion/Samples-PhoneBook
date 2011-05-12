using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.Data.DomainObjects.Queries.Configuration;
using Remotion.Globalization;
using Remotion.Utilities;

namespace PhoneBook.Domain
{
  [DBTable]
  [MultiLingualResources("PhoneBook.Domain.Globalization.Location")]
  public partial class Location : BindableDomainObject
  {
    [StringProperty(MaximumLength=60, IsNullable=false)]
    public virtual string Street { get; set; }

    // Location's table will have a "LocationNumber" instead a "Number" column
    // [DBColumn ("LocationNumber")] 
    [StringProperty(MaximumLength=12)]
    public virtual string Number { get; set; }                                                    

    [StringProperty(MaximumLength=60)]
    public virtual string City { get; set; }

    public virtual Country? Country { get; set; }
    public virtual int ZipCode { get; set; }

    public static Location NewObject ()
    {
      return DomainObject.NewObject<Location> ();
    }

    public static Location GetObject (ObjectID objid)
    {
      return DomainObject.GetObject<Location> (objid);
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

    public void DeleteMakeHomeless ()
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
        var country = "";
        if (Country == null)
        {
          country = "";
        }
        else
        {
          country = " (" + EnumDescription.GetDescription (Country) + ")";
        }
        return Street + country;
      }
    }
  }
}
