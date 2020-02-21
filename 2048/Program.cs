﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {

        

        static void Main(string[] args)
        {
            Grid grid = new Grid();
            grid.AddCell();
            grid.DrawGrid();
            
            while (!grid.GameIsLost)
            {
                grid.Move();
                grid.AddCell();
                grid.DrawGrid();
            }
            

           
        }
    }
}
