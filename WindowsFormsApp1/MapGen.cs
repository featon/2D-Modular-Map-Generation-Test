using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{

    public class MapGenerator
    {

        public int seed;
        public bool[,] plottedMap = new bool[5, 5];
        public bool[,,] doorMap = new bool[5, 5, 4];
        public int[,] roomID = new int[5, 5];

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

            //Loop room generation in relation to previously generated room until row 4.
            while (i != 4)
            {

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

                //Console.WriteLine("The Cursor will move in this direction: {0}", newDirection);
                //Console.ReadKey();

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

                       // Console.WriteLine("Translation Failed");
                        //Console.ReadKey();

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

                        //Console.WriteLine("Translation Failed");
                        //Console.ReadKey();

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

                        //Console.WriteLine("Translation Failed");
                        //Console.ReadKey();

                    }

                }

                //Displays the Cursor
                //Console.WriteLine("CursorIsNowOver: {0},{1}", i, j);
                //Console.ReadKey();

                //Plots a room over the Cursor.
                plottedMap[i, j] = true;

            }

            exitRoom = new Tuple<int, int>(4, j);
            Console.WriteLine("This is the Terminal Coordinate: {0}, {1}.", exitRoom.Item1, exitRoom.Item2);


            //Roll to add random doors for each room
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {

                    string newDirection;
                    //If Cursor is on UpperLeftMost Bound...
                    if (x == 0 && y == 0)
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
                    else if (x == 0 && y == 4)
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
                    else if (x == 4 && y == 0)
                    {

                        List<string> direction = new List<string>
                        {
                      "Right",
                        };

                        int index = plotGen.Next(direction.Count);
                        newDirection = direction[index];

                    }
                    //If Cursor is on LowerRightMost Bound...
                    else if (x == 4 && y == 4)
                    {

                        List<string> direction = new List<string>
                        {
                      "Left",
                        };

                        int index = plotGen.Next(direction.Count);
                        newDirection = direction[index];

                    }
                    //If Cursor is on LeftMost Bound...
                    else if (y == 0)
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
                    else if (y == 4)
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
                    else if (x == 0)
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
                    else if (x == 4)
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

                    //Console.WriteLine("The Cursor will move in this direction: {0}", newDirection);
                    //Console.ReadKey();

                    int delta;

                    //If Direction is Down Translate Accordingly
                    if (newDirection == "Down")
                    {
                        delta = x + 1;
                        if (plottedMap[delta, y] == false)
                        {

                            doorMap[x, y, 1] = true;
                            doorMap[delta, y, 3] = true;

                        }
                        else if (plottedMap[delta, y] == true)
                        {

                            // Console.WriteLine("Translation Failed");
                            //Console.ReadKey();

                        }

                    }
                    //If Direction is Left Translate Accordingly
                    else if (newDirection == "Left")
                    {
                        delta = y - 1;
                        if (plottedMap[x, delta] == false)
                        {

                            doorMap[x, y, 2] = true;
                            doorMap[x, delta, 0] = true;

                        }
                        else if (plottedMap[x, delta] == true)
                        {

                            //Console.WriteLine("Translation Failed");
                            //Console.ReadKey();

                        }

                    }
                    //If Direction is Right Translate Accordingly
                    else if (newDirection == "Right")
                    {
                        delta = y + 1;
                        if (plottedMap[x, delta] == false)
                        {

                            doorMap[x, y, 0] = true;
                            doorMap[x, delta, 2] = true;

                        }
                        else if (plottedMap[x, delta] == true)
                        {

                            //Console.WriteLine("Translation Failed");
                            //Console.ReadKey();

                        }


                    }
                }
            }

            //Read doorMap and Generate a roomID for each room
            for (int x = 0; x < 5; x++) {
                for (int y = 0; y < 5; y++) {

                    if (doorMap[x, y, 0]){

                        roomID[x, y] += 1;

                    }
                    if (doorMap[x, y, 1]){

                        roomID[x, y] += 10;

                    }
                    if (doorMap[x, y, 2]){

                        roomID[x, y] += 100;

                    }
                    if (doorMap[x, y, 3]){

                        roomID[x, y] += 1000;

                    }
                }
            }
            Console.WriteLine("");

            //Display Completion Message.
            Console.WriteLine("Map Successfully Generated.");

        }

        public int GetNewSeed()
        {

            Random seedGen = new Random();
            return (seed = seedGen.Next(1000000, 99999999));

        }

        public void ClearRoomID() {

            for (int i = 0; i < 5; i++){

                for (int j = 0; j < 5; j++) {

                    roomID[i, j] = 0;

                }

            }

        }

    }
}