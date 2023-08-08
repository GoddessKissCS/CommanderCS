namespace StellarGK.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> Logger;
        private readonly RequestDelegate Pipeline;
        public CustomExceptionHandlerMiddleware(RequestDelegate Pipeline, ILogger<CustomExceptionHandlerMiddleware> Logger)
        {
            this.Logger = Logger;
            this.Pipeline = Pipeline;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Before Execution
                await Pipeline(context).ConfigureAwait(false);
                // After Execution
            }
            catch (BadHttpRequestException _)
            {
                // Ignore those exceptions since they are created by connection errors and not our code
            }
            catch (Exception ex)
            {
                Logger.LogError(exception: ex, $"Uncaught Exception. Message => \"{ex.Message}\"");
                throw;
            }

        }
    }
}
