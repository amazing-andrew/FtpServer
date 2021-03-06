﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public class Noop : FtpCommand
    {
        private const string NoopOK = "200 OK";

        public void Execute(FtpRequest request, FtpSession session) {
            session.Send(NoopOK);
        }
    }
}
