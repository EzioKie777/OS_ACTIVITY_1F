// Names: ROY GABRIEL REFUGIO and NEL BONCALES
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Proc
{
public int Pid, Arrival, Burst;
public int Start = -1; // first CPU time (-1 = none yet)
public int Completion;
public int Tat => Completion - Arrival; // turnaround time
public int Wt => Tat - Burst; // waiting time
public int Rt => Start - Arrival; // response time
}
class Program
{
static List<Proc> MakeWorkload() => new List<Proc>
{
new Proc { Pid = 1, Arrival = 0, Burst = 7 },
new Proc { Pid = 2, Arrival = 2, Burst = 4 },
new Proc { Pid = 3, Arrival = 4, Burst = 1 },
new Proc { Pid = 4, Arrival = 5, Burst = 4 },
};
// Every algorithm returns a Gantt list: one entry per time unit,
// holding the pid that ran in that unit (0 = CPU idle).
static List<int> Fcfs(List<Proc> procs)
{
var gantt = new List<int>();
int t = 0;
foreach (var p in procs.OrderBy(x => x.Arrival).ThenBy(x => x.Pid))
{
// TODO 1: if the CPU is idle until p arrives, add 0 to gantt and advance t
// TODO 2: set p.Start, add p.Burst copies of p.Pid to gantt,
// advance t, then set p.Completion
}
return gantt;
}
static List<int> Sjf(List<Proc> procs) // nonpreemptive
{
var gantt = new List<int>();
var remaining = new List<Proc>(procs);
int t = 0;
while (remaining.Count > 0)
{
// TODO 3: among processes with Arrival <= t, pick the smallest Burst
// (ties: earlier Arrival, then smaller Pid).
// If none has arrived, add 0 (idle) to gantt, t++ and continue.
// TODO 4: run it to completion: set Start and Completion, fill gantt,
// advance t, and remove it from 'remaining'
}
return gantt;
}
static List<int> RoundRobin(List<Proc> procs, int q)
{
var gantt = new List<int>();
var left = procs.ToDictionary(p => p.Pid, p => p.Burst); // remaining time
var queue = new Queue<Proc>();
var pending = procs.OrderBy(p => p.Arrival).ThenBy(p => p.Pid).ToList();
int t = 0, next = 0, finished = 0;
while (finished < procs.Count)
{
// TODO 5 (see the steps in Task 3)
}
return gantt;
}
static void PrintReport(string name, List<Proc> procs, List<int> gantt)
{
Console.WriteLine($"=== {name} ===");
var sb = new StringBuilder("Gantt: ");
int start = 0;
for (int i = 1; i <= gantt.Count; i++)
{
if (i == gantt.Count || gantt[i] != gantt[start])
{
string label = gantt[start] == 0 ? "idle" : $"P{gantt[start]}";
sb.Append($"|{label} {start}-{i} ");
start = i;
}
}
sb.Append('|');
Console.WriteLine(sb);
Console.WriteLine("PID AT BT CT TAT WT RT");
foreach (var p in procs.OrderBy(x => x.Pid))
Console.WriteLine($"{p.Pid,3} {p.Arrival,3} {p.Burst,3} {p.Completion,3} {p.Tat,4} {p.Wt,3} {p.Rt,3}");
Console.WriteLine($"Avg WT = {procs.Average(p => p.Wt):F2} Avg TAT = {procs.Average(p => p.Tat):F2} Avg RT = {procs.Average(p => p.Rt):F2}");
Console.WriteLine();
}
static void PartB()
{
// Task set B: burst C and period T in milliseconds
double[] burst = { 25, 35 };
double[] period = { 50, 80 };
// TODO 6: compute U = sum of C/T, and the RM bound n * (2^(1/n) - 1).
// Print U, the bound, and whether RM and EDF are guaranteed to work.
}
static void Main()
{
var w = MakeWorkload(); PrintReport("FCFS", w, Fcfs(w));
w = MakeWorkload(); PrintReport("SJF", w, Sjf(w));
w = MakeWorkload(); PrintReport("Round Robin (q = 3)", w, RoundRobin(w, 3));
PartB();
}
}