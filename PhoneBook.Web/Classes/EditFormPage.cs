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
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Remotion.Web.UI.Controls;
using Remotion.ObjectBinding.Web.UI.Controls;
using Remotion.ObjectBinding;

namespace PhoneBook.Web.Classes
{
  public class EditFormPage: BasePage
  {
    private bool _isSaved;
    private bool _dataSourceModePropagated = false;

    /// <summary> Gets the data source for the edit form. Must be overridden in derived classes.</summary>
    protected virtual IBusinessObjectDataSourceControl DataSource { get { throw new NotImplementedException("Implement DataSource in derived class."); } }

    /// <summary> Gets the <see cref="TabbedMultiView"/> that holds the user controls.</summary>
    protected virtual TabbedMultiView UserControlMultiView => null;

    /// <summary> Gets all user controls that should load and save values of the current object. </summary>
    /// <remarks>
    /// The default implemenation gets all <see cref="DataEditUserControl"/> instances from the <see cref="TabbedMultiView"/>
    /// returned by <see cref="TabView"/>.
    /// </remarks>
    protected virtual IEnumerable<DataEditUserControl> DataEditUserControls
    {
      get
      {
        var multiView = UserControlMultiView;
        if (multiView == null)
          yield break;

        var userControls = multiView.Views.Cast<TabView>()
          .SelectMany (view => view.LazyControls.OfType<DataEditUserControl>());

        foreach (var userControl in userControls)
        {
          yield return userControl;
        }
      }
    }

    protected void LoadObject (IBusinessObject businessObject)
    {
      DataSource.BusinessObject = businessObject;
      DataSource.LoadValues (IsPostBack);

      foreach (var control in DataEditUserControls)
      {
        control.DataSource.BusinessObject = businessObject;
        control.LoadValues (IsPostBack);
      }
    }

    protected bool SaveObject()
    {
      EnsurePostLoadInvoked();
      EnsureValidatableControlsInitialized();

      var isValid = DataSource.Validate();

      var firstInvalidControl = DataEditUserControls.FirstOrDefault(control => !control.Validate());
      if (firstInvalidControl != null)
      {
        isValid = false;
      }
      
      if (isValid)
      {
        SaveValidObject();
      }
      else
      {
        var multiView = UserControlMultiView;
        if (multiView == null)
          return false;

        for (Control control = firstInvalidControl; control != null; control = control.Parent)
        {
          if (!(control is TabView))
            continue;

          multiView.SetActiveView ((TabView) control);
          break;
        }
      }

      return isValid;
    }

    private void SaveValidObject ()
    {
      foreach (var control in DataEditUserControls)
        control.SaveValues (false);

      DataSource.SaveValues (false);
      _isSaved = true;
      // transaction will be committed by caller or using auto commit.
    }

    protected override void OnPreRender (EventArgs e)
    {
      base.OnPreRender (e);
      EnsureDataSourceModePropagated();
    }

    protected DataSourceMode DataSourceMode 
    {
      get { return DataSource.Mode; }
      set
      {
        DataSource.Mode = value;
        PropagateDataSourceMode();
      }
    }

    protected void EnsureDataSourceModePropagated()
    {
      if (_dataSourceModePropagated)
        return;

      PropagateDataSourceMode();
      _dataSourceModePropagated = true;
    }

    private void PropagateDataSourceMode()
    {
      foreach (var control in DataEditUserControls)
        control.DataSource.Mode = DataSource.Mode;
    }

    protected override void OnUnload (EventArgs e)
    {
      base.OnUnload (e);

      if (_isSaved)
        return;

      foreach (var control in DataEditUserControls)
        control.SaveValues (true);

      DataSource.SaveValues (true);
    }

    /// <exception cref="InvalidOperationException">Page has no <see cref="UserControlMultiView"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">A <see cref="TabView"/> with the given ID could not be found.</exception>
    public TUserControl GetUserControl<TUserControl> (string tabViewID)
      where TUserControl: Control
    {
      var multiView = UserControlMultiView;
      if (multiView == null)
        throw new InvalidOperationException ("Page has no UserControlMultiView.");

      var view = (TabView) multiView.FindControl (tabViewID);
      if (view == null)
        throw new ArgumentOutOfRangeException ($"No child control with ID {tabViewID} found.");

      view.EnsureLazyControls();

      var firstChildControl = view.LazyControls.OfType<TUserControl>().FirstOrDefault();

      if(firstChildControl != default (TUserControl))
      {
        return firstChildControl;
      }

      throw new ArgumentOutOfRangeException ($"TabView {ID} has no lazy control of type {typeof (TUserControl).Name}.");
    }

  }
}
