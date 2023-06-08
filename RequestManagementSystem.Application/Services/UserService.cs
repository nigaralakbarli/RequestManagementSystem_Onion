using AutoMapper;
using Microsoft.AspNetCore.Http;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.DTOs.User.Request;
using RequestManagementSystem.Application.DTOs.User.Response;
using RequestManagementSystem.Application.Helper.FileHelper;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace RequestManagementSystem.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserCategoryRepository _userCategoryRepository;

    public UserService(
        IMapper mapper,
        IUserRepository userRepository, 
        IFileService fileService, 
        IHttpContextAccessor httpContextAccessor,
        IUserCategoryRepository userCategoryRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _fileService = fileService;
        _httpContextAccessor = httpContextAccessor;
        _userCategoryRepository = userCategoryRepository;
    }


    public ICollection<UserResponseDTO> GetUsers()
    {
        return _mapper.Map<List<UserResponseDTO>>(_userRepository.GetAll());
    }

    public UserResponseDTO GetUserById(int userId)
    {
        return _mapper.Map<UserResponseDTO>(_userRepository.GetById(userId));
    }

    public bool CreateUser(UserCreateDTO userCreateDTO)
    {
        var user = _userRepository.Find(c => c.Name.Trim().ToUpper() == userCreateDTO.Name.TrimEnd().ToUpper());
        if (user != null)
        {
            var mapped = _mapper.Map<User>(userCreateDTO);
            _userRepository.Add(mapped);
            return true;
        }
        return false;
    }

    public bool DeleteUser(int userId)
    {
        var user = _userRepository.GetById(userId);
        if (user != null)
        {
            _userRepository.Remove(user);
            return true;
        }
        return false;
    }

    public bool UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        var user = _userRepository.GetById(userUpdateDTO.Id);
        if (user != null)
        {
            var mapped = _mapper.Map<User>(userUpdateDTO);
            _userRepository.Update(mapped);
            return true;
        }
        return false;
    }

    public void ChangePhoto(User user)
    {
        if (_fileService.IsImage(user.Image))
        {
            _fileService.Delete(user.ImagePath, "img");
            user.ImagePath = _fileService.Upload(user.Image, "img");
            _userRepository.Update(user);
        }
    }

    public User GetCurrentUser()
    {
        var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        return _userRepository.Find(u => u.Id == userId).FirstOrDefault();
    }
    public string ChangePassword(string oldPassword, string newPassword, string repeatedPassword)
    {
        var user = GetCurrentUser();
        string pattern = "^(?=.*[A-Z])(?=.*\\W).{8,}$";

        if (user.Password == oldPassword)
        {
            if (Regex.IsMatch(newPassword, pattern))
            {
                if (newPassword == repeatedPassword)
                {
                    user.Password = newPassword;
                    _userRepository.Update(user);
                    return "Password updated successfully";
                }
                else
                {
                    return "Repeated password doesn't match with new password";
                }

            }
            else
            {
                return "Password must be at least 8 characters long, contain at least one uppercase letter, and one special character.";
            }
        }
        else
        {
            return  "Incorrect old password";
        }
    }
    public void AddUserCategory(UserCategoryCreateDTO userCategory)
    {
        var mapped = _mapper.Map<UserCategory>(userCategory);
        _userCategoryRepository.Add(mapped);
    }
}
