using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Movies.Api.Auth
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey)) 
            {
                context.Result = new UnauthorizedObjectResult("API key is missing");
                return;
            }

            var apikey = _configuration["ApiKey"]!;
            if(apikey != extractedApiKey)
            {
                context.Result = new UnauthorizedObjectResult("API key is missing");
                
            }


        }
    }
}
