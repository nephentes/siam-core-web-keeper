using Microsoft.EntityFrameworkCore;
using SiamCoreRepository.Definitions;

namespace SiamCoreRepository
{

    public interface IBaseDAL
    {

        void RecreateDatabase();

        DbSet<TestInstanceDTO> Tests { get; set; }

        DbSet<PluginDefinitionDTO> Plugins { get; set; }

        DbSet<UserDTO> Users { get; set; }

        BaseDAL SelfContext { get; }

    }

}
