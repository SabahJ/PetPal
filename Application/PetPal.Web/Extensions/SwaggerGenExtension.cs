using Asp.Versioning.ApiExplorer;

namespace PetPal.Web.Extensions;

/// <summary>
/// PetPal Swagger Extensions
/// </summary>
public static class SwaggerGenExtension
{
    /// <summary>
    /// Customize Add Swagger Gen for PetPal
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddPetPalSwagger(this IServiceCollection serviceCollection)
    {
        var descriptionProvider = serviceCollection.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
        
        return serviceCollection.AddSwaggerGen(option =>
        {
            foreach (var description in descriptionProvider.ApiVersionDescriptions)
            {
                option.SwaggerDoc(description.GroupName, new ()
                {
                    Version = $"{description.ApiVersion.MajorVersion}.{description.ApiVersion.MinorVersion}",
                    Title = $"PetPal Shelter API version - {description.GroupName}",
                    Description = @"An ASP.NET Core Web API to connect homeless pets with loving families.
                                    Our mission is to facilitate the adoption process, making it easier for potential pet parents
                                    to find their perfect furry companions. The platform serves as a bridge between shelters,
                                    rescue organizations, and individuals looking to adopt pets"
                });
                
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "PetPal.Web.xml");
                option.IncludeXmlComments(filePath);
            }
        });
    }

    /// <summary>
    /// Customize Use Swagger for PetPal
    /// </summary>
    /// <param name="applicationBuilder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UsePetPalSwaggerUi(this WebApplication applicationBuilder)
    {
        var descriptions = applicationBuilder.DescribeApiVersions();
        
        return applicationBuilder.UseSwaggerUI(option =>
        {
            foreach (var description in descriptions)
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = $"PetPal API {description.GroupName.ToUpperInvariant()}";
                option.SwaggerEndpoint( url, name );
            }
            option.EnableFilter();
            option.EnableDeepLinking();
            option.RoutePrefix = "swagger";
        });
    }
}