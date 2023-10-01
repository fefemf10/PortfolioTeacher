namespace PortfolioServer.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Database.EnsureCreated())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            else
                context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
