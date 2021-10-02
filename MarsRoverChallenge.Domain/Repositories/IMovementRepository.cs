using MarsRoverChallenge.Domain.Models;

namespace MarsRoverChallenge.Domain.Repositories
{
    public interface IMovementRepository
    {
        void MoveForward(LocationReport position, int maxPosition);

        void TurnLeft(Position position);

        void TurnRight(Position position);
    }
}
