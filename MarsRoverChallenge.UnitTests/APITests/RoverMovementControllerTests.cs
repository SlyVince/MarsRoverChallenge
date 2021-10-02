using FluentAssertions;
using MarsLunarRoverChallenge.Controllers;
using MarsRoverChallenge.Domain.Models;
using MarsRoverChallenge.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MarsRoverChallenge.UnitTests.APITests
{
    public class RoverMovementControllerTests
    {
        private readonly Mock<MovementRepository> _mockMovementRepo;
        private readonly RoverMovementController _roverMovementController;

        private const int MAX_POSITION = 4;
        private const string ALLOWED_MOVEMENT_LETTERS = "LRF";
        private const string ALLOWED_COMPASS_LETTERS = "NESW";

        public RoverMovementControllerTests()
        {
            _mockMovementRepo = new Mock<MovementRepository>();
            _roverMovementController = new RoverMovementController(_mockMovementRepo.Object);
        }

        [Fact]
        public void When_Invalid_MovementInstructions_MoveRoverPosition_Returns_BadRequest()
        {
            Position initialPosition = new Position
            {
                XPosition = 0,
                YPosition = 2,
                CompassPoint = "E"
            };

            string movementInstructions = "T";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            badRequestResult.Value.Should().Be($"Movement instructions can only contain one of the following letters {ALLOWED_MOVEMENT_LETTERS}");
        }

        [Fact]
        public void When_Invalid_CompassPoint_MoveRoverPosition_Returns_BadRequest()
        {
            Position initialPosition = new Position
            {
                XPosition = 0,
                YPosition = 2,
                CompassPoint = "G"
            };

            string movementInstructions = "F";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            badRequestResult.Value.Should().Be($"Compass points can only contain one of the following letters {ALLOWED_COMPASS_LETTERS}");
        }

        [Fact]
        public void When_MaxXPosition_Exceeded_MoveRoverPosition_Returns_BadRequest()
        {
            Position initialPosition = new Position
            {
                XPosition = 5,
                YPosition = 2,
                CompassPoint = "N"
            };

            string movementInstructions = "F";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            badRequestResult.Value.Should().Be($"Inital position greater than the max allowed of {MAX_POSITION}");
        }

        [Fact]
        public void When_MaxYPosition_Exceeded_MoveRoverPosition_Returns_BadRequest()
        {
            Position initialPosition = new Position
            {
                XPosition = 4,
                YPosition = 5,
                CompassPoint = "N"
            };

            string movementInstructions = "F";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            badRequestResult.Value.Should().Be($"Inital position greater than the max allowed of {MAX_POSITION}");
        }

        [Fact]
        public void When_Negative_YPosition_MoveRoverPosition_Returns_BadRequest()
        {
            Position initialPosition = new Position
            {
                XPosition = 4,
                YPosition = -1,
                CompassPoint = "N"
            };

            string movementInstructions = "F";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            badRequestResult.Value.Should().Be("Inital position cannot be less than 0");
        }

        [Fact]
        public void When_Negative_XPosition_MoveRoverPosition_Returns_BadRequest()
        {
            Position initialPosition = new Position
            {
                XPosition = -4,
                YPosition = 2,
                CompassPoint = "N"
            };

            string movementInstructions = "F";

            ActionResult<LocationReport> actionResult = _roverMovementController.MoveRoverPostion(initialPosition, movementInstructions);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            badRequestResult.Value.Should().Be("Inital position cannot be less than 0");
        }

        [Fact]
        public void When_Valid_Data_MoveRoverPosition_Returns_OK()
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
        }
    }
}
