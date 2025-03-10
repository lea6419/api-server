public interface IFileService
{
    Task<IEnumerable<UserFile>> GetFilesByUserIdAsync(int userId);
    Task<UserFile?> GetFileByIdAsync(int fileId);
    Task<UserFile> UpdateFileAsync(UserFile file);
    Task<UserFile> UpdaloadeFileAsync(UserFile file);

    Task<UserFile> DeleteFileAsync(int fileId);
}

