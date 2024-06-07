using HR.ManagementHub.BlazorUI.Common.Interfaces;
using HR.ManagementHub.BlazorUI.Models.LeaveTypes;
using AutoMapper;

namespace HR.ManagementHub.BlazorUI.Services.Base;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly IMapper _mapper;

    public LeaveTypeService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }
    public async Task<LeaveTypeVM> GetLeaveTypeDetails(Guid uid)
    {
        var leaveType = await _client.LeaveTypesGET2Async(uid);
        return _mapper.Map<LeaveTypeVM>(leaveType);
    }

    public async Task<List<LeaveTypeVM>> GetLeaveTypes()
    {
        var leaveTypes = await _client.LeaveTypesGETAsync();
        var leaveTypeVMs = _mapper.Map<List<LeaveTypeVM>>(leaveTypes.LeaveTypeDto);
        return leaveTypeVMs;
    }

    public async Task<CreateLeaveTypeCommandResult> CreateLeaveType(LeaveTypeVM leaveType)
    {
        try
        {
            var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
            await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);
            return new CreateLeaveTypeCommandResult();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Response<Guid>> UpdateLeaveType(Guid uid, LeaveTypeVM leaveType)
    {
        try
        {
            var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
            await _client.LeaveTypesPUTAsync(uid.ToString(), updateLeaveTypeCommand);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex )
        {

            throw;
        }
    }

    public Task<Response<Guid>> DeleteLeaveType(Guid uid)
    {
        throw new NotImplementedException();
    }
}
