using Microsoft.AspNetCore.Mvc;

namespace BookRadarFrontEnd.Helpers
{
    public interface IHelper
    {
        public string RenderPartial(Controller controller, string viewName, object model);
    }
}
