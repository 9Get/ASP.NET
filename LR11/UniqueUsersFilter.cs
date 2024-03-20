using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11
{
    public class UniqueUsersFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ipAddress = filterContext.HttpContext.Request.Host.ToString();

            string filePath = "UniqueUsers.txt";
            string[] existingEntries = File.ReadAllLines(filePath);
            bool alreadyExists = Array.Exists(existingEntries, line => line == ipAddress);

            if (!alreadyExists)
            {
                File.AppendAllText(filePath, ipAddress + Environment.NewLine);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
