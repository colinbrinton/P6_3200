using System;
using System.Collections.Generic;

namespace P6
{
  
    class reviewCollage : imageCollage, IReview
    {
        review imageReview;
        const uint DFLT_SCORE = 3;
        const uint DFLT_RANK = 50;
        const bool DFLT_FREE = true;
        const int DFLT_DATE = 20161902;
        const int SCORE_MIN = 1;

        const int RANK_OUTOF = 100;

        public reviewCollage(List<int> col = null, uint scr = DFLT_SCORE, uint rnk = DFLT_RANK, bool fr = DFLT_FREE, int dt = DFLT_DATE)
            : base(col)
        {
            imageReview = new review(scr, rnk, fr, dt);
        }

        uint IReview.getRawScore()
        {
            return imageReview.getRawScore();
        }

        uint IReview.getWeightedScore()
        {
            return imageReview.getWeightedScore();
        }

        bool IReview.wasFree()
        {
            return imageReview.wasFree();
        }

        int IReview.getDate()
        {
            return imageReview.getDate();
        }

    }
}
