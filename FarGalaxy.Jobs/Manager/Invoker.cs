using FarGalaxy.Jobs.Contracts;

namespace FarGalaxy.Jobs
{
    public abstract class Invoker : IJob
    {
        protected readonly string[] Args;

        protected Invoker(string[] args)
        {
            Args = args;
        }

        public abstract void Execute();
    }
}
