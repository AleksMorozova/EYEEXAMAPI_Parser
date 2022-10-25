using EYEEXAMAPI_Parser.Model;

namespace EYEEXAMAPI_Parser.Services
{
    public interface IScheduleService
    {
        public Task<List<RawScheduleNoticeOfLease>> GetRawSchedule();
    }
}
