using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Database.Tests
{
    public class TestBootstrapper
    {
        private readonly IWebHost _host;

        private static TestBootstrapper _instance;

        public static TestBootstrapper Instance
        {
            get { return _instance ?? (_instance = new TestBootstrapper()); }
        }

        private TestBootstrapper()
        {
            _host = new WebHostBuilder()
                .UseStartup<TestStartup>()
                .Build();
        }

        public T Resolve<T>()
        {
            using (var serviceScope = _host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                return services.GetRequiredService<T>();
            }
        }
    }
}
