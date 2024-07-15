using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FindTheBestSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    t[,] seats = new t[11, 18]
        //{
        //        //x = 18,y = 11
        //        // 1    2    3    4    5    6    7    8    9   10   11   12   13   14   15   16   17   18                     
        //        { t.x, t.x, t.x, t.x, t.x, t.x, t.n, t.n, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //1
        //        { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //2
        //        { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //3
        //        { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //4
        //        { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.fz, t.fz, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //5
        //        { t.f, t.f, t.f, t.x, t.x, t.f, t.f, t.f, t.fz, t.fz, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //6
        //        { t.f, t.f, t.f, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //7
        //        { t.f, t.f, t.f, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //8
        //        { t.f, t.sl, t.sp, t.x, t.x, t.f, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp },      //9  
        //        { t.f, t.sl, t.sp, t.x, t.x, t.f, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp },      //10   
        //        { t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp }   //11       
        //   //index 0    1    2    3    4    5    6    7    8    9   10   11   12   13   14   15   16   17                        
        //};



            t[,] seats = new t[11, 18]
        {
                //x = 18,y = 11
                // 1    2    3    4    5    6    7    8    9   10   11   12   13   14   15   16   17   18                     
                { t.x, t.x, t.x, t.x, t.x, t.x, t.n, t.n, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //1
                { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //2
                { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //3
                { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //4
                { t.x, t.x, t.x, t.x, t.x, t.f, t.f, t.f, t.fz, t.fz, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //5
                { t.f, t.f, t.f, t.x, t.x, t.f, t.f, t.f, t.fz, t.fz, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //6
                { t.f, t.f, t.f, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //7
                { t.f, t.f, t.f, t.x, t.x, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f, t.f },                    //8
                { t.f, t.sl, t.sp, t.x, t.x, t.f, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp },      //9  
                { t.f, t.sl, t.sp, t.x, t.x, t.f, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp },      //10   
                { t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp, t.sl, t.sp }   //11       
           //index 0    1    2    3    4    5    6    7    8    9   10   11   12   13   14   15   16   17                        
        };

            FindTheBestSeats();


            int[,] FindTheBestSeats()
            {
                int x = seats.GetLength(1);
                int y = seats.GetLength(0);
                Console.WriteLine(x);
                Console.WriteLine(y);

                bool x_is_event = x % 2 == 0;
                bool y_is_event = y % 2 == 0;

                int middle_x = !x_is_event ? x / 2 : x / 2 - 1;
                int middle_y = !y_is_event ? y / 2 : y / 2 - 1;

                Console.WriteLine($"index x :{middle_x}");
                Console.WriteLine($"index y: {middle_y}");

                int current_x = middle_x;
                int current_y = middle_y;


                int smallSkip = 0;
                int longSkip = 0;

                bool thereAreMorePlacesToCheck = true;
                bool placesFounded = false;
                if (y_is_event)
                {
                    return OnEvenNumberOfRows();
                }
                else
                {
                    return OnNotEvenNumberOfRows();
                }

                int[,] OnNotEvenNumberOfRows()
                {
                    while (thereAreMorePlacesToCheck && !placesFounded)
                    {
                        //Sprawdzenie czy aktualnie sprawdzane miejsca są wolne
                        int[,] founed = CheckCurrentPlacesRight(seats);
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        //jezeli nie
                        IncreaseSkips();

                        founed = OneUp();
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        founed = GoRight();
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        founed = GoDown();
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        GoLeft();

                        GoUp(checkDirection.left);

                        GoMiddle(checkDirection.left);

                    }
                    return new int[0, 0];




                }

                int[,] OnEvenNumberOfRows()
                {
                    while (thereAreMorePlacesToCheck && !placesFounded)
                    {
                        //Sprawdzenie czy aktualnie sprawdzane miejsca są wolne
                        int[,] founed = CheckCurrentPlacesRight(seats);
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        //jezeli nie
                        IncreaseSkips();

                        founed = OneUp();
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        founed = GoRight();
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        founed = GoDown();
                        if (founed.Length > 0)
                        {
                            return founed;
                        }

                        GoLeft();

                        GoUp(checkDirection.right);

                        GoMiddle(checkDirection.right);

                    }
                    return new int[0, 0];
                }

                void IncreaseSkips()
                {
                    smallSkip++;
                    longSkip = smallSkip * 2;
                }

                int[,] OneUp()
                {
                    current_y--;
                    return CheckCurrentPlacesRight(seats);

                }

                int[,] GoRight()
                {
                    for (int i = 0; i < smallSkip; i++)
                    {
                        current_x++;
                        var current =  CheckCurrentPlacesRight(seats);
                        if (current.Length > 0)
                        {
                            return current;
                        }
                    }
                    return new int[0,0];
                }

                int[,] GoDown()
                {
                    for(int i = 0; i < longSkip; i++)
                    {
                        current_y++;
                        var current = CheckCurrentPlacesRight(seats);
                        if (current.Length > 0)
                        {
                            return current;
                        }
                    }
                    return new int[0, 0];
                }

                int[,] GoLeft()
                {
                    for (int i = 0; i < longSkip; i++)
                    {
                        current_x--;
                        if(current_x >= middle_x)
                        {
                            var current = CheckCurrentPlacesRight(seats);
                            if (current.Length > 0)
                            {
                                return current;
                            }
                        }
                        if (current_x <= middle_x)
                        {
                            var current = CheckCurrentPlacesLeft(seats);
                            if (current.Length > 0)
                            {
                                return current;
                            }
                        }
                    }
                    return new int[0, 0];
                }

                int[,] GoUp(checkDirection direction)
                {
                    for (int i = 0; i < longSkip; i++)
                    {
                        current_y--;
                        var current = direction == checkDirection.right ? CheckCurrentPlacesRight(seats) : CheckCurrentPlacesLeft(seats); 
                        if (current.Length > 0)
                        {
                            return current;
                        }
                    }
                    return new int[0, 0];
                }

                int[,] GoMiddle(checkDirection direction)
                {
                    for (int i = 0; i < smallSkip; i++)
                    {
                        current_x++;
                        var current = direction == checkDirection.right ? CheckCurrentPlacesRight(seats) : CheckCurrentPlacesLeft(seats);
                        if (current.Length > 0)
                        {
                            return current;
                        }
                    }
                    return new int[0, 0];
                }


                int[,] CheckCurrentPlacesRight(t[,] seats)
                {
                    if (seats[current_y, current_x] == t.f && seats[current_y, current_x + 1] == t.f)
                    {
                        var result = new int[,]
                        {
                        {current_y, current_x },
                        {current_y, current_x + 1 }
                        };
                        Console.WriteLine($"miejsca znalezione! rząd: {result[0, 0] + 1}, miejsca {result[0, 1] + 1} i {result[1, 1] + 1}"); // plus jeden bo rzędy zaczynają się od 
                        placesFounded = true;
                        return result;
                    }
                    else return new int[0, 0];
                }

                int[,] CheckCurrentPlacesLeft(t[,] seats)
                {
                    if (seats[current_y, current_x] == t.f && seats[current_y, current_x - 1] == t.f)
                    {
                        var result = new int[,]
                        {
                        {current_y, current_x },
                        {current_y, current_x - 1 }
                        };
                        Console.WriteLine($"miejsca znalezione! rząd: {result[0, 0] + 1}, miejsca {result[0, 1] + 1} i {result[1, 1] + 1}"); // plus jeden bo rzędy zaczynają się od 
                        placesFounded = true;
                        return result;
                    }
                    else return new int[0, 0];
                }

                return new int[0, 0];

                
            }
        }

        

        public enum t
        {
            [Display(Name=" x ")]
            x,
            [Display(Name=" n ")]
            n,
            [Display(Name=" f ")]
            f,
            [Display(Name="sl ")]
            sl,
            [Display(Name="sp ")]
            sp,
            [Display(Name="fz ")]
            fz,
            [Display(Name="slz")]
            slz,
            [Display(Name="slp")]
            slp
        }
        public enum state
        {
            middle,
            left,
            right
        }
        public enum checkDirection
        {
            left, 
            right
        }
    }
}
