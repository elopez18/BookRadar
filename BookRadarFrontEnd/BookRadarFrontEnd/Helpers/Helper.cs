using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BookRadarFrontEnd.Helpers
{
    public class Helper: IHelper
    {

        private readonly ICompositeViewEngine _viewEngine;

        public Helper(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider)
        {
            _viewEngine = viewEngine;
        }

        public string RenderPartial(Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                try
                {

                    var viewEngineResult = _viewEngine.GetView(viewName, viewName, isMainPage: false);
                    var viewContext = new ViewContext(controller.ControllerContext, viewEngineResult.View, controller.ViewData, controller.TempData, sw, new HtmlHelperOptions());

                    viewEngineResult.View.RenderAsync(viewContext).GetAwaiter().GetResult();
                }
                catch (Exception)
                {

                }

                return sw.ToString();
            }
        }
    }
}
