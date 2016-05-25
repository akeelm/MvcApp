using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MvcApp.DependencyResolution;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcApp.Tests.StructureMapRegistry
{
    public static class StructuremapMvc
    {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion

        #region Public Methods and Operators

        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

        public static void Start()
        {
            IContainer container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }

        #endregion
    }
}
