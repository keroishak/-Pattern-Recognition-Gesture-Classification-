using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace GestureClassification.Model
{
    public class Points
    {

        public Points()
        {
            pts = new List<Vector2>();
        }


        public void Load_ptsFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string line = null;

            string[] substr;
            //main loop on whole file line by line
            while ((line = file.ReadLine()) != null)
            {
                if (line[0] == 'v' || line[0] == 'V')
                    continue;

                else if (line[0] == 'n' || line[0] == 'N')
                    continue;

                else if (line[0] == '{')
                    continue;

                else if (line[0] == '}')
                    break;

                else
                {

                   substr = line.Split(' ');

                    double x = Convert.ToDouble(substr[0].ToString());
                    double y = Convert.ToDouble(substr[1].ToString());

                    pts.Add(new Vector2(x,y));
                }
            }

            file.Close();
        }



        public List<Vector2> pts;
    }
}
