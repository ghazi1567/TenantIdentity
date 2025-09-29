namespace TenantIdentity.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public Guid TenantId { get; set; }

        public UserDto()
        {

        }
        public UserDto(Guid id, string? email, bool isEmailConfirmed, Guid tenantId)
        {
            Id = id;
            Email = email;
            IsEmailConfirmed = isEmailConfirmed;
            TenantId = tenantId;
        }
    }



    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class ChangePasswordDto
    {
        public string UserId { get; set; } = string.Empty;
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }

    public class ResetPasswordDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }

    public class ForgotPasswordDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
