using Microsoft.EntityFrameworkCore;
using XBridge.Data.Database;
using XBridge.Service.Interface;

namespace XBridge.Service;

public class GetEntriesForTodayService : IGetEntriesForTodayService
{
    
    private readonly BridgeDbContext _dbContext;
    
    public GetEntriesForTodayService(BridgeDbContext db)
    {
        _dbContext = db;
    }

    public async Task<List<Message>> GetEntriesForToday()
    {
        return await _dbContext.Message
            .Include(m => m.Project)          
            .OrderBy(m => m.CreatedAt)        
            .ToListAsync();
    }
}