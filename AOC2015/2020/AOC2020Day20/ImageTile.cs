using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class ImageTile
    {
        List<string> ImageData { get; set; }

        List<int> Borders { get; set; }

        int TileID { get; set; }

        int TopBorder { get; set; }
        int TopBorderFlippedHoriz { get; set; }

        int RightBorder { get; set; }
        int RightBorderFlippedVert { get; set; }

        int BottomBorder { get; set; }
        int BottomBorderFlippedHoriz { get; set; }

        int LeftBorder { get; set; }
        int LeftBorderFlippedVert { get; set; }

        public ImageTile(List<string> input)
        {
            BuildTile(input);

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
            TopBorderFlippedHoriz = 0;

            for (int i = 0; i < ImageData[0].Length; i++)
            {
                if (ImageData[0][i].Equals('#'))
                {
                    TopBorder = TopBorder | (1 << (ImageData[0].Length - i - 1));                    
                }
            }

            TopBorderFlippedHoriz = BinaryFlip(TopBorder, ImageData[0].Length);

            Borders.Add(TopBorder);
            Borders.Add(TopBorderFlippedHoriz);

            //Right Border
            RightBorder = 0;
            RightBorderFlippedVert = 0;

            for (int i = 0; i < ImageData.Count(); i++)
            {
                if (ImageData[i][ImageData[i].Length - 1].Equals('#'))
                {
                    RightBorder = RightBorder | (1 << (ImageData.Count() - i - 1));                    
                }
            }

            RightBorderFlippedVert = BinaryFlip(RightBorder, ImageData.Count());

            Borders.Add(RightBorder);
            Borders.Add(RightBorderFlippedVert);

            //Bottom Border
            BottomBorder = 0;
            BottomBorderFlippedHoriz = 0;

            for (int i = 0; i < ImageData[ImageData.Count() - 1].Length; i++)
            {
                if (ImageData[ImageData.Count() - 1][i].Equals('#'))
                {
                    BottomBorder = BottomBorder | (1 << (ImageData[ImageData.Count() - 1].Length - i - 1));                    
                }
            }

            BottomBorderFlippedHoriz = BinaryFlip(BottomBorder, ImageData[ImageData.Count() - 1].Length);

            Borders.Add(BottomBorder);
            Borders.Add(BottomBorderFlippedHoriz);

            //Left Border
            LeftBorder = 0;
            LeftBorderFlippedVert = 0;

            for (int i = 0; i < ImageData.Count(); i++)
            {
                if (ImageData[i][0].Equals('#'))
                {
                    LeftBorder = LeftBorder | (1 << (ImageData.Count() - i - 1));                    
                }
            }

            LeftBorderFlippedVert = BinaryFlip(LeftBorder, ImageData.Count());

            Borders.Add(LeftBorder);
            Borders.Add(LeftBorderFlippedVert);
        }

        public void Rotate(int angle)
        {

        }

        public void Flip(bool horizontal)
        {

        }

        private int BinaryFlip(int input, int numBits)
        {
            int result = 0;

            for (int i = 0; i < numBits; i++)
            {
                result = result | (input & (1 << numBits - i));
            }

            return result;
        }
    }
}
