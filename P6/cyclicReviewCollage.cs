using System;
using System.Collections.Generic;


namespace P6
{
    class cyclicReviewCollage : cyclicCollage, reviewI
    {
        review cyclicReview;

         public cyclicReviewCollage(List<int> col, uint scr, uint rnk, bool fr, int dt, int shft) : base(col, shft)
        {
            cyclicReview = new review(scr, rnk, fr, dt);
        }

        public uint reviewI.getRawScore()
        {
            return cyclicReview.getRawScore();
        }

        public uint reviewI.getWeightedScore()
        {
            return cyclicReview.getWeightedScore();
        }

        public bool reviewI.wasFree()
        {
            return cyclicReview.wasFree();
        }

        public int reviewI.getDate()
        {
            return cyclicReview.getDate();
        }
    }
}
