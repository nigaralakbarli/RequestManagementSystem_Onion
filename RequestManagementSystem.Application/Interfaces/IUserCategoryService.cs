using RequestManagementSystem.Application.DTOs.UserCtegory.Request;
using RequestManagementSystem.Application.DTOs.UserCtegory.Response;

namespace RequestManagementSystem.Application.Interfaces;

public interface IUserCategoryService
{
    List<UserCategoryResponseDTO> GetUserCategories();
    List<UserCategoryResponseDTO> GetByUserId(int userId);
    bool CreateUserCategory(UserCategoryRequestDTO userCategoryRequestDTO);
    bool DeleteUserCategory(int id);
    bool UpdateUserCategory(UserCategoryRequestDTO userCategoryRequestDTO);

}
