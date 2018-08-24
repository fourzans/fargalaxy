using FarGalaxy.Contracts.DataAccess;
using FarGalaxy.Entities;
using FarGalaxy.Entities.Objects;
using FarGalaxy.Entities.Objects.Movements;
using FarGalaxy.Entities.Objects.Planets;
using FarGalaxy.Entities.Objects.Stars;
using FarGalaxy.Repositories.Migrations;
using System;
using System.Collections.Generic;

namespace FarGalaxy.Repository.Migrations
{
    public class AddGalaxyMigration : Migration
    {
        private readonly INoSqlProvider _storageProvider;

        public AddGalaxyMigration(INoSqlProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public override void Up()
        {
            Galaxy galaxy = CreateGalaxy(new List<Planet>
            {
                CreateFerengi(),
                CreateBetazoid(),
                CreateVulcan()
            });

            _storageProvider
                .Add(nameof(Galaxy), galaxy);
        }
 
        private static Planet CreateVulcan()
        {
            return new Vulcan
            {
                Name = nameof(Vulcan),
                CoordinateX = 0,
                CoordinateY = 1000,
                Radius = 1000,
                Speed = 5,
                Movement = new AntiClockwise()
            };
        }

        private static Planet CreateBetazoid()
        {
            return new Betazoid
            {
                Name = nameof(Betazoid),
                CoordinateX = 0,
                CoordinateY = 2000,
                Radius = 2000,
                Speed = 3,
                Movement = new Clockwise()
            };
        }
       
        private static Planet CreateFerengi()
        {
            return new Ferengi
            {
                Name = nameof(Ferengi),
                CoordinateX = 0,
                CoordinateY = 500,
                Radius = 500,
                Speed = 1,
                Movement = new Clockwise()
            };
        }

        private static Galaxy CreateGalaxy(List<Planet> planets)
        {
            return new Galaxy
            {
                SolarSystem = new SolarSystem
                {
                    Sun = new Sun
                    {
                        Name = nameof(Sun),
                        CoordinateX = 0,
                        CoordinateY = 0,
                    },
                    Planets = planets
                }
            };
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
