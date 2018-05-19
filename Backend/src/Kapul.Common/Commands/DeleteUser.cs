using System;
namespace Kapul.Common.Commands
{
    public class DeleteUser : ICommand
    {
        public Guid Id { get; }
    }
}
