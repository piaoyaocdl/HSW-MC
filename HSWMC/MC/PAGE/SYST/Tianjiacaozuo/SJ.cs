﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MC.PAGE.SYST.Tianjiacaozuo
{
    public class BumenSet
    {
        public long Id { set; get; }

        public string bumenmingcheng { set; get; }

        public virtual ICollection<YuangongSet> yuangongs { set; get; }
    }
    public class YuangongSet
    {
        public YuangongSet()
        {
            shixiangs = new List<PAGE.GONGZUOJIKU.ShixiangSet>(0);
        }
        public long Id { set; get; }

        public string yuangongmingzi { set; get; }

        public virtual ICollection<PAGE.GONGZUOJIKU.ShixiangSet> shixiangs { set; get; }

        public long bumenId { set; get; }
        public virtual BumenSet bumen { set; get; }
    }


}
