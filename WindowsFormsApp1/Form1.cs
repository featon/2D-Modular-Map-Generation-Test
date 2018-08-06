using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CheckBox GetRoomLocation(int row, int column, int door)
        {

            List<CheckBox>[,] RoomList = new List<CheckBox>[5, 5];

            RoomList[0, 0] = new List<CheckBox>() {
                door000,
                door001,
                door002,
                door003
            };

            RoomList[0, 1] = new List<CheckBox>() {
                door010,
                door011,
                door012,
                door013
            };

            RoomList[0, 2] = new List<CheckBox>() {
                door020,
                door021,
                door022,
                door023
            };

            RoomList[0, 3] = new List<CheckBox>() {
                door030,
                door031,
                door032,
                door033
            };

            RoomList[0, 4] = new List<CheckBox>() {
                door040,
                door041,
                door042,
                door043
            };



            RoomList[1, 0] = new List<CheckBox>() {
                door100,
                door101,
                door102,
                door103
            };

            RoomList[1, 1] = new List<CheckBox>() {
                door110,
                door111,
                door112,
                door113
            };

            RoomList[1, 2] = new List<CheckBox>() {
                door120,
                door121,
                door122,
                door123
            };

            RoomList[1, 3] = new List<CheckBox>() {
                door130,
                door131,
                door132,
                door133
            };

            RoomList[1, 4] = new List<CheckBox>() {
                door140,
                door141,
                door142,
                door143
            };


            RoomList[2, 0] = new List<CheckBox>() {
                door200,
                door201,
                door202,
                door203
            };

            RoomList[2, 1] = new List<CheckBox>() {
                door210,
                door211,
                door212,
                door213
            };

            RoomList[2, 2] = new List<CheckBox>() {
                door220,
                door221,
                door222,
                door223
            };

            RoomList[2, 3] = new List<CheckBox>() {
                door230,
                door231,
                door232,
                door233
            };

            RoomList[2, 4] = new List<CheckBox>() {
                door240,
                door241,
                door242,
                door243
            };


            RoomList[3, 0] = new List<CheckBox>() {
                door300,
                door301,
                door302,
                door303
            };

            RoomList[3, 1] = new List<CheckBox>() {
                door310,
                door311,
                door312,
                door313
            };

            RoomList[3, 2] = new List<CheckBox>() {
                door320,
                door321,
                door322,
                door323
            };

            RoomList[3, 3] = new List<CheckBox>() {
                door330,
                door331,
                door332,
                door333
            };

            RoomList[3, 4] = new List<CheckBox>() {
                door340,
                door341,
                door342,
                door343
            };


            RoomList[4, 0] = new List<CheckBox>() {
                door400,
                door401,
                door402,
                door403
            };

            RoomList[4, 1] = new List<CheckBox>() {
                door410,
                door411,
                door412,
                door413
            };

            RoomList[4, 2] = new List<CheckBox>() {
                door420,
                door421,
                door422,
                door423
            };

            RoomList[4, 3] = new List<CheckBox>() {
                door430,
                door431,
                door432,
                door433
            };

            RoomList[4, 4] = new List<CheckBox>() {
                door440,
                door441,
                door442,
                door443
            };

            return RoomList[row, column][door];
        }

        public void MapPlottedMap()
        {

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    for (int k = 0; k < 4; k++)
                    {

                        if (mapGen.doorMap[i, j, k])
                        {

                            GetRoomLocation(i, j, k).Checked = true;

                        }

                    }

                }

            }




        }


        private void bttnNew_Click(object sender, EventArgs e)
        {
            Console.WriteLine("");

            mapGen.GetNewSeed();

            Console.WriteLine("This is the Seed: {0}", mapGen.seed);

            ClearMap();
            mapGen.GenerateNewMap();

            MapPlottedMap();
        }

        private void bttnTest_Click(object sender, EventArgs e)
        {
            gb_00.BackColor = Color.Cyan;
            
        }

        private void ClearMap() {

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    for (int k = 0; k < 4; k++)
                    {
                        mapGen.doorMap[i, j, k] = false;
                        GetRoomLocation(i, j, k).Checked = false;

                    }

                }

            }


        }

        private void mapTest_Load(object sender, EventArgs e)
        {

        }

        private void door043_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void door003_CheckedChanged(object sender, EventArgs e)
        {

        }

    }

}
