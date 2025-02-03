using ClenaArch.Domain.Abstraction;
using ClenaArch.Domain.Entities;
using Dapper;
using System.Data;

namespace ClenaArch.Infrastructure.Repositories;

public class MemberDapperRepository : IMemberDapperRepository
{
    private readonly IDbConnection _dbConnection;

    public MemberDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Member> GetMemberByIdAsync(int id)
    {
        string query = "SELECT * FROM members WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
    }

    public async Task<IEnumerable<Member>> GetMembersAsync()
    {
        string query = "SELECT * FROM Members";
        return await _dbConnection.QueryAsync<Member>(query);
    }
}
