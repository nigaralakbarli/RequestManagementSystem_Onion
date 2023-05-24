using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Category.Response;

namespace RequestManagementSystem.Application.Interfaces;

public interface ICategoryService
{
    List<CategoryResponseDTO> GetCategories();
    CategoryResponseDTO GetCategoryById(int categoryId);
    bool CreateCategory(CategoryRequestDTO categoryRequestDTO);
    bool UpdateCategory(CategoryRequestDTO categoryRequestDTO);
    bool DeleteCategory(int categoryId);
}
