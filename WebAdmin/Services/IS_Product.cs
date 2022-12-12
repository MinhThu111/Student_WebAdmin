using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_WebAdmin.Models;

namespace Student_WebAdmin.Services
{
    public interface IS_Product
    {
        List<M_Product> getAll();
        string errObj();
    }
}
