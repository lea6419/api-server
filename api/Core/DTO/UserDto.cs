public class UserDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }// "Admin" / "Typist"

    public string Password { get; set; }
}
