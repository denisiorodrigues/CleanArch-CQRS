using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Commands;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberByIdAsync(request.Id);
        
        if (member is null)
        {
            throw new InvalidOperationException($"Member with id {request.Id} not found");
        }

        member.Update(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);
        _unitOfWork.MemberRepository.UpdateMemberAsync(member);
        await _unitOfWork.CommitAsync();

        return member;
    }
}
