using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.PAGE.GONGZUOJIKU
{
    public class ShixiangSet
    {
       public ShixiangSet()
        {
            jindus = new List<ShixiangjinduSet>(0);
        }
        public long Id { set; get; }
        public string shixiang { set; get; }
        public string beizhu { set; get; }
        public bool yiwanjie { set; get; }
        public virtual ICollection<ShixiangjinduSet> jindus { set; get; }

        public long yuangongId { set; get; }
        public virtual PAGE.SYST.Tianjiacaozuo.YuangongSet yuangong { set; get; }
    }

    public class ShixiangjinduSet
    {
        public long Id { set; get; }
        public Nullable<DateTime> shijian { set; get; }
        public string jindu { set; get; }

        public long shixiangId { set; get; }
        public virtual ShixiangSet shixiang { set; get; }
    }
}
