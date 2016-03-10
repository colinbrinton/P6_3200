using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6
{
    class Program
    {
        const int DEFAULT_SIZE = 5;
        static void Main()
        {

            imageCollage testCollage = new imageCollage(generateCollage());
            displayCollage(testCollage.getDisplay());

            Console.WriteLine();

            cyclicCollage testCyclic = new cyclicCollage(generateCollage());
            displayCollage(testCyclic.getDisplay());

            Console.WriteLine();

            bitCollage testBit = new bitCollage(generateCollage());
            displayCollage(testBit.getDisplay());

            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey(); //Input
           
        }

        static List<int> generateCollage(int size = DEFAULT_SIZE)
        {
            const int COL_MIN = 10000; //May be changed to accommodate an image database with a different 
            const int COL_MAX = 100000;//  amount of images.
            List<int> collage = new List<int>();
            Random rnd = new Random();
            for (int index = 0; index < size; index++)
            {
                int randomImg = rnd.Next(COL_MIN, COL_MAX);
                while (collage.Contains(randomImg))
                    randomImg = rnd.Next(COL_MIN, COL_MAX);
                collage.Add(randomImg);
            }

            return collage;
        }

        //Description - Helper method used above and in test suite methods
        static void displayCollage(int[] imgCol)
        {
            int index = 0;
            Console.Write(imgCol[index]);
            foreach (int element in imgCol)
            {
                if (index != 0)
                {
                    Console.Write(", ");
                    Console.Write(imgCol[index]);
                }
                ++index;
            }

        }
    }
}
