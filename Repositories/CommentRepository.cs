using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using start.Data;
using start.Dtos.Comment;
using start.Interfaces;
using start.Mappers;
using start.Models;

namespace start.Repositories
{
    public class CommentRepository(ApplicationDBContext context) : ICommentRepository
    {        
        private readonly ApplicationDBContext _context = context;

        public async Task<List<Comment>> GetAllAsync()
        {
            var comments = await _context.Comments.ToListAsync();

            return comments;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            return comment;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateDto)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null) return null;

            existingComment.Title = updateDto.Title;
            existingComment.Content = updateDto.Content;
            existingComment.CreatedAt = updateDto.CreatedAt;
            existingComment.StockId = updateDto.StockId;

            await _context.SaveChangesAsync();

            return existingComment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
    }
}