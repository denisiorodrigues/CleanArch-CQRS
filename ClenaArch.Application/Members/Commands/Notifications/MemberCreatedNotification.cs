using ClenaArch.Domain.Entities;
using MediatR;

namespace ClenaArch.Application.Members.Commands.Notifications;

public class MemberCreatedNotification : INotification
{
    public MemberCreatedNotification(Member member)
    {
        Member = member;
    }
    
    public Member Member { get; }
}
