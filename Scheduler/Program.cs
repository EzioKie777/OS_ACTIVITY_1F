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
public int Tat =&gt; Completion - Arrival; // turnaround time
public int Wt =&gt; Tat - Burst; // waiting time
public int Rt =&gt; Start - Arrival; // response time
}
class Program
{
static List&lt;Proc&gt; MakeWorkload() =&gt; new List&lt;Proc&gt;
{
new Proc { Pid = 1, Arrival = 0, Burst = 7 },
new Proc { Pid = 2, Arrival = 2, Burst = 4 },
new Proc { Pid = 3, Arrival = 4, Burst = 1 },
new Proc { Pid = 4, Arrival = 5, Burst = 4 },
};
// Every algorithm returns a Gantt list: one entry per time unit,
// holding the pid that ran in that unit (0 = CPU idle).
static List&lt;int&gt; Fcfs(List&lt;Proc&gt; procs)
{
var gantt = new List&lt;int&gt;();
int t = 0;
foreach (var p in procs.OrderBy(x =&gt; x.Arrival).ThenBy(x =&gt; x.Pid))
{
// TODO 1: if the CPU is idle until p arrives, add 0 to gantt and advance t
// TODO 2: set p.Start, add p.Burst copies of p.Pid to gantt,
// advance t, then set p.Completion
}
return gantt;
}
static List&lt;int&gt; Sjf(List&lt;Proc&gt; procs) // nonpreemptive
{
var gantt = new List&lt;int&gt;();
var remaining = new List&lt;Proc&gt;(procs);
int t = 0;
while (remaining.Count &gt; 0)
{
// TODO 3: among processes with Arrival &lt;= t, pick the smallest Burst
// (ties: earlier Arrival, then smaller Pid).
// If none has arrived, add 0 (idle) to gantt, t++ and continue.
// TODO 4: run it to completion: set Start and Completion, fill gantt,
// advance t, and remove it from &#39;remaining&#39;
}
return gantt;
}
static List&lt;int&gt; RoundRobin(List&lt;Proc&gt; procs, int q)
{
var gantt = new List&lt;int&gt;();
var left = procs.ToDictionary(p =&gt; p.Pid, p =&gt; p.Burst); // remaining time
var queue = new Queue&lt;Proc&gt;();
var pending = procs.OrderBy(p =&gt; p.Arrival).ThenBy(p =&gt; p.Pid).ToList();
int t = 0, next = 0, finished = 0;
while (finished &lt; procs.Count)
{
// TODO 5 (see the steps in Task 3)
}
return gantt;
}
static void PrintReport(string name, List&lt;Proc&gt; procs, List&lt;int&gt; gantt)
{
Console.WriteLine($&quot;=== {name} ===&quot;);
var sb = new StringBuilder(&quot;Gantt: &quot;);
int start = 0;
for (int i = 1; i &lt;= gantt.Count; i++)
{
if (i == gantt.Count || gantt[i] != gantt[start])
{
string label = gantt[start] == 0 ? &quot;idle&quot; : $&quot;P{gantt[start]}&quot;;
sb.Append($&quot;|{label} {start}-{i} &quot;);
start = i;
}
}
sb.Append(&#39;|&#39;);
Console.WriteLine(sb);
Console.WriteLine(&quot;PID AT BT CT TAT WT RT&quot;);
foreach (var p in procs.OrderBy(x =&gt; x.Pid))
Console.WriteLine($&quot;{p.Pid,3} {p.Arrival,3} {p.Burst,3} {p.Completion,3}
{p.Tat,4} {p.Wt,3} {p.Rt,3}&quot;);
Console.WriteLine($&quot;Avg WT = {procs.Average(p =&gt; p.Wt):F2} Avg TAT =
{procs.Average(p =&gt; p.Tat):F2} Avg RT = {procs.Average(p =&gt; p.Rt):F2}&quot;);
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
var w = MakeWorkload(); PrintReport(&quot;FCFS&quot;, w, Fcfs(w));
w = MakeWorkload(); PrintReport(&quot;SJF&quot;, w, Sjf(w));
w = MakeWorkload(); PrintReport(&quot;Round Robin (q = 3)&quot;, w, RoundRobin(w, 3));
PartB();
}
}