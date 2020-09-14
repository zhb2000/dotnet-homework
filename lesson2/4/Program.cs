using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CSHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock(100);
            clock.OnTick += (sender, time) => Console.WriteLine($"current time: {time}");
            clock.OnAlarm += (sender, time) => Console.WriteLine("Timeout!");
            clock.Start();
        }
    }

    class AlarmClock
    {
        public delegate void TickHandler(Object sender, int time);
        public delegate void AlarmHandler(Object sender, int time);

        /// <summary>
        /// 嘀嗒事件
        /// </summary>
        public event TickHandler OnTick = null;
        /// <summary>
        /// 响铃事件
        /// </summary>
        public event AlarmHandler OnAlarm = null;

        public AlarmClock(int alarmTime) => AlarmTime = alarmTime;

        /// <summary>
        /// 闹钟到时时间
        /// </summary>
        public int AlarmTime { get; set; }

        /// <summary>
        /// 开始计时
        /// </summary>
        public void Start()
        {
            new Thread(() =>
            {
                for (int time = 1; time <= AlarmTime; time++)
                {
                    OnTick?.Invoke(this, time);
                }
                OnAlarm?.Invoke(this, AlarmTime);
            }).Start();
        }
    }
}
