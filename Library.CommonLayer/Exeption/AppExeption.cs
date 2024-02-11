using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonLayer.Exeption
{
    public class AppExeption:Exception
    {
        public AppExeption(string message):base(message)
        {

        }
    }
}
