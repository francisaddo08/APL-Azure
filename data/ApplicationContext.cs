using APL_Technical_Test.data.entities;

using Microsoft.EntityFrameworkCore;

namespace APL_Technical_Test.data
{
    public class ApplicationContext :DbContext
    {
        public DbSet<ImageInformation> imageInformation { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public ApplicationContext() { }
    }
}
