using Blazored.LocalStorage;
using IntranetV6.Client.DataModels;
using Microsoft.AspNetCore.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetV6.Client.Services
{
  public class ApplicationState
  {
    public bool IsLoggedIn {  get { return _isLoggedIn; } }
    public string LoginName { get { return _loginName; } private set { _loginName = value; _localStorage.SetItem("loginName", value); } }
    public string EmailAddress { get { return _emailAddress; } private set { _emailAddress = value; _localStorage.SetItem("emailAddress", value); } }
    public string DisplayName { get { return _displayName; } private set { _displayName = value; _localStorage.SetItem("displayName", value); } }

    private ILocalStorageService _localStorage;
    private IUriHelper _uriHelper;

    private bool _isLoggedIn { get; set; } = false;
    private string _loginName { get; set; } = String.Empty;
    private string _emailAddress { get; set; } = String.Empty;
    private string _displayName { get; set; } = String.Empty;
    private List<string> _roles { get; set; } = new List<string>();

    public ApplicationState(ILocalStorageService localStorage, IUriHelper uriHelper)
    {
      _localStorage = localStorage;
      _uriHelper = uriHelper;
    }

    public void CreateSession(LoginResponse loginResponse)
    {
      if(loginResponse.Success)
      {
        _isLoggedIn = true;
        _localStorage.SetItem("isloggedin", true);

        LoginName = loginResponse.LoginName;
        EmailAddress = loginResponse.EmailAddress;
        DisplayName = loginResponse.DisplayName;
      }
    }

    public async Task CheckAndRetrieveSessionAsync()
    {
      // TODO: Once we have a JWT working, then all we really need to do is pull the token from the store and decode that, as well
      // as checking token expiry etc.

      var state = await _localStorage.GetItem<bool>("isloggedin");
      if (state == true)
      {
        _isLoggedIn = true;
      }

      var loginName = await _localStorage.GetItem<string>("loginName");
      if(!String.IsNullOrEmpty(loginName))
      {
        _loginName = loginName;
      }

      var emailAddress = await _localStorage.GetItem<string>("emailAddress");
      if (!String.IsNullOrEmpty(emailAddress))
      {
        _emailAddress = emailAddress;
      }

      var displayName = await _localStorage.GetItem<string>("displayName");
      if (!String.IsNullOrEmpty(displayName))
      {
        _displayName = displayName;
      }

    }

    public void DestroySession()
    {
      _localStorage.RemoveItem("isloggedin"); _isLoggedIn = false;
      _localStorage.RemoveItem("loginName"); _loginName = String.Empty;
      _localStorage.RemoveItem("emailAddress"); _emailAddress = String.Empty;
      _localStorage.RemoveItem("displayName"); _displayName = String.Empty;
    }

    public void CheckPageAuth(List<string> requiredRoles = null)
    {
      Console.WriteLine("In Check Auth");
      Console.WriteLine($"_isLoggedIn = {_isLoggedIn}");
      if (!_isLoggedIn) _uriHelper.NavigateTo("/signin");

      if(requiredRoles != null)
      {
        bool result = _roles.Intersect(requiredRoles).Any();
        if (!result) _uriHelper.NavigateTo("/error403");
      }
    }

  }
}
