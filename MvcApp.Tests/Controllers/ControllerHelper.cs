using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcApp.Tests.Controllers
{
    public static class ControllerHelper
    {
        public static void AssertController(Task<ActionResult> result, Controller controller)
        {
            Assert.IsNull(result.Exception);
            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsNotNull(result);
        }

        public static void AssertController(ActionResult result, Controller controller)
        {
            Assert.IsNotNull(result);
            Assert.IsTrue(controller.ModelState.IsValid);
        }

        public static void AssertController(ViewResult result, Controller controller)
        {
            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsNotNull(result);
        }
    }
}
