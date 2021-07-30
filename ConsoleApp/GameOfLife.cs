using System;

namespace ConsoleApp
{
    public class GameOfLife
    {
        private const char ALIVE = '*';
        private const char DEAD =  '.';

        public char[,] NextGeneration(char[,] grid)
        {
            var gridCopy = grid.Clone() as char[,];
            for (int XPosition = 0; XPosition < grid.GetLength(0); XPosition++)
            {
                for (int YPosition = 0; YPosition < grid.GetLength(1); YPosition++)
                {
                    var currentCell = gridCopy[XPosition, YPosition];
                    var numberOfNeighbours = GetNumberOfAliveNeighboars(gridCopy, XPosition, YPosition);

                    if (IsAliveCell(currentCell) && numberOfNeighbours < 2)
                    {
                        grid[XPosition, YPosition] = DEAD;
                    }

                    if (IsAliveCell(currentCell) && numberOfNeighbours > 3)
                    {
                        grid[XPosition, YPosition] = DEAD;
                    }

                    if (IsDeadCell(currentCell) && numberOfNeighbours == 3)
                    {
                        grid[XPosition, YPosition] = ALIVE;
                    }
                }
            }

            return grid;
        }

        private int GetNumberOfAliveNeighboars(char[,] grid, int XPosition, int YPosition)
        {
            var result = 0;
            int xStart;
            int xEnd;
            int yStart;
            int yEnd;

            xStart = XPosition > 0 ? XPosition - 1 : XPosition;
            xEnd = XPosition < grid.GetUpperBound(0) ? XPosition + 1 : XPosition;
            yStart = YPosition > 0 ? YPosition - 1 : YPosition;
            yEnd = YPosition < grid.GetUpperBound(1) ? YPosition + 1 : YPosition;

            for (int currentX = xStart; currentX <= xEnd; currentX++)
            {
                for (int currentY = yStart; currentY <= yEnd; currentY++)
                {
                    var isNeighbour = IsNeighbour(XPosition, YPosition, currentX, currentY);
                    if (isNeighbour && IsAliveCell(grid[currentX, currentY]))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private bool IsNeighbour(int XPosition, int YPosition, int currentX, int currentY) 
        {
            return !(XPosition == currentX && YPosition == currentY);
        }

        private bool IsAliveCell(char cell)
        {
            return cell == ALIVE;
        }

        private bool IsDeadCell(char cell)
        {
            return cell == DEAD;
        }
    }
}