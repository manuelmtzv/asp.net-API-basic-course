using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using start.Dtos.Comment;
using start.Models;

namespace start.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                StockId = comment.StockId
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentDto createCommentDto, int stockId)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = stockId
            };
        }

        public static Comment ToCommentFromUpdateDto(this UpdateCommentDto UpdateCommentDto)
        {
            return new Comment
            {
                Title = UpdateCommentDto.Title,
                Content = UpdateCommentDto.Content,
            };
        }
    }
}