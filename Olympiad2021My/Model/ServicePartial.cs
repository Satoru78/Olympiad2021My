using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Olympiad2021My.Model
{
    partial class Service
    {
        public int Minute
        {
            get
            {
                return DurationInSeconds / 60;
            }
        }

        public double Price
        {
            get
            {
                return Convert.ToDouble(Cost) - Convert.ToDouble(Cost) * Convert.ToDouble(Discount) / 100;
            }
        }

        public string BackgroundColor
        {
            get
            {
                return Discount != 0 ? Color.FromRgb(231, 250, 191).ToString() : Color.FromRgb(255, 255, 255).ToString();
            }
        }
    }
}
