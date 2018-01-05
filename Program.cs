using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace FCFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Thread threadfcfs = new Thread(new ThreadStart(p.FCFS));
            threadfcfs.Start();

            Console.ReadKey();
        }
        Stopwatch Hesapla = new Stopwatch();

        public void FCFS()
        {
            Hesapla.Start();

            List<Process> processList = Sırala();

            Console.WriteLine("______________________________________");
            Console.WriteLine("Gant Chart FCFS");
            Console.WriteLine("______________________________________");

            int counter = 0;
            for (int i = 0; i < processList.Count; i++)
            {

                Console.Write(processList[i].processName + "\t");
                if (processList[i].arrivalTime < counter)
                    Console.Write(counter + "\t");
                else
                {
                    Console.Write(processList[i].arrivalTime + "\t");
                    counter = processList[i].arrivalTime;

                }
                counter += processList[i].burstTime;

                Console.Write(counter + "\t");


                Console.WriteLine();
            }

            Hesapla.Stop();
            Console.Write("FCFS algoritma çalışma süresi : ");
            TimeSpan HesaplananZaman = Hesapla.Elapsed;
            string HesaplamaSonucu = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", HesaplananZaman.Hours, HesaplananZaman.Minutes,
                HesaplananZaman.Seconds, HesaplananZaman.Milliseconds);
            Console.WriteLine(HesaplamaSonucu);

        }





        public List<Process> Sırala()
        {
            List<Process> processList = FileOperations();
            Process temp;
            for (int i = 0; i < processList.Count; i++)
            {
                for (int j = i + 1; j < processList.Count; j++)
                {
                    if (processList[i].arrivalTime > processList[j].arrivalTime || processList[i].arrivalTime == processList[j].arrivalTime && processList[i].burstTime > processList[j].burstTime)
                    {
                        temp = processList[i];
                        processList[i] = processList[j];
                        processList[j] = temp;
                    }
                }
            }
            return processList;
        }




        public List<Process> FileOperations()
        {
            List<Process> processList = new List<Process>();

            string dosya_yolu = @"processInfo.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                string[] line = yazi.Split(',');

                Process process = new Process(line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
                processList.Add(process);

                yazi = sw.ReadLine();

            }

            sw.Close();
            fs.Close();

            return processList;
        }




    }
}
