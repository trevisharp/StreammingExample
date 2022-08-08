using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using io = System.IO;

namespace back.Controllers;

using Model;

[ApiController]
public class ContentController : ControllerBase
{
    [HttpGet("test")]
    public object test()
    {
        var path = @"C:\Users\Usuário\Desktop\StreammingExample\videoToStreamming\";
        StreammingDBContext context = new StreammingDBContext();

        for (int i = 0; i < 57; i++)
        {
               var data = io.File.ReadAllBytes(path + $"Ronnie O'Sullivan Fastest 147{i}.ts");

               context.Contents.Add(new Content()
               {
                   Bytes = data
               });
        }
        var m3u8 = io.File.ReadAllBytes(path + "Ronnie O'Sullivan Fastest 147.m3u8");
        context.Contents.Add(new Content()
        {
            Bytes = m3u8
        });
        context.SaveChanges();
        
        return "Bonito";
    }

    [HttpGet("content/{id}")]
    [EnableCors("main")]
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
