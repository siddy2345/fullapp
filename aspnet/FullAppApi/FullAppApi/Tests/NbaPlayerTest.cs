using NUnit.Framework;
using FullAppApi.Controllers;
using FullAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullAppApi.Tests
{
    [TestFixture]
    public class NbaPlayerTest
    {
        [Test]
        public async Task Test_GetPlayers_Success()
        {
            //arrange
            var controller = new NbaPlayerController();

            //act
            var result = await controller.GetNbaPlayers();

            //assert
            var players = result.Value;
            Assert.IsNotNull(players);
            Assert.AreEqual("LeBron", players[0].Surname);
        }
    }
}
