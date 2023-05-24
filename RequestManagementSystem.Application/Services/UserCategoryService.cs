using AutoMapper;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.UserCtegory.Request;
using RequestManagementSystem.Application.DTOs.UserCtegory.Response;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.Application.Services;

public class UserCategoryService : IUserCategoryService
{
    private readonly IUserCategoryRepository _userCategoryRepository;
    private readonly IMapper _mapper;

    public UserCategoryService(
        IUserCategoryRepository userCategoryRepository,
        IMapper mapper)
    {
        _userCategoryRepository = userCategoryRepository;
        _mapper = mapper;
    }

    public bool CreateUserCategory(UserCategoryRequestDTO userCategoryRequestDTO)
    {
        var userCategory = _userCategoryRepository
            .Find(uc=> uc.UserId == userCategoryRequestDTO.UserId && uc.CategoryId == userCategoryRequestDTO.CategoryId);
        if(userCategory != null)
        {
            var mapped = _mapper.Map<UserCategory>(userCategoryRequestDTO);
            _userCategoryRepository.Add(mapped);
            return true;
        }
        return false;
    }
    public List<UserCategoryResponseDTO> GetUserCategories()
    {
        return _mapper.Map<List<UserCategoryResponseDTO>>(_userCategoryRepository.GetAll());    
    }
    public List<UserCategoryResponseDTO> GetByUserId(int userId)
    {
        return _mapper.Map<List<UserCategoryResponseDTO>>(_userCategoryRepository.Find(uc=> uc.UserId == userId));
    }
    public bool DeleteUserCategory(int id)
    {
        var userCategory = _userCategoryRepository.GetById(id);
        if (userCategory != null)
        {
            _userCategoryRepository.Remove(userCategory);
            return true;
        }
        return false;
    }
    public bool UpdateUserCategory(UserCategoryRequestDTO userCategoryRequestDTO)
    {
        var userCategory = _userCategoryRepository.GetById(userCategoryRequestDTO.Id);
        if (userCategory != null)
        {
            var mapped = _mapper.Map<UserCategory>(userCategoryRequestDTO);
            _userCategoryRepository.Update(mapped);
            return true;
        }
        return false;
    }
}
