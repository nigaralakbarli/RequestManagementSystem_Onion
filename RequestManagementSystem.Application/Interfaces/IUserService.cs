using RequestManagementSystem.Application.DTOs.User.Request;
using RequestManagementSystem.Application.DTOs.User.Response;
using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.Application.Interfaces;

public interface IUserService
{
    ICollection<UserResponseDTO> GetUsers();
    UserResponseDTO GetUserById(int userId);
    bool CreateUser(UserCreateDTO userCreateDTO);
    bool DeleteUser(int userId);
    bool UpdateUser(UserUpdateDTO userUpdateDTO);
    public void ChangePhoto(User user);
    User GetCurrentUser();
    string ChangePassword(string oldPassword, string newPassword, string repeatedPassword);
    void AddUserCategory(UserCategoryCreateDTO userCategory);
}
