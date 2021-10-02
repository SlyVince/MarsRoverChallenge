using MarsRoverChallenge.Domain.Models;
using MarsRoverChallenge.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarsLunarRoverChallenge.Controllers
{
    [Route("api")]
    [ApiController]
    public class RoverMovementController : ControllerBase
    {
        private readonly IMovementRepository _movementRepository;

        private const int MAX_POSITION = 4;
        private const string ALLOWED_MOVEMENT_LETTERS = "LRF";
        private const string ALLOWED_COMPASS_LETTERS = "NESW";

        public RoverMovementController(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<LocationReport> MoveRoverPostion([FromBody] Position position, string movementInstructions)
        {
            if (!LettersValid(movementInstructions, ALLOWED_MOVEMENT_LETTERS))
            {
                return new BadRequestObjectResult($"Movement instructions can only contain one of the following letters {ALLOWED_MOVEMENT_LETTERS}");
            }

            if (!LettersValid(position.CompassPoint, ALLOWED_COMPASS_LETTERS))
            {
                return new BadRequestObjectResult($"Compass points can only contain one of the following letters {ALLOWED_COMPASS_LETTERS}");
            }

            if (position.XPosition > MAX_POSITION || position.YPosition > MAX_POSITION)
            {
                return new BadRequestObjectResult($"Inital position greater than the max allowed of {MAX_POSITION}");
            }

            if (position.XPosition < 0 || position.YPosition < 0)
            {
                return new BadRequestObjectResult("Inital position cannot be less than 0");
            }

            LocationReport locationReport = new LocationReport
            {
                Position = position,
                Scuffs = 0
            };

            foreach (var movement in movementInstructions)
            {
                switch (movement)
                {
                    case 'L':
                        _movementRepository.TurnLeft(locationReport.Position);
                        break;

                    case 'R':
                        _movementRepository.TurnRight(locationReport.Position);
                        break;

                    case 'F':
                        _movementRepository.MoveForward(locationReport, MAX_POSITION);
                        break;
                }
            }

            return Ok(locationReport);
        }

        private bool LettersValid(string letters, string allowedLetters)
        {
            foreach (var letter in letters)
            {
                if (!allowedLetters.Contains(letter.ToString()))
                    return false;
            }

            return true;
        }
    }
}