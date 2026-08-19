using XBridge.Data.Database;

namespace XBridge.Service.Interface;

public interface IGetEntriesForTodayService
{
    public Task<List<Message>> GetEntriesForToday();
}