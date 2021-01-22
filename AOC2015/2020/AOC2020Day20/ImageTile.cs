using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class ImageTile
    {
        public List<string> ImageData { get; set; }

        public List<int> Borders { get; set; }

        public int TileID { get; set; }

        public int TopBorder { get; set; }
        //int TopBorderFlippedHoriz { get; set; }

        public int RightBorder { get; set; }
        //int RightBorderFlippedVert { get; set; }

        public int BottomBorder { get; set; }
        //int BottomBorderFlippedHoriz { get; set; }

        public int LeftBorder { get; set; }
        //int LeftBorderFlippedVert { get; set; }

        public ImageTile(List<string> input)
        {
            BuildTile(input);

            CalculateBorders();
        }

        public ImageTile(int tileID, List<string> imageData)
        {
            ImageData = imageData.ToList();
            TileID = tileID;

            CalculateBorders();
        }

        private void BuildTile(List<string> input)
        {
            ImageData = new List<string>();

            foreach (string line in input)
            {
                if (line.Contains("Tile"))
                {
                    TileID = Convert.ToInt32(StringOps.SubStringPost(line.Replace(":", ""), "Tile").Trim());                       
                }
                else
                {
                    ImageData.Add(line);
                }
            }

        }

        public void CalculateBorders()
        {
            Borders = new List<int>();

            //Top Border
            TopBorder = 0;
            //TopBorderFlippedHoriz = 0;

            for (int i = 0; i < ImageData[0].Length; i++)
            {
                if (ImageData[0][i].Equals('#'))
                {
                    TopBorder = TopBorder | (1 << (ImageData[0].Length - i - 1));                    
                }
            }

            //TopBorderFlippedHoriz = BinaryFlip(TopBorder, ImageData[0].Length);

            Borders.Add(TopBorder);
            //Borders.Add(TopBorderFlippedHoriz);

            //Right Border
            RightBorder = 0;
            //RightBorderFlippedVert = 0;

            for (int i = 0; i < ImageData.Count(); i++)
            {
                if (ImageData[i][ImageData[i].Length - 1].Equals('#'))
                {
                    RightBorder = RightBorder | (1 << (ImageData.Count() - i - 1));                    
                }
            }

            //RightBorderFlippedVert = BinaryFlip(RightBorder, ImageData.Count());

            Borders.Add(RightBorder);
            //Borders.Add(RightBorderFlippedVert);

            //Bottom Border
            BottomBorder = 0;
            //BottomBorderFlippedHoriz = 0;

            for (int i = 0; i < ImageData[ImageData.Count() - 1].Length; i++)
            {
                if (ImageData[ImageData.Count() - 1][i].Equals('#'))
                {
                    BottomBorder = BottomBorder | (1 << (ImageData[ImageData.Count() - 1].Length - i - 1));                    
                }
            }

            //BottomBorderFlippedHoriz = BinaryFlip(BottomBorder, ImageData[ImageData.Count() - 1].Length);

            Borders.Add(BottomBorder);
            //Borders.Add(BottomBorderFlippedHoriz);

            //Left Border
            LeftBorder = 0;
            //LeftBorderFlippedVert = 0;

            for (int i = 0; i < ImageData.Count(); i++)
            {
                if (ImageData[i][0].Equals('#'))
                {
                    LeftBorder = LeftBorder | (1 << (ImageData.Count() - i - 1));                    
                }
            }

            //LeftBorderFlippedVert = BinaryFlip(LeftBorder, ImageData.Count());

            Borders.Add(LeftBorder);
            //Borders.Add(LeftBorderFlippedVert);
        }

        public List<string> Rotate90()
        {
            List<string> result = new List<string>();

            result.Add($"Tile {TileID}:");

            for (int i = 0; i < ImageData[0].Length; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = ImageData.Count() - 1; j >= 0; j--)
                {
                    sb.Append(ImageData[j][i]);
                }
                result.Add(sb.ToString());
            }

            return result;
        }

        public List<string> Flip()
        {
            List<string> result = new List<string>();

            result.Add($"Tile {TileID}:");

            for (int i = ImageData.Count() - 1; i >= 0; i--)
            {
                result.Add(ImageData[i]);
            }

            return result;
        }

        private int BinaryFlip(int input, int numBits)
        {
            int result = 0;

            string bin = Convert.ToString(input, toBase: 2).PadLeft(numBits, '0');

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numBits; i++)
            {
                sb.Append(bin[numBits - i - 1]);
            }

            result = Convert.ToInt32(sb.ToString(), 2);

            //for (int i = 0; i < numBits; i++)
            //{
            //    //result = result | (input & (1 << numBits - 1 - i));
            //    result = result | ((input & (1 << i)) << (numBits - 1 - i));
            //}

            return result;
        }
    }
}
