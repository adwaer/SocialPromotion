using System;
using Adwaer.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nanny.Domain.Entities
{
    public class UserRole : IdentityUserRole<Guid>, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public SimpleCustomerAccount User { get; set; }
    }
}