using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface ITimeService
    {
        DateTimeOffset SystemTimeNow { get; }
    }
}
