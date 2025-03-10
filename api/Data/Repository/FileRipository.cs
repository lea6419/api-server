using Data;
using Microsoft.EntityFrameworkCore;

public class FileRepository : Repository<UserFile>, IFileRepository
{

    public FileRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<UserFile>> GetFilesByUserIdAsync(int userId)
    {
        return await _context.Files.Where(f => f.UserId == userId).ToListAsync();
    }
}
