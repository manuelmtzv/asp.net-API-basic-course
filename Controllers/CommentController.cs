using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using start.Dtos.Comment;
using start.Interfaces;
using start.Mappers;

namespace start.Controllers
{
    [Route("comments")]
    [ApiController]
    public class CommentController(ICommentRepository commentRepository, IStockRepository stockRepository): ControllerBase
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        private readonly IStockRepository _stockRepository = stockRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();            

            return Ok(comments.Select(comment => comment.ToCommentDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId}")]
         public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto createCommentDto)
        {
            if (!await _stockRepository.StockExistsAsync(stockId)) return BadRequest("Stock does not exist.");

            var comment = createCommentDto.ToCommentFromCreateDto(stockId);
            await _commentRepository.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepository.UpdateAsync(id, updateCommentDto.ToCommentFromUpdateDto());
            if (comment == null) return NotFound(); 

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null) return NotFound();

            return NoContent();
        }
    }
}