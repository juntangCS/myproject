﻿using System;

namespace Granite.Models.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? LastUpdatedTime { get; set; }
    }
}