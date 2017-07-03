using System.Collections.Generic;

namespace Bill.Domain.Auth
{
    public class Action : EntityUuidString
    {
        public virtual string ActionName { get; set; }
        public virtual IList<Role> Roles { get; set; }
    }
}