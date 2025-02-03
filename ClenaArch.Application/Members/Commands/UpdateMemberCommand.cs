using ClenaArch.Application.Abstractions;

namespace ClenaArch.Application.Members.Commands;

public sealed class UpdateMemberCommand : MemberCommandBase
{
    public int Id { get; set; }
}
