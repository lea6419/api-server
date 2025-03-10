public interface IUserRepository : IRepository<User>
{

    Task<User> GetByUsernameAsync(string username);
    Task<User> LoginAsync(string email, string password);
}
