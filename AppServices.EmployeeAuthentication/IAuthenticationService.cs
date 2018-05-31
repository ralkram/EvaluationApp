using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppServices.EmployeeAuthentication

{
    public interface IAuthenticationService
    {
        string GetCurrentUserId();
        bool IsUserAuthenticated();
        void Initialize(IServiceCollection services, IConfiguration config);
        void Configure(IApplicationBuilder applicationBuilder);
        void SignOut( );
    }
}
