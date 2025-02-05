using ClenaArch.Application.Members.Commands.Notifications;
using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace ClenaArch.Application.Members.Commands;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;
    //Validação feita no pipeline
    //private readonly IValidator<CreateMemberCommand> _validator;
    IMediator _mediator;

    public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateMemberCommand> validator, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        //_validator = validator;
    }

    public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        //_validator.ValidateAndThrow(request);

        var newMember =  new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

        await _unitOfWork.MemberRepository.AddMemberAsync(newMember);
        await _unitOfWork.CommitAsync();

        await _mediator.Publish(new MemberCreatedNotification(newMember), cancellationToken);

        return newMember;
    }
}
