using Microsoft.Extensions.Hosting;
using Schmidt.Softplan.TechnicalEvaluation.Data.Seeder;

namespace Schmidt.Softplan.TechnicalEvaluation.Bootstrap
{
    public static class BootstrapStartup
    {
        public static IHost Seed(this IHost host)
        {
            host.Services.Seed();
            return host;
        }
    }
}
