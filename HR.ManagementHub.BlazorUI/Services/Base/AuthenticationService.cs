using Blazored.LocalStorage;
using HR.ManagementHub.BlazorUI.Common.Interfaces;
using HR.ManagementHub.BlazorUI.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.ManagementHub.BlazorUI.Services.Base;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client,
                                 ILocalStorageService localStorage,
                                 AuthenticationStateProvider authenticationStateProvider)
        : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenitcationRequest = new AuthRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenitcationRequest);
            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                await ((ApiAuthenticationStateProvider)
                    _authenticationStateProvider).LoggedIn();
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public async Task Logout()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password,
            UserName = userName
        };

        var response = await _client.RegisterAsync(registrationRequest);
        if (!string.IsNullOrEmpty(response.UserId))
        {
            return true;
        }

        return false;
    }
}
