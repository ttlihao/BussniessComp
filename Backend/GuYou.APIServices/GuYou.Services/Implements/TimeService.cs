using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class TimeService : ITimeService
    {
        public DateTimeOffset SystemTimeNow => ConvertToUtcPlus7(DateTimeOffset.Now);

        public static DateTimeOffset ConvertToUtcPlus7(DateTimeOffset dateTime)
        {
            return dateTime.ToOffset(TimeSpan.FromHours(7));
        }
    }
}
