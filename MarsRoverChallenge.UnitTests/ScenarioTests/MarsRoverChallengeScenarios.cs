using FluentAssertions;
using MarsLunarRoverChallenge.Controllers;
using MarsRoverChallenge.Domain.Models;
using MarsRoverChallenge.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MarsRoverChallenge.UnitTests.ScenarioTests
{
    public class MarsRoverChallengeScenarios
    {
        private readonly MovementRepository _movementRepo;
        private readonly RoverMovementController _roverMovementController;

        public MarsRoverChallengeScenarios()
        {
            _movementRepo = new MovementRepository();
            _roverMovementController = new RoverMovementController(_movementRepo);
        }

        [Fact]
        public void Scenario_1()
        {
            Position initialPosition = new Position
            {
                XPosition = 0,
                YPosition = 2,
                CompassPoint = "E"
            };

            string movementInstructions = "FLFRFFFRFFRR";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var okRequestResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var locationReportResult = okRequestResult.Value.As<LocationReport>();

            locationReportResult.Position.XPosition.Should().Be(4);
            locationReportResult.Position.YPosition.Should().Be(1);
            locationReportResult.Position.CompassPoint.Should().Be("N");
            locationReportResult.Scuffs.Should().Be(0);
        }

        [Fact]
        public void Scenario_2()
        {
            Position initialPosition = new Position
            {
                XPosition = 4,
                YPosition = 4,
                CompassPoint = "S"
            };

            string movementInstructions = "LFLLFFLFFFRFF";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var okRequestResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var locationReportResult = okRequestResult.Value.As<LocationReport>();

            locationReportResult.Position.XPosition.Should().Be(0);
            locationReportResult.Position.YPosition.Should().Be(1);
            locationReportResult.Position.CompassPoint.Should().Be("W");
            locationReportResult.Scuffs.Should().Be(1);
        }

        [Fact]
        public void Scenario_3()
        {
            Position initialPosition = new Position
            {
                XPosition = 2,
                YPosition = 2,
                CompassPoint = "W"
            };

            string movementInstructions = "FLFLFLFRFRFRFRF";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var okRequestResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var locationReportResult = okRequestResult.Value.As<LocationReport>();

            locationReportResult.Position.XPosition.Should().Be(2);
            locationReportResult.Position.YPosition.Should().Be(2);
            locationReportResult.Position.CompassPoint.Should().Be("N");
            locationReportResult.Scuffs.Should().Be(0);
        }

        [Fact]
        public void Scenario_4()
        {
            Position initialPosition = new Position
            {
                XPosition = 1,
                YPosition = 3,
                CompassPoint = "N"
            };

            string movementInstructions = "FFLFFLFFFFF";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var okRequestResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var locationReportResult = okRequestResult.Value.As<LocationReport>();

            locationReportResult.Position.XPosition.Should().Be(0);
            locationReportResult.Position.YPosition.Should().Be(0);
            locationReportResult.Position.CompassPoint.Should().Be("S");
            locationReportResult.Scuffs.Should().Be(3);
        }
    }
}
