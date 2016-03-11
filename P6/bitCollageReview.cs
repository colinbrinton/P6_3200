using System;
using System.Collections.Generic;

namespace P6
{
    class bitReviewCollage : bitCollage, IReview
    {
        review bitReview;
        const uint DFLT_SCORE = 3;
        const uint DFLT_RANK = 50;
        const bool DFLT_FREE = true;
        const int DFLT_DATE = 20161902;
        const int SCORE_MIN = 1;

        const int RANK_OUTOF = 100;
         public bitReviewCollage(List<int> col = null, uint scr = DFLT_SCORE, uint rnk = DFLT_RANK, 
             bool fr = DFLT_FREE, int dt = DFLT_DATE) : base(col)
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
