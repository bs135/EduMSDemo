﻿using System;

namespace EduMSDemo.Components.Alerts
{
    public class Alert
    {
        public String Message { get; set; }
        public AlertType Type { get; set; }
        public Decimal FadeoutAfter { get; set; }
    }
}
