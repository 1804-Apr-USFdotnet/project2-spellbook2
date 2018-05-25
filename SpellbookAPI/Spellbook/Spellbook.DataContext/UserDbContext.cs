using System.Data.Entity;
using Spellbook.Models;

namespace Spellbook.DataContext
{
	public class UserDbContext : DbContext
	{
		public UserDbContext() : base("name=UserContext")
		{
			//Database.SetInitializer<UserDbContext>(new User_DbInit());
		}

		//public DbSet<User> Users { get; set;}
	}

	class User_DbInit : CreateDatabaseIfNotExists<UserDbContext>
	{
		protected override void Seed(UserDbContext context)
		{
			base.Seed(context);
			context.SaveChanges();
		}
	}
}

