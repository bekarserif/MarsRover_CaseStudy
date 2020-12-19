using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_CaseStudy
{

    public enum Directions
    {
        N = 'N',
        E = 'E',
        S = 'S',
        W = 'W'
    }

    public interface IRover
    {
        void MoveRover(List<int> maxPoints, string moves);
    }
    public class Rover : Util
    {
        public int RoverNumber { get; set; }
        public int AreaX { get; set; }
        public int AreaY { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Directions Direction { get; set; }

        public Rover(int _roverNumber)
        {
            this.RoverNumber = _roverNumber;
            AreaX = AreaY = 0;
        }


        #region RoverMovements

        // Rotates rover -90 Degrees
        void RotateLeft()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        // Rotates rover 90 Degrees
        void RotateRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        // Moves rover 1 unit to the position its facing
        void Move()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.YCoordinate = this.YCoordinate + 1;
                    break;
                case Directions.E:
                    this.XCoordinate = this.XCoordinate + 1;
                    break;
                case Directions.S:
                    this.YCoordinate = this.YCoordinate - 1;
                    break;
                case Directions.W:
                    this.XCoordinate = this.XCoordinate - 1;
                    break;
                default:
                    break;
            }
        }
        // Reverts rovers last move
        void RevertLastMove()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.YCoordinate = this.YCoordinate - 1;
                    break;
                case Directions.E:
                    this.XCoordinate = this.XCoordinate - 1;
                    break;
                case Directions.S:
                    this.YCoordinate = this.YCoordinate + 1;
                    break;
                case Directions.W:
                    this.XCoordinate = this.XCoordinate + 1;
                    break;
                default:
                    break;
            }
        }
        #endregion


        /// <summary>
        /// Returns true if given location successfully initialized to rover
        /// </summary>
        /// <param name="_areaLimits"></param>
        /// <param name="_roverLocation"></param>
        /// <returns>Boolean</returns>
        public Boolean InitializeRoverLocation(List<int> _areaLimits, string[] _roverLocation)
        {
            int roverLocationX, roverLocationY;
            Directions roverDirection;

            if (_roverLocation.Length != 3)
                return false;
            if (!(IsInteger(_roverLocation[0]) && IsInteger(_roverLocation[1]) && IsValidDirection(_roverLocation[2])))
                return false;

            roverLocationX = Int32.Parse(_roverLocation[0]);
            roverLocationY = Int32.Parse(_roverLocation[1]);
            //Casting last input to Direction enum
            roverDirection = (Directions)Enum.Parse(typeof(Directions), _roverLocation[2].ToUpper(), true);
            if (roverLocationX < 0 || roverLocationY < 0 || roverLocationX > _areaLimits[0] || roverLocationY > _areaLimits[1])
            {
                Console.WriteLine("Hover Is Out of Boundries! Please Enter Valid Starting Point");
                return false;
            }
            this.XCoordinate = roverLocationX;
            this.YCoordinate = roverLocationY;
            this.Direction = roverDirection;
            return true;
        }

        /// <summary>
        /// Moves the rover according to user input. Rover will stop moving if its out of area limit boundries;
        /// </summary>
        /// <param name="_areaLimits"></param>
        /// <param name="moves"></param>
        public void MoveRover(List<int> _areaLimits, string moves)
        {

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        break;
                }
                if (this.XCoordinate < 0 || this.YCoordinate < 0 || this.XCoordinate > _areaLimits[0] || this.YCoordinate > _areaLimits[1])
                {
                    Console.WriteLine("Hover Is Out of Boundries! Please Enter Valid Movement Values");
                    RevertLastMove();
                    break;
                }

            }
        }
    }
}
