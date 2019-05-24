using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

/**
 *** Faruk_Altay 07.07.2018 
 */

namespace erp_proje
{
    class Class1
    {
        public SqlConnection myConn = new SqlConnection("Data Source=.;Integrated Security=TRUE;Initial Catalog=erp");


        public string ildoldur { get; set; }

    }
}
