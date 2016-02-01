using System.Collections.Generic;
using SocialNetwork.Domain.Models;
using System;

namespace SocialNetwork.BuisnessLayer.Abstract
{
    public interface IAuthDataService
    {
        IEnumerable<Authorization> GetAuthorizations();

        void add(string Id, string FirstName, string LastName, string PatronymicName, DateTime birthday, string City, string Contact);
    }
}
