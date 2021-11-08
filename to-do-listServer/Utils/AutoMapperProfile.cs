using AutoMapper;
using to_do_listServer.Models;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Config
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            CreateMap<RegisterRequest, User>();

            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        return prop.GetType() != typeof(string) || !string.IsNullOrEmpty((string)prop);
                    }
                ));
        }
    }
}