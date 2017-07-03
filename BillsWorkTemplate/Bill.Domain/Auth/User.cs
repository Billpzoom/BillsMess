using Bill.Domain.Value;

namespace Bill.Domain.Auth
{
    public class User : EntityUuidString
    {
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual Role Role { get; set; }

        public virtual UserStatus Status { get; set; }
    }
}