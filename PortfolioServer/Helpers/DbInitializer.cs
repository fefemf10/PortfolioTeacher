namespace PortfolioServer.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
