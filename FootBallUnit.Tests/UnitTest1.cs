using System;
using System.Linq;
using System.Net.Http;
using FootBallTournament;
using FootBallTournament.Controllers;
using FootBallTournament.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using FluentAssertions;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FootBallUnit.Tests
{
    [TestCaseOrderer("FootBallUnit.Tests.PriorityOrderer", "FootBallUnit.Tests")]
    [ExcludeFromCodeCoverage]
    public abstract class UnitTest1
    {
           protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }
           private AdminController _adminController;
           private TeamsController _teamsController;
           private PlayersController _playersController;
        //    public UnitTest1() 
        //    : base(
        //         new DbContextOptionsBuilder<ApplicationDbContext>()
        //             .UseInMemoryDatabase("TestDatabase")
        //             .Options)
        // {
        // }
        protected UnitTest1(DbContextOptions<ApplicationDbContext> contextOptions)
        {
           ContextOptions = contextOptions;
            var context = new ApplicationDbContext(ContextOptions);
               _adminController = new AdminController(context);
               _teamsController = new TeamsController(context);
               _playersController = new PlayersController(context);


            
            Seed();
        }
        private void Seed()
        {
            var context = new ApplicationDbContext(ContextOptions);
             context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                foreach (var entity in context.ChangeTracker.Entries().ToList())
                    {
                        entity.State = EntityState.Detached;
                    }
        }
     
        public HttpClient Client { get; private set; }
      //write the test cases here
        
       
    }
}
