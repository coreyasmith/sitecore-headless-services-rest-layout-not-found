using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering;
using Sitecore.LayoutService.Mvc.Controllers;
using Sitecore.LayoutService.Mvc.ItemResolving;
using Sitecore.LayoutService.Mvc.Results;
using Sitecore.LayoutService.Serialization;
using Sitecore.Mvc.Presentation;

namespace CoreySmith.Feature.LayoutService.Controllers
{
    public class LayoutNotFoundLayoutServiceController : LayoutServiceController
    {
        public LayoutNotFoundLayoutServiceController(
            ILayoutService layoutService,
            ISerializerService serializerService,
            IConfiguration configuration,
            IPlaceholderRenderingService placeholderService,
            IItemResolver itemResolver,
            ILayoutServiceContext serviceContext,
            ILayoutServiceResultFactory layoutServiceResultFactory)
            : base(layoutService, serializerService, configuration, placeholderService, itemResolver, serviceContext, layoutServiceResultFactory)
        {
        }

        protected override ActionResult ValidateLayoutServiceRequest(string configuration, string item, out Item resolvedItem, out NamedConfiguration resolvedConfiguration)
        {
            var result = base.ValidateLayoutServiceRequest(configuration, item, out resolvedItem, out resolvedConfiguration);
            if (result != null || resolvedItem == null) return result;

            using (new ContextItemSwitcher(resolvedItem))
            {
                if (PageContext.Current.PageView is RenderingView)
                {
                    return null;
                }
            }

            resolvedItem = null;

            // Clear Context.Item so that site context is not added to Layout Service response
            Sitecore.Context.Item = null;

            return null;
        }
    }
}
