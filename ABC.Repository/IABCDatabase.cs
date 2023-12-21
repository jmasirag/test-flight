using ABC.Repository.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Repository
{
    public interface IABCDatabase
    {
        List<DFWGateLoungeFlight> DFWGateLoungeFlight { get; }
    }
}
