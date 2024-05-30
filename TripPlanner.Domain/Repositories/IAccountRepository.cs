﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Domain.Entities;

namespace TripPlanner.Domain.Repositories
{
    public interface IAccountRepository
    {
        public Task<string> Register(User user, string password, string role);
        public Task<IEnumerable<IdentityError>> RegisterUser(User user, string password);
        public Task<IEnumerable<IdentityError>> RegisterAdmin(User user, string password);
        public Task<bool> Verify(string email, string verficationToken);
        //public Task<IEnumerable<IdentityError>> Verify(string email, string verficationToken);
    }
}
