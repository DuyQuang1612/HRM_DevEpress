namespace HRM_DevEpress.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }
        public string EmailConfirmed { get; set; } = string.Empty;

        public string PasswordConfirmed { get; set; } = string.Empty;

    }
}
