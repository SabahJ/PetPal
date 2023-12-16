using Microsoft.AspNetCore.Mvc;

namespace PetPal.Web.Controllers.VersionsDraftTest;

/// <summary>
/// Test api to check versioning and swagger
/// Default version is V1.0
/// </summary>
[ApiController]
[Route("api/welcoming")]
public class WelcomingDefault
{
    /// <summary>
    /// Get Welcoming Message
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> GetWelcomingMessage()
    {
        var message = "Hello, and welcome";
        return message;
    }
    
}