using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB.Core.Domain.Interfaces
{
    public interface IGlobalSettings
    {
        string PostgresConnStr { get; init; }
        string Secret { get; init; }
        string AdminName { get; init; }
        string AdminPassword { get; init; }
    }
}
