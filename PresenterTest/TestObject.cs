using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenterTest
{
    class TestObject
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Val { get; set; }

        public enum eType
        {
            T1, T2, T3
        }
        public eType Type { get; set; }
    }
}
