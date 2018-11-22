using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class GeneratorId : IGetID
    {        
        public int GetId(int? Id)
        {
            return (int)Id++;
        }
    }
}
