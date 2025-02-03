using ClenaArch.Application.Members.Commands;
using ClenaArch.Application.Members.Queries;
using ClenaArch.Domain.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClenaArch.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet] //Queries
    public async Task<IActionResult> GetMembers()
    {
        var query = new GetMembersQuery();
        var members = await _mediator.Send(query);

        return members != null ? Ok(members) : NotFound();
    }

    [HttpGet("{id}")] //Queries
    public async Task<IActionResult> GetMembers(int id)
    {
        var query = new GetMemberByIdQuery() { Id = id };

        var member = await _mediator.Send(query);

        return member != null ? Ok(member) : NotFound("Member not found");
    }

    [HttpPost] //Commands
    public async Task<IActionResult> CreateMember(CreateMemberCommand command)
    {
        var member = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetMembers), new { id = member.Id }, member);
    }

    [HttpPut("{id}")]// Commands
    public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
    {
        command.Id = id;

        var updateMember = await _mediator.Send(command);

        return updateMember != null ? Ok(updateMember) : NotFound("Member not found");
    }

    [HttpDelete()] //Commands
    public async Task<IActionResult> DeleteMember(DeleteMemberCommand command)
    {
        var member = _mediator.Send(command);

        return member != null ? Ok(member) : NotFound("Member not found");
    }
}
