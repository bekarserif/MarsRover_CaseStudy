using System;
using System.Collections.Generic;

namespace MarsRover_CaseStudy
{
    class Program: Util
    {
        static void Main(string[] args)
        {
            try
            {
                #region Definitions
                List<int> areaLimits = new List<int>();
                List<Rover> roverList = new List<Rover>();
                int roverCount;
                string roverMovements;
                #endregion
                Console.WriteLine("-------------------------------WELCOME TO THE MARS ROVER INTERFACE-------------------------------");


                // Getting the input for area limits and controlling if its valid value
                #region AreaLimitDefinition
                Console.WriteLine("Please Enter X and Y Coordinate Limits For Area You Want To Explore");
                Console.WriteLine("(Example Input Value: 5 5)");

                var areaLimitsInput = Console.ReadLine().Trim().Split(' ');
                while (true)
                {
                    // Validation for areaLimits
                    if (areaLimitsInput.Length == 2)
                    {
                        if (IsInteger(areaLimitsInput[0]) && IsInteger(areaLimitsInput[1]))
                        {
                            areaLimits.Add(Int32.Parse(areaLimitsInput[0]));
                            areaLimits.Add(Int32.Parse(areaLimitsInput[1]));
                            break;
                        }
                    }

                    // If function returns false loop will continue until valid area limits entry
                    Console.WriteLine("ERROR! Please Enter a Valid X and Y Coordinate Pair For Area You Want To Explore");
                    areaLimitsInput = Console.ReadLine().Trim().Split(' ');
                }
                #endregion


                // Setting the number of rovers according to user input
                #region SetNumberOfRovers
                Console.WriteLine("Please Enter Number of Rovers");
                var roverCountInput = Console.ReadLine().Trim();
                while (true)
                {
                    if (IsInteger(roverCountInput))
                    {
                        roverCount = Int32.Parse(roverCountInput);
                        break;
                    }
                    // If function returns false loop will continue until valid number entry
                    Console.WriteLine("Please Enter a Valid Number");
                    roverCountInput = Console.ReadLine().Trim();
                }


                #endregion


                // Initializing rovers locations within area limits according to user input
                #region InitializeRoverLocation

                Console.WriteLine("Please Enter The Rover's Starting Location");
                Console.WriteLine("(Example Input Value: 1 2 N)");
                for (int i = 0; i < roverCount; i++)
                {
                    Console.WriteLine("Please Enter The " + (i + 1) + ". Rover's Starting Location");
                    var roverLocation = Console.ReadLine().Trim().ToUpper().Split(' ');
                    var rover = new Rover((i + 1));
                    while (true)
                    {
                        if (rover.InitializeRoverLocation(areaLimits, roverLocation))
                            break;

                        // If function returns false loop will continue until valid location entry
                        Console.WriteLine("ERROR! Please Enter a Valid Starting Location");
                        roverLocation = Console.ReadLine().Trim().ToUpper().Split(' ');
                    }
                    roverList.Add(rover);
                }
                #endregion


                // Moving Rovers according to user input
                #region MoveRovers
                while (true)
                {
                    Console.WriteLine("Enter the command sequance for moving Rovers. Command sequence definitions and descriptions listed below:");
                    Console.WriteLine("R: Rotates Rover  90 degrees");
                    Console.WriteLine("L: Rotates Rover -90 degrees");
                    Console.WriteLine("M: Moves Rover 1 unit to the position its facing");
                    Console.WriteLine("X: Exits the program");
                    Console.WriteLine("(Example Input Value: LMRM)");
                    foreach (var rover in roverList)
                    {

                        Console.WriteLine("Please Enter Movement Values For " + (rover.RoverNumber) + ". Rover");
                        roverMovements = Console.ReadLine().ToUpper();
                        if (roverMovements == "X")
                        {
                            goto Exit;
                        }
                        rover.MoveRover(areaLimits, roverMovements);
                        Console.WriteLine(rover.RoverNumber + ". rover is currently at " + rover.XCoordinate + " " + rover.YCoordinate + " facing " + rover.Direction);
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            #endregion
            Exit:
                Console.WriteLine("Thank You For Using Mars Rover Interface ");
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
