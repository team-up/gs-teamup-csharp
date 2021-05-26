using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace GsTeamupChat
{
    class Program
    {
        static void Main(string[] args)
        {
            EventService eventService = new EventService(new ChatService());
            while (true)
            {
                EventInfo eventInfo = eventService.GetInfo();
                if (eventInfo == null)
                {
                    Console.WriteLine("ev 정보를 받아올 수 없습니다.");
                    System.Threading.Thread.Sleep(1000 * 3);
                    return;
                }
                for (int i = 0; i < 86400 / (eventInfo.lpWaitTimeout + 5) + 1; i++)
                {
                    TeamupEventList eventWrap = eventService.Polling((eventInfo.lpWaitTimeout + 5) * 1000);
                    if(eventWrap == null)
                    {
                        System.Threading.Thread.Sleep(1000 * 3);
                        return;
                    }
                    if (eventWrap.events != null && eventWrap.events.Length != 0)
                    {
                        for (int j = 0; j < eventWrap.events.Length; j++)
                        {
                            eventService.ActionEvent(eventWrap.events[j]);
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(eventInfo.lpIdleTime * 1000);
                    }
                }
            }
        }
    }
}
