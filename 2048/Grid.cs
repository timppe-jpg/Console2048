using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Grid
    {

        private int[,] grid = new int[,]
        {
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 }
        };
        private bool gameIsLost = false;
        private int score = 0;

        public int[,] PlayGrid { get { return grid; } set { grid = value; } }
        public bool GameIsLost {get{ return gameIsLost; }set  { gameIsLost = value; } }

        public void DrawGrid()
        {
            int count = 0;
            Console.Clear();
            foreach (var cell in this.PlayGrid)
            {
                switch (cell)
                {
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 16:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 32:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 64:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 128:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 256:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 512:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 1024:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 2048:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;

                    default:
                        break;
                }
                Console.Write($"[{cell}]\t");
                Console.ForegroundColor = ConsoleColor.White;
                if (count++ > 2)
                {
                    count = 0;
                    Console.WriteLine("\n");
                }
            }
            if (!gameIsLost)
            {
                Console.WriteLine($"Score: {score}");
            }
            else
            {
                Console.WriteLine($"GameOver\nYour score was: {score}");
                Console.ReadKey();
            }
            
        }

        public void AddCell()
        {
            Random rng = new Random();
            bool cellAdded = false;
            int lap = 0;

            while (!cellAdded && lap++ < 17)
            {
                int row = rng.Next(0,4);
                int column = rng.Next(0,4);

                if (this.grid[row,column] == 0)
                {

                    if (rng.NextDouble() < 0.9)
                    {
                        grid[row, column] = 2;
                    }
                    else
                    {
                        grid[row, column] = 4;
                    } 
                    cellAdded = true;
                }
            }
            //if (!IsOver())
            //{
            //    gameIsLost = true;
            //}



        }

        public void Move()
        {
            var move = Console.ReadKey().Key;

            switch (move)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    CombineUp();
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    CombineDown();
                    MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    CombineLeft();
                    MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    CombineRight();
                    MoveRight();
                    break;

                default:
                    
                    break;
            }
        }

        private int[] GetRow(int row)
        {
            int[] result = new int[4];

            for (int i = 0; i < 4; i++)
            {
                result[i] = this.grid[row, i];
            }
            return result;
        }

        private int[] GetColumn(int column)
        {
            int[] result = new int[4];

            for (int i = 0; i < 4; i++)
            {
                result[i] = this.grid[i,column];
            }

            return result;
        }

        private void MoveLeft()
        {
            bool ready = false;
            bool isChanged = false;
            while (!ready)
            {
                isChanged = false;
                for (int row = 0; row < 4; row++)
                {
                    for (int index = 0; index < 3; index++)
                    {
                        if (grid[row,index] == 0 && grid[row,index + 1] != 0)
                        {
                            grid[row,index] = grid[row,index + 1];
                            grid[row,index + 1] = 0;
                            isChanged = true;
                        }
                    }
                }
                if (!isChanged)
                {
                    ready = true;
                }
            }
         
        }

        private void MoveRight()
        {
            bool ready = false;
            bool isChanged = false;
            while (!ready)
            {
                isChanged = false;
                for (int row = 0; row < 4; row++)
                {
                    for (int index = 3; index > 0; index--)
                    {
                        if (grid[row, index] == 0 && grid[row, index - 1] != 0)
                        {
                            grid[row, index] = grid[row, index - 1];
                            grid[row, index - 1] = 0;
                            isChanged = true;
                        }
                    }
                }
                if (!isChanged)
                {
                    ready = true;
                }
            }
        }

        private void MoveUp()
        {
            bool ready = false;
            bool isChanged = false;
            while (!ready)
            {
                isChanged = false;
                for (int index = 0; index < 4; index++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if (grid[row, index] == 0 && grid[row + 1, index] != 0)
                        {
                            grid[row, index] = grid[row + 1, index];
                            grid[row + 1, index] = 0;
                            isChanged = true;
                        }
                    }
                }
                if (!isChanged)
                {
                    ready = true;
                }
            }
        }

        private void MoveDown()
        {
            bool ready = false;
            bool isChanged = false;
            while (!ready)
            {
                isChanged = false;
                for (int index = 0; index < 4; index++)
                {
                    for (int row = 3; row > 0; row--)
                    {
                        if (grid[row, index] == 0 && grid[row - 1, index] != 0)
                        {
                            grid[row, index] = grid[row - 1, index];
                            grid[row - 1, index] = 0;
                            isChanged = true;
                        }
                    }
                }
                if (!isChanged)
                {
                    ready = true;
                }
            }
        }

        private void CombineLeft()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int index = 0; index < 3; index++)
                {
                    if (grid[row,index] == grid[row, index+1])
                    {
                        grid[row, index] *= 2;
                        grid[row, index + 1] = 0;
                        score += grid[row,index];
                    }
                }
            }
        }

        private void CombineRight()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int index = 3; index > 0; index--)
                {
                    if (grid[row, index] == grid[row, index - 1])
                    {
                        grid[row, index] *= 2;
                        grid[row, index - 1] = 0;
                        score += grid[row, index];
                    }
                }
            }
        }

        private void CombineUp()
        {
            for (int index = 0; index < 4; index++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (grid[row, index] == grid[row + 1, index])
                    {
                        grid[row, index] *= 2;
                        grid[row + 1, index] = 0;
                        score += grid[row, index];
                    }
                }
            }
        }

        private void CombineDown()
        {
            for (int index = 0; index < 4; index++)
            {
                for (int row = 3; row > 0; row--)
                {
                    if (grid[row, index] == grid[row - 1, index])
                    {
                        grid[row, index] *= 2;
                        grid[row - 1, index] = 0;
                        score += grid[row, index];
                    }
                }
            }
        }

        private bool IsOver()
        {
            bool result = false;
            Grid temp = new Grid();
            temp.grid = this.grid;
            
            temp.MoveLeft();
            //check horizontal
            for (int row = 0; row < 4; row++)
            {
                for (int index = 0; index < 3; index++)
                {
                    if (temp.grid[row, index] == temp.grid[row, index + 1])
                    {
                        result = true;
                    }
                }
            }
            temp.grid = this.grid;
            temp.MoveDown();
            //check vertical
            for (int index = 0; index < 4; index++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (temp.grid[row, index] == temp.grid[row + 1, index])
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
