using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawAsync
{
    public partial class Form1 : Form
    {
        //list of houses so many houses can be drawn on the panel
        List<House> houses = new List<House>();
        // random colors for the roof and walls
        Random rand = new Random();
        string[] colors = { "Red", "Brown", "Purple", "Orange", "Coral", "BlueViolet", "IndianRed", "Pink", "Crimson", "Tan", "LightPink", "Gold", "NavajoWhite", "Plum" };
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            ReDraw();
        }
        //drawing method
        //--draws all the houses on the list
        //optinal optimization-> after every new added house, all other houses are redrawn
        private void ReDraw()
        {
            Graphics obj = canvas.CreateGraphics();
            foreach (House hs in houses)
            {
                //as the colors are saved in string i need to get the brushes
                Color wall = Color.FromName(hs.WallColor);
                Color roof = Color.FromName(hs.RoofColor);
                Brush wallBrush = new SolidBrush(wall);
                Brush roofBrush = new SolidBrush(roof);
                //drawing square walls
                obj.FillRectangle(wallBrush, hs.StartPoint - 40, hs.EndPoint - 40, 80, 80);

                //draw triangle roof
                Point[] points = new Point[3];
                points[0] = new Point(hs.StartPoint, hs.EndPoint - 80);
                points[1] = new Point(hs.StartPoint - 60, hs.EndPoint - 40);
                points[2] = new Point(hs.StartPoint + 60, hs.EndPoint - 40);
                obj.FillPolygon(roofBrush, points);
            }
        }
        //mouse click listener to draw a house
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //select random colors
                Color wall = Color.FromName(colors[rand.Next(colors.Length)]);
                Color roof = Color.FromName(colors[rand.Next(colors.Length)]);

                House hs = new House(wall.Name.ToString(), roof.Name.ToString(), e.Location.X, e.Location.Y);
                houses.Add(hs);

                canvas.Invalidate();
            }
        }
        //clear canvas button
        private void clearBtn_Click(object sender, EventArgs e)
        {
            //emptying the list
            houses.Clear();
            //redrawing the empty list-> empty panel
            ReDraw();
            canvas.Invalidate();
        }

        //Save and Open functionalities are set at run time (as oposed to design time)
        //save JSON click
        private async void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //setting options
            saveFileDialog1.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save file as JSON";
            saveFileDialog1.DefaultExt = ".json";
            saveFileDialog1.InitialDirectory = "C:\\Users\\Fiji\\Downloads";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null)
                {
                    await JsonSerialize(houses, saveFileDialog1.FileName);
                    MessageBox.Show("File saved!");
                }
            }
        }
        //open JSON click
        private async void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Open JSON file";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.CheckPathExists)
                {
                    clearBtn.PerformClick();
                    await JsonDeserialize(openFileDialog1.FileName);
                    ReDraw();
                    if (houses != null)
                        MessageBox.Show("File loaded!");
                    Invalidate();
                }
            }
        }
        //METHODS
        public async Task JsonSerialize(List<House> data, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            await File.WriteAllTextAsync(filePath, jsonString);
        }
        public async Task JsonDeserialize(string filePath)
        {
            List<House> fetchedData = new();
            string data = await File.ReadAllTextAsync(filePath);
            fetchedData = JsonConvert.DeserializeObject<List<House>>(data.ToString());

            if (fetchedData != null)
                houses.AddRange(fetchedData);
            else
                MessageBox.Show("Empty file!");
        }

       
    }
}
