using AutoMapper;
using FullAppApi.Controllers;
using FullAppApi.Data;
using FullAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FullAppApiTest
{
    public class NbaPlayerTest
    {
        [Test]
        public async Task Test_GetPlayers_Success()
        {
            // Arrange
            var expectedPlayers = new List<NbaPlayerViewModel>
            {
                new NbaPlayerViewModel
                {
                    Id = 1,
                    Surname = "LeBron",
                    LastName = "James",
                    Franchise = "Lakers"
                }
            };

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<NbaPlayerViewModel>>(It.IsAny<List<NbaPlayerViewModel>>()))
                      .Returns((List<NbaPlayerViewModel> source) => source.Select(player => new NbaPlayerViewModel
                      {
                          Id = player.Id,
                          Surname = player.Surname,
                          LastName = player.LastName,
                          Franchise = player.Franchise
                      }).ToList());

            using (var dbContext = new DataContext(options))
            {
                dbContext.AddRange(expectedPlayers);
                dbContext.SaveChanges();
            }

            using (var dbContext = new DataContext(options))
            {
                var controller = new NbaPlayerController(dbContext, mapperMock.Object);

                // Act
                var actionResult = await controller.GetNbaPlayers();

                // Assert
                var players = actionResult.Result as OkObjectResult;
                Assert.IsNotNull(players);
                
                if (players.Value != null)
                {
                    var playerList = players.Value as List<NbaPlayerViewModel>;
                    Assert.That(playerList!.First().Surname, Is.EqualTo("LeBron"));
                }
                
            }
        }
    }
}
