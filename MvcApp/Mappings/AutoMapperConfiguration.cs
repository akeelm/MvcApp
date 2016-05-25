using AutoMapper;
using System.Web.Mvc;

namespace MvcApp.Mappings
{
    /// <summary>
    /// Main configuration entry for AutoMapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        public static void Setup()
        {
            //Register all AutoMapper profiles
            var profiles = DependencyResolver.Current.GetServices<Profile>();
            Mapper.Initialize(cfg => {
                foreach (var profile in profiles)
                    cfg.AddProfile(profile);
            });
        }
    }
}