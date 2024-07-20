using Microsoft.EntityFrameworkCore;

namespace PhotoUploader.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<FileModel> Files { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
