using EYEEXAMAPI_Parser;
using EYEEXAMAPI_Parser.Model;
using System.Collections.Generic;

namespace EYEEXAMAPI_Parser_Tests.Data
{
    public static class RawSchedules
    {
        public static List<RawScheduleNoticeOfLease> RawSchedulesList = new List<RawScheduleNoticeOfLease>()
        {
            new RawScheduleNoticeOfLease()
            {
                EntryNumber = "1",
                EntryDate = "",
                EntryType = "Schedule of Notices of Leases",
                EntryText = new List<string>() {
                    "09.07.2009      Endeavour House 47 Cuba      06.07.2009      EGL557357  ",
                    "Edged and       Street London                125 years from             ",
                    "numbered 2 in                                 1.1.2009                   ",
                    "blue (part of)"                                                           ,
                    "NOTE: By a Deed dated 20 July 1995 made between (1) Orbit Housing Association and (2) Clifford Ronald Mitchell the terms of the Lease were varied.  (Copy Deed filed under TGL27169)"
                }
            },
        };
    }
}
