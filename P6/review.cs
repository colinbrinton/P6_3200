using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6
{
    interface reviewI
    {
        uint getRawScore();
        uint getWeightedScore();
        bool wasFree();
        int getDate();
    }

    class review
    {
        static const uint DFLT_SCORE = 3;
        static const uint DFLT_RANK = 50;
        static const bool DFLT_FREE = true;
        static const int DFLT_DATE = 20161902;
        static const int SCORE_MIN = 1;

        static const int RANK_OUTOF = 100;

        uint score;
        uint rank;

        int date;
        bool free;

        public review(uint scr, uint rnk, bool fr, int dt)
        {
            score = scr;
	        rank = rnk;
	        free = fr;
	        date = dt;
        }


        public uint getRawScore()
        {
	        return score;
        }

        public uint getWeightedScore()
        {
	        double fullPoints = RANK_OUTOF;
	        double rankPercent = (rank / fullPoints);
	        double weighted = (score * rankPercent);

	        if (weighted < SCORE_MIN)
		        weighted = SCORE_MIN;
            return (uint)Math.Round(weighted);
        }

        public bool wasFree()
        {
	        return free;
        }

        public int getDate()
        {
	        return date;
        }
    }
}
