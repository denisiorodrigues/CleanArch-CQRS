using ClenaArch.Domain.Abstraction;
using ClenaArch.Infrastructure.Context;

namespace ClenaArch.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IMemberRepository? _memberRepository;
    private readonly AppDbContext _context;

    public UnitOfWork( AppDbContext context)
    {
        _context = context;
    }

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository ??= new MemberRepository(_context);
        }
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
