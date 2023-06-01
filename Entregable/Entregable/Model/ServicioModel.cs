using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entregable.Model
{
    public class ServicioModel
    {

        [PrimaryKey, AutoIncrement]
        public int IdServicio { get; set; }

        public string FechaServicio { get; set; }
        public string Dire { get; set; }       

       
        public string HoraServicio { get; set; }

       
    }
}
