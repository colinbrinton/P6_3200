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
        const int NUM_OBJ = 6; //Used for random distribution in hetero array
        const int IMAGE = 0;   //  |
        const int CYCLIC = 1;  //  |
        const int BIT = 2;     //  V
        const int REVIEW = 3;
        const int C_REVIEW = 4;
        const int B_REVIEW = 5;
        const int MIN_IMG = 5; // Size range for the number of images
        const int MAX_IMG = 11;//     each test object should hold
        const int TEST_SIZE = 10; // Used for the non-random test objects in index 10-12
        const int REPEAT = 5;  //Number of times repeatDisplay() should call imageCollage.display()
        const int COLLAGE_PORTION = 2; // Used in 

        const int RANDOM_SIZE = H_ARRAY_SIZE - NUM_OBJ; //These allow the amount of random objects in
        const int BIT_INDEX = H_ARRAY_SIZE - 3;         // H_ARRAY_SIZE to change without breaking
        const int CYCLIC_INDEX = H_ARRAY_SIZE - 2;      //   the driver. |
        const int IMAGE_INDEX = H_ARRAY_SIZE - 1;       //               v

        static Random rnd = new Random();
        static void Main()
        {

            imageCollage[] collageHeteroArary = new imageCollage[H_ARRAY_SIZE];

            imageCollage[] heteroRCArray = new imageCollage[NUM_OBJ];
            IReview[] heteroRArray = new IReview[NUM_OBJ];

            allocateCollageArray(ref collageHeteroArary);
            allocateTestArray(ref heteroRCArray, ref heteroRArray);

            displayAll(collageHeteroArary);

           // imageCollageTestSuite(heteroRCArray);

            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey(); //Input

         
        }

        static List<int> generateCollage(int size = DEFAULT_SIZE)
        {
            const int COL_MIN = 10000; //May be changed to accommodate an image database with a different 
            const int COL_MAX = 100000;//  amount of images.
            List<int> collage = new List<int>();
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

        //Description - Helper method used in test suite methods
        static void repeatDisplay(imageCollage item, int rep = REPEAT)
        {
            for (int count = 0; count < rep; ++count)
            {
                displayCollage(item.getDisplay());
                Console.WriteLine();
            }
        }

        //Description - Used in main() to display the random portion of the hetero array
        static void displayAll(imageCollage[] collageArray)
        {
            for (int index = 0; index < collageArray.Length; index++)
            {
                    Console.Write("Collage ");
                    Console.Write(index + 1);
                    Console.Write(": ");
                    displayCollage(collageArray[index].getDisplay());
                    Console.WriteLine();
            }
        }

        static void collageTestSuite(imageCollage[] collageArray)
        {
            const int OFFSET = 1;

            for (int index = 0; index < NUM_OBJ; index++)
            {
                Console.Write("Calling getDisplay() on object 5 times: ");
                Console.WriteLine();
                repeatDisplay(collageArray[index]);
                Console.WriteLine();

                Console.WriteLine();
                Console.Write("Testing replaceImage() imageCollage method: ");
                Console.WriteLine();
                Console.Write("Calling getDisplay() to fill an array of images to replace...");
                int[] replace = collageArray[index].getDisplay();
                Console.Write("Done.");
                Console.WriteLine();
                for (int k = 0; k < (TEST_SIZE / COLLAGE_PORTION); ++k)
                {
                    Console.Write("Attempting to replace ");
                    Console.Write(replace[k]);
                    Console.Write("...");
                    if (collageArray[k].replaceImage(replace[k])) //Each call will succeed because
                        Console.Write("Success!");                 //   each ID is in the object
                    else
                        Console.Write("Failed!");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.Write("Calling getDisplay() on object 5 more times: ");
                Console.WriteLine();
                repeatDisplay(collageArray[index]);
                Console.WriteLine();

                Console.WriteLine();
                Console.Write("Testing imgQuery(): ");
                Console.WriteLine();
                Console.Write("Is ");
                Console.Write(replace[(TEST_SIZE - (TEST_SIZE / COLLAGE_PORTION)) + OFFSET]);
                Console.Write(" in the collage: ");
                if (collageArray[index].imgQuery(replace[(TEST_SIZE - (TEST_SIZE / COLLAGE_PORTION)) + OFFSET]))
                    Console.Write("Yes!");
                else
                    Console.Write("No!");
                Console.WriteLine();
                Console.Write("Is ");
                Console.Write(replace[IMAGE]);
                Console.Write(" in the collage: ");
                if (collageArray[index].imgQuery(replace[IMAGE]))
                    Console.Write("Yes!");
                else
                    Console.Write("No!");
                Console.WriteLine();

                Console.WriteLine();
                Console.Write("getDisplay() has been called ");
                Console.Write(collageArray[index].getDisplayCount());
                Console.Write(" times.");
                Console.WriteLine();

                Console.Write(collageArray[index].getReplaceCount());
                Console.Write(" images have been replaced.");
                Console.WriteLine();

                Console.WriteLine();
                Console.Write("Calling toggleActive()...");
                collageArray[index].toggleActive();
                Console.Write("Done.");
                Console.WriteLine();
                Console.Write("Attempting to replace ");
                Console.Write(replace[(TEST_SIZE - (TEST_SIZE / COLLAGE_PORTION)) + OFFSET]); //This call will fail, already replaced above
                Console.Write("...");
                if (collageArray[index].replaceImage(replace[(TEST_SIZE - (TEST_SIZE / COLLAGE_PORTION)) + OFFSET]))
                    Console.Write("Success!");
                else
                    Console.Write("Failed!");
                Console.WriteLine();
                Console.Write("Attempting to display collage: ");
                displayCollage(collageArray[index].getDisplay());
                Console.WriteLine();

                Console.Write("Calling toggleActive()...");
                collageArray[index].toggleActive();
                Console.Write("Done.");
                Console.WriteLine();
                Console.Write("Attempting to replace ");
                Console.Write(replace[TEST_SIZE - (TEST_SIZE / COLLAGE_PORTION)]);
                Console.Write("...");
                if (collageArray[index].replaceImage(replace[TEST_SIZE - (TEST_SIZE / COLLAGE_PORTION)]))
                    Console.Write("Success!");
                else
                    Console.Write("Failed!");
                Console.WriteLine();
                Console.Write("Attempting to display collage: ");
                Console.WriteLine();
                displayCollage(collageArray[index].getDisplay());
                Console.WriteLine();

                Console.WriteLine();
                Console.Write("Press any key to clear screen and move on to next object...");
                Console.ReadKey(); //Input
                Console.Clear();
            }
        }

        // Description - accepts a reference to an array of the base class imageCollage.
        //               randomly allocates 10 slots of collage objects followed by one
        //               of each object.
        static void allocateCollageArray(ref imageCollage[] colArray)
        {
            int collageSelector;
            int collageSize;

            for (int index = 0; index < colArray.Length; index++)
            {
                collageSelector = rnd.Next(NUM_OBJ);
                collageSize = rnd.Next(MIN_IMG, MAX_IMG);
                    if (collageSelector == IMAGE)
                        colArray[index] = new imageCollage(generateCollage(collageSize));
                    if (collageSelector == CYCLIC)
                        colArray[index] = new cyclicCollage(generateCollage(collageSize));
                    if (collageSelector == BIT)
                        colArray[index] = new bitCollage(generateCollage(collageSize));
                    if (collageSelector == REVIEW)
                        colArray[index] = new reviewCollage(generateCollage(collageSize));
                    if (collageSelector == C_REVIEW)
                        colArray[index] = new cyclicReviewCollage(generateCollage(collageSize));
                    if (collageSelector == B_REVIEW)
                        colArray[index] = new bitReviewCollage(generateCollage(collageSize));
            }
        }

        static void allocateTestArray(ref imageCollage[] colArray, ref IReview[] revArray)
        {
            const int SCORE_MIN = 1;
            const int SCORE_MAX = 6;
            const int RANK_MIN = 1;
            const int RANK_MAX = 101;
            const int DATE_MIN = 20000101;
            const int DATE_MAX = 20160223;
            uint score;
            uint rank;
            bool free;
            int date;

             score = (uint)rnd.Next(SCORE_MIN, SCORE_MAX);
             rank = (uint)rnd.Next(RANK_MIN, RANK_MAX);
             free = (rnd.Next() % 2) == 1;
             date = rnd.Next(DATE_MIN, DATE_MAX);

             for (int collage = 0; collage < NUM_OBJ; collage++)
             {

                 if (collage == IMAGE)
                 {
                     imageCollage iC = new imageCollage(generateCollage(TEST_SIZE));
                     colArray[collage] = iC;
                 }
                 if (collage == CYCLIC)
                 {
                     cyclicCollage cC = new cyclicCollage(generateCollage(TEST_SIZE));
                     colArray[collage] = cC;
                 }
                 if (collage == BIT)
                 {
                     bitCollage bC = new bitCollage(generateCollage(TEST_SIZE));
                     colArray[collage] = bC;
                 }
                 if (collage == REVIEW)
                 {
                     reviewCollage rC = new reviewCollage(generateCollage(TEST_SIZE), score, rank, free, date);
                     colArray[collage] = rC;
                     revArray[collage] = rC;
                 }
                 if (collage == C_REVIEW)
                 {
                     cyclicReviewCollage cRC = new cyclicReviewCollage(generateCollage(TEST_SIZE), score, rank, free, date);
                     colArray[collage] = cRC;
                     revArray[collage] = cRC;
                 }
                 if (collage == B_REVIEW)
                 {
                     bitReviewCollage bRC = new bitReviewCollage(generateCollage(TEST_SIZE), score, rank, free, date);
                     colArray[collage] = bRC;
                     revArray[collage] = bRC;
                 }
             }
        }
    }
}


