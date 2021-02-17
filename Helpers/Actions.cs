using marsRovers.Enums;
using marsRovers.Entities;
using System;

namespace marsRovers.Helpers
{

    public static class Actions
    {
        /// <summary>
        /// Creates a new grid
        /// </summary>
        public static Plateau GetPlateau(string line)
        {
            if(line.Length == 2)
            {
                char[] positions = line.ToCharArray();
                Plateau plateau = new Plateau(int.Parse(positions[0].ToString()),int.Parse(positions[1].ToString()));
                return plateau;
            }

            return new Plateau(0,0);

        }
        /// <summary>
        /// Creates a new rover and executes the instructions to navigate the plateau
        /// </summary>
        public static Rover GetNewRover(int index, string line1, string line2, Plateau plateau, bool showDetails){
            Rover rover;
            if(line1.Length == 3)
            {
                rover = new Rover("Rover " + index.ToString(), int.Parse(line1[0].ToString()),int.Parse(line1[1].ToString()),line1[2]);
                if(showDetails)
                {
                    Console.WriteLine(rover.Name + "  ***********************");
                }
                char[] instructions = new char[line2.Length];
                instructions = line2.ToCharArray();
                foreach (char c in instructions)
                {
                    if(c == 'M')
                    {
                        GetNextPosition(ref rover,plateau);
                        if(showDetails)
                        {
                            Console.Write("Position X: ");
                            Console.WriteLine(rover.PositionX);
                            Console.Write("PositionY: ");
                            Console.WriteLine(rover.PositionY);
                            Console.Write("Direction: ");
                            Console.WriteLine(rover.Direction);
                            Console.WriteLine("_____________________");
                        }
                        
                    }else if(c.ToString() == Movements.L.ToString() || c.ToString() == Movements.R.ToString())
                    {
                        rover.Direction = GetNextDirection(rover.Direction,c);
                    }
                }
                
                return rover;
            }

            return new Rover("",0,0,'N');
        }
        /// <summary>
        /// Set the Rover's orientation based on the next movement
        /// </summary>
        public static Directions GetNextDirection(Directions currentDirection, char movement){
            if(movement.ToString() == Movements.L.ToString())
            {
                if(currentDirection == Directions.N)
                {
                    return Directions.W;
                }else if(currentDirection == Directions.S)
                {
                    return Directions.E;
                }else if(currentDirection == Directions.W)
                {
                    return Directions.S;
                }else if(currentDirection == Directions.E)
                {
                    return Directions.N;
                }

            }else if (movement.ToString() == Movements.R.ToString())
            {
                if(currentDirection == Directions.N)
                {
                    return Directions.E;
                }else if(currentDirection == Directions.S)
                {
                    return Directions.W;
                }else if(currentDirection == Directions.W)
                {
                    return Directions.N;
                }else if(currentDirection == Directions.E)
                {
                    return Directions.S;
                }
            }

            return Directions.N;
        }
        /// <summary>
        /// Moves the rover forward one grid point
        /// </summary>
        public static void GetNextPosition(ref Rover rover, Plateau plateau)
        {
            switch (rover.Direction)
            {
                case Directions.N:
                    if(rover.PositionY < plateau.PositionY)
                    {
                        //Console.WriteLine("MoveUp");
                        MoveUp(ref rover);
                    }
                break;
                case Directions.S:
                    if(rover.PositionY > 0)
                    {
                        //Console.WriteLine("MoveDown");
                        MoveDown(ref rover);
                    }
                break;
                case Directions.E:
                    if(rover.PositionX < plateau.PositionY)
                    {
                        //Console.WriteLine("MoveRight");
                        MoveRight(ref rover);
                    }
                break;
                case Directions.W:
                    if(rover.PositionX > 0)
                    {
                        //Console.WriteLine("MoveLeft");
                        MoveLeft(ref rover);
                    }
                break;
                default:
                break;
            }
        }

        private static void MoveUp(ref Rover rover)
        {
            rover.PositionY++;
        }
        private static void MoveDown(ref Rover rover)
        {
            rover.PositionY--;
        }
        private static void MoveLeft(ref Rover rover)
        {
            rover.PositionX--;
        }
        private static void MoveRight(ref Rover rover)
        {
            rover.PositionX++;
        }
    }

}