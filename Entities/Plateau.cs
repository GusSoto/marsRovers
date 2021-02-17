namespace marsRovers.Entities
{
    public class Plateau
    {
        public Plateau(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}