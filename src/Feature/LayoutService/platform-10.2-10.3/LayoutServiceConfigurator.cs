using CoreySmith.Feature.LayoutService.Services;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.LayoutService.Mvc.Services.Interfaces;

namespace CoreySmith.Feature.LayoutService
{
    public class LayoutServiceConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Decorate<ILayoutServiceValidator, LayoutNotFoundLayoutServiceValidator>();
        }
    }
}
