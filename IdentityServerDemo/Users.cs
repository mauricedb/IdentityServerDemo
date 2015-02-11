﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace IdentityServerDemo
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser()
                {
                    Username = "bob",
                    Password = "bob",
                    Enabled = true,
                    Subject = "1"
                }
            };
        } 
    }
}