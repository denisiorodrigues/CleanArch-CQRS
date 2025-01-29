using ClenaArch.Domain.Entities;

namespace ClenaArch.Domain.Abstraction;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllMembersAsync();
    Task<Member> GetMemberByIdAsync(int id);
    Task<Member> AddMemberAsync(Member member);
    Task<Member> UpdateMemberAsync(Member member);
    Task<Member> DeleteMemberAsync(int id);
}
