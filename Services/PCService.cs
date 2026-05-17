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

    public async Task<PCListResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCListResponse(
                   pc.Id,
                   pc.Name,
                   pc.Weight,
                   pc.Warranty,
                   pc.CreatedAt,
                   pc.Stock
                   )).FirstOrDefaultAsync(cancellationToken) 
            ?? throw new NotFoundException($"PC with id: {id} not found");
    }

    public async Task<PCListResponse> AddAsync(CreatePCRequest request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new PCListResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(pc => pc.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Name, request.Name)
                    .SetProperty(e => e.Weight, request.Weight)
                    .SetProperty(e => e.Warranty, request.Warranty)
                    .SetProperty(e => e.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
        
        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}