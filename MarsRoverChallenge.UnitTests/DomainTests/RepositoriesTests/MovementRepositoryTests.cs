using MarsRoverChallenge.Domain.Models;
using MarsRoverChallenge.Domain.Repositories;
using FluentAssertions;
using Xunit;

namespace MarsRoverChallenge.UnitTests.DomainTests.RepositoriesTests
{
    public class MovementRepositoryTests
    {
        private readonly MovementRepository _movementRepo;
        private const int MAX_POSITION = 4;

        public MovementRepositoryTests()
        {
            _movementRepo = new MovementRepository();
        }

        [Fact]
        public void When_Passing_N_To_MoveForward_YPostion_Increased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 0,
                    YPosition = 0,
                    CompassPoint = "N"
                },
                Scuffs = 0
                
            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Position.YPosition.Should().Be(1);
        }

        [Fact]
        public void Given_I_Am_Max_Position_When_Passing_N_To_MoveForward_Scuff_Count_Increased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 0,
                    YPosition = 4,
                    CompassPoint = "N"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Scuffs.Should().Be(1);
        }

        [Fact]
        public void When_Passing_E_To_MoveForward_XPostion_Increased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 0,
                    YPosition = 0,
                    CompassPoint = "E"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Position.XPosition.Should().Be(1);
        }

        [Fact]
        public void Given_I_Am_Max_Position_When_Passing_E_To_MoveForward_Scuff_Count_Increased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 4,
                    YPosition = 0,
                    CompassPoint = "E"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Scuffs.Should().Be(1);
        }

        [Fact]
        public void When_Passing_S_To_MoveForward_YPostion_Decreased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 0,
                    YPosition = 1,
                    CompassPoint = "S"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Position.YPosition.Should().Be(0);
        }

        [Fact]
        public void Given_I_Am_Min_Position_When_Passing_S_To_MoveForward_Scuff_Count_Increased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 0,
                    YPosition = 0,
                    CompassPoint = "S"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Scuffs.Should().Be(1);
        }

        [Fact]
        public void When_Passing_W_To_MoveForward_XPostion_Decreased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 1,
                    YPosition = 0,
                    CompassPoint = "W"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Position.YPosition.Should().Be(0);
        }

        [Fact]
        public void Given_I_Am_Min_Position_When_Passing_W_To_MoveForward_Scuff_Count_Increased()
        {
            LocationReport locationReport = new LocationReport
            {
                Position = new Position
                {
                    XPosition = 0,
                    YPosition = 0,
                    CompassPoint = "W"
                },
                Scuffs = 0

            };

            _movementRepo.MoveForward(locationReport, MAX_POSITION);

            locationReport.Scuffs.Should().Be(1);
        }

        [Fact]
        public void When_Passing_N_To_TurnLeft_CompassPoint_Should_Be_W()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "N"

            };

            _movementRepo.TurnLeft(position);

            position.CompassPoint.Should().Be("W");
        }

        [Fact]
        public void When_Passing_E_To_TurnLeft_CompassPoint_Should_Be_N()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "E"

            };

            _movementRepo.TurnLeft(position);

            position.CompassPoint.Should().Be("N");
        }

        [Fact]
        public void When_Passing_S_To_TurnLeft_CompassPoint_Should_Be_E()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "S"

            };

            _movementRepo.TurnLeft(position);

            position.CompassPoint.Should().Be("E");
        }

        [Fact]
        public void When_Passing_W_To_TurnLeft_CompassPoint_Should_Be_S()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "W"

            };

            _movementRepo.TurnLeft(position);

            position.CompassPoint.Should().Be("S");
        }

        [Fact]
        public void When_Passing_N_To_TurnRight_CompassPoint_Should_Be_E()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "N"

            };

            _movementRepo.TurnRight(position);

            position.CompassPoint.Should().Be("E");
        }

        [Fact]
        public void When_Passing_E_To_TurnLeft_CompassPoint_Should_Be_S()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "E"

            };

            _movementRepo.TurnRight(position);

            position.CompassPoint.Should().Be("S");
        }

        [Fact]
        public void When_Passing_S_To_TurnLeft_CompassPoint_Should_Be_W()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "S"

            };

            _movementRepo.TurnRight(position);

            position.CompassPoint.Should().Be("W");
        }

        [Fact]
        public void When_Passing_W_To_TurnLeft_CompassPoint_Should_Be_N()
        {
            Position position = new Position
            {
                XPosition = 0,
                YPosition = 0,
                CompassPoint = "W"

            };

            _movementRepo.TurnRight(position);

            position.CompassPoint.Should().Be("N");
        }
    }
}
