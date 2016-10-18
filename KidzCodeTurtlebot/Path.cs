using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidzCodeTurtlebot
{
    public class Path
    {
        private List<Drive> path;


        public Path()
        {
            this.path = new List<Drive>();
        }

        public Path(List<Drive> path)
        {
            this.path = path;
        }


        public static Path getPath1()
        {
            List<Drive> data = new List<Drive>();

            data.Add(Drive.STRAIGHT);
            data.Add(Drive.LEFT);
            data.Add(Drive.RIGHT);
            data.Add(Drive.RIGHT);
            data.Add(Drive.RIGHT);
            data.Add(Drive.LEFT);
            data.Add(Drive.LEFT);
            data.Add(Drive.STRAIGHT);
            data.Add(Drive.LEFT);
            data.Add(Drive.STRAIGHT);
            data.Add(Drive.STRAIGHT);
            data.Add(Drive.LEFT);
            data.Add(Drive.STRAIGHT);
            data.Add(Drive.STRAIGHT);

            return new Path(data);
        }

        public List<Drive> Data
        {
            get
            {
                return path;
            }
            set
            {
                this.path = value;
            }
        }
    }
}
