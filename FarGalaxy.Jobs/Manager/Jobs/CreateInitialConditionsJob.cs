using Autofac;
using FarGalaxy.Contracts.DataAccess;
using FarGalaxy.Jobs.Contracts;
using FarGalaxy.Repositories.Migrations;
using FarGalaxy.Repository.Migrations;
using System;
using System.Collections.Generic;
using static System.Console;
using static System.ConsoleColor;
using static FarGalaxy.Jobs.Program;

namespace FarGalaxy.Jobs.Manager.Jobs
{
    public class CreateInitialConditionsJob : IJob
    {
        public void Execute()
        {
            ForegroundColor = Yellow;
            WriteLine("Creating initial conditions...\n");

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                INoSqlProvider storageProvider = scope.Resolve<INoSqlProvider>();

                Stack<Migration> migrations = new Stack<Migration>
                (
                    new[] { new AddGalaxyMigration(storageProvider) }
                );

                Write("Running migrations...");

                Stack<Migration> history = new Stack<Migration>();

                try
                {
                    while (migrations.Count > 0)
                    {
                        Migration migration = migrations.Pop();
                        ForegroundColor = Cyan;
                        Write($"\n\tRunning {migration.GetType().Name} ... ");
                        try
                        {
                            Do(history, migration);
                        }
                        catch (Exception e)
                        {
                            Undo(history, e);
                        }
                    }
                }
                catch (Exception)
                {
                    WriteLine("Fatal error. Please re-install application.");
                    throw;
                }
            }

            ForegroundColor = Green;
            WriteLine("\nFinished. ");
            ResetColor();
        }

        private static void Undo(Stack<Migration> history, Exception e)
        {
            WriteLine(e.Message);
            WriteLine("Rollbacking changes...");
            while (history.Count > 0)
            {
                Migration rollback = history.Pop();
                WriteLine($"\n\tRunning {rollback.GetType().Name} ...");
                rollback.Down();
            }
        }

        private static void Do(Stack<Migration> history, Migration migration)
        {
            migration.Up();
            history.Push(migration);
            ForegroundColor = Magenta;
            WriteLine("OK");
        }
    }
}
