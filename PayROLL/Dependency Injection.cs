using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayROLL
{
    public static class Dependency_Injection
    {
        public static void AddPayROLL(this IServiceCollection services)
        {
             services.AddQuartz(Options =>
            {
                Options.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService();

    }
    }
}
