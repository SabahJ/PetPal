using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PetPal.Web.Controllers.VersionsDraftTest;

/// <summary>
/// Test api to check versioning and swagger
/// This is for V1.0
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/welcoming")]
public class WelcomingV1
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