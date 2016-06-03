﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gs_teamup_chat
{
    class Message
    {
        [JsonProperty]
        internal string content { get; set; }

        public Message(string msg)
        {
            this.content = msg;
        }
    }
}