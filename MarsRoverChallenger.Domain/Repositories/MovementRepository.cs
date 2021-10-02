using MarsRoverChallenger.Domain.Models;

namespace MarsRoverChallenger.Domain.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        public void MoveForward(LocationReport locationReport, int maxPosition)
        {
            switch (locationReport.Position.CompassPoint)
            {
                case "N":
                    if (locationReport.Position.YPosition == maxPosition)
                    {
                        locationReport.Scuffs++;
                    }
                    else
                    {
                        locationReport.Position.YPosition++;
                    }
                    break;

                case "E":
                    if (locationReport.Position.XPosition == maxPosition)
                    {
                        locationReport.Scuffs++;
                    }
                    else
                    {
                        locationReport.Position.XPosition++;
                    }
                    break;

                case "S":
                    if (locationReport.Position.YPosition == maxPosition)
                    {
                        locationReport.Scuffs++;
                    }
                    else
                    {
                        locationReport.Position.YPosition--;
                    }
                    break;

                case "W":
                    if (locationReport.Position.XPosition == maxPosition)
                    {
                        locationReport.Scuffs++;
                    }
                    else
                    {
                        locationReport.Position.XPosition--;
                    }
                    break;
            }
        }

        public void TurnLeft(Position position)
        {
            switch (position.CompassPoint)
            {
                case "N":
                    position.CompassPoint = "W";
                    break;

                case "E":
                    position.CompassPoint = "N";
                    break;

                case "S":
                    position.CompassPoint = "E";
                    break;

                case "W":
                    position.CompassPoint = "S";
                    break;
            }

        }

        public void TurnRight(Position position)
        {
            switch (position.CompassPoint)
            {
                case "N":
                    position.CompassPoint = "E";
                    break;

                case "E":
                    position.CompassPoint = "S";
                    break;

                case "S":
                    position.CompassPoint = "W";
                    break;

                case "W":
                    position.CompassPoint = "N";
                    break;
            }
        }
    }
}
