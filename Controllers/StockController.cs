using System;
using Microsoft.AspNetCore.Mvc;
using start.Data;
using start.Dtos.Stock;
using start.Interfaces;
using start.Mappers;
using start.QueryObjects;

namespace start.Controllers
{
    [Route("/stocks")]
    [ApiController]
    public class StockController(ApplicationDBContext context, IStockRepository stockRepository) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;
        private readonly IStockRepository _stockRepository = stockRepository;

        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery] StockQueryObject queryObject)
        {
            var stocks = await _stockRepository.GetAllAsync(queryObject); 

            return Ok(stocks.Select(stock => stock.ToStockDto()));
        }

        [HttpGet("{id:int}")]
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateDto) 
        {
            var stockModel = await _stockRepository.UpdateAsync(id, updateDto.ToStockFromUpdateDto());

            if (stockModel == null) return NotFound();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepository.DeleteAsync(id);

            if (stockModel == null) return NotFound();

            return NoContent();
        }
    }
}