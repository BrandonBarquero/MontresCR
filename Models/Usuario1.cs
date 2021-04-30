using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Usuario1
    {
        public string user { set; get; }
        public string contra { set; get; }

        public Usuario1(string user, string contra)
        {
            this.user = user;
            this.contra = contra;
        }

    }
}