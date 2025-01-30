using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Commands;

public class DeleteMemberCommand : IRequest<Member>
{
    public int Id { get; set; }
}
