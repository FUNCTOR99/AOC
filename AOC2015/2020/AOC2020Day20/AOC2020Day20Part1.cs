using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day20Part1 : AOCProblem
    {
        public AOC2020Day20Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<ImageTile> tiles = new List<ImageTile>();

            List<string> currentTile = new List<string>();

            foreach (String line in input)
            {
                if (line.Trim().Length == 0)
                {
                    tiles.Add(new ImageTile(currentTile));
                    currentTile = new List<string>();
                }
                else
                {
                    currentTile.Add(line);
                }
            }

            tiles.Add(new ImageTile(currentTile));

            int numTiles = tiles.Count();

            for (int i = 0; i < numTiles; i++)
            {
                ImageTile rotated90 = new ImageTile(tiles[i].Rotate90());
                ImageTile rotated180 = new ImageTile(rotated90.Rotate90());
                ImageTile rotated270 = new ImageTile(rotated180.Rotate90());

                ImageTile flipped = new ImageTile(tiles[i].Flip());
                ImageTile rotated90Flipped = new ImageTile(rotated90.Flip());
                ImageTile rotated180Flipped = new ImageTile(rotated180.Flip());
                ImageTile rotated270Flipped = new ImageTile(rotated270.Flip());

                tiles.Add(rotated90);
                tiles.Add(rotated180);
                tiles.Add(rotated270);
                tiles.Add(flipped);
                tiles.Add(rotated90Flipped);
                tiles.Add(rotated180Flipped);
                tiles.Add(rotated270Flipped);
            }

            List<ImageTile> it3001 = tiles.Where(it => it.TileID == 3001).ToList();
            List<int> borderCounts = new List<int>();
            List<int> corners = new List<int>();

            long cornerProduct = 1;
            int numCorners = 0;

            for (int i = 0; i < tiles.Count(); i++)
            {
                int borderCount = BorderCount(tiles, i);
                borderCounts.Add(borderCount);

                if (borderCount == 2)
                {
                    if (corners.Contains(tiles[i].TileID) == false)
                    {
                        corners.Add(tiles[i].TileID);
                        cornerProduct = cornerProduct * (long) tiles[i].TileID;
                        numCorners++;
                    }                                        
                }
            }

            

            return $"Result { cornerProduct }.";        
        }         
        
        private int BorderCount(List<ImageTile> tiles, int index)
        {
            int count = 0;

            //check top border;
            count = count + tiles.Where(it => (it.TileID != tiles[index].TileID) && (tiles[index].TopBorder == it.BottomBorder)).Count();

            //check right border;
            count = count + tiles.Where(it => (it.TileID != tiles[index].TileID) && (tiles[index].RightBorder == it.LeftBorder)).Count();

            //check bottom border;
            count = count + tiles.Where(it => (it.TileID != tiles[index].TileID) && (tiles[index].BottomBorder == it.TopBorder)).Count();

            //check left border;
            count = count + tiles.Where(it => (it.TileID != tiles[index].TileID) && (tiles[index].LeftBorder == it.RightBorder)).Count();

            return count;
        }


    }
}
