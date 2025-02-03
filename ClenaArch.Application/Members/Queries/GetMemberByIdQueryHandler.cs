using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Queries;

public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Member>
{
    private readonly IMemberDapperRepository _memberDapperRepository;

    public GetMemberByIdQueryHandler(IMemberDapperRepository memberDapperRepository)
    {
        _memberDapperRepository = memberDapperRepository;
    }

    public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await _memberDapperRepository.GetMemberByIdAsync(request.Id);
        return member;
    }
}
