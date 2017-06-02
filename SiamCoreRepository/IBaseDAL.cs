using Microsoft.EntityFrameworkCore;
using SiamCoreRepository.Definitions;

namespace SiamCoreRepository
{

    public interface IBaseDAL
    {

        DbSet<PluginDefinitionDTO> Plugins { get; set; }

        DbSet<UserDTO> Users { get; set; }

        BaseDAL SelfContext { get; }

    }

}
