using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurdyaevKursach.DataFolder
{
    public partial class kurdyaevEntities2 : DbContext
    {
        private static kurdyaevEntities2 context;

        public static kurdyaevEntities2 GetContext()
        {
            if (context == null)
            {
                context = new kurdyaevEntities2();
            }
            return context;
        }
    }
}
