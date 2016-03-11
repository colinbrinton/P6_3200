using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6
{
    class Program
    {
        const int H_ARRAY_SIZE = 13; //Complete size of the testing array (10 random slots +3)
        const int DEFAULT_SIZE = 5;
        const int NUM_COL = 3; //Used for random distribution in hetero array
        const int IMAGE = 0;   //  |
        const int CYCLIC = 1;  //  |
        const int BIT = 2;     //  V
        const int MIN_IMG = 5; // Size range for the number of images
        const int MAX_IMG = 11;//     each test object should hold
        const int TEST_SIZE = 10; // Used for the non-random test objects in index 10-12
        const int REPEAT = 5;  //Number of times repeatDisplay() should call imageCollage.display()
        const int COLLAGE_PORTION = 2; // Used in 

        const int RANDOM_SIZE = H_ARRAY_SIZE - NUM_COL; //These allow the amount of random objects in
        const int BIT_INDEX = H_ARRAY_SIZE - 3;         // H_ARRAY_SIZE to change without breaking
        const int CYCLIC_INDEX = H_ARRAY_SIZE - 2;      //   the driver. |
        const int IMAGE_INDEX = H_ARRAY_SIZE - 1;       //               v

        static Random rnd = new Random();
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


            reviewCollage testObj = new reviewCollage();

            imageCollage[] heteroRCArray = new imageCollage[H_ARRAY_SIZE];
            IReview[] heteroRArray = new IReview[H_ARRAY_SIZE];


   

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

        // Description - accepts a reference to an array of the base class imageCollage.
        //               randomly allocates 10 slots of collage objects followed by one
        //               of each object.
        static void allocateRCArrays(ref imageCollage[] colArray, ref IReview revArray)
        {
            int collageSelector;
            int collageSize;

            for (int index = 0; index < colArray.Length; index++)
            {
                collageSelector = rnd.Next(NUM_COL);
                collageSize = rnd.Next(MIN_IMG, MAX_IMG);
                if (index < RANDOM_SIZE) //Random portion of array
                {
                    if (collageSelector == IMAGE)
                        colArray[index] = new imageCollage(generateCollage(collageSize));
                    if (collageSelector == CYCLIC)
                        colArray[index] = new cyclicCollage(generateCollage(collageSize));
                    if (collageSelector == BIT)
                        colArray[index] = new bitCollage(generateCollage(collageSize));
                }
                if (index >= RANDOM_SIZE) // Constant portion of array used in test suites
                {
                    colArray[index] = new bitCollage(generateCollage(TEST_SIZE));
                    ++index;
                    colArray[index] = new cyclicCollage(generateCollage(TEST_SIZE));
                    ++index;
                    colArray[index] = new imageCollage(generateCollage(TEST_SIZE));
                }
            }
        }
    }
}


