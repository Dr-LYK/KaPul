using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Commands
{
    public class GetCar : ICommand
    {
        public Guid Id { get; }
    }
}
