using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using start.Dtos.Stock;
using start.Models;

namespace start.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, Stock stock);

        Task<Stock?> DeleteAsync(int id);
        
        Task<bool> StockExistsAsync(int id);        
    }
}