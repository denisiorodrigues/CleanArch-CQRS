namespace ClenaArch.Domain.Abstraction;

public interface IUnitOfWork
{
    IMemberRepository MemberRepository { get; }
    Task<int> CommitAsync();
}
