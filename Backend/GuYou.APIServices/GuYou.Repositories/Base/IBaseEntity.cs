using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Base
{
    public interface IBaseEntity
    {
        DateTimeOffset CreatedTime { get; set; }
        DateTimeOffset LastUpdatedTime { get; set; }
        DateTimeOffset? DeletedTime { get; set; }

        string CreatedBy { get; set; }
        string LastUpdatedBy { get; set; }
        string? DeletedBy { get; set; }

        bool IsActive { get; set; }
        bool IsDelete { get; set; }
    }
}
