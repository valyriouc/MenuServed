using Backend.Database;
using Backend.Information;
using Backend.Models;
using Backend.Transfer.Auth;
using System.Data.Common;
using System.Security.Claims;

namespace Backend.Services.Auth;

public class RegisterService : IServiceBase<RegisterData, ClaimsPrincipal>
{
    public ILogger Logger { get; set; }

    private bool IsCustomerRegistration { get; set; }

    private AppDbContext DbContext { get; } 

    public RegisterService(AppDbContext dbContext, ILogger logger)
    {
        Logger = logger;
        DbContext = dbContext;
    }
    
    public void Init(bool isCustomerRegistration)
    {
        IsCustomerRegistration = isCustomerRegistration;
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

        user = IsCustomerRegistration ?
            UserModel.CreateCustomer(data) :
            UserModel.CreateRestaurent(data);

        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();

        return user.CreatePrinciple();
    }
}
