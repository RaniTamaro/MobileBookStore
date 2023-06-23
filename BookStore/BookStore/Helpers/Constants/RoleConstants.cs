using System.Collections.Generic;

namespace BookStore.Helpers.Constants
{
    public static class RoleConstants
    {
        public static readonly string UserRole = "UserRole";
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";

        public static List<string> GetRoles()
        {
            return new List<string> { Admin, User };
        }
    }
}
