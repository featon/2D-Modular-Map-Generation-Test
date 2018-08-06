using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{

    public class MapGenerator
    {

        private int seed;
        public bool[,] plottedMap = new bool[5, 5];
        public bool[,,] doorMap = new bool[5, 5, 4];

        private string[,] drawnMap = new string[5, 5];
        private Tuple<int, int> primeRoom;
        private Tuple<int, int> exitRoom;

        public void GenerateNewMap()
        {

            //Initialize the RNG and private XY variables.
            Random plotGen = new Random(seed);
            int i, j;

            //Zero mapPlot
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {

                    plottedMap[i, j] = false;

                }

            }

            //Generate Prime Room Coordinates on Row 0.
            i = 0;
            j = plotGen.Next(0, 5);

            //Store Coordinate in primeroom Tuple and display results.
            primeRoom = new Tuple<int, int>(i, j);
            Console.WriteLine("This is the Prime Coordinate: {0}, {1}.", primeRoom.Item1, primeRoom.Item2);
            Console.ReadKey();

            //Plot the PrimeRoom on the Map.
            plottedMap[primeRoom.Item1, primeRoom.Item2] = true;

            //Loop room generation in relation to previously generated room until row 4.
            while (i != 4)
            {

                var cursorLocation = new Tuple<int, int>(i, j);
                string newDirection;

                //If Cursor is on UpperLeftMost Bound...
                if (i == 0 && j == 0)
                {

                    List<string> direction = new List<string>
                    {
                      "Right",
                      "Down"
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on UpperRightMost Bound...
                else if (i == 0 && j == 4)
                {

                    List<string> direction = new List<string>
                    {
                      "Left",
                      "Down"
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on LowerLeftMost Bound...
                else if (i == 4 && j == 0)
                {

                    List<string> direction = new List<string>
                    {
                      "Right",
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on LowerRightMost Bound...
                else if (i == 4 && j == 4)
                {

                    List<string> direction = new List<string>
                    {
                      "Left",
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on LeftMost Bound...
                else if (j == 0)
                {

                    List<string> direction = new List<string>
                    {
                      "Right",
                      "Down",
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on RightMost Bound...
                else if (j == 4)
                {

                    List<string> direction = new List<string>
                    {
                      "Left",
                      "Down"
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on UpperMost Bound...
                else if (i == 0)
                {

                    List<string> direction = new List<string>
                    {
                      "Right",
                      "Down",
                      "Left"
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is on LowerMost Bound...
                else if (i == 4)
                {

                    List<string> direction = new List<string>
                    {
                      "Right",
                      "Left",
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }
                //If Cursor is not on a Bound...
                else
                {

                    List<string> direction = new List<string>
                    {
                      "Right",
                      "Left",
                      "Down"
                    };

                    int index = plotGen.Next(direction.Count);
                    newDirection = direction[index];

                }

                Console.WriteLine("The Cursor will move in this direction: {0}", newDirection);
                Console.ReadKey();
                int delta;
                //If Direction is Down Translate Accordingly
                if (newDirection == "Down")
                {
                    delta = i + 1;
                    if (plottedMap[delta, j] == false)
                    {

                        doorMap[i, j, 1] = true;
                        doorMap[delta, j, 3] = true;

                        i++;

                    }
                    else if (plottedMap[delta, j] == true)
                    {

                        Console.WriteLine("Translation Failed");
                        Console.ReadKey();

                    }

                }
                //If Direction is Left Translate Accordingly
                else if (newDirection == "Left")
                {
                    delta = j - 1;
                    if (plottedMap[i, delta] == false)
                    {

                        doorMap[i, j, 2] = true;
                        doorMap[i, delta, 0] = true;

                        j--;

                    }
                    else if (plottedMap[i, delta] == true)
                    {

                        Console.WriteLine("Translation Failed");
                        Console.ReadKey();

                    }

                }
                //If Direction is Right Translate Accordingly
                else if (newDirection == "Right")
                {
                    delta = j + 1;
                    if (plottedMap[i, delta] == false)
                    {

                        doorMap[i, j, 0] = true;
                        doorMap[i, delta, 2] = true;

                        j++;

                    }
                    else if (plottedMap[i, delta] == true)
                    {

                        Console.WriteLine("Translation Failed");
                        Console.ReadKey();

                    }

                }

                //Displays the Cursor
                Console.WriteLine("CursorIsNowOver: {0},{1}", i, j);
                Console.ReadKey();

                //Plots a room over the Cursor.
                plottedMap[i, j] = true;

            }

            exitRoom = new Tuple<int, int>(4, j);

            //Display Completion Message.
            Console.WriteLine("Map Successfully Generated.");
            Console.ReadKey();

        }

        public int GetNewSeed()
        {

            Random seedGen = new Random();
            return (seed = seedGen.Next(1000000, 99999999));

        }

        public void DrawDrawnMap()
        {

            //Set Default Map.
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    if (plottedMap[i, j] == false)
                    {

                        drawnMap[i, j] = "X";

                    }
                    else
                    {

                        drawnMap[i, j] = "0";

                    }

                }


            }

            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine("{0}|{1}|{2}|{3}|{4} ", drawnMap[i, 0], drawnMap[i, 1], drawnMap[i, 2], drawnMap[i, 3], drawnMap[i, 4]);

            }
            Console.WriteLine();

        }

        public void DrawDoorMap()
        {

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    Console.Write("This is the DoorMap for Row {4}, Collumn {5} :|{0}|{1}|{2}|{3}|", doorMap[i, j, 0], doorMap[i, j, 1], doorMap[i, j, 2], doorMap[i, j, 3], i, j);
                    Console.WriteLine("");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.WriteLine("");
            Console.Write("Enter your X:");
            int userX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Enter your Y:");
            int userY = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("|   |{0}|   |", doorMap[userX, userY, 3]);
            Console.WriteLine("|{0}|   |{1}|", doorMap[userX, userY, 2], doorMap[userX, userY, 0]);
            Console.WriteLine("|   |{0}|   |", doorMap[userX, userY, 1]);

            Console.ReadKey();


        }
    }
}

