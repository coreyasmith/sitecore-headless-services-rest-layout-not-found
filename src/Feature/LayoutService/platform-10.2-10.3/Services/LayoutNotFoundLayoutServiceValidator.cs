using System;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.LayoutService.Mvc.Factories.Interfaces;
using Sitecore.LayoutService.Mvc.Models;
using Sitecore.LayoutService.Mvc.Services.Interfaces;

namespace CoreySmith.Feature.LayoutService.Services
{
    public class LayoutNotFoundLayoutServiceValidator : ILayoutServiceValidator
    {
        private readonly ILayoutServiceValidator _innerValidator;
        private readonly IRenderingViewFactory _renderingViewFactory;

        public LayoutNotFoundLayoutServiceValidator(ILayoutServiceValidator validator, IRenderingViewFactory renderingViewFactory)
        {
            _innerValidator = validator ?? throw new ArgumentNullException(nameof(validator));
            _renderingViewFactory = renderingViewFactory ?? throw new ArgumentNullException(nameof(renderingViewFactory));
        }

        public ValidationRequestResult ValidateLayoutServiceRequest(ValidationRequestModel requestModel)
        {
            var result = _innerValidator.ValidateLayoutServiceRequest(requestModel);
            if (result?.HttpStatusCodeResult != null) return result;

            var item = result?.ResolvedItem;
            if (item == null) return result;

            using (new ContextItemSwitcher(item))
            {
                if (_renderingViewFactory.GetRenderingView() != null)
                {
                    return result;
                }
            }

            result.ResolvedItem = null;

            // Clear Context.Item so that site context is not added to Layout Service response
            Context.Item = null;

            return result;
        }
    }
}
