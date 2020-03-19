using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class BaseContext
    {
        protected readonly Context _context;
        public BaseContext(Context context) => _context = context;
    }
}
