using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null);
        void SendScholarship(string subject, string html, string from = null);
    }
}
