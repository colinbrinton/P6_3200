using System;
using System.Collections.Generic;

namespace P6
{
    class bitReviewCollage : bitCollage, IReview
    {
        review bitReview;
         public bitReviewCollage(List<int> col, uint scr, uint rnk, bool fr, int dt) : base(col)
        {
            bitReview = new review(scr, rnk, fr, dt);
        }

         uint IReview.getRawScore()
         {
             return bitReview.getRawScore();
         }

         uint IReview.getWeightedScore()
         {
             return bitReview.getWeightedScore();
         }

         bool IReview.wasFree()
         {
             return bitReview.wasFree();
         }

         int IReview.getDate()
         {
             return bitReview.getDate();
         }
    }
}
