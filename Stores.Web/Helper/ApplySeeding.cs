
using Stores.Data.Context;
using Stores.Reposatory;

namespace Store.Web.Helper
    {
        public class ApplySeeding
        {
            public static async Task ApplyseedingAsync(WebApplication app)
            {
                using (var scope = app.Services.CreateScope())
                {
                    var Services = scope.ServiceProvider;
                    var loggerfactory = Services.GetService<ILoggerFactory>();
                    try
                    {
                        var context = Services.GetRequiredService<StoresDBContext>();

                        await StortesContextSeed.SeedAsync(context, loggerfactory);
                    }
                    catch (Exception ex)
                    {
                        var logger = loggerfactory.CreateLogger<ApplySeeding>();
                        logger.LogError(ex.Message);
                    }
                }
            }
        }
    }

