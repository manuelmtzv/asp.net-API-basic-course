using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using start.Dtos.Stock;
using start.Models;
using start.QueryObjects;

namespace start.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(StockQueryObject queryObject);

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, Stock stock);

        Task<Stock?> DeleteAsync(int id);
        
        Task<bool> StockExistsAsync(int id);        
    }
}