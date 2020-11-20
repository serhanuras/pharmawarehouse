using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using PharmaWarehouse.Api.Modules.Data;
using PharmaWarehouse.Api.Modules.Extensions;
using PharmaWarehouse.Api.Services;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaWarehouse.Api.Tests.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private UserService userService;

        private IUnitOfWork unitOfWork;

        [SetUp]
        public void Setup()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connection = new MySqlConnection(
                    configuration.GetMySqlConnectionString());

            var compiler = new MySqlCompiler();

            var queryFactory = new QueryFactory(connection, compiler);

            this.unitOfWork = new UnitOfWork(queryFactory);

            this.userService = new UserService(null, this.unitOfWork);
        }

        [Test]
        public void Count()
        {
            var result = this.userService.Count();
            Assert.Greater(result, -1);
        }

        [Test]
        public void Add()
        {
            var result = this.userService.Upsert(new PharmaWarehouse.Api.Entities.User
            {
                Email = "serhan.uras@gmail.com",
                BirthDate = DateTime.Now.AddYears(-38),
                FirstName = "Mustafa Serhan",
                LastName = "Uras",
                Password = "Password1",
                RoleId = 0,
            });
            Assert.Greater(result.Id, -1);
        }

        [Test]
        public void Update()
        {
            var result = this.userService.Upsert(new PharmaWarehouse.Api.Entities.User
            {
                Email = "serhan.uras@gmail.com",
                BirthDate = DateTime.Now.AddYears(-38),
                FirstName = "Serhan",
                LastName = "Uras",
                Password = "Password2",
                RoleId = 0,
                Id = 1
            });
            Assert.Greater(result.Id, -1);
        }

        [Test]
        public void Get()
        {
            var result = this.userService.Get(2);
            Assert.AreEqual(result.Id, 2);
        }

        [Test]
        public void Delete()
        {
            var ex = Assert.Throws<Exception>(() => this.userService.Delete(1));
            Assert.AreEqual(ex, null);
        }
    }
}
