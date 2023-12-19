using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIS_LAB2_ELEMENT;

namespace AIS_LAB2_AGREGATE
{
    public interface IBranchHandable
    {
        void AddNewDetail(Detail detail);
        void PutToBad(Detail detail);
    }

    public abstract class Branch:IBranchHandable
    {
        public List<Detail> details;
        public List<Detail> badDetails;

        public abstract void AddNewDetail(Detail detail);
        public abstract void PutToBad(Detail detail);
    }

    public class FixedSizeBranch : Branch
    {
        public List<Detail> details = new List<Detail>();
        public List<Detail> badDetails = new List<Detail>();

        int code;
        int size;
        string detailType;

        public FixedSizeBranch(int code, int size, string detailType)
        {
            this.code = code;
            this.size = size;
            this.detailType = detailType;
        }


        public override void AddNewDetail(Detail detail) 
        {
            if (details.Count<=size)
            {
                details.Add(detail);
            }
            else
            {
                Console.WriteLine("Партия полна");
            }
        }
        public override void PutToBad(Detail detail)
        {
            badDetails.Add(detail);
            details.Remove(detail);
        }
    }

    public class FreeSizeBranch : Branch
    {
        public List<Detail> details = new List<Detail>();
        public List<Detail> badDetails = new List<Detail>();

        int code;
        string detailType;

        public FreeSizeBranch(int code, string detailType)
        {
            this.code = code;
            this.detailType = detailType;
        }

        public override void PutToBad(Detail detail)
        {
            details.Add(detail);
        }

        public override void AddNewDetail(Detail detail) 
        {
            badDetails.Add(detail);
            details.Remove(detail);
        }
    }
}
