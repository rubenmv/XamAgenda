using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamAgenda.Models
{
    public class Appointment
    {
        string description = String.Empty;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }
    }
}
