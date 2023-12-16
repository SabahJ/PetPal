using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PetPal.Web.Controllers.VersionsDraftTest;

/// <summary>
/// Test api to check versioning and swagger
/// This is for V2.0
/// </summary>
[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/welcoming")]
public class WelcomingV2
{
    /// <summary>
    /// Get Welcoming Message
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> GetWelcomingMessage()
    {
        var message = "Hello, and welcome, this is V2.0";
        return message;
    }
}