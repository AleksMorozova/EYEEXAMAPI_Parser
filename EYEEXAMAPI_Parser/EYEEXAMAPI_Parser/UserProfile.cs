using AutoMapper;
using EYEEXAMAPI_Parser.Model;

namespace EYEEXAMAPI_Parser
{
    public class ScheduleProfile : Profile
    {
        // This can be used to automate some mapping
        public ScheduleProfile()
        {
            CreateMap<RawScheduleNoticeOfLease, ParsedScheduleNoticeOfLease>()
                .ForMember(x => x.EntryDate, opt => opt.Ignore())
                .ForMember(x => x.RegistrationDateAndPlanRef, opt => opt.Ignore())
                .ForMember(x => x.PropertyDescription, opt => opt.Ignore())
                .ForMember(x => x.LesseesTitle, opt => opt.MapFrom(src => GetLesseesTitle(src.EntryText)))
                .ForMember(x => x.EntryNumber, opt => opt.MapFrom(src => src.EntryNumber))
                .ForMember(x => x.DateOfLeaseAndTerm, opt => opt.MapFrom(src => "DateOfLeaseAndTerm"))
                .ForMember(x => x.Notes, opt => opt.MapFrom(src => GetNotes(src.EntryText)));
        }

        private string GetLesseesTitle(List<string> res)
        {
            return ""; 
        }
        private List<string> GetNotes(List<string> res)
        {
            return res.FindAll(_ => _.Contains("NOTE"));
        }
    }
}
