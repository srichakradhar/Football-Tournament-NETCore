using FootBallTournament.Models;
using Microsoft.EntityFrameworkCore;

namespace FootBallUnit.Tests
{
    public class FootBallTournamentTests : UnitTest1
    {
        public FootBallTournamentTests()
            : base(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("TestDatabase")
                    .Options)
        {
        }
    }
}