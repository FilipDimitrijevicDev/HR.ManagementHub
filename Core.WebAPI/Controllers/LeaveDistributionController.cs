using Core.Application.Features.LeaveDistribution.Commands.CreateLeaveDistribution;
using Core.Application.Features.LeaveDistribution.Commands.DeleteLeaveDistribution;
using Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;
using Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;
using Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Core.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveDistributionController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveDistributionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<GetLeaveDistributionDetailsQueryResult>> GetLeaveDistributionDetailsAsync(Guid uid)
    {
        var leaveDistributionDetails = await _mediator.Send(new GetLeaveDistributionDetailsQuery { Uid = uid });
        return Ok(leaveDistributionDetails);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetLeaveDistributionsQuery>> GetLeaveDistributionsAsync()
    {
        var leaveDistributions = await _mediator.Send(new GetLeaveDistributionsQuery());
        return Ok(leaveDistributions);
    }

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public async Task<ActionResult<CreateLeaveDistributionCommandResult>> CreateLeaveDistributionAsync(CreateLeaveDistributionCommand leaveDistributionCommand)
    {
        var result = await _mediator.Send(leaveDistributionCommand);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UpdateLeaveDistributionCommandResult>> UpdateLeaveDistributionAsync(UpdateLeaveDistributionCommand LeaveDistributionCommand)
    {
        await _mediator.Send(LeaveDistributionCommand);
        return Ok(LeaveDistributionCommand);
    }

    [HttpDelete("{uid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid uid)
    {
        var command = new DeleteLeaveDistributionCommand { Uid = uid };
        await _mediator.Send(command);
        return Ok(command);
    }
}
