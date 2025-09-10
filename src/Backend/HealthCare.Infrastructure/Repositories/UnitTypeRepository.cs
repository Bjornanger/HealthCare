using HealthCare.Application.Interfaces.RepositoryInterfaces;
using HealthCare.Domain.Models;
using HealthCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructure.Repositories;

public class UnitTypeRepository : IUnitTypeRepository
{
    private readonly ApplicationDbContext _context;

    public UnitTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<UnitType>> GetAllAsync()
    {
       return await _context.UnitTypes.ToListAsync();
    }

    public async Task<UnitType?> GetByIdAsync(Guid id)
    {
        return await _context.UnitTypes.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UnitType> AddAsync(UnitType entity)
    {
        var newUnitType = await  _context.UnitTypes.AddAsync(entity);

        await _context.SaveChangesAsync();
        return newUnitType.Entity;

    }

    public async Task<bool> UpdateAsync(UnitType newUnitType, Guid oldUnitTypeId)
    {
        var unitTypeToUpdate = await _context.UnitTypes.FirstOrDefaultAsync(u => u.Id == oldUnitTypeId);

        if (unitTypeToUpdate != null)
        {
            unitTypeToUpdate.Name = newUnitType.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var successObject = await _context.UnitTypes.FirstOrDefaultAsync(u => u.Id == id);

        if (successObject != null)
        {
            _context.UnitTypes.Remove(successObject);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}