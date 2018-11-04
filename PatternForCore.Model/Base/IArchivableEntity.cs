using System;

namespace PatternForCore.Model.Base
{
    public interface IArchivableEntity
    {
        bool IsArchived { get; set; }
        DateTime? ArchiveDate { get; set; }
    }
}
