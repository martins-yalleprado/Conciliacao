using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Model
{
    public class AuthenticateAdModel
    {
        public UserAD UserAD { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class GroupAD
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserAD
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int sAMAccountName { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public string ObjectCategory { get; set; }
        public DateTime PasswordLastSet { get; set; }
        public string Dn { get; set; }
        public string Groups { get; set; }
        public List<GroupAD> lstGroupAD { get; set; }
    }
}
