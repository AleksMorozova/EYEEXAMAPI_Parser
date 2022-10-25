using EYEEXAMAPI_Parser;
using EYEEXAMAPI_Parser.Model;
using System.Collections.Generic;

namespace EYEEXAMAPI_Parser_Tests.Data
{
    public static class ParsedSchedules
    {
        public static List<ParsedScheduleNoticeOfLease> ParsedSchedulesList = new List<ParsedScheduleNoticeOfLease>()
        {
            new ParsedScheduleNoticeOfLease()
            {
                EntryNumber = 1,
                EntryDate = null,
                                RegistrationDateAndPlanRef = "09.07.2009 Edged and numbered 2 in blue (part of)",
                PropertyDescription = "Endeavour House, 47 Cuba Street, London",
                DateOfLeaseAndTerm = "06.07.2009 125 years from 1.1.2009",
                LesseesTitle = "EGL557357",
                Notes = new List<string>() {
                    "NOTE: By a Deed dated 20 July 1995 made between (1) Orbit Housing Association and (2) Clifford Ronald Mitchell the terms of the Lease were varied.  (Copy Deed filed under TGL27169)"
                }
            },
        };
    }
}
