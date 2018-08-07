using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class mapTest : Form
    {

        MapGenerator mapGen = new MapGenerator();

        public mapTest()
        {

            InitializeComponent();

            mapGen.GetNewSeed();

            Console.WriteLine("This is the Seed: {0}", mapGen.seed);

            ClearMap();
            mapGen.GenerateNewMap();

            MapPlottedMap();

        }

        public void MapPlottedMap()
        {

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    SetRoomID(i, j);
               
                }

            }

        }

        public void SetRoomID(int i, int j) {

            List<GroupBox>[] RoomID = new List<GroupBox>[5];

            RoomID[0] = new List<GroupBox> {

                            gb_00,
                            gb_01,
                            gb_02,
                            gb_03,
                            gb_04

                        };

            RoomID[1] = new List<GroupBox>
                        {

                            gb_10,
                            gb_11,
                            gb_12,
                            gb_13,
                            gb_14

                        };

            RoomID[2] = new List<GroupBox>
                        {

                            gb_20,
                            gb_21,
                            gb_22,
                            gb_23,
                            gb_24

                        };

            RoomID[3] = new List<GroupBox>
                        {

                            gb_30,
                            gb_31,
                            gb_32,
                            gb_33,
                            gb_34

                        };

            RoomID[4] = new List<GroupBox>
                        {

                            gb_40,
                            gb_41,
                            gb_42,
                            gb_43,
                            gb_44

                        };

            if (mapGen.roomID[i, j] == 0)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._0;

            }
            else if (mapGen.roomID[i, j] == 1)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._1;

            }
            else if (mapGen.roomID[i, j] == 101)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._2;

            }
            else if (mapGen.roomID[i, j] == 100)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._3;

            }
            else if (mapGen.roomID[i, j] == 10)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._4;

            }
            else if (mapGen.roomID[i, j] == 11)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._5;

            }
            else if (mapGen.roomID[i, j] == 111)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._6;

            }
            else if (mapGen.roomID[i, j] == 110)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._7;

            }
            else if (mapGen.roomID[i, j] == 1010)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._8;

            }
            else if (mapGen.roomID[i, j] == 1011)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._9;

            }
            else if (mapGen.roomID[i, j] == 1111)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._10;

            }
            else if (mapGen.roomID[i, j] == 1110)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._11;

            }
            else if (mapGen.roomID[i, j] == 1000)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._12;

            }
            else if (mapGen.roomID[i, j] == 1001)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._13;

            }
            else if (mapGen.roomID[i, j] == 1101)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._14;

            }
            else if (mapGen.roomID[i, j] == 1100)
            {

                RoomID[i][j].BackgroundImage = Properties.Resources._15;

            }

        }

        private void ClearMap() {

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    for (int k = 0; k < 4; k++)
                    {
                        mapGen.doorMap[i, j, k] = false;
                        //GetRoomLocation(i, j, k).Checked = false;
                        mapGen.ClearRoomID();
                        SetRoomID(i, j);

                    }

                }

            }


        }

        private void bttnNew_Click(object sender, EventArgs e)
        {

            mapGen.GetNewSeed();

            Console.WriteLine("This is the Seed: {0}", mapGen.seed);

            ClearMap();
            mapGen.GenerateNewMap();

            MapPlottedMap();

        }
    }

}
