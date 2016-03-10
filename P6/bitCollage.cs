// AUTHOR: Colin Brinton
// FILENAME: bitCollage.cs
// DATE: 3/6/2016
// REVISION HISTORY: 4.0

/* DESCRIPTION:
 * Extends the functionality of imageCollage. It uses an overridden getDisplay()
 * to display a subset of its image IDs which is randomly determined to be between.
 * one and three less than its original set. replaceImage is overridden all will only
 * successfully replace odd image ID's.
 */

/* ASSUMPTIONS:
 * replaceImage() will not be used on even image ID's. 
 */

using System;
using System.Collections.Generic;

namespace P6
{
    class bitCollage : imageCollage
    {
        const int MIN_OMIT = 1;
        const int MAX_OMIT = 4;

        //Description - Public default constructor, accepts the desired number of image
        //              ID's with a default value of 5. Assumes used wants a random
        //              selection of images within their database. Will not allow for
        //              duplicate images.
        //postconditions: valid bitCollage object ready to use
        public bitCollage(List<int> col) : base(col) {}

        //Description: returns the a smaller subset of its stored image ID's, will
        //             randomly omit 1-3 images from returned int array.
        //preconditions: called on an active bitCollage object
        public override int[] getDisplay()
        {
            if (active)
            {
                ++displayCount;
                int omit = rnd.Next(MIN_OMIT, MAX_OMIT);
                List<int> omitList = new List<int>();
                int[] display = new int[collage.Count - omit];
                int randomIndex;
                while (omit > 0)
                {
                    randomIndex = rnd.Next(0, (collage.Count - 1));
                    while (omitList.Contains(randomIndex))
                        randomIndex = rnd.Next(0, (collage.Count - 1));
                    omitList.Add(randomIndex);
                    --omit;
                }

                int displayIndex = 0;
                for (int index = 0; index < collage.Count; ++index)
                {
                    if (!omitList.Contains(index))
                    {
                        display[displayIndex] = collage[index];
                        ++displayIndex;
                    }
                }
                return display;
            }
            else
            {
                int[] nullDisplay = new int[] { NULL };
                return nullDisplay;
            }
        }

        //preconditions: Called on an active imageCollage object
        //               passed an odd ID
        //postconditions: replaced passed "imgID" with new random,
        //                 non-duplicate ID (if ODD)
        public override bool replaceImage(int imgID)
        {
            if (active && ((imgID % 2) != 0))
            {
                if (collage.Contains(imgID))
                {
                    int replacement = rnd.Next(COL_MIN, COL_MAX);
                    while (collage.Contains(replacement))
                        replacement = rnd.Next(COL_MIN, COL_MAX);
                    collage[collage.IndexOf(imgID)] = replacement;
                    ++replaceCount;
                    return true;
                }
            }
            return false;
        }

    }
}
