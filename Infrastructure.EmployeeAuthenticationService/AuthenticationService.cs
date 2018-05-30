using AppServices.EmployeeAuthentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.EmployeeAuthenticationService
{
    public class AuthenticationService : AppServices.EmployeeAuthentication.IAuthenticationService
    {
        private IServiceCollection Services { get; set; }

        HttpContext currentContext;
        public AuthenticationService(IHttpContextAccessor context)
        {
            currentContext = context?.HttpContext;
        }
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAuthentication();
        }

        // MOCKUP METHOD, TO BE IMPLEMENTED
        public int GetCurrentUserId()
        {
            return 1;
        }

        public void Initialize(IServiceCollection services, IConfiguration config)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            string returnUrl = "signin-oidc";

            var authSettings = config.GetSection("AuthenticationSettings");

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = "Cookies";
                    options.Authority = authSettings["Authority"];
                    options.RequireHttpsMetadata = false;
                    options.CallbackPath = PathString.FromUriComponent("/" + returnUrl);                    
                    options.ClientId = authSettings["ClientId"];
                    options.ClientSecret = authSettings["ClientSecret"];
                    options.ResponseType = "code id_token";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("GetEmployees");
                });

            Services = services;
        }

        // MOCKUP METHOD, TO BE IMPLEMENTED
        public bool IsUserAuthenticated()
        {
            return true;
        }

        public void SignOut()
        {
            currentContext?.SignOutAsync("Cookies").Wait();
            currentContext?.SignOutAsync("oidc").Wait();
        }
    }
}
