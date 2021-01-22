using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day20Part2 : AOCProblem
    {

        public AOC2020Day20Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            List<ImageTile> tiles = new List<ImageTile>();

            List<string> currentTile = new List<string>();

            //process the input 
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

            //create a master list of all possible tile orientations, (rotated and flipped)
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

            //Create a dictionary with the border IDs to use to determine if a given border ID is an edge or not.
            Dictionary<int, int> borderIDCounts = new Dictionary<int, int>();

            foreach (ImageTile tile in tiles)
            {
                if (borderIDCounts.ContainsKey(tile.TopBorder) == false)
                    borderIDCounts.Add(tile.TopBorder, 1);
                else
                    borderIDCounts[tile.TopBorder] = borderIDCounts[tile.TopBorder] + 1;

                if (borderIDCounts.ContainsKey(tile.BottomBorder) == false)
                    borderIDCounts.Add(tile.BottomBorder, 1);
                else
                    borderIDCounts[tile.BottomBorder] = borderIDCounts[tile.BottomBorder] + 1;

                if (borderIDCounts.ContainsKey(tile.LeftBorder) == false)
                    borderIDCounts.Add(tile.LeftBorder, 1);
                else
                    borderIDCounts[tile.LeftBorder] = borderIDCounts[tile.LeftBorder] + 1;

                if (borderIDCounts.ContainsKey(tile.RightBorder) == false)
                    borderIDCounts.Add(tile.RightBorder, 1);
                else
                    borderIDCounts[tile.RightBorder] = borderIDCounts[tile.RightBorder] + 1;
            }

            //Start assembling the image tiles.
            List<List<ImageTile>> addedTiles = new List<List<ImageTile>>();

            List<ImageTile> row = new List<ImageTile>();

            //add the first row (top border is an edge)
            bool firstRowComplete = false;

            while (!firstRowComplete)
            {
                if (row.Count == 0)
                {
                    foreach (ImageTile tile in tiles)
                    {
                        if (EdgeCount(tile, ref borderIDCounts) == 2)
                        {
                            if (IsEdge(tile.LeftBorder, ref borderIDCounts) && IsEdge(tile.TopBorder, ref borderIDCounts))
                            {
                                row.Add(tile);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (ImageTile tile in tiles)
                    {
                        if (row.Where(it => it.TileID == tile.TileID).Count() == 0)     //row doens't already contain this tile
                        {
                            if (IsEdge(tile.TopBorder, ref borderIDCounts) && (tile.LeftBorder == row.Last().RightBorder))
                            {
                                row.Add(tile);

                                if (IsEdge(tile.RightBorder, ref borderIDCounts))
                                {
                                    firstRowComplete = true;
                                    break;
                                }
                            }
                        }                       
                    }
                }
            }

            addedTiles.Add(row);

            //fill in the subsequent rows.
            bool tileAssemblyComplete = false;

            while (!tileAssemblyComplete)
            {
                List<ImageTile> newRow = new List<ImageTile>();
                List<ImageTile> prevRow = addedTiles.Last();

                //add an edge piece
                foreach (ImageTile tile in tiles)
                {
                    if (EdgeCount(tile, ref borderIDCounts) >= 1)
                    {
                        if (IsEdge(tile.LeftBorder, ref borderIDCounts) 
                            && (tile.TopBorder == prevRow[0].BottomBorder)
                            && !ContainsImageTile(tile, ref addedTiles))
                        {
                            newRow.Add(tile);
                            break;
                        }
                    }
                }

                //add the middle pieces
                for (int i = 1; i < prevRow.Count(); i++)
                {
                    ImageTile tileToAdd = tiles.Where(it => (it.LeftBorder == newRow[i - 1].RightBorder) 
                                                         && (it.TopBorder == prevRow[i].BottomBorder)
                                                         && !ContainsImageTile(it, ref addedTiles)).First();

                    newRow.Add(tileToAdd);

                    if (IsEdge(tileToAdd.BottomBorder, ref borderIDCounts))
                    {
                        tileAssemblyComplete = true;
                    }
                }

                addedTiles.Add(newRow);
            }

            //Build the final image by merging the tiles and removing the borders

            List<String> imageData = new List<string>();

            foreach (List<ImageTile> listTiles in addedTiles)
            {
                int tileRowCount = listTiles.First().ImageData.Count();

                for (int i = 1; i < tileRowCount - 1; i++)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < listTiles.Count; j++)
                    {
                        sb.Append(listTiles[j].ImageData[i].Substring(1, listTiles[j].ImageData[i].Length - 2));
                    }

                    imageData.Add(sb.ToString());
                }
            }

            ImageTile finalImage = new ImageTile(13, imageData);

            //Find the orientation that contains sea monsters
            int rotationCount = 0;

            int seaMonsterCount = SeaMonsterCount(finalImage);

            while (seaMonsterCount == 0)
            {
                if (rotationCount >= 3)
                {
                    finalImage = new ImageTile(finalImage.Rotate90());
                    finalImage = new ImageTile(finalImage.Flip());

                    rotationCount = 0;
                }
                else
                {
                    finalImage = new ImageTile(finalImage.Rotate90());
                    rotationCount++;
                }

                seaMonsterCount = SeaMonsterCount(finalImage);
            }

            //calculate Rough waters
            int roughCount = 0;
            foreach (string imageLine in finalImage.ImageData)
            {
                roughCount = roughCount + imageLine.Where(x => x.Equals('#')).Count();
            }

            result = roughCount - (seaMonsterCount * 15);  //assumes there is no overlap between the sea monsters.

            return $"Result { result }.";
        }

        private int EdgeCount(ImageTile tile, ref Dictionary<int, int> edgeIDs)
        {
            int result = 0;

            if (edgeIDs[tile.TopBorder] == 4)
                result++;

            if (edgeIDs[tile.RightBorder] == 4)
                result++;

            if (edgeIDs[tile.BottomBorder] == 4)
                result++;

            if (edgeIDs[tile.LeftBorder] == 4)
                result++;

            return result;
        }

        private bool IsEdge(int value, ref Dictionary<int, int> edgeIDs)
        {
            if (edgeIDs[value] == 4)
                return true;
            else
                return false;
        }

        private bool ContainsImageTile(ImageTile tile,  ref List<List<ImageTile>> listOfListOfImageTiles)
        {
            foreach (List<ImageTile> listOfImageTiles in listOfListOfImageTiles)
            {
                if (listOfImageTiles.Any(it => it.TileID == tile.TileID))
                    return true;
            }

            return false;
        }

        private int SeaMonsterCount(ImageTile tile)
        {
            int count = 0;

            for (int i = 0; i < tile.ImageData.Count() - 2; i++)
            {
                for (int j = 0; j < tile.ImageData.First().Length - 19; j++)
                {
                    if (tile.ImageData[i][j + 18].Equals('#') &&

                        tile.ImageData[i + 1][j].Equals('#') &&
                        tile.ImageData[i + 1][j + 5].Equals('#') &&
                        tile.ImageData[i + 1][j + 6].Equals('#') &&
                        tile.ImageData[i + 1][j + 11].Equals('#') &&
                        tile.ImageData[i + 1][j + 12].Equals('#') &&
                        tile.ImageData[i + 1][j + 17].Equals('#') &&
                        tile.ImageData[i + 1][j + 18].Equals('#') &&
                        tile.ImageData[i + 1][j + 19].Equals('#') &&

                        tile.ImageData[i + 2][j + 1].Equals('#') &&
                        tile.ImageData[i + 2][j + 4].Equals('#') &&
                        tile.ImageData[i + 2][j + 7].Equals('#') &&
                        tile.ImageData[i + 2][j + 10].Equals('#') &&
                        tile.ImageData[i + 2][j + 13].Equals('#') &&
                        tile.ImageData[i + 2][j + 16].Equals('#'))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
