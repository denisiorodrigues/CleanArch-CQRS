using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using ClenaArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClenaArch.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    protected readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Member> AddMemberAsync(Member member)
    {
        if (member == null)
            throw new ArgumentNullException(nameof(member));

        await _context.Members.AddAsync(member);
        return member;
    }

    public async Task<Member> DeleteMemberAsync(int id)
    {
        var member = await GetMemberByIdAsync(id);

        if (member == null)
            throw new ArgumentNullException("Member not found");

        _context.Members.Remove(member);

        return member;
    }

    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        var meberslist = await _context.Members.ToListAsync();
        return meberslist ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> GetMemberByIdAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
            throw new ArgumentNullException(nameof(member));

        return member;
    }

    public void UpdateMemberAsync(Member member)
    {
        if(member == null)
            throw new ArgumentNullException(nameof(member));

        _context.Members.Update(member);
    }
}
