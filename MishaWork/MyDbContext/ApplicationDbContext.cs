using Microsoft.EntityFrameworkCore;
using MishaWork.Models;

namespace MishaWork.MyDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=helloapp.db");
        //}
        public User IsUserExists(User user)
        {
            foreach (var User in Users)
            {
                if(User.Name == user.Name && User.Password == user.Password) return User;
            }
            return null;
        }
        public User GetUserById(int id)
        {
            foreach (var User in Users)
            {
                if (User.Id == id) return User;
            }
            return null;
        }
    }
}
