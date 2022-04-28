namespace MinimalAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of API endpoint mapping
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData userData)
    {
        try
        {
            return Results.Ok(await userData.GetUsers());
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData userData)
    {
        try
        {
            var result = await userData.GetUser(id);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> InsertUser(User user, IUserData userData)
    {
        try
        {
            await userData.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> UpdateUser(User user, IUserData userData)
    {
        try
        {
            await userData.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData userData)
    {
        try
        {
            await userData.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}