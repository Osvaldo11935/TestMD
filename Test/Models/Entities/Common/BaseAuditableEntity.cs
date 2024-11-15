using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Models.Entities.Common
{
    public class BaseAuditableEntity
    {
        public Guid? Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #region Constructor
        public BaseAuditableEntity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }

        #endregion
    }
}
