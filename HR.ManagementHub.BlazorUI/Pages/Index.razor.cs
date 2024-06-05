using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages;

public partial class Index
{
    //[Inject]
    //private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    //[Inject]
    //public IAuthenticationService AuthenticationService { get; set; }

    //protected async override Task OnInitializedAsync()
    //{
    //    await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
    //}

    protected void GoToLogin()
    {
        NavigationManager.NavigateTo("login/");
    }

    protected void GoToRegister()
    {
        NavigationManager.NavigateTo("register/");
    }

    //protected async void Logout()
    //{
    //    await AuthenticationService.Logout();
    //}
}
