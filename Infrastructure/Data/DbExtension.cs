using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class DbExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {

        var user = UserEntity.Create(
            "admin",
        "admin@gmail.com",
        BCrypt.Net.BCrypt.HashPassword("admin123"));
           
        var role = RoleEntity.Create("Admin");
        var userRole =  UserRoleEntity.Create(  user.Id ,  role.Id);

        modelBuilder.Entity<UserEntity>().HasData(
            user
        );
        modelBuilder.Entity<RoleEntity>().HasData(
            role
        );
        modelBuilder.Entity<UserRoleEntity>().HasData(
            userRole
        );
    }

}