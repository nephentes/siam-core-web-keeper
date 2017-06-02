using SiamCoreRepository;

namespace SiamCoreServices
{

    public static class InitializeService
    {

        /// <summary>
        /// Initialize new database
        /// </summary>
        public static void InitializeDatabase(IUsersService usersService, IBaseDAL baseDAL)
        {
            baseDAL.RecreateDatabase();
            usersService.CreateUser("admin", "zuzia66");
        }

    }

}
