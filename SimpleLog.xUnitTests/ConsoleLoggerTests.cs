﻿using System;
using Xunit;

namespace SimpleLog.xUnitTests
{
    [Trait("","ConsoleTarget")]
    public class ConsoleLoggerTests
    {
        [Fact(DisplayName ="Fallbacks to default formatter if error")]
        public void FallbackToDefaultFormatterIfError()
        {
            string log = string.Empty;
            void write(string msg) => log = msg;

            new SimpleLog.ConsoleTarget.ConsoleTarget(write, write)
            {
                Formatter = (e) => { throw new Exception(); }
            }.Log(new LogEntry()
            {
                Message = "logged message"
            });

            Assert.StartsWith("Log format exception falling back", log);
            Assert.EndsWith("logged message", log);
        }
    }
}
