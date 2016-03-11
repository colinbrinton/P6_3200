using System;
using System.Collections.Generic;


namespace P6
{
    class cyclicReviewCollage : cyclicCollage, IReview
    {
        review cyclicReview;
        const uint DFLT_SCORE = 3;
        const uint DFLT_RANK = 50;
        const bool DFLT_FREE = true;
        const int DFLT_DATE = 20161902;
        const int SCORE_MIN = 1;

        const int RANK_OUTOF = 100;

         public cyclicReviewCollage(List<int> col = null, uint scr = DFLT_SCORE, uint rnk = DFLT_RANK, bool fr = DFLT_FREE, int dt = DFLT_DATE,
             int shft = DEFAUL_SHIFT) : base(col, shft)
        {
            cyclicReview = new review(scr, rnk, fr, dt);
        }

        uint IReview.getRawScore()
        {
            return cyclicReview.getRawScore();
        }

        uint IReview.getWeightedScore()
        {
            return cyclicReview.getWeightedScore();
        }

        bool IReview.wasFree()
        {
            return cyclicReview.wasFree();
        }

        int IReview.getDate()
        {
            return cyclicReview.getDate();
        }
    }
}
