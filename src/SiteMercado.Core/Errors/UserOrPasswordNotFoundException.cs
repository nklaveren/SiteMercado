using System;

namespace SiteMercado.Core.Errors
{
    public class UserOrPasswordNotFoundException : Exception
    {
        public UserOrPasswordNotFoundException() : base("Username or password incorrect")
        {

        }
    }
}
