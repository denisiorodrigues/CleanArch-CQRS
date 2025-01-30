using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Commands;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberByIdAsync(request.Id);
        if (member is null)
        {
            throw new InvalidOperationException($"Member with id {request.Id} not found");
        }
        await _unitOfWork.MemberRepository.DeleteMemberAsync(member.Id);
        await _unitOfWork.CommitAsync();
        return member;
    }
}
