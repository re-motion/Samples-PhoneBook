using System.Collections.Generic;
using System.Linq;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.ObjectBinding;
using Remotion.Data.DomainObjects.Queries;
using Remotion.Globalization;
using Remotion.Reflection;

// using Remotion.Globalization;

namespace PhoneBook.Domain
{
  [DBTable]
  [MultiLingualResources ("PhoneBook.Domain.Globalization.Person")]
  public class Person : BindableDomainObject
  {
    [StringProperty(MaximumLength = 60)]
    public virtual string FirstName { get; set; }

    [StringProperty(IsNullable = false, MaximumLength = 60)]
    public virtual string LastName { get; set; }

    public virtual Location Location { get; set; }

    [DBBidirectionalRelation("Person", SortExpression = "CountryCode,AreaCode,Number,Extension")]
    public virtual ObjectList<PhoneNumber> PhoneNumbers { get; set; }

    protected Person ()
    {
    }

    protected Person (string firstName, string lastName, Location location)
    {
      FirstName = firstName;
      LastName = lastName;
      Location = location;
    }

    public static Person NewObject (string firstName, string lastName, Location location)
    {
      return NewObject<Person> (ParamList.Create(firstName, lastName, location));
    }

    public static Person NewObject()
    {
      return NewObject<Person>();
    }

    public static Person GetObject(ObjectID objid)
    {
      return GetObject<Person>(objid);
    }

    public new void Delete ()
    {
      base.Delete ();
    }

    public static IEnumerable<Person> PeopleFrom (string city)
    {
      using (ClientTransaction.CreateRootTransaction().EnterDiscardingScope())
      {
        var query = from p in QueryFactory.CreateLinqQuery<Person>()
                    where p.Location.City == city &&
                          p.PhoneNumbers.Count > 0
                    select p;
        return query.ToArray();
      }
    }

    public static Person GetFirstPersonByFirstName (string firstName)
    {
      var query = from p in QueryFactory.CreateLinqQuery<Person> ()
                  where p.FirstName == firstName
                  select p;
      var pArr = query.ToArray ();
      return pArr.Length > 0 ? pArr[0] : null;
    }

    public override string DisplayName
    {
      get
      {
        var displayName = string.Empty;
        if (!string.IsNullOrEmpty (FirstName))
        {
          displayName = FirstName[0] + ". ";
        }
        displayName += LastName;
        return displayName;
      }
    }

    public static IEnumerable<Person> FindPeopleByLocation (Location location)
    {
      var query = QueryFactory.CreateQueryFromConfiguration ("FindPeopleByLocation");
      query.Parameters.Add ("@location", location.ID.Value);
      return ClientTransaction.Current.QueryManager.GetCollection<Person> (query).ToArray ();
    }
  }
}