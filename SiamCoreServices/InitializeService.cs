namespace SiamCoreServices
{

    public static class InitializeService
    {

        /// <summary>
        /// Initialize new database
        /// </summary>
        public static void InitializeDatabase(IUsersService usersService)
        {
            usersService.CreateUser("admin", "zuzia66");
        }

    }

}
