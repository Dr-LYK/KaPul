using System;

namespace Kapul.Common.Commands
{
    public class GetCar : ICommand
    {
        public Guid Id { get; }
    }
}
