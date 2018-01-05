using System;
using System.Collections.Generic;
using System.Text;

namespace FCFS
{
    public class Process
    {
        public string processName;
        public int burstTime;
        public int priority;
        public int arrivalTime;
        public Process(string name, int arrivalTime, int burstTime, int priority)
        {
            processName = name;
            this.burstTime = burstTime;
            this.priority = priority;
            this.arrivalTime = arrivalTime;


        }
    }
}
