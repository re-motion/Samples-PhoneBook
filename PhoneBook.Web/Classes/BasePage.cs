// This file is part of the re-motion Core Framework (www.re-motion.org)
// Copyright (C) 2005-2008 rubicon informationstechnologie gmbh, www.rubicon.eu
// 
// The re-motion Core Framework is free software; you can redistribute it 
// and/or modify it under the terms of the GNU Lesser General Public License 
// version 3.0 as published by the Free Software Foundation.
// 
// re-motion is distributed in the hope that it will be useful, 
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with re-motion; if not, see http://www.gnu.org/licenses.
// 
using System;
using System.Threading;
using System.Globalization;
using Remotion.Globalization;
using Remotion.ServiceLocation;
using Remotion.Web;
using Remotion.Web.ExecutionEngine;
using Remotion.Web.Infrastructure;
using Remotion.Web.UI.Globalization;

namespace PhoneBook.Web.Classes
{
  [WebMultiLingualResources ("PhoneBook.Web.Globalization.Global")]
  public class BasePage: WxePage, IObjectWithResources
  {

    protected override void OnPreRender (EventArgs e)
    {
      var themedResourceUrlResolver = SafeServiceLocator.Current.GetInstance<IThemedResourceUrlResolverFactory> ().CreateResourceUrlResolver ();
      string url = themedResourceUrlResolver.GetResourceUrl (this, ResourceType.Html, "Style.css");

      Remotion.Web.UI.HtmlHeadAppender.Current.RegisterStylesheetLink(GetType() + "remotionstyle", url);

      url = ResolveClientUrl("~/Html/style.css");
      Remotion.Web.UI.HtmlHeadAppender.Current.RegisterStylesheetLink (GetType () + "projectstyle", url);

      // globalization
      IResourceManager rm = ResourceManagerUtility.GetResourceManager (this);

      if (rm != null)
        ResourceDispatcher.Dispatch (this, rm);

      base.OnPreRender(e);
    }

    IResourceManager IObjectWithResources.GetResourceManager()
    {
      return this.GetResourceManager();
    }

    protected virtual IResourceManager GetResourceManager()
    {
      Type type = this.GetType();

      if (MultiLingualResources.ExistsResource (type))
        return MultiLingualResources.GetResourceManager (type, true);
      else
        return null;
    }
  }
}
