using System;

namespace PatternForCore.Models.Base
{
    public interface IArchivableEntity
    {
        bool IsArchived { get; set; }
        DateTime? ArchiveDate { get; set; }
    }
}
