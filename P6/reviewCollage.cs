using System;
using System.Collections.Generic;

namespace P6
{
  
    class reviewCollage : imageCollage, reviewI
    {
        review imageReview;

        public reviewCollage(List<int> col, uint scr, uint rnk, bool fr, int dt) : base(col)
        {
            imageReview = new review(scr, rnk, fr, dt);
        }

        public uint reviewI.getRawScore()
        {
            return imageReview.getRawScore();
        }

        public uint reviewI.getWeightedScore()
        {
            return imageReview.getWeightedScore();
        }

        public bool reviewI.wasFree()
        {
            return imageReview.wasFree();
        }

        public int reviewI.getDate()
        {
            return imageReview.getDate();
        }

    }
}
