using AutoMapper;
using HR.ManagementHub.BlazorUI.Models.LeaveTypes;
using HR.ManagementHub.BlazorUI.Services.Base;

namespace HR.ManagementHub.BlazorUI.Common.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
        }
    }
}
