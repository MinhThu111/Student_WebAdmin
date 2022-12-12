using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_WebAdmin.Models;

namespace Student_WebAdmin.Services
{
    public class S_Product: IS_Product
    {
        public List<M_Product> getAll()
        {
            return new List<M_Product>
            {
                new M_Product{Id=1, Name="Milk", Age=12},
                new M_Product{Id=2, Name="Eggs", Age=1},
                new M_Product{Id=3, Name="Fish",Age=11}
            };
        }
        public string errObj()
        {
            return "hello everyone";
        }
    }
}
