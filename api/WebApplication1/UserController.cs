using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // רישום משתמש חדש
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
    {
        var user = new User
        {
            Username = userDto.FullName,
            Email = userDto.Email,
            Role = userDto.Role
        };

        var result = await _userService.CreateUserAsync(user);
        return Ok(result);
    }

    // התחברות משתמש
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var token = await _userService.LoginAsync(loginDto.Email, loginDto.Password);
        if (token == null)
            return Unauthorized("Invalid credentials");

        return Ok(new { Token = token });
    }

    // קבלת פרטי משתמש לפי ID
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null)
            return NotFound();

        var userDto = new UserDto
        {
            Id = user.UserId,
            FullName = user.Username,
            Email = user.Email,
            Role = user.Role
        };

        return Ok(userDto);
    }

    // עדכון פרטי משתמש
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserDto userDto)
    {
        var user = new User
        {
            UserId = userId,
            Username = userDto.FullName,
            Email = userDto.Email,
            Role = userDto.Role
        };

        var result = await _userService.UpdateUserAsync(user);
        return Ok(result);
    }

    // מחיקת משתמש
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {

       return Ok( await _userService.DeleteUserAsync(userId));
       
    }
}
