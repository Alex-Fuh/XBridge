using XBridge.Data.Database;

namespace XBridge.Service.Interface;

public interface IMessageQueryService
{
    public Task<List<Message>> GetEntriesForToday();
}