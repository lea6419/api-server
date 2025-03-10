using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    // להעלות קובץ
    [HttpPost]
    public async Task<IActionResult> UploadFile(FileDto fileDto)
    {
        if (string.IsNullOrEmpty(fileDto.FilePath))
        {
            return BadRequest("FileType is required.");
        }

        var file = new UserFile
        {
            FileName = fileDto.FileName,
            FileType = fileDto.FilePath,  // וודא שיש ערך!
            Size = fileDto.Size,
            CreatedAt = DateTime.UtcNow,
            FilePath = fileDto.FilePath,
            UserId = fileDto.UserId
        };

        var result = await _fileService.UpdaloadeFileAsync(file);
        if (result==null)
        {
            return StatusCode(500, result);
        }

        return Ok(result);
    }


    // לקבל את כל הקבצים של משתמש
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetFilesByUserId(int userId)
    {
        var files = await _fileService.GetFilesByUserIdAsync(userId);
        var result = files.Select(f => new FileDto
        {
            Id = f.Id,
            FileName = f.FileName,
            FilePath = f.FilePath,
            UploadDate = f.UpdatedAt,
            UserId = f.UserId
        });

        return Ok(result);
    }

    // מחיקת קובץ
    [HttpDelete("{fileId}")]
    public async Task<IActionResult> DeleteFile(int fileId)
    {
        var result = await _fileService.DeleteFileAsync(fileId);
        if (result!=null)
            return NoContent();

        return NotFound();
    }
}
