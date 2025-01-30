using ClenaArch.Domain.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ClenaArch.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MembersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var members = await _unitOfWork.MemberRepository.GetAllMembersAsync();

        return members != null ? Ok(members) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMembers(int id)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberByIdAsync(id);

        return member != null ? Ok(member) : NotFound("Member not found");
    }
}
