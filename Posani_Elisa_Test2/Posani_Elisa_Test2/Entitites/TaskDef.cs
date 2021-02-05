using System;
using System.Collections.Generic;
using System.Text;

namespace Posani_Elisa_Test2.Entitites
{
    public class TaskDef
    {
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        private int priority = -1;

        public int Priority
        {
            get { return priority; }
            set { if (value == 0 || value == 1 || value == 2) priority = value; else priority = -1; }
        }

    }
}
