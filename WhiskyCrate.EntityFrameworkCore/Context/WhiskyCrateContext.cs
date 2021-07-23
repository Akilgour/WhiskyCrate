using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyCrate.EntityFrameworkCore.Context
{
    public class WhiskyCrateContext : DbContext
    {
        public WhiskyCrateContext()
        { }

        public IDbSet<Distillery> Distilleries { get; set; }
    }
}
 