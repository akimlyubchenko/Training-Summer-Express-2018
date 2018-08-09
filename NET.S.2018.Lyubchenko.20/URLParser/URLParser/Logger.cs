﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLParser
{
    public abstract class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText("log.txt", $"{message}\n");
        }
    }
}
