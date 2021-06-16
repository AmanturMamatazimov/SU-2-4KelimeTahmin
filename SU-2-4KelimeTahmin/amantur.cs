using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU_2_4KelimeTahmin
{
    
    class amantur
    {
        SqlConnection bag = new SqlConnection("server=DESKTOP-DNDEKN8\\SQLEXPRESS;initial catalog=su2kelimetahmin;integrated security=true");
        public string kelime_getir(bool en)
        {
            string kelime;
            SqlDataAdapter da = new SqlDataAdapter("select tr,en from kelimeler", bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Random rasgele = new Random();
            int satiradedi = dt.Rows.Count;
            int sayi = rasgele.Next(0,satiradedi);
            if (en == false)
                kelime = dt.Rows[sayi][0].ToString();
           else
            kelime = dt.Rows[sayi][1].ToString();
            return kelime;
        }
        public string kelime_gizle(string kelime)
        {
            string gizli="";
            for (int i=0;i<kelime.Length;i++)
            {
                 gizli += "*";
            }
            return gizli;
        }
        public string dene(char harf,string kelime,string gizli)
        {
            string yeni="";
            for (int i=0;i<kelime.Length;i++)
            {
                if (kelime[i] == harf)
                    yeni += harf;
                else
                    yeni += gizli[i];
            }
            
            return yeni;
        }
    }
}
