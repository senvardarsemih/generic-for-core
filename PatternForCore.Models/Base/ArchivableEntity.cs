using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatternForCore.Models.Base
{
    public abstract class ArchivableEntity<T> : Entity<T>, IArchivableEntity
    {
        /// <summary>
        /// indicates whether the entity is archived
        /// </summary>
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }

        /// <summary>
        /// indicates the archived date
        /// </summary>
        [ScaffoldColumn(false)]
        [Column(TypeName = "DateTime2")]
        public DateTime? ArchiveDate { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        protected ArchivableEntity()
        {
            IsArchived = false;
            ArchiveDate = null;
        }
    }
}
