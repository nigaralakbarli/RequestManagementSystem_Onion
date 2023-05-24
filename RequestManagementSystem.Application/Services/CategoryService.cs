using AutoMapper;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Category.Response;
using RequestManagementSystem.Application.DTOs.Department.Request;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;

namespace RequestManagementSystem.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserCategoryRepository _userCategoryRepository;
    private readonly IUserService _userService;

    public CategoryService(
        IMapper mapper,
        ICategoryRepository categoryRepository,
        IUserCategoryRepository userCategoryRepository,
        IUserService userService)
    {
        _userCategoryRepository = userCategoryRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _userService = userService;
    }

    public List<CategoryResponseDTO> GetCategories()
    {
        var user = _userService.GetCurrentUser();
        var userCategories = _userCategoryRepository
            .Find(uc => uc.UserId == user.Id)
            .Where(uc => uc.IsCreatable == true)
            .Select(n => n.CategoryId).ToList();

        var categories = _categoryRepository
            .Find(c => userCategories.Contains(c.Id)).ToList();

        return _mapper.Map<List<CategoryResponseDTO>>(categories);
    }

    public CategoryResponseDTO GetCategoryById(int categoryId)
    {
        return _mapper.Map<CategoryResponseDTO>(_categoryRepository.GetById(categoryId));
    }

    public bool CreateCategory(CategoryRequestDTO categoryRequestDTO)
    {
        var category = _categoryRepository
            .Find(c => c.Name.Trim().ToUpper() == categoryRequestDTO.Name.TrimEnd().ToUpper());
        if(category != null) 
        {
            var mapped = _mapper.Map<Category>(categoryRequestDTO);
            _categoryRepository.Add(mapped);
            return true;
        }
        return false;
    }

    public bool UpdateCategory(CategoryRequestDTO categoryRequestDTO)
    {
        var category = _categoryRepository.GetById(categoryRequestDTO.Id);
        if (category != null)
        {
            var mapped = _mapper.Map<Category>(categoryRequestDTO);
            _categoryRepository.Update(mapped);
            return true;
        }
        return false;
    }

    public bool DeleteCategory(int categoryId)
    {
        var category = _categoryRepository.GetById(categoryId);
        if (category != null)
        {
            _categoryRepository.Remove(category);
            return true;
        }
        return false;
    }
}
