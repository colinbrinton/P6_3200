using System;
using System.Collections.Generic;

namespace P6
{
    class bitReviewCollage : bitCollage, reviewI
    {
        review bitReview;
         public bitReviewCollage(List<int> col, uint scr, uint rnk, bool fr, int dt) : base(col)
        {
            bitReview = new review(scr, rnk, fr, dt);
        }

         public uint reviewI.getRawScore()
         {
             return bitReview.getRawScore();
         }

         public uint reviewI.getWeightedScore()
         {
             return bitReview.getWeightedScore();
         }

         public bool reviewI.wasFree()
         {
             return bitReview.wasFree();
         }

         public int reviewI.getDate()
         {
             return bitReview.getDate();
         }
    }
}
