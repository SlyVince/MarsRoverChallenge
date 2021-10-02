using MarsRoverChallenger.Domain.Models;

namespace MarsRoverChallenger.Domain.Repositories
{
    public interface IMovementRepository
    {
        void MoveForward(LocationReport position, int maxPosition);

        void TurnLeft(Position position);

        void TurnRight(Position position);
    }
}
