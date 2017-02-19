using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace HallBookingSystem
{
    public class Operation
    {
        private static OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\InitialDBFs;Mode=ReadWrite;Extended Properties=dBASE IV;Persist Security Info=False");
        public static User currUser = null;
        private static string EncryptionKey = "MAKV2SPBNI99212";
        public static string MsgTitle = "Expert Mobile System By Shah Infotech-9979866022";
        public static int ExecuteNonQuery(string Query)
        {
            OleDbCommand cmd = new OleDbCommand(Query, Conn);
            int Result = 0;
            try
            {
                if (Conn.State != ConnectionState.Open)
                    Conn.Open();
                cmd.CommandTimeout = 0;
                Result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Operation.writeLog("===========================ExecuteNonQuery====================================" + Environment.NewLine + "Date & Time : " + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + Environment.NewLine + "Query : " + Query + Environment.NewLine + "Error Msg: " + ex.Message + Environment.NewLine + Environment.NewLine + "--------------------------------------------------------------------" + Environment.NewLine + "Error Stack : " + ex.StackTrace + Environment.NewLine + "====================================================================" + Environment.NewLine, Operation.ErrorLog);
            }
            finally
            {
                Conn.Close();
            }
            return Result;
        }

        public static DataTable GetDataTable(string Query)
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            DataTable dt = new DataTable();
            try
            {
                OleDbCommand cmd = new OleDbCommand(Query, Conn);
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                //Operation.writeLog("===========================GetDataTable=========================================" + Environment.NewLine + "Date & Time : " + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() + Environment.NewLine + "Query : " + Query + Environment.NewLine + "Error Msg: " + ex.Message + Environment.NewLine + Environment.NewLine + "--------------------------------------------------------------------" + Environment.NewLine + "Error Stack : " + ex.StackTrace + Environment.NewLine + "====================================================================" + Environment.NewLine, Operation.ErrorLog);
                //MessageBox.Show("Error Ocuured" + ex.Message, MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return dt;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
        }

        public static string Encryptdata(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decryptdata(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
