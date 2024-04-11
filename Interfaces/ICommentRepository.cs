using start.Dtos.Comment;
using start.Models;

namespace start.Interfaces
{
  public interface ICommentRepository 
  {
    Task<List<Comment>> GetAllAsync();

    Task<Comment?> GetByIdAsync(int id);

    Task<Comment> CreateAsync(Comment comment);

    Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateDto);

    Task<Comment?> DeleteAsync(int id);      
  }
}