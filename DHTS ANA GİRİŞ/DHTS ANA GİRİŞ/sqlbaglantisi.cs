using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DHTS_ANA_GİRİŞ
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
          SqlConnection baglanti = new SqlConnection("Data Source = LAPTOP-7U014QGU; initial catalog=DiyetisyenOtomasyon; Integrated Security=TRUE");
            baglanti.Open();
            return baglanti;
        }

}
}
