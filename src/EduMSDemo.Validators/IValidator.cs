﻿using EduMSDemo.Components.Alerts;
using System;
using System.Web.Mvc;

namespace EduMSDemo.Validators
{
    public interface IValidator : IDisposable
    {
        ModelStateDictionary ModelState { get; set; }
        Int32 CurrentAccountId { get; set; }
        AlertsContainer Alerts { get; set; }
    }
}
