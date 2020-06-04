using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    interface IDatabaseSearch
    {
        void Search(string searchValue);
        void Search(int searchValue);
    }
}
