using System;
using System.IO;
using marsRovers.Entities;
using marsRovers.Helpers;

namespace marsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                String line, line2;
                short row = 1;
                ConsoleKeyInfo pressedKey;
                bool showDetails = false;
                Console.WriteLine("Please use the data.txt file in root folder to change the input of this program.");
                Console.WriteLine("Do you want to see a detailed execution y/n?");
                pressedKey = Console.ReadKey();
                showDetails = (pressedKey.KeyChar.ToString().ToLower() == "y");
                Console.WriteLine(pressedKey.KeyChar.ToString().ToLower());

                //Read a file in the root folder of the proyect
                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"/data.txt");
                //Read the first line of text
                line = sr.ReadLine();
                line = line.Replace(" ","");
                
                Plateau plateau = Actions.GetPlateau(line);
                 
                line = sr.ReadLine().Replace(" ","").ToUpper();
                line2 = sr.ReadLine().Replace(" ","").ToUpper();
                
                Rover rover;
                Console.WriteLine("********************RESULTS********************************");
                while (line != null)
                {
                    line = line.Replace(" ","").ToUpper();
                    line2 =  line2.Replace(" ","").ToUpper();
                    rover = Actions.GetNewRover(row,line,line2,plateau,showDetails);
                    
                    Console.Write(rover.Name);
                    Console.WriteLine($" - Position: {rover.PositionX} {rover.PositionY}, Direction: {rover.Direction}");
                    line = sr.ReadLine();
                    line2 = sr.ReadLine();
                    row++;

                }

                //close the file
                sr.Close();
                Console.Write("Type any kay to exit!");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

    }
}
