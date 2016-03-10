// AUTHOR: Colin Brinton
// FILENAME: imageCollage.cs
// DATE: 3/6/2016
// REVISION HISTORY: 4.0

/* DESCRIPTION:
 * The intended use of imageCollage is to "display" a selection of random images
 * stored within an external database. It generates an array of image ID's, 
 * represented as an array of ints. It returns an array of ints to the user
 * which may then be used trigger the real life display of images in a database.
 * The images in the database must be numbered consecutively 10000-99999.
 * It is not intended for imageCollage to store images but rather select images
 * to be displayed from a central storage area. Each object may be toggled "on"
 * or "off." After it's initialization, getDisplay() will return its image ID's
 * in the same order. Each call to getDisplay() is counted in a protected data
 * member which value can be returned via an accessor method. An image may be
 * replaced with another by passing the image ID to replaceImage(). The number
 * of successfully replaced images is counted in a protected data member which 
 * may also be returned via a public method. Finally, imgQuery() returns a bool
 * of true or false, the passed image ID is in the collage.
 */

/* ASSUMPTIONS:
 * Because a unique list of IDs is generated for each imageCollage object, it is
 * assumed that the class will be used as a trigger for a central database that
 * stores images. This is my interpretation of, "You do not need to actually store 
 * images: each image can be represented by a unique id" in the requirements. In
 * this example it is assumed that the image database holds 89999 images, labeled
 * consecutively 10000-99999. It is assumed that all images in the database are of
 * equal desire and therefore the images are selected randomly.
 */

using System;
using System.Collections.Generic; // Needed for List() to store image IDs

namespace P6
{
    class imageCollage
    {
        protected static Random rnd = new Random();
        protected const int NULL = 0;
        protected const List<int> NULL_COL = null;
        protected const int COL_MIN = 10000; //May be changed to accommodate an image database with a different 
        protected const int COL_MAX = 100000;//  amount of images.
        protected List<int> collage;
        protected bool active;
        protected int displaySize;
        protected int displayCount = 0;
        protected int replaceCount = 0;


        //Description - Public default constructor, accepts the desired number of image
        //              ID's with a default value of 5. Assumes used wants a random
        //              selection of images within their database. Will not allow for
        //              duplicate images.
        //postconditions: valid imageCollage object ready to use
        public imageCollage(List<int> col = NULL_COL)
        {
            active = true;
            collage = new List<int>(col);
            displaySize = collage.Count;
        }

        //preconditions: called on a properly allocated imageCollage object
        public int getDisplayCount()
        {
            if (active)
                return displayCount;
            else return NULL;
        }

        //preconditions: called on an active imageCollage object
        public int getReplaceCount()
        {
            if (active)
                return replaceCount;
            else return NULL;
        }

        //preconditions: called on a properly allocated imageCollage object
        //postcondition: changes state of object, turning "off" objects "on"
        //               and vice versa
        public void toggleActive()
        {
            if (active)
                active = false;
            else
                active = true;
        }

        //preconditions: called on an active imageCollage object
        public bool imgQuery(int imgID)
        {
            if (active)
            {
                if (collage.Contains(imgID))
                    return true;
            }
            return false;
        }

        //preconditions: Called on an active imageCollage object
        //postconditions: replaces passed imgID with new random,
        //                 non-duplicate ID
        public virtual bool replaceImage(int imgID)
        {
            if (active)
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

        //Description: returns the stored array of image ID's
        //preconditions: called on an active imageCollage object
        public virtual int[] getDisplay()
        {
            if (active)
            {
                ++displayCount;
                int[] display = new int[collage.Count];
                for (int index = 0; index < collage.Count; ++index)
                {
                    display[index] = collage[index];
                }
                return display;
            }
            else
            {
                int[] nullDisplay = new int[] { NULL };
                return nullDisplay;
            }
        }


    }
}
