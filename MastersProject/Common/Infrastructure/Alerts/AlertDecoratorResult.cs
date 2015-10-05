using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Common.Utils.ExtensionMethods;
namespace MastersProject.Core.Common.Infrastructure
{
    public class AlertDecoratorResult:ActionResult
    {
        public ActionResult InnerResult { get; set; }
        public string AlertClass { get; set; }
        public string Message { get; set; }
        public bool IsTimedOut { get; set; }
        public AlertDecoratorResult(ActionResult innerResult, string alertClass, string message, bool isTimedOut)
        {
            this.InnerResult = innerResult;
            this.AlertClass = alertClass;
            this.Message = message;
            this.IsTimedOut = isTimedOut;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertClass,Message,IsTimedOut));
            InnerResult.ExecuteResult(context);

          }
    }
}