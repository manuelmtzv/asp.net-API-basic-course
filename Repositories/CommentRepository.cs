using System;
using Microsoft.EntityFrameworkCore;
using start.Data;
using start.Dtos.Comment;
using start.Interfaces;
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

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
            var commentModel = await _context.Comments.FindAsync(id);
            if (commentModel == null) return null;

            commentModel.Title = comment.Title;
            commentModel.Content = comment.Content;

            await _context.SaveChangesAsync();

            return commentModel;
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