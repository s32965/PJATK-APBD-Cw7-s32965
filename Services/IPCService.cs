using Cw7.DTOs;

namespace Cw7.Services;

public interface IPCService
{
    Task<IEnumerable<PCListResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcComponentResponse> GetComponentsById(int id, CancellationToken cancellationToken);
    Task<PCListResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCListResponse> AddAsync(CreatePCRequest request, CancellationToken cancellationToken);
}