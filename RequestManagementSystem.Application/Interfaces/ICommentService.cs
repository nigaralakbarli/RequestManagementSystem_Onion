using RequestManagementSystem.Application.DTOs.Comment.Request;
using RequestManagementSystem.Application.DTOs.Comment.Response;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.Application.Interfaces;

public interface ICommentService
{
    List<CommentResponseDTO> GetAll(int requestId);
    void Create(CommentRequestDTO commentRequestDTO);
    CommentResponseDTO GetLast(int requestId);
}
