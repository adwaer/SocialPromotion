using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nanny.Domain.Entities
{
    public class SimpleCustomerAccount : IdentityUser<Guid, IdentityUserLogin<Guid>, UserRole, IdentityUserClaim<Guid>>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        [Index("IX_Unique_Email", 1, IsUnique = true), MaxLength(255)]
        public override string Email { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
