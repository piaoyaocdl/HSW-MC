namespace MC
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Shujuku : DbContext
    {
        
        public Shujuku()
            : base("name=Shujuku")
        {
        }


        public virtual DbSet<PAGE.SYST.Tianjiacaozuo.BumenSet> BumenSet { get; set; }
        public virtual DbSet<PAGE.SYST.Tianjiacaozuo.YuangongSet> YuangongSet { get; set; }
        public virtual DbSet<PAGE.GONGZUOJIKU.ShixiangSet> ShixiangSet { get; set; }
        public virtual DbSet<PAGE.GONGZUOJIKU.ShixiangjinduSet> ShixiangjinduSet { get; set; }
    }
}