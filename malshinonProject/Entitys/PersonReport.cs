using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinonProject.Entitys
{
    internal class PersonReport
    {
		private int Id;
        private int PersonId;

        private int ReportId;

        public PersonReport()
        {
        }

        public int id
		{
			get { return Id; }
			set {Id = value; }
		}
        

        public int personId
        {
            get { return PersonId; }
            set { PersonId = value; }
        }
        

        public int reportId
        {
            get { return ReportId; }
            set { ReportId = value; }
        }

    }
}
