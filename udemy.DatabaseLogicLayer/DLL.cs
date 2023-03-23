using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy.Entities;

namespace udemy.DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValues;

        public DLL()
        {
            //con = new SqlConnection("data source=.; initial catalog = TelefonRehberi; user Id = sa; password=1;");

            con = new SqlConnection("Server = DESKTOP-3J5F9CS\\SQLEXPRESS; Database = TelefonRehberi; Trusted_Connection = True;");
        }

        public void BaglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            else
                con.Close();
        }

        public int SistemKontrol(Kullanici K)
        {
            try
            {
                cmd = new SqlCommand("select count(*) from Kullanici where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre", con);
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = K.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                BaglantiAyarla();
                ReturnValues = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public int KayitEKLE(Rehber R)
        {
            try
            {
                cmd = new SqlCommand("insert into Rehber (ID,Isim,Soyisim,TelefonNumarasiI,TelefonNumarasiII,TelefonNumarasiIII,EmailAdres,WebAdres,Adres,Aciklama) values (@ID,@Isim,@Soyisim,@TelefonNumarasiI,@TelefonNumarasiII,@TelefonNumarasiIII,@EmailAdres,@WebAdres,@Adres,@Aciklama)", con);
                cmd.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("WebAdres", SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public int KayitDuzenle(Rehber R)
        {
            try
            {
                cmd = new SqlCommand(@"update Rehber 
Set
Isim = @Isim,
Soyisim = @Soyisim,
TelefonNumarasiI = @TelefonNumarasiI,
TelefonNumarasiII = @TelefonNumarasiII,
TelefonNumarasiIII = @TelefonNumarasiIII,
EmailAdres = @EmailAdres,
WebAdres = @WebAdres,
Adres = @Adres,
Aciklama = @Aciklama,
where
ID = @ID
", con);
                cmd.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                cmd.Parameters.Add("Isim", SqlDbType.NVarChar).Value = R.Isim;
                cmd.Parameters.Add("Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                cmd.Parameters.Add("TelefonNumarasiI", SqlDbType.NVarChar).Value = R.TelefonNumarasiI;
                cmd.Parameters.Add("TelefonNumarasiII", SqlDbType.NVarChar).Value = R.TelefonNumarasiII;
                cmd.Parameters.Add("TelefonNumarasiIII", SqlDbType.NVarChar).Value = R.TelefonNumarasiIII;
                cmd.Parameters.Add("EmailAdres", SqlDbType.NVarChar).Value = R.EmailAdres;
                cmd.Parameters.Add("WebAdres", SqlDbType.NVarChar).Value = R.WebAdres;
                cmd.Parameters.Add("Adres", SqlDbType.NVarChar).Value = R.Adres;
                cmd.Parameters.Add("Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public int KayitSil(Guid ID)
        {
            try
            {
                cmd = new SqlCommand(@"delete Rehber where ID = @ID ", con);
                cmd.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = ID;

                BaglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return ReturnValues;
        }

        public SqlDataReader KayitListe()
        {
            cmd = new SqlCommand("Select * from Rehber", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }

        public SqlDataReader KayitListeID(Guid ID)
        {
            cmd = new SqlCommand("Select * from Rehber where ID = @ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
    }
}
