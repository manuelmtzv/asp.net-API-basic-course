using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using start.Data;
using start.Dtos.Stock;
using start.Interfaces;
using start.Mappers;
using start.Models;
using start.Repositories;

namespace start.Controllers
{
    [Route("/stocks")]
    [ApiController]
    public class StockController(ApplicationDBContext context, IStockRepository stockRepository) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;
        private readonly IStockRepository _stockRepository = stockRepository;

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync(); 

            return Ok(stocks.Select(stock => stock.ToStockDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null) return NotFound();

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto createDto) {
            var stockModel = await _stockRepository.CreateAsync(createDto.ToStockFromCreateDto());

            return CreatedAtAction(nameof (GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateDto) 
        {
            var stockModel = await _stockRepository.UpdateAsync(id, updateDto.ToStockFromUpdateDto());

            if (stockModel == null) return NotFound();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepository.DeleteAsync(id);

            if (stockModel == null) return NotFound();

            return NoContent();
        }
    }
}