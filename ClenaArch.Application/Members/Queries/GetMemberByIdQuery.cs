using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Queries;

public class GetMemberByIdQuery : IRequest<Member>
{
    public int Id { get; set; }
}
