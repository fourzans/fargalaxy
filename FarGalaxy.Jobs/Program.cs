using Autofac;
using FarGalaxy.IoC;
using FarGalaxy.Jobs.Manager;

namespace FarGalaxy.Jobs
{
    public static class Program
    {
        public static readonly IContainer Container = new JobsBuilder().Build();

        private static void Main(string[] args)
        {
            Invoker invoker = new NDeskInvoker(args);
            invoker.Execute();
        }
    }
}
