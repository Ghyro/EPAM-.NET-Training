using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.BusinessModels
{
    public class GeneratorId : IGetID
    {        
        public int GetId(int? id)
        {
            return (int)id++;
        }
    }
}
