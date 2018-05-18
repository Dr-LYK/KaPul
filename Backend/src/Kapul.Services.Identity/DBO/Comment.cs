using System;
namespace Kapul.Services.Identity.DBO
{
    public class Comment
    {
        public long Id { get; set; }
        public long PassengerId { get; set; }
        public string Detail { get; set; }
        public byte Rate { get; set; }
    }
}
