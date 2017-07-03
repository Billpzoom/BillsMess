using System.Collections.Generic;

namespace Bill.Domain.Auth
{
    public class Role : EntityUuidString
    {
        public virtual string RoleName { get; set; }

        public virtual IList<User> Users { get; set; }
        
        public virtual IList<Action> Actions { get; set; }
    }
}