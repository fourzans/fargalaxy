using FarGalaxy.Jobs.Manager.Jobs;
using NDesk.Options.Fork;
using NDesk.Options.Fork.Common;
using static System.Console;
using static System.Convert;

namespace FarGalaxy.Jobs.Manager
{
    public class NDeskInvoker : Invoker
    {
        private readonly OptionSet _optionSet = new OptionSet();

        public NDeskInvoker(string[] args) : base(args)
        {
        }

        public override void Execute()
        {
            var showHelp = false;

            _optionSet.Add("ci|create-initial", "Creates the initial conditions. ",
                years => new CreateInitialConditionsJob().Execute());
            _optionSet.Add("c|conditions=", "Show contidions for years. ",
                years => new ShowConditionsJob(ToInt32(years) * 365).Execute());
            _optionSet.Add("cm|create-model=", "Create the models into KeyValue. ",
                years => new CreateModelJob(ToInt32(years) * 365).Execute());
            _optionSet.Add("h|help", "Show this message and exit", v => showHelp = v != null);

            try
            {
                _optionSet.Parse(Args);
            }
            catch (OptionException optionException)
            {
                WriteLine(optionException.Message);
                WriteLine("Try FarGalaxy.Jobs --help' for more information.");
            }

            if (showHelp)
            {
                ShowHelp(_optionSet);
            }
        }

        private static void ShowHelp(OptionSet optionSet)
        {
            WriteLine("Usage: FarGalaxy.Jobs");
            WriteLine();
            WriteLine("Options:");
            optionSet.WriteOptionDescriptions(Out);
        }

    }
}
