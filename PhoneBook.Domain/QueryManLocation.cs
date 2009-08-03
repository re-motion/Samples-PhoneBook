using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remotion.Data.DomainObjects;
using Remotion.Data.DomainObjects.Queries;

namespace PhoneBook.Domain
{
  public partial class Location
  {
    public static Location[] QueryManGetLocations ()
    {
      var query = QueryFactory.CreateQueryFromConfiguration ("QueryManGetLocations");
      return ClientTransaction.Current.QueryManager.GetCollection<Location> (query).ToArray ();
    }

    public static Location[] QueryManFindLocationsByCountry (Country country)
    {
      var query = QueryFactory.CreateQueryFromConfiguration ("QueryManFindLocationsByCountry");
      query.Parameters.Add ("@country", country);
      return ClientTransaction.Current.QueryManager.GetCollection<Location> (query).ToArray ();
    }
  }
}
