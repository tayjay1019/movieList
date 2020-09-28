using System;
using System.IO;

namespace movieList
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string file = "movies.csv";
            Boolean leave = false;
            Boolean sub = false;

            StreamReader sr = new StreamReader(file);

            while(!leave){
                Console.WriteLine("Press 1 to read the list.");
                Console.WriteLine("Enter 2 to add to the list.");
                Console.WriteLine("Enter 4 to exit.");

                int resp;
                if(!int.TryParse(Console.ReadLine(), out resp)){
                    throw new Exception ("Not a valid option");
                }

                if (resp == 1){
                    while (!sr.EndOfStream){
                        string line = sr.ReadLine();
                        String[] arr = line.Split(',');
                        Console.WriteLine("{0,-8} {1,-40} {2}", arr[0], arr[1], arr[2]);
                    }
                    Console.WriteLine("");
                    sr.Close();
                }

                if (resp == 2){
                    while (!sub){
                        Console.WriteLine("Enter movie name");
                        String name = Console.ReadLine();
                        Console.WriteLine("Enter movie year");
                        String year = Console.ReadLine();
                        Console.WriteLine("Enter genre's with a '|' inbetween");
                        String genre = Console.ReadLine();

                        String check = name + " (" + year + ")";

                        while (!sr.EndOfStream){
                            string line = sr.ReadLine();
                            String[] test = line.Split(',');
                            
                            if( check == test[1]){
                                Console.WriteLine("Movie already in list");
                            }
                            else {
                                sub = true;
                            }
                        }
                    }
                }

                if (resp == 4){
                    leave = true;
                }

            }

        }
    }
}
