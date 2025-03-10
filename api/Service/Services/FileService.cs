using Microsoft.EntityFrameworkCore;

public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;

    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<IEnumerable<UserFile>> GetFilesByUserIdAsync(int userId)
    {
        return await _fileRepository.GetFilesByUserIdAsync(userId);
    }

    public async Task<UserFile?> GetFileByIdAsync(int fileId)
    {
        return await _fileRepository.GetByIdAsync(fileId);
    }

    public async Task<UserFile> UploadFileAsync(UserFile file)
    {
         await _fileRepository.AddAsync(file);
        return file;
    }

    public async Task<UserFile> UpdateFileAsync(UserFile file)
    {
        return  await _fileRepository.UpdateAsync(file);
        
    }
    public async Task<UserFile> UpdaloadeFileAsync(UserFile file)
    {
      return  await _fileRepository.AddAsync(file);
       
    }

    public async Task<UserFile> DeleteFileAsync(int fileId)
    {
       var f=  await _fileRepository.DeleteAsync(fileId);
        return f;
    }
}
