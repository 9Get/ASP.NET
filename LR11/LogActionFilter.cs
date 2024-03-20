using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace LR11
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? controllerName = context.ActionDescriptor.DisplayName;
            string? actionName = context.ActionDescriptor.DisplayName;

            string logMessage = $"{DateTime.Now} - Controller: {controllerName}, Action: {actionName}";

            string filePath = "ActionLog.txt";
            File.AppendAllText(filePath, logMessage + Environment.NewLine);

            base.OnActionExecuting(context);
        }
    }
}
