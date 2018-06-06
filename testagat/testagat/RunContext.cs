using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testagat
{
    public class RunContext
    {
        private static RunContext Instance = null;
        public int CurrentTaskID { get; set; }
        private RunContext()
        {

        }
        public static RunContext GetInstance()
        {
            if (Instance == null)
                Instance = new RunContext();
            return Instance;
        }
    }
}