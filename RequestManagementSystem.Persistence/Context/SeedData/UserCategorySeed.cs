using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.Persistence.Context.SeedData;

public static partial class DataSeeder
{
    public static List<UserCategory> SeedUserCateory()
    {
        List<UserCategory> userCategories = new List<UserCategory>()
            {
                new UserCategory()
                {
                    Id = 1,
                    UserId = 1,
                    CategoryId = 1,
                    IsCreatable = true,
                    IsExecutable = true,
                },
                new UserCategory()
                {
                    Id = 2,
                    UserId = 1,
                    CategoryId = 2,
                    IsCreatable = true,
                    IsExecutable = true,
                },
                new UserCategory()
                {
                    Id = 3,
                    UserId = 1,
                    CategoryId = 3,
                    IsCreatable = true,
                    IsExecutable = true,
                },
                new UserCategory()
                {
                    Id = 4,
                    UserId = 1,
                    CategoryId = 3,
                    IsCreatable = true,
                    IsExecutable = true,
                },
                new UserCategory()
                {

                    Id = 5,
                    UserId = 1,
                    CategoryId = 5,
                    IsCreatable = true,
                    IsExecutable = true,
                },
                new UserCategory()
                {
                    Id = 6,
                    UserId = 2,
                    CategoryId = 1,
                    IsCreatable = true,
                    IsExecutable = true,
                },
                new UserCategory()
                {
                    Id = 7,
                    UserId = 2,
                    CategoryId = 2,
                    IsCreatable = true,
                    IsExecutable = true,
                }
            };

        return userCategories;
    }
}
