using Information_system_i_ASP.Net.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

public class IdentitySeeder
{
    public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<Employee>>();
        var logger = serviceProvider.GetRequiredService<ILogger<IdentitySeeder>>();

        // Definiera rollerna som ska seedas
        string[] roleNames = { "Admin", "Employee" };

        // Seed roller
        foreach (var roleName in roleNames)
        {
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (roleResult.Succeeded)
                {
                    logger.LogInformation($"Role '{roleName}' created successfully.");
                }
                else
                {
                    logger.LogError($"Error creating role '{roleName}': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                }
            }
        }

        // Seed användare som matchar ResponsibleEmployee från AppDbContext data
        await CreateEmployeeIfNotExists(userManager, logger, "admin@example.com", "Admin User", "Admin@12345", "Admin");
        await CreateEmployeeIfNotExists(userManager, logger, "chris.allen@example.com", "Chris Allen", "ChrisAllen@12345", "Employee");
        await CreateEmployeeIfNotExists(userManager, logger, "logistics.admin@example.com", "Logistics Admin", "LogisticsAdmin@12345", "Admin");
        await CreateEmployeeIfNotExists(userManager, logger, "sara.lee@example.com", "Sara Lee", "SaraLee@12345", "Employee");
        await CreateEmployeeIfNotExists(userManager, logger, "patrick.hill@example.com", "Patrick Hill", "PatrickHill@12345", "Employee");
        await CreateEmployeeIfNotExists(userManager, logger, "nancy.green@example.com", "Nancy Green", "NancyGreen@12345", "Employee");
        await CreateEmployeeIfNotExists(userManager, logger, "mark.stevenson@example.com", "Mark Stevenson", "MarkStevenson@12345", "Employee");
        await CreateEmployeeIfNotExists(userManager, logger, "laura.knight@example.com", "Laura Knight", "LauraKnight@12345", "Employee");
    }

    private static async Task CreateEmployeeIfNotExists(UserManager<Employee> userManager, ILogger logger, string email, string name, string password, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user != null)
        {
            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
            }
            logger.LogInformation($"User '{email}' already exists. Resetting password.");
            await ResetUserPassword(userManager, user, password);
            await EnsureUserRole(userManager, user, role);
        }
        else
        {
            user = new Employee
            {
                UserName = email,
                Email = email,
                Name = name,
                EmailConfirmed = true,
                NormalizedEmail = email.ToUpperInvariant(),
                NormalizedUserName = email.ToUpperInvariant()
            };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await EnsureUserRole(userManager, user, role);
                logger.LogInformation($"User '{email}' created successfully and assigned to role '{role}'.");
            }
            else
            {
                logger.LogError($"Error creating user '{email}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }

    private static async Task ResetUserPassword(UserManager<Employee> userManager, Employee user, string newPassword)
    {
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var result = await userManager.ResetPasswordAsync(user, token, newPassword);

        if (!result.Succeeded)
        {
            throw new Exception($"Failed to reset password: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    private static async Task EnsureUserRole(UserManager<Employee> userManager, Employee user, string role)
    {
        var roles = await userManager.GetRolesAsync(user);
        if (!roles.Contains(role))
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}

