using EYEEXAMAPI_Parser.Model;
using Microsoft.Extensions.Caching.Memory;

namespace EYEEXAMAPI_Parser.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IMemoryCache _cache;
        public ScheduleService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public async Task<List<RawScheduleNoticeOfLease>> GetRawSchedule()
        {
            // TODO: cache key be stored in the appsettings
            if (!_cache.TryGetValue("RawSchedule", out List<RawScheduleNoticeOfLease> rawSchedule))
            {            
                // TODO: base url should be stored in the appsettings
                var client = HttpClientFactory.CreateClient("https://localhost:7203/");

                HttpResponseMessage response = await client.GetAsync("schedules");

                rawSchedule = await response.Content.ReadFromJsonAsync<List<RawScheduleNoticeOfLease>>();
                
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };

                // TODO: cache should be invalidate after updating of schedules
                _cache.Set("RawSchedule", rawSchedule, cacheEntryOptions);
            }

            return rawSchedule;
        }
    }
}
