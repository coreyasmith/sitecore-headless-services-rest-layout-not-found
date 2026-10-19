using CoreySmith.Feature.LayoutService.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using Sitecore.LayoutService.Mvc.Controllers;

namespace CoreySmith.Feature.LayoutService
{
    public class LayoutServiceConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Replace(ServiceDescriptor.Transient<LayoutServiceController, LayoutNotFoundLayoutServiceController>());
        }
    }
}
