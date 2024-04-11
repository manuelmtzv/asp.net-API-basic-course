using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using start.Data;
using start.Dtos.Stock;
using start.Interfaces;
using start.Models;

namespace start.Repositories
{
    public class StockRepository(ApplicationDBContext context) : IStockRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(stock => stock.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {   
            var stockModel = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(stock => stock.Id == id);

            if (stockModel == null) return null;

            return stockModel;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }


        public async Task<Stock?> UpdateAsync(int id, Stock stock)
        {
            var stockModel = _context.Stocks.Find(id);

            if (stockModel == null) return null;

            stockModel.Symbol = stock.Symbol;
            stockModel.CompanyName = stock.CompanyName;
            stockModel.Purchase = stock.Purchase;
            stockModel.LastDiv = stock.LastDiv;
            stockModel.Industry = stock.Industry;
            stockModel.MarketCap = stock.MarketCap;          

            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FindAsync(id);

            if (stockModel == null) return null;

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }        

        public async Task<bool> StockExistsAsync(int id)
        {
            return await _context.Stocks.AnyAsync(stock => stock.Id == id);
        }
    }
}