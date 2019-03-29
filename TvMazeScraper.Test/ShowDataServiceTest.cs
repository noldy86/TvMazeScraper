using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TvMazeScraper.Controllers;
using TvMazeScraper.Data.Models;
using TvMazeScraper.Models;
using TvMazeScraper.Services;

namespace Tests
{
    public class ShowDataServiceTest
    {
        public Mock<IShowDataService> ShowDataService;

        [SetUp]
        public void Setup()
        {
            ShowDataService = new Mock<IShowDataService>();
        }

        [Test]
        public void ConvertBirthDayFromEntityToResponse()
        {
            //collect data
            int pageSize = 50;
            int page = 1;

            var testShowCollection = GetTestShowCollection();

            ShowDataService.Setup(s => s.GetShowAndCastData(page, pageSize)).Returns(testShowCollection);

            //convert to Json response
            var showController = new ShowController(ShowDataService.Object);
            var actionResult = showController.ShowsWithCast(page, pageSize);

            //check for valid actionresult type
            var result = actionResult as OkObjectResult;
            Assert.IsNotNull(result);

            //check for valid responsetype
            var resultContent = result.Value as List<ShowResponse>;
            Assert.IsNotNull(resultContent);

            //the amount of shows should be the same as what we started with
            Assert.AreEqual(1, resultContent.Count);

            var castMembers = resultContent.First().Cast;

            //first show should have 3 cast members
            Assert.AreEqual(3,castMembers.Count);

            //check the datetime values for correctness
            foreach (var cast in castMembers)
            {
                //expect max 10 characters yyyy-MM-dd
                Assert.AreEqual(10, cast.BirthDayDate.Length);
            }

        }

        private List<Show> GetTestShowCollection()
        {
            return new List<Show>
            {
                new Show{Casts = GetTestCastCollection(), Id = 1, Name = "L33tShow", ShowId = 1337, Url = "http://uri.com"}
            };
        }

        private List<Cast> GetTestCastCollection()
        {
            return new List<Cast>
            {
                new Cast{Birthday = new DateTime(1986,07,01), Name = "TestCastmember1", CastId = 1,},
                new Cast{Birthday = new DateTime(1986,07,02), Name = "TestCastmember2", CastId = 2},
                new Cast{Birthday = new DateTime(1986,07,03), Name = "TestCastmember3", CastId = 3}

            };
        }
    }
}