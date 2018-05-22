﻿namespace PMS.Api.Filters
{
    using System.Reflection;
    using System.Web.Mvc;
    using log4net;

    public class LogErrorAttribute : HandleErrorAttribute
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(ExceptionContext filterContext)
        {
            Logger.ErrorFormat("Web Exception:{0}", filterContext.Exception);
        }
    }
}