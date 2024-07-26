using Backend.Database;
using Backend.Information;
using Backend.Models;
using Backend.Transfer.Auth;
using System.Security.Claims;

namespace Backend.Services.Auth;

public class RegisterRestaurentService : IServiceBase<RegisterData, ClaimsPrincipal>
{
    public ILogger Logger { get; }

    public AppDbContext DbContext { get; }

    public RegisterRestaurentService(AppDbContext dbContext, ILogger logger)
    {
        DbContext = dbContext;
        Logger = logger;
    }

    public async Task<ClaimsPrincipal> RunAsync(RegisterData data)
    {
        UserModel? user = DbContext.Users.FirstOrDefault(
            x => x.Email == data.Email);

        if (user is not null)
        {
            throw ApiException.BadRequest(
                "There already exists an account with this email!");
        }

        user = UserModel.CreateRestaurent(data);

        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();

        return user.CreatePrinciple();
    }
}

public class RegisterCustomerService : IServiceBase<RegisterData, ClaimsPrincipal>
{
    public ILogger Logger { get; set; }

    private AppDbContext DbContext { get; } 

    public RegisterCustomerService(AppDbContext dbContext, ILogger logger)
    {
        Logger = logger;
        DbContext = dbContext;
    }

    public async Task<ClaimsPrincipal> RunAsync(RegisterData data)
    {
        UserModel? user = DbContext.Users.FirstOrDefault(
            x => x.Email == data.Email);

        if (user is not null)
        {
            throw ApiException.BadRequest(
                "There already exists an account with this email!");
        }

        user = UserModel.CreateCustomer(data);

        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();

        return user.CreatePrinciple();
    }
}
