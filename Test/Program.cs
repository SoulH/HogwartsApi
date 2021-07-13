using Core;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = new Registration() { Name = "012345678901234567890123456789" };
            var res = entity.Validate();
        }
    }
}
