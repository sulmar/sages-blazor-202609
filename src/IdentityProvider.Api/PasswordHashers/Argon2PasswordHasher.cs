using Microsoft.AspNetCore.Identity;

namespace IdentityProvider.Api.Infrastructures;

/// Custom <see cref="IPasswordHasher{TUser}"/> using Argon2 instead of PBKDF2.
/// Argon2 is memory-hard, more resistant to GPU/ASIC brute-force, 
/// and allows tuning of time and memory cost.
/// </summary>
/// 
// dotnet add package Isopoh.Cryptography.Argon2
public class Argon2PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
{
    public string HashPassword(TUser user, string password)
        => Isopoh.Cryptography.Argon2.Argon2.Hash(password);

    public PasswordVerificationResult VerifyHashedPassword(
        TUser user, string hashedPassword, string providedPassword)
        => Isopoh.Cryptography.Argon2.Argon2.Verify(hashedPassword, providedPassword)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
}