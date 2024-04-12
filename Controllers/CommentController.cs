using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comments = await _commentRepository.GetAllAsync();            

            return Ok(comments.Select(comment => comment.ToCommentDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
         public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto createCommentDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _stockRepository.StockExistsAsync(stockId)) return BadRequest("Stock does not exist.");

            var comment = createCommentDto.ToCommentFromCreateDto(stockId);
            await _commentRepository.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("{id}:int")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepository.UpdateAsync(id, updateCommentDto.ToCommentFromUpdateDto());
            if (comment == null) return NotFound(); 

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id}:int")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null) return NotFound();

            return NoContent();
        }
    }
}