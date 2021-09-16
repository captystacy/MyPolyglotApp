﻿using Microsoft.AspNetCore.Http;
using MyPolyglotWeb.Models.DomainModels;
using MyPolyglotWeb.Repositories.IRepository;
using MyPolyglotWeb.Services.IServices;
using System.Linq;

namespace MyPolyglotWeb.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserDB GetCurrentUser()
        {
            var idStr = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = int.Parse(idStr);
            return _userRepository.Get(id);
        }
    }
}
