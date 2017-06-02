using Microsoft.EntityFrameworkCore;
using SiamCoreRepository.Definitions;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace SiamCoreRepository
{

    public class BaseDAL : DbContext, IBaseDAL
    {



        public static void SetConnectionString(string connectionString)
        {
            RepositoryConfiguration.ConnectionString = connectionString;
        }


        public BaseDAL() : base()
        {
           
        }

        public void RecreateDatabase()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(RepositoryConfiguration.ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //using modelBuilder to map some relationships
        }

        public DbSet<PluginDefinitionDTO> Plugins { get; set; }

        public DbSet<UserDTO> Users { get; set; }

        #region SelfContext area

        private BaseDAL selfContext = null;
        public BaseDAL SelfContext
        {
            get
            {
                if (selfContext == null)
                    selfContext = new BaseDAL();
                return selfContext;
            }
        }

        #endregion

    }
        
}
