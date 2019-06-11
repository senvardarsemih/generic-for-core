using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatternForCore.Model.Base
{
    public abstract class BaseEntity
    {

    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        /// <summary>
        /// identity number for the entity
        /// </summary>
        public virtual T Id { get; set; }

        /// <summary>
        /// indicates the created date for the entity
        /// </summary>
        [ScaffoldColumn(false)]
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// indicates the who created the entity
        /// </summary>
        [ScaffoldColumn(false)]
        public int CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "DateTime2")]
        public DateTime? UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        public int? UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public Guid Guid { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        protected Entity()
        {
            Guid = Guid.NewGuid();
            CreatedDate = DateTime.Now.ToLocalTime();
            IsActive = true;
        }
    }
}
