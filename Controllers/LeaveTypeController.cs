using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Command;
using LeaveManagementApplication.Application.Features.LeaveTypeFeatures.Query;
using LeaveManagementApplication.Application.ViewModels.Leavetype;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LeaveManagementApplication.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveTypeController>
    [HttpGet("GetLeaveTypeList")]
    public async Task<List<LeaveTypeViewModel>> GetLeaveTypeList()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeListQuery());
        return leaveTypes;
    }

    [HttpGet("GetLeaveTypeDetail/{id}")]
    public async Task<ActionResult<LeaveTypeViewModel>> GetLeaveTypeDetail(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailQuery { Id = id });
        return leaveType;
    }

    // POST api/<LeaveTypeController>
    [HttpPost("CreateLeaveType")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateLeaveType( CreateLeaveTypeCommand leaveType)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var response = await _mediator.Send(leaveType);
        return CreatedAtAction(nameof(GetLeaveTypeList), new { id = response });
    }

    // PUT api/<LeaveTypeController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<LeaveTypeController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}