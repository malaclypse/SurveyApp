using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly SurveyContext _dbContext;

        public PasswordService(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Login(string password)
        {
            var user = await _dbContext.Password.FirstOrDefaultAsync(x => x.PasswordId == 1); //Get user from database.

            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                return false;

            return true;
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Create hash using password salt.
                for (int i = 0; i < computedHash.Length; i++)
                { // Loop through the byte array
                    if (computedHash[i] != passwordHash[i]) return false; // if mismatch
                }
            }
            return true; //if no mismatches.
        }
    }
}
