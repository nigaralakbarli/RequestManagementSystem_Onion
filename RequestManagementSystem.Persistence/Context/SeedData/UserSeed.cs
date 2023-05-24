using RequestManagementSystem.Domain.Entities;

namespace RequestManagementSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static List<User> SeedUser()
        {
            List<User> users = new List<User>()
            {
                new User 
                { 
                    Id = 1, 
                    Name = "Nigar", 
                    Password = "nigar123", 
                    InternalNumber = "123456", 
                    ContactNumber = "+995 551234567", 
                    AllowNotification = true, 
                    Role = "Admin", 
                    DepartmentId = 1, 
                    Position = "meslehetci" 
                },
                new User
                {
                    Id = 2,
                    Name = "Ferec",
                    Password = "ferec123",
                    InternalNumber = "123456",
                    ContactNumber = "+995 551234567",
                    AllowNotification = true, 
                    Role = "User",
                    DepartmentId = 2,
                    Position = "meslehetci"
                }
            };

            return users;
        }
    }
}
