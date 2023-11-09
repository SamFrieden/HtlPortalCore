using System.ComponentModel.DataAnnotations;

namespace HtlPortalCore.DataAccess.Entities
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        [Key]
        public TId Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        protected BaseEntity()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
