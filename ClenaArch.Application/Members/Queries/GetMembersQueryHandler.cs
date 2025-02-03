using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Queries;

public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
{
    private readonly IMemberDapperRepository _memberDapperRepository;

    public GetMembersQueryHandler(IMemberDapperRepository memberDapperRepository)
    {
        _memberDapperRepository = memberDapperRepository;
    }

    public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
    {
        var members = await _memberDapperRepository.GetMembersAsync();
        return members;
    }
}
