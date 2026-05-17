using Cw7.DTOs;

namespace Cw7.Services;

public interface IPCService
{
    Task<IEnumerable<PCListResponse>> GetAllAsync(CancellationToken cancellationToken);
}