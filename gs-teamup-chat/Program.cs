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
            EventService eventService = new EventService();
            while (true)
            {
                TeamupEventList eventWrap = eventService.Polling();

                if (eventWrap != null && eventWrap.events != null && eventWrap.events.Length != 0) {
                    for (int i = 0; i < eventWrap.events.Length; i++)
                    {
                        eventService.ActionEvent(eventWrap.events[i]);
                    }
                }
            }
        }
    }
}
