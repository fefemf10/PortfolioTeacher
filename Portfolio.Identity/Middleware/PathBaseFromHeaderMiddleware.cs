namespace Portfolio.Identity.Middleware
{
    public class PathBaseFromHeaderMiddleware
    {
        private readonly RequestDelegate next;

        public PathBaseFromHeaderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var prefix = context.Request.Headers["X-Forwarded-Prefix"].FirstOrDefault();
            if (!string.IsNullOrEmpty(prefix))
            {
                var originalPath = context.Request.Path;
                if (originalPath.StartsWithSegments(prefix, out var remaining))
                {
                    context.Request.PathBase = new PathString(prefix);
                    context.Request.Path = remaining;
                }
            }
            await this.next(context);
        }
    }
}
