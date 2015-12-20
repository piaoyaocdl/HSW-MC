using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.PAGE.GONGZUOJIKU
{
    public class ShixiangSet
    {
        public long Id { set; get; }
        public string shixiang { set; get; }
        public string beizhu { set; get; }
        public virtual ICollection<ShixiangjinduSet> jindus { set; get; }
    }

    public class ShixiangjinduSet
    {
        public long Id { set; get; }
        public Nullable<DateTime> shijian { set; get; }
        public string jindu { set; get; }
    }
}
