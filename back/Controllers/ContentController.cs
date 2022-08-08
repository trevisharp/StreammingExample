using Microsoft.AspNetCore.Mvc;

namespace back.Controllers;

using Model;

[ApiController]
public class ContentController : ControllerBase
{
    [HttpGet("test")]
    public object test()
    {
        
    }

    [HttpGet("content/{id}")]
    public IActionResult getContent(int id)
    {
        StreammingDBContext context = new StreammingDBContext();
        var content = context.Contents
            .FirstOrDefault(c => c.Id == id);
        if (content == null)
            return NotFound();
        return File(content.Bytes, "application/octet-stream");
    }
}
