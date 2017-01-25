using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrnsnChecker
{
    public class Character
    {
        public string Name { get; set; }
        public string Server { get; set; }

        public Character(string input)
        {
            var splittedInput = input.Split('-');
            Name = splittedInput[0];
            Server = splittedInput[1];
        }
    }
}
