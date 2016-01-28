﻿using System.Collections.Generic;
using SocialNetwork.Domain.Models;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IAuthDataService
    {
        IEnumerable<Authorization> GetAuthorizations();

        void add(string Login, string Password);
    }
}
