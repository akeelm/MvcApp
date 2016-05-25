using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MvcApp.Tests.StructureMapRegistry
{
    public class StructureMapScopeModule : IHttpModule
    {
        public void Dispose()
        {
            StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
        }

        public void Init()
        {
            StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
        }

        public void Init(HttpApplication context)
        {
            StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
        }
    }
}
