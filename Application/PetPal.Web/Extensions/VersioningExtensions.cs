using Asp.Versioning;

namespace PetPal.Web.Extensions;

/// <summary>
/// PetPal Versioning Extensions
/// </summary>
public static class VersioningExtensions
{
    /// <summary>
    /// Customize Add API Versioning for PetPal
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IApiVersioningBuilder AddPetPalApiVersioning(this IServiceCollection serviceCollection)
    {
        
        return serviceCollection.AddApiVersioning(option =>
        {
            option.AssumeDefaultVersionWhenUnspecified = true;
            option.DefaultApiVersion = new ApiVersion(1, 0);
            option.ReportApiVersions = true;
        }).AddApiExplorer(option =>
        {
            option.GroupNameFormat = "'v'VVV";
            option.FormatGroupName = (groupName, apiVersion) => $"{groupName}-{apiVersion}";
            option.SubstituteApiVersionInUrl = true; 
        });
    }
}