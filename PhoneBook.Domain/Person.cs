using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Globalization;

namespace PhoneBook.Domain
{
  [DBTable]
  [MultiLingualResources("PhoneBook.Domain.Globalization.Person")]
  public class Person : BindableDomainObject
  {
    [StringProperty(MaximumLength=60)]
    public virtual string FirstName { get; set; }

    [StringProperty(MaximumLength=60, IsNullable=false)]
    public virtual string Surname { get; set; }

    public virtual Location Location { get; set; }
    
    [DBBidirectionalRelation("Person", SortExpression="CountryCode, AreaCode, Number, Extension")]    
    public virtual ObjectList<PhoneNumber> PhoneNumbers { get; set; }

    public static Person NewObject ()
    {
      return DomainObject.NewObject<Person> ();
    }

    public static Person GetObject (ObjectID objid)
    {
      return DomainObject.GetObject<Person> (objid);
    }

    public new void Delete ()
    {
      base.Delete ();
    }

    public static Person[] FindPersons ()
    {
      var query = from p in QueryFactory.CreateLinqQuery<Person> ()
                  select p;
      return query.ToArray ();
    }

    public static Person GetFirstPersonByFirstName (string firstName)
    {
      var query = from p in QueryFactory.CreateLinqQuery<Person> ()
                  where p.FirstName == firstName
                  select p;
      var pArr = query.ToArray ();
      if (pArr.Length > 0)
      {
        return pArr[0];
      }
      else
      {
        return null;
      }
    }

    public override string DisplayName
    {
      get
      {
        string displayName = "";
        if (!String.IsNullOrEmpty (FirstName))
        {
          displayName = FirstName[0] + ". ";
        }
        displayName += Surname;
        return displayName;
      }
    }
  }
}
