using AutoMapper;
using Repository.Models;
using MvcApp.ViewModels.Account;

namespace MvcApp.Mappings
{
    public class UserForgotPasswordMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserForgotPasswordViewModel, UserForgotPassword>()
                .ForMember(u => u.Code, map => map.UseValue(Services.Security.Random.GenerateString(10)));
        }
    }
}