using Microsoft.EntityFrameworkCore;
using NewWorkWhisperAPI.Models;

namespace WorkWhisperAPI.BusinessLogics
{
    public class Userlogics
    {
        public int GetTotalNumberOfUsers(DbSet<User> Users)
        {
            int totalCount = Users.Count();
            return totalCount;
        }

    }
}
