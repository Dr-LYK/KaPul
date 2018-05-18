using System;
namespace Kapul.Services.Identity.DBO
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PassengerId { get; set; }
        public string Detail { get; set; }
        public byte Rate { get; set; }
    }
}
