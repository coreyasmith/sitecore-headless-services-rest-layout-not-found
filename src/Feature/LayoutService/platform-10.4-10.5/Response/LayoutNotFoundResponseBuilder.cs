using System;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.Mvc.Factories.Interfaces;
using Sitecore.LayoutService.Mvc.Request.Models;
using Sitecore.LayoutService.Mvc.Response.Interfaces;
using Sitecore.Mvc.Presentation;

namespace CoreySmith.Feature.LayoutService.Response
{
    public class LayoutNotFoundResponseBuilder : IResponseBuilder
    {
        private readonly IResponseBuilder _innerBuilder;
        private readonly IRenderingViewFactory _renderingViewFactory;

        public LayoutNotFoundResponseBuilder(IResponseBuilder responseBuilder, IRenderingViewFactory renderingViewFactory)
        {
            _innerBuilder = responseBuilder ?? throw new ArgumentNullException(nameof(responseBuilder));
            _renderingViewFactory = renderingViewFactory ?? throw new ArgumentNullException(nameof(renderingViewFactory));
        }

        public Item ResolveItem(ItemRequestModel itemModel)
        {
            var item = _innerBuilder.ResolveItem(itemModel);
            if (item == null) return null;

            using (new ContextItemSwitcher(item))
            {
                if (_renderingViewFactory.GetRenderingView() != null)
                {
                    return item;
                }
            }

            // Clear Context.Item so that site context is not added to Layout Service response
            Context.Item = null;
            return null;
        }

        public NamedConfiguration ResolveConfiguration(ConfigurationRequestModel configurationModel)
        {
            return _innerBuilder.ResolveConfiguration(configurationModel);
        }

        public Rendering ResolveRendering(ComponentRequestModel componentModel)
        {
            return _innerBuilder.ResolveRendering(componentModel);
        }
    }
}
