namespace test
{
    internal class Program
    {
        static void Main()
        {
            // Seating is represented in a 2D array
            // 0  - no seat (non-seating area)
            // 1  - available seat
            // -1 - taken seat
            // 21 - available sofa left seat
            // 22 - available sofa right seat
            // -21 - taken sofa left seat
            // -22 - taken sofa right seat
            int[,] seating = new int[11, 20]
            {
            { 0,  0,  0,  0,  0,  0, -1, -1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 0,  0,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 0,  0,  0,  0,  0,  1,  1,  1,  1,  -1,  -1,  -1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 1,  1,  1,  0,  0,  1,  1,  -1,  -1,  -1,  -1,  -1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 1,  1,  1,  0,  0,  1,  1,  1,  1,  -1,  -1,  -1,  -1,  1,  1,  1,  1,  1,  1,  1 },
            { 1,  1,  1,  0,  0,  1,  1,  1,  1,  1,  1,  1,  -1,  1,  1,  1,  1,  1,  1,  1 },
            { 1, 21, 22,  0,  0,  1, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22 },
            { 1, 21, 22,  0,  0,  1, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22 },
            {21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22, 21, 22 },
            };

            Print2DArray(seating);

            var bestSeats = FindBestSeats(seating);

            if (bestSeats.Item1 != -1 && bestSeats.Item2 != -1)
            {
                Console.WriteLine($"The two best seats are: Row {bestSeats.Item3 + 1}, Seat {bestSeats.Item1 + 1} and Row {bestSeats.Item3 + 1}, Seat {bestSeats.Item2 + 1}");
            }
            else
            {
                Console.WriteLine("No suitable seats found.");
            }
        }

        static Tuple <int, int, int> FindBestSeats(int[,] seating)
        {

            int rowsMaxIndex = seating.GetLength(0) - 1;
            int colMaxIndex = seating.GetLength(1) - 1;

            int middleRow = seating.GetLength(0) % 2 != 0 ? seating.GetLength(0) / 2 : seating.GetLength(0) / 2 - 1;
            int middleCol = seating.GetLength(1) % 2 != 0 ? seating.GetLength(1) / 2 : seating.GetLength(1) / 2 - 1;

            bool found = false;

            
            var middle = Check(seating, true, true, middleCol, middleRow, out found);
            if(found) { return middle; }



            for (int i = 1; i <= Math.Max(middleRow, middleCol); i++)
            {
                int startY = middleRow; 
                int startX = middleCol;

                for (int j = 0; j <= i; j++)
                {
                    //left up
                    var leftUp = Check(seating, startX - i >= 0, startY - j >= 0, startX - i, startY - j, out found);
                    if (found) return leftUp;
                    //left down
                    var leftDown = Check(seating, startX - i >= 0, startY + j >= rowsMaxIndex, startX - i, startY + j, out found);
                    if (found) return leftDown;
                    //right up
                    var rightUp = Check(seating, startX + i <= colMaxIndex, startY - j >= 0, startX + i, startY - j, out found);
                    if (found) return rightUp;
                    //right down
                    var rightDown = Check(seating, startX + i <= colMaxIndex, startY + j <= rowsMaxIndex, startX + i, startY + j, out found);
                    if (found) return rightDown;


                    if (j < i) //one iteration less
                    {
                        //up left
                        var upLeft = Check(seating, startX - j >= 0, startY - i >= 0, startX - j, startY - i, out found);
                        if (found) return upLeft;
                        //up right
                        var upRight = Check(seating, startX + j <= colMaxIndex, startY - i >= 0, startX + j, startY - i, out found);
                        if (found) return upRight;
                        //down left
                        var downLeft = Check(seating, startX - j >= 0, startY + i <= rowsMaxIndex, startX - j, startY + i, out found);
                        if (found) return downLeft;
                        //down right
                        var downRight = Check(seating, startX + j <= colMaxIndex, startY + i <= rowsMaxIndex, startX + j, startY + i, out found);
                        if (found) return downRight;
                    }
                }
            }

            return Tuple.Create(-1, -1, -1);
        }

        static Tuple<int, int, int> Check(int [,] seating, bool firstIf, bool secondIf, int x, int y, out bool correct)
        {
            if(firstIf && secondIf)
            {
                correct = true;
                if (IsSeatAvailable(seating[y, x]) && IsSeatAvailable(seating[y, x + 1]))
                {
                    return Tuple.Create(x, x + 1 , y);
                }
                else if (IsSofaAvailable(seating[y , x], seating[y, x + 1]))
                {
                    return Tuple.Create(x, x + 1, y);
                }
            }

            correct = false;
            return Tuple.Create(-1, -1, -1);
        }

        static bool IsSeatAvailable(int seat)
        {
            return seat == 1;
        }

        static bool IsSofaAvailable(int seat1, int seat2)
        {
            return seat1 == 21 && seat2 == 22;
        }

        static void Print2DArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            Console.Write("\t");
            for (int j = 0; j < cols; j++)
            {
                Console.Write(j + 1 + ".\t");
            }
            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                Console.Write(i + 1 + ". \t");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
