using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaFarmTaskCore.Repositories
{
    public static class IdGenerator
    {
        private static int _currentId = 0;

        public static int Generate()
        {
            return ++_currentId;
        }
    }
}
