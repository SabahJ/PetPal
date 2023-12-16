using Asp.Versioning;

namespace PetPal.Web.Extensions;

public static class VersioningExtensions
{
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