using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data  
{
    public class DbFactory:Disposable,IDbFactory
    {
        ProjectWorkContext dbContext;
        public ProjectWorkContext Init()
        {
            return dbContext ?? (dbContext = new ProjectWorkContext());
        }
        protected override void DisposeCore() {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
