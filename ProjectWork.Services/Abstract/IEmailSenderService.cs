﻿using ProjectWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Services
{
    public interface IEmailSenderService
    {
          Task sendMail(EmailMessage message);
    }
}
