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
    public class CommentController(ICommentRepository commentRepository): ControllerBase
    {
        private readonly ICommentRepository _commentRepository = commentRepository;

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

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto createCommentDto)
        {
            var comment = createCommentDto.ToCommentFromCreateDto();
            await _commentRepository.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepository.UpdateAsync(id, updateCommentDto);
            if (comment == null) return NotFound();

            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentRepository.DeleteAsync(id);
            if (comment == null) return NotFound();

            return Ok(comment);
        }
    }
}