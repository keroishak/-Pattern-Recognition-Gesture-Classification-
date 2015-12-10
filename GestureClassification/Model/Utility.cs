using System; 
using System.Text; 
using System.IO; 
using System.Drawing; 
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace GestureClassification.Model
{
    
    public struct Data
    {
        /// <summary>
        /// Representation of one row of our dataset
        /// </summary>

        public string PGMFileName { get; set; }
        public List<Vector2> Points{get;set;}
        public byte Class { get; set; }
    }
    public static class Utility
    {
        private static ColorPalette grayScale;

        public static Bitmap ToBitmap(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fs, Encoding.ASCII))
                {
                    if (reader.ReadChar() == 'P' && reader.ReadChar() == '5')
                    {
                        reader.ReadChar();
                        //reader.ReadBytes(24);
                        int width = 0;
                        int height = 0;
                        int level = 0;
                        bool two = false;
                        StringBuilder sb = new StringBuilder();
                        width = ReadNumber(reader, sb);
                        height = ReadNumber(reader, sb);
                        level = ReadNumber(reader, sb);
                        two = (level > 255);

                        Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
                        if (grayScale == null)
                        {
                            grayScale = bmp.Palette;
                            for (int i = 0; i < 256; i++)
                            {
                                grayScale.Entries[i] = Color.FromArgb(i, i, i);
                            }
                        }
                        bmp.Palette = grayScale;
                        BitmapData dt = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                        int offset = dt.Stride - dt.Width;
                        unsafe
                        {
                            byte* ptr = (byte*)dt.Scan0;

                            for (int i = 0; i < height; i++)
                            {
                                for (int j = 0; j < width; j++)
                                {
                                    byte v;
                                    if (two)
                                    {
                                        v = (byte)(((double)((reader.ReadByte() << 8) + reader.ReadByte()) / level) * 255.0);
                                    }
                                    else
                                    {
                                        v = reader.ReadByte();
                                    }
                                    *ptr = v;
                                    ptr++;
                                }
                                ptr += offset;
                            }
                        }

                        bmp.UnlockBits(dt);
                        return bmp;
                    }
                    else
                    {
                        throw new InvalidOperationException("target file is not a PGM file");
                    }
                }
            }
        }

        public static void SaveAsBitmap(string src, string dest)
        {
            ToBitmap(src).Save(dest, ImageFormat.Bmp);
        }

        private static int ReadNumber(BinaryReader reader, StringBuilder sb)
        {
            char c = '\0';
            sb.Length = 0;
            while (Char.IsDigit(c = reader.ReadChar()))
            {
                sb.Append(c);
            }
            return int.Parse(sb.ToString());
        }

        private static List<Vector2> LoadPoints(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string line = null;
            List<Vector2> pts=new List<Vector2>();
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

                    pts.Add(new Vector2(x, y));
                }
            }

            file.Close();
            return pts;
        }

        public static List<Data> LoadDataFromDirectory()
        {
            return new List<Data>();
        }
    }
}