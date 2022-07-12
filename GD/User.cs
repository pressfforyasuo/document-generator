using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GD
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Sername { get; set; }

        public string Otchestvo { get; set; }

        public string BirDay { get; set; }

        public string Role { get; set; }

        public string Kyrs {get; set; }

        public string Group { get; set; }


    }

}
