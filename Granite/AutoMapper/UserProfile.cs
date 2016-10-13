using AutoMapper;
using Granite.Models.User;
using Granite.Models.Users;
using Saas.Business.Entities;

namespace Granite.AutoMapper
{
    /// <summary>
    /// Student profile.
    /// </summary>
    public class UserProfile :Profile
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserQueryModel>();
            CreateMap<UserCreateModel, User>();
            CreateMap<UserUpdateModel, User>();
        }
    }
}