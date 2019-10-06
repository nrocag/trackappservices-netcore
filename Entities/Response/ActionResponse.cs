using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response
{
    public class ActionResponse
    {
        public ActionResponse(Message message, bool success)
        {
            this.Message = message;
            this.Success = success;
        }

        public Message Message { get; private set; }

        public bool Success { get; private set; }
    }
}
