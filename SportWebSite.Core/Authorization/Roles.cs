using SportWebSite.Domain.Enums;

namespace SportWebSite.Domain.Authorization
{
    public static class Roles
    {
        public const string ADMIN = nameof(UserRole.Admin);
        public const string MANAGER = nameof(UserRole.Manager);
        public const string SCOUT = nameof(UserRole.Scout);
        public const string PLAYER = nameof(UserRole.Player);
        //public const string ADMIN_MANAGER = nameof(UserRole.Admin) + nameof(UserRole.Manager);
        //public const string ADMIN_MANAGER_SCOUT = nameof(UserRole.Admin) + nameof(UserRole.Manager) + nameof(UserRole.Scout);
    }
}
