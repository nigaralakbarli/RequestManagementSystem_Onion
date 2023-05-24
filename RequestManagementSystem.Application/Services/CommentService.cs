using AutoMapper;
using RequestManagementSystem.Application.DTOs.Comment.Request;
using RequestManagementSystem.Application.DTOs.Comment.Response;
using RequestManagementSystem.Application.Helper.FileHelper;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IAuthService _authService;

    public CommentService(
        ICommentRepository commentRepository,
        IMapper mapper,
        IFileService fileService,
        IAuthService authService)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _fileService = fileService;
        _authService = authService;
    }
    public void Create(CommentRequestDTO commentRequestDTO)
    {

        var comment = _mapper.Map<Comment>(commentRequestDTO);
        if (comment.FileUpload != null && comment.FileUpload.Length > 0)
        {
            comment.FileUploadPath = _fileService.Upload(comment.FileUpload, "Comment");
        }
        comment.UserId = _authService.GetCurrentUser().Id;
        _commentRepository.Add(comment);
    }

    public List<CommentResponseDTO> GetAll(int requestId)
    {
        var comments = _commentRepository.Find(c => c.RequestId == requestId).ToList();
        return _mapper.Map<List<CommentResponseDTO>>(comments);
    }

    public CommentResponseDTO GetLast(int requestId)
    {
        var comment = _commentRepository.Find(c => c.RequestId == requestId).OrderByDescending(c => c.Id).FirstOrDefault();
        return _mapper.Map<CommentResponseDTO>(comment);
    }
}
