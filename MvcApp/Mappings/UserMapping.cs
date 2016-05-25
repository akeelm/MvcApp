using AutoMapper;
using Repository.Models;
using MvcApp.ViewModels.Account;

namespace MvcApp.Mappings
{
    public class UserMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<LoginViewModel, User>()
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.UserName));

            CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.Password, map => map.MapFrom(vm => Services.Security.PasswordHash.CreateHash(vm.Password)));
        }
    }
}