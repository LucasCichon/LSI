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
            { 0,  0,  0,  0,  0,  1,  1,  1, -1,  -1,  -1, -1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 1,  1,  1,  0,  0,  1,  1,  1,  1, -1,  1,  -1,  1,  1,  1,  1,  1,  1,  1,  1 },
            { 1,  1,  1,  0,  0,  1,  1,  1,  -1,  1,  1,  -1,  -1,  1,  1,  1,  1,  1,  1,  1 },
            { 1,  1,  1,  0,  0,  1,  1,  1,  1,  -1,  -1,  -1,  -1,  1,  1,  1,  1,  1,  1,  1 },
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

            int rowsMaxIndex = seating.GetLength(0) - 1; //10
            int colMaxIndex = seating.GetLength(1) - 1; //17

            int middleRow = seating.GetLength(0) % 2 != 0 ? seating.GetLength(0) / 2 : seating.GetLength(0) / 2 - 1;
            int middleCol = seating.GetLength(1) % 2 != 0 ? seating.GetLength(1) / 2 : seating.GetLength(1) / 2 - 1;

            bool found = false;

            
            var middle = Check(seating, true, true, middleCol, middleRow, out found);
            if(found) { return middle; }

            for (int i = 1; i <= Math.Max(middleRow, middleCol); i++) // is the offset value
            {
                int startY = middleRow - i > 0 ? middleRow - i : 0; //5 + i
                int startX = middleCol - i > 0 ? middleCol - i : 0; //8 + i
                int left = i * 2 + 1;
                int offset = i * 2;

                for (int j = 0; j < left; j++)
                {
                    var first = Check(seating, startY <= rowsMaxIndex, startX + j < colMaxIndex, startX + j, startY, out found);
                    if (found) return first;

                    var second = Check(seating, startY + offset <= rowsMaxIndex, startX + j < colMaxIndex, startX + j, startY + offset, out found);
                    if (found) return second;

                    if (j > 0)
                    {
                        var third = Check(seating, startY + j <= rowsMaxIndex, startX < colMaxIndex, startX, startY + j, out found);
                        if(found) return third;

                        var fourth = Check(seating, startY + j <= rowsMaxIndex, startX + offset < colMaxIndex, startX + offset, startY + j, out found);
                        if (found) return fourth;
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
