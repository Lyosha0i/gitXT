using System;
using System.Diagnostics;

namespace Task2._1._2
{

    class Program
    {
        static void Main(string[] args)
        {
            //Eloquent.All();
            Console.WriteLine();
            Figure[] figures = new Figure[400];
            Console.WriteLine("Choose the action:\n1. Add a figure\n2. Output figures\n3. Clear the canvas\n4. Exit");
            int c=0,i=0,j;
            //Ring a = new Ring(0,0,0,0);
            while (i!=4)
            {
                int.TryParse(Console.ReadLine(),out i);//i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Enter the type of the figure:\n1. Line\n2. Circle\n3. Ring\n4. Square\n5. Triangle");
                        int.TryParse(Console.ReadLine(), out j);
                        switch (j)
                        {
                            case 1:
                                Console.WriteLine("Enter settings of figure Line");
                                Console.WriteLine("Enter the first dot");
                                int x1L, y1L, x2L, y2L;
                                    int.TryParse(Console.ReadLine(),out x1L);
                                int.TryParse(Console.ReadLine(), out y1L);
                                Console.WriteLine("Enter the second dot");
                                int.TryParse(Console.ReadLine(), out x2L);
                                int.TryParse(Console.ReadLine(), out y2L);
                                Line line = new Line(x1L,y1L,x2L,y2L);
                                figures[c] = line;
                                c++;
                                Console.WriteLine("Figure Line has been created!");
                                break;
                                case 2:
                                		Console.WriteLine("Enter settings of figure Circle");
                                Console.WriteLine("Enter the center coordinates");
                                int xC, yC, rC;
                                int.TryParse(Console.ReadLine(), out xC);
                                int.TryParse(Console.ReadLine(), out yC);
                                Console.WriteLine("Enter the radius");
                                int.TryParse(Console.ReadLine(), out rC);
                                Circle circle = new Circle(xC, yC, rC);
                                figures[c] = circle;
                                c++;
                                Console.WriteLine("Figure Circle has been created!");
                                break;
                                case 3:
                                		Console.WriteLine("Enter settings of figure Ring");
                                Console.WriteLine("Enter the center coordinates");
                                int xR, yR, r1, r2;
                                int.TryParse(Console.ReadLine(), out xR);
                                int.TryParse(Console.ReadLine(), out yR);
                                Console.WriteLine("Enter the outer radius");
                                int.TryParse(Console.ReadLine(), out r1);
                                Console.WriteLine("Enter the inner radius");
                                int.TryParse(Console.ReadLine(), out r2);
                                Ring ring = new Ring(xR,yR,r1,r2);
                                figures[c] = ring;
                                c++;
                                Console.WriteLine("Figure Ring has been created!");
                                break;
                                case 4:
                                		Console.WriteLine("Enter settings of figure Square");
                                Console.WriteLine("Enter the first dot");
                                int x1S, y1S, x2S, y2S;
                                int.TryParse(Console.ReadLine(), out x1S);
                                int.TryParse(Console.ReadLine(), out y1S);
                                Console.WriteLine("Enter the second dot");
                                int.TryParse(Console.ReadLine(), out x2S);
                                int.TryParse(Console.ReadLine(), out y2S);
                                Square square = new Square(x1S,y1S,x2S,y2S);
                                figures[c] = square;
                                c++;
                                Console.WriteLine("Figure Square has been created!");
                                break;
                                case 5:
                                		Console.WriteLine("Enter settings of figure Triangle");
                                Console.WriteLine("Enter the first dot");
                                int x1T,y1T,x2T,y2T,x3T,y3T;
                                int.TryParse(Console.ReadLine(), out x1T);
                                int.TryParse(Console.ReadLine(), out y1T);
                                Console.WriteLine("Enter the second dot");
                                int.TryParse(Console.ReadLine(), out x2T);
                                int.TryParse(Console.ReadLine(), out y2T);
                                Console.WriteLine("Enter the third dot");
                                int.TryParse(Console.ReadLine(), out x3T);
                                int.TryParse(Console.ReadLine(), out y3T);
                                Triangle triangle = new Triangle(x1T,y1T,x2T,y2T,x3T,y3T);
                                figures[c] = triangle;
                                c++;
                                Console.WriteLine("Figure Triangle has been created!");
                                break;
                            default:break;
                                //1:
                                //		Console.WriteLine("Enter settings of figure {0}");
                                //Console.WriteLine("Enter center coordinates");
                                //Console.WriteLine("Enter radius");
                                //Console.WriteLine("Figure {0} has been created!");
                                //1:
                                //		Console.WriteLine("Enter settings of figure {0}");
                                //Console.WriteLine("Enter center coordinates");
                                //Console.WriteLine("Enter radius");
                                //Console.WriteLine("Figure {0} has been created!");
                                //1:
                                //		Console.WriteLine("Enter settings of figure {0}");
                                //Console.WriteLine("Enter center coordinates");
                                //Console.WriteLine("Enter radius");
                                //Console.WriteLine("Figure {0} has been created!");
                                //1:
                                //		Console.WriteLine("Enter settings of figure {0}");
                                //Console.WriteLine("Enter center coordinates");
                                //Console.WriteLine("Enter radius");
                                //Console.WriteLine("Figure {0} has been created!");
                                //1:
                                //		Console.WriteLine("Enter settings of figure {0}");
                                //Console.WriteLine("Enter center coordinates");
                                //Console.WriteLine("Enter radius");
                                //Console.WriteLine("Figure {0} has been created!");
                                //};
                                //break;
								};
                        Console.WriteLine("Choose the action:\n1. Add a figure\n2. Output figures\n3. Clear the canvas\n4. Exit");
                        break;
                            case 2:
                        foreach (Figure item in figures)
                        {
                            if (item == null) break;
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine("Choose the action:\n1. Add a figure\n2. Output figures\n3. Clear the canvas\n4. Exit");
                        break;
                            case 3:
                        for (j = 0; j < figures.Length; j++)figures[j]=null;
                        c = 0;
                        Console.WriteLine("Choose the action:\n1. Add a figure\n2. Output figures\n3. Clear the canvas\n4. Exit");
                        break;
                    case 4: break;
                    default:
                        Console.WriteLine("Choose the action:\n1. Add a figure\n2. Output figures\n3. Clear the canvas\n4. Exit");
                        break;
                };
                };
            }
        }
    }
