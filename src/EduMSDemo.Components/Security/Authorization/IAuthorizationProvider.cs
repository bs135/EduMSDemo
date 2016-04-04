﻿using System;

namespace EduMSDemo.Components.Security
{
    public interface IAuthorizationProvider
    {
        Boolean IsAuthorizedFor(Int32? accountId, String area, String controller, String action);

        void Refresh();
    }
}
