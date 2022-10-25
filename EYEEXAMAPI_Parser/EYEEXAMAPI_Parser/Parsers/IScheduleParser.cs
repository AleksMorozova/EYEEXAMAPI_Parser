using EYEEXAMAPI_Parser.Model;

namespace EYEEXAMAPI_Parser.Parsers
{
    public interface IScheduleParser
    {
        public List<ParsedScheduleNoticeOfLease> Parse(List<RawScheduleNoticeOfLease> rawSchedule);
    }
}
