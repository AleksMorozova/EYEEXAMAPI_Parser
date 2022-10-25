using EYEEXAMAPI_Parser.Model;
using System.Text.RegularExpressions;

namespace EYEEXAMAPI_Parser.Parsers
{
    public class ScheduleParser : IScheduleParser
    {
        public List<ParsedScheduleNoticeOfLease> Parse(List<RawScheduleNoticeOfLease> rawSchedule)
        {
            var parsedSchedule = new List<ParsedScheduleNoticeOfLease>();

            rawSchedule
                .ForEach(rawScheduleItem =>
                {
                    var entryText = ParseEntryText(rawScheduleItem.EntryText);
                    var schedule = new ParsedScheduleNoticeOfLease()
                    {
                        EntryNumber = int.Parse(rawScheduleItem.EntryNumber),
                        EntryDate = String.IsNullOrEmpty(rawScheduleItem.EntryDate) ? null : DateOnly.Parse(rawScheduleItem.EntryDate),
                        Notes = rawScheduleItem.EntryText.FindAll(_ => _.Contains("NOTE")),
                        RegistrationDateAndPlanRef = entryText.GetValueOrDefault("RegistrationDateAndPlanRef"),
                        LesseesTitle = entryText.GetValueOrDefault("LesseesTitle"),
                        PropertyDescription = entryText.GetValueOrDefault("PropertyDescription"),
                        DateOfLeaseAndTerm = entryText.GetValueOrDefault("DateOfLeaseAndTerm")
                    };
                    parsedSchedule.Add(schedule);
                });
            return parsedSchedule;
        }

        private Dictionary<string, string> ParseEntryText(List<string> entryText)
        {

            var res = new Dictionary<string, string>();
            var registrationDateAndPlanRef = new List<string>();  
            var lesseesTitle = new List<string>();
            var propertyDescription = new List<string>();
            var dateOfLeaseAndTerm = new List<string>();

            entryText.ForEach(s =>
            {
                if (!s.Contains("NOTE"))
                {
                    String[] rawdata = Regex.Split(s, @" {3,8}");

                    var text = string.Join(",", rawdata).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    registrationDateAndPlanRef.Add(text.Length >= 0 ? text[0].Trim() : "");
                    propertyDescription.Add(text.Length > 1 ? text[1].Trim() : "");
                    dateOfLeaseAndTerm.Add(text.Length > 2 ? text[2].Trim() : "");
                    lesseesTitle.Add(text.Length > 3 ? text[3].Trim() : "");
                }
            });

            lesseesTitle.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            propertyDescription.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            registrationDateAndPlanRef.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            dateOfLeaseAndTerm.RemoveAll(s => string.IsNullOrWhiteSpace(s));

            res.Add("RegistrationDateAndPlanRef", String.Join(", ", registrationDateAndPlanRef.ToArray()));
            res.Add("LesseesTitle",  String.Join(", ", lesseesTitle.ToArray()));
            res.Add("PropertyDescription", String.Join(", ", propertyDescription.ToArray()));
            res.Add("DateOfLeaseAndTerm", String.Join(", ", dateOfLeaseAndTerm.ToArray()));

            return res;
        }
    }
}
