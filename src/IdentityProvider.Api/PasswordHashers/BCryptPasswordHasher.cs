using Microsoft.AspNetCore.Identity;

namespace IdentityProvider.Api.Infrastructures;

// dotnet add package BCrypt.Net-Next

/// <summary>
/// Custom <see cref="IPasswordHasher{TUser}"/> using BCrypt instead of PBKDF2.
/// Slower by design, configurable work factor, stronger against brute-force.
/// </summary>
public class BCryptPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
{
    public string HashPassword(TUser user, string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public PasswordVerificationResult VerifyHashedPassword(
        TUser user, string hashedPassword, string providedPassword)
        => BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
}