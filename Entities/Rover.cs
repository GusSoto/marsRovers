using marsRovers.Enums;

namespace marsRovers.Entities
{
    public class Rover
    {
        public Rover(string name, int positionX, int positionY, char direction)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            switch(direction)
            {
                case 'N':
                Direction = Directions.N;
                break;
                case 'S':
                Direction = Directions.S;
                break;
                case 'W':
                Direction = Directions.W;
                break;
                case 'E':
                Direction = Directions.E;
                break;
            }
        }

        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Directions Direction { get; set; }
    }
}