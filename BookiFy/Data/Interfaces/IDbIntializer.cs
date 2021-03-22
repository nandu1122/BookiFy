    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Data.Interfaces
{
    public interface IDbIntializer
    {
        void Initialize();
        void SeedData();

    }
}
