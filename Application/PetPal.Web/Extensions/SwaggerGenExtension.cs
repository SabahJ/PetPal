namespace PetPal.Web.Extensions;

public static class SwaggerGenExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new()
            {
                Version = "v1",
                Title = "PetPal Shelter API",
                Description = @"An ASP.NET Core Web API to connect homeless pets with loving families.
                                 Our mission is to facilitate the adoption process, making it easier for potential pet parents
                                 to find their perfect furry companions. The platform serves as a bridge between shelters,
                                 rescue organizations, and individuals looking to adopt pets"
            });
        });
    }

    public static IApplicationBuilder CustomizeUseSwaggerUi(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseSwaggerUI(option =>
        {
            option.SwaggerEndpoint("/swagger/v1/swagger.json", "PetPal APIs");
            option.EnableFilter();
            option.EnableDeepLinking();
            option.RoutePrefix = "swagger";
        });
    }
}