using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Queries;

public class GetMembersQuery : IRequest<IEnumerable<Member>>
{
}
