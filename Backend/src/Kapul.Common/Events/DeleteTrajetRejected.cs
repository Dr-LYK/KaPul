using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class DeleteTrajetRejected: IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        protected DeleteTrajetRejected()
        {
        }

        public DeleteTrajetRejected(Guid id, string reason, string code)
        {
            this.Id = id;
            this.Reason = reason;
            this.Code = code;
        }
    }
}
