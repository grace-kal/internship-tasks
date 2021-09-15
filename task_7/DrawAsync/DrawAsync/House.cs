using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawAsync
{
    [Serializable()]
    public class House
    {
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public string RoofColor { get; set; }
        public string WallColor { get; set; }

        public House(string roofColor, string wallColor, int startPoint, int endPoint)
        {
            this.RoofColor = roofColor;
            this.WallColor = wallColor;
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }

    }
}
