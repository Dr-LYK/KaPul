using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.ModelBinding
{
    public class LoginUserResponse
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}
