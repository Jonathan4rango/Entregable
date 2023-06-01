using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entregable.ViewModel
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string LastName { get; set; }

        [PrimaryKey]
        public int UserId { get; set; }
        public string Correo { get; set; }
        public string Contra { get; set; }

        [MaxLength(10)]
        public string Tel { get; set; }

        [Unique]
        public string Usuario { get; set; }



    }
}
