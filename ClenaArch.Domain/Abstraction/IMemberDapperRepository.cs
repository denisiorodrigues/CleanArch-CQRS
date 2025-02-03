using ClenaArch.Domain.Entities;

namespace ClenaArch.Domain.Abstraction;

public interface IMemberDapperRepository
{
    Task<IEnumerable<Member>> GetMembersAsync();
    Task<Member> GetMemberByIdAsync(int id);
}
