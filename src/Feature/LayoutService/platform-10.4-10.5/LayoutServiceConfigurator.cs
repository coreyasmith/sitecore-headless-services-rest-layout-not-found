using CoreySmith.Feature.LayoutService.Response;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.LayoutService.Mvc.Response.Interfaces;

namespace CoreySmith.Feature.LayoutService
{
    public class LayoutServiceConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Decorate<IResponseBuilder, LayoutNotFoundResponseBuilder>();
        }
    }
}
