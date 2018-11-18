using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Maze
{
    public class Map
    {
        public Map() { }
        private static int MAX_SIZE = 6;

        public int startRow { get; set; }
        public int startCol { get; set; }
        public int endRow { get; set; }
        public int endCol { get; set; }

        char[,] map = new char[6, 6]{
            {'1','1','1','1','1','1'},
            {'0','0','1','0','0','0'},
            {'1','0','0','0','1','1'},
            {'1','0','1','0','1','1'},
            {'1','0','1','0','1','1'},
            {'1','1','1','1','1','1'},
        };

        public void searchPoint()
        {
            startRow = 9999;
            startCol = 9999;
            endRow = 9999;
            endCol = 9999;
            for (int i = 0; i < 6; i++)
            {
                if (map[i, 0] == '0' &&startRow==9999&&startCol==9999)
                {
                    startRow = i;
                    startCol = 0;
                    break;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (map[0, i] == '0' && startRow == 9999 && startCol == 9999)
                {
                    startRow = 0;
                    startCol = i;
                    break;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (map[6 - 1, i] == '0' && startRow == 9999 && startCol == 9999)
                {
                    startRow = 6 - 1;
                    startCol = i;
                    break;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (map[i, 6 - 1] == '0' && startRow == 9999 && startCol == 9999)
                {
                    startRow = i;
                    startCol = 6 - 1;
                    break;
                }
            }
            
            if(startRow == 9999||startCol == 9999)
            {
                Console.WriteLine("출발지점을 인식하지 못했습니다.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            for (int i = 6 - 1; i > 0; i--)
            {
                if (map[i, 6 - 1] == '0' && endRow == 9999 && endCol == 9999)
                {
                    if (i != startRow || (6 - 1) != startCol)
                    {
                        endRow = i;
                        endCol = 6 - 1;
                        break;
                    }

                }
            }
            for (int i = 6 - 1; i > 0; i--)
            {
                if (map[6 - 1, i] == '0'&&endRow==9999 && endCol ==9999)
                {
                    if ((6 - 1) != startRow || i != endCol)
                    {
                        endRow = 6 - 1;
                        endCol = i;
                        break;
                    }
                }
            }
            for (int i = 6 - 1; i > 0; i--)
            {
                if (map[0, i] == '0' && endRow == 9999 && endCol == 9999)
                {
                    if (0 != startRow || i != endCol)
                    {
                        endRow = 0;
                        endCol = i;
                        break;
                    }
                }
            }
            for (int i = 6 - 1; i > 0; i--)
            {
                if (map[i, 0] == '0' && endRow == 9999 && endCol == 9999)
                {
                    if (i != startRow || 0 != endCol)
                    {
                        endRow = i;
                        endCol = 0;
                        break;
                    }
                }
            }
            if (endRow == 9999 || endCol == 9999)
            {
                Console.WriteLine("도착지점을 인식하지 못했습니다.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        public bool isValidLoc(int r, int c)
        {
            if (r < 0 || c < 0 || r >= MAX_SIZE || c >= MAX_SIZE) return false;
            else return map[r, c] == '0' || map[r, c] == 'x';
        }
        
        public bool isJucntion(int r, int c)
        {
            if (r > 0 && c > 0 && r < MAX_SIZE-1 && c < MAX_SIZE-1)
            {
                int way = 0;
                if (map[r - 1, c] == '0' ||
                    map[r - 1, c] == '.')
                    way++;
                if (map[r + 1, c] == '0' ||
                    map[r + 1, c] == '.')
                    way++;
                if (map[r, c - 1] == '0' ||
                    map[r, c - 1] == '.')
                    way++;
                if (map[r, c + 1] == '0' ||
                    map[r, c + 1] == '.')
                    way++;

                if (way >= 3) return true;
                else return false;
            }
            return false;
            
        }

        public char GetMap(int r, int c)
        {
            return map[r, c];
        }

        public void SetMap(int r, int c, char t)
        {
            this.map[r, c] = t;
        }

        public void printMaze()
        {
            // Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (map[i, j] == '1') Console.Write("■");          //벽
                    if (map[i, j] == '0') Console.Write("  ");         //빈공간
                    if (map[i, j] == 'e') Console.Write("◎");          //출발지점
                    if (map[i, j] == 'x') Console.Write("↓");          //도착지점
                    if (map[i, j] == '.') Console.Write("△");          //지나간 길(스택)
                }
                Console.WriteLine();
            }
        }
    }
}
