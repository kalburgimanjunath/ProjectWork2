using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Data
{
    public interface IDbFactory :IDisposable
    {
        ProjectWorkContext Init();
    }
}
