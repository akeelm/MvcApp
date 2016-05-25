using AutoMapper;
using MvcApp.DependencyResolution;
using StructureMap;
using StructureMap.Graph;

namespace MvcApp.Tests.StructureMapRegistry
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            //AutoMapper profiles
            Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.AddAllTypesOf<Profile>();
            });
        }

        #endregion
    }
}
 