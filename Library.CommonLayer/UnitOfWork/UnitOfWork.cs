using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.UnitOfWork
{
    public interface UnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Save();
        Task RoleBack();
    }
}
