using Core.Application.Features.LeaveType.Commands.CreateLeaveType;
using Core.Application.Features.LeaveType.Commands.DeleteLeaveType;
using Core.Application.Features.LeaveType.Commands.UpdateLeaveType;
using Core.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Core.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetAllLeaveTypesQueryResult> GetAllLeaveTypes()
    {
        var leaveTypes = await _mediator.Send(new GetAllLeaveTypesQuery());
        return leaveTypes;
    }

    [HttpGet("{uid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<GetLeaveTypeDetailsQueryResult> GetLeaveTypeDetails(Guid uid)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(uid));
        return leaveType;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CreateLeaveTypeCommandResult>> Post(CreateLeaveTypeCommand leaveTypeCommand)
    {
        var response = await _mediator.Send(leaveTypeCommand);
        
        return response;
    }

    [HttpPut("{uid}")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UpdateLeaveTypeCommandResult>> Put(UpdateLeaveTypeCommand leaveTypeCommand)
    {
        var result = await _mediator.Send(leaveTypeCommand);
        return Ok(result);
    }

    [HttpDelete("{uid}")]
    public async Task<ActionResult<DeleteLeaveTypeCommandResult>> Delete(DeleteLeaveTypeCommand leaveTypeCommand)
    {
        var result = await _mediator.Send(leaveTypeCommand);
        return Ok(result);
    }
}
