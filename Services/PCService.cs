using Microsoft.EntityFrameworkCore;
using Cw7.Infrastructure;
using Cw7.Models;
using Cw7.DTOs;
using Cw7.Excepetions;

namespace Cw7.Services;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCListResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCListResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
            )).ToListAsync(cancellationToken);
    }

    public async Task<PcComponentResponse> GetComponentsById(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
                   .Where(e => e.Id == id)
                   .Select(pc => new PcComponentResponse(
                       pc.Id,
                       pc.Name,
                       pc.Weight,
                       pc.Warranty,
                       pc.CreatedAt,
                       pc.Stock,
                       pc.PCComponents.Select(pcc => new ComponentListResponse(
                           pcc.Amount,
                           // Note: Since your DTO expects an ICollection here, we wrap the single component in a List.
                           // (See the "Pro-Tip" below)
                           new List<ComponentResponse> 
                           {
                               new ComponentResponse(
                                   pcc.Component.Code,
                                   pcc.Component.Name,
                                   pcc.Component.Description,
                                   new ManufacturerResponse(
                                       pcc.Component.ComponentManufacturer.Id,
                                       pcc.Component.ComponentManufacturer.Abbreviation,
                                       pcc.Component.ComponentManufacturer.FullName,
                                       pcc.Component.ComponentManufacturer.FoundationDate
                                   ),
                                   new TypeResponse(
                                       pcc.Component.ComponentType.Id,
                                       pcc.Component.ComponentType.Abbreviation,
                                       pcc.Component.ComponentType.Name
                                   )
                               )
                           }
                       )).ToList()
                   )).FirstOrDefaultAsync(cancellationToken) 
               ?? throw new NotFoundException($"PC with id: {id} not found");
    }
}