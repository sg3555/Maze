using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze
{
    class SearchMaze
    {
        public SearchMaze() { }

        public void startMap(Map mp)
        {
            mp.searchPoint();

            Stack<Location2D> locStack = new Stack<Location2D>();
            List<Location2D> record = new List<Location2D>();
            Location2D entry = new Location2D(mp.startRow, mp.startCol);
            locStack.Push(entry);
            bool isSuccess = false;
            mp.printMaze();

            while (locStack != null)
            {
                Thread.Sleep(500);
                Location2D here = locStack.Pop();

                int r = here.row;
                int c = here.col;
                record.Add(new Location2D(r, c));
                
                if (r == mp.endRow && c == mp.endCol)
                {
                    mp.SetMap(r, c, '.');
                    mp.printMaze();
                    Console.WriteLine("미로 탐색 성공");
                    isSuccess = true;
                    break;
                }
                else
                {
                    mp.SetMap(r, c, '.');
                    mp.printMaze();
                    Console.Write($"({r},{c}) ");
                    if (mp.isJucntion(r, c)==true)
                    {
                        Console.Write("\n지금까지 지나온 길 : ");
                        for(int i = 0; i<record.Count;i++)
                        {
                            Console.Write($"({record[i].row},{record[i].col})");
                        }
                        Console.WriteLine();
                        Thread.Sleep(100);
                    }
                    if (mp.isValidLoc(r - 1, c)) locStack.Push(new Location2D(r - 1,c));
                    if (mp.isValidLoc(r + 1, c)) locStack.Push(new Location2D(r + 1, c));
                    if (mp.isValidLoc(r, c - 1)) locStack.Push(new Location2D(r, c - 1));
                    if (mp.isValidLoc(r, c + 1)) locStack.Push(new Location2D(r, c + 1));
                }
                
            }
            if(isSuccess == false)
                Console.WriteLine("미로 탐색 실패");
        }
    }
}
