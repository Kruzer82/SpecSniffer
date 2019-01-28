using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SpecSniffer;

namespace Sniffer
{
    public static class MySQL
    {
        private static string server;
        private static string port;
        private static string user;
        private static string password;
        private static string database;
        private static string connectionString;
        private static MySqlConnection connection;
        private static MySqlCommand cmd;

        //Read data from Settings.xml used to connect to MySQL. Report true if succeeded
        private static bool ReadSettings()
        {
            try
            {
                XElement xElement = XElement.Load("Settings.xml");
                IEnumerable<XElement> settings = xElement.Elements("MySQL");
                foreach (var x in settings)
                {
                    server = x.Attribute("Server").Value;
                    port = x.Attribute("Port").Value;
                    user = x.Attribute("User").Value;
                    password = x.Attribute("Password").Value;
                    database = x.Attribute("Database").Value;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Run ReadSettings() if it return true try to connect to server. Returns string concluding effort
        public static string Connect()
        {
            if(ReadSettings())
            {
                connectionString = string.Format("SERVER={0};PORT={1};USERID={2};PASSWORD={3};DATABASE={4};CONNECTION TIMEOUT=3;", server, port, user, password, database);
                try
                {
                    connection = new MySqlConnection(@connectionString);
                    connection.Open();
                    return "@MySQL: Connected to server.";
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            return "!!MySQL: Can't connect to server";
                        case 1045:
                            return "!!MySQL: Invalid username/password.";
                        default:
                            return "!!MySQL: " + ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return "!!MySQL: " + ex.Message;
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            else
            {
                return "!!MySQL: Couldn't read settings. Try run program again.";
            }
        }

        /// <summary>
        /// Search for value in MYsql table 
        /// </summary>
        /// <param name="column">name of column where value should be searched</param>
        /// <param name="table">table name where searching</param>
        /// <param name="value">value to find </param>
        /// <returns></returns>
        public static bool IsInTable(string column, string table, string value)
        {
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("SELECT {0} FROM {1} WHERE {0} = @value ORDER BY id DESC LIMIT 1", column, table);
                cmd.Parameters.AddWithValue("@value", value);

                connection.Open();
                cmd.Prepare();
                if (cmd.ExecuteScalar() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
                //return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        //Search for last value 'searchedSN' and update it for last row in database
        public static string UpdateValue(string table, string updateColumn, string newValue, string searchColumn, string searchedSN)
        {
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("UPDATE {0} SET {1} = @newValue WHERE {2} = @searchedSN ORDER BY id DESC LIMIT 1", table, updateColumn, searchColumn);
                cmd.Parameters.AddWithValue("@newValue", newValue);
                cmd.Parameters.AddWithValue("@searchedSN", searchedSN);

                connection.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                return "@MySQL: " + string.Format("SN {0} has been updated with value {1} on column {2}.", searchedSN, newValue, updateColumn);
            }
            catch (Exception ex)
            {
                return "!!MySQL: " + ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        
        //Save Windows licence info if machinge got old licence
        public static bool SaveCmarWithCoa(string oldCOA, string newCMAR, string SaleOrder)
        {
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO tpr_old_coa (old_licence,new_mar,so) VALUES (@old_licence,@new_mar,@so)";
                cmd.Parameters.AddWithValue("@old_licence", oldCOA);
                cmd.Parameters.AddWithValue("@new_mar", newCMAR);
                cmd.Parameters.AddWithValue("@so", SaleOrder);

                connection.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public static bool SaveCmarWithoutCoa(string os_name,string device_type,string serial, string manufacturer, string model, string cpu, string new_mar, string so)
        {
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO tpr_no_coa (os_name, device_type, serial, manufacturer, model, cpu, new_mar, so) " +
                                                 "VALUES (@os_name,@device_type,@serial,@manufacturer,@model,@cpu,@new_mar,@so)";
                cmd.Parameters.AddWithValue("@os_name", os_name);
                cmd.Parameters.AddWithValue("@device_type", device_type);
                cmd.Parameters.AddWithValue("@serial", serial);
                cmd.Parameters.AddWithValue("@manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@cpu", cpu);
                cmd.Parameters.AddWithValue("@new_mar", new_mar);
                cmd.Parameters.AddWithValue("@so", so);

                connection.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public static string SaveSpec(string so,string rp,string model,string cpu,string serial, string ram,
            string hdd1Size, string hdd1Model, string hdd1Serial, 
            string hdd2Size, string hdd2Model, string hdd2Serial,
            string optical,string gpu1,string gpu2,string resname,string diagonal, 
            string osName,string osBuild,string osLanguage,string licence,string coa, 
            string comments,string bluetooth, string wifi, string camera, string fpr)
        {
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = String.Format("INSERT INTO so_log" +
            "( so, rp, model,cpu, serial, ram, hdd1_size, hdd1_model, hdd1_serial,  hdd2_size, hdd2_model, hdd2_serial, optical, gpu1, gpu2, resname, diagonal, os_name, os_build, os_language, os_key, os_label, comments, bluetooth, wifi, camera, fpr) VALUES" +
            "(@so,@rp,@model,@cpu,@serial,@ram,@hdd1_size,@hdd1_model,@hdd1_serial,@hdd2_size,@hdd2_model,@hdd2_serial,@optical,@gpu1,@gpu2,@resname,@diagonal,@os_name,@os_build,@os_language,@os_key,@os_label,@comments,@bluetooth,@wifi,@camera,@fpr)");

                cmd.Parameters.AddWithValue("@so", so);
                cmd.Parameters.AddWithValue("@rp", rp);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@cpu", cpu);
                cmd.Parameters.AddWithValue("@serial", serial);
                cmd.Parameters.AddWithValue("@ram", ram);

                cmd.Parameters.AddWithValue("@hdd1_size", hdd1Size);
                cmd.Parameters.AddWithValue("@hdd1_model", hdd1Model);
                cmd.Parameters.AddWithValue("@hdd1_serial", hdd1Serial);
                cmd.Parameters.AddWithValue("@hdd2_size", hdd2Size);
                cmd.Parameters.AddWithValue("@hdd2_model", hdd2Model);
                cmd.Parameters.AddWithValue("@hdd2_serial", hdd2Serial);

                cmd.Parameters.AddWithValue("@optical", optical);
                cmd.Parameters.AddWithValue("@gpu1", gpu1);
                cmd.Parameters.AddWithValue("@gpu2", gpu2);

                cmd.Parameters.AddWithValue("@resname", resname);
                cmd.Parameters.AddWithValue("@diagonal", diagonal);
                cmd.Parameters.AddWithValue("@os_name", osName);
                cmd.Parameters.AddWithValue("@os_build", osBuild);

                cmd.Parameters.AddWithValue("@os_language", osLanguage);
                cmd.Parameters.AddWithValue("@os_key", licence);
                cmd.Parameters.AddWithValue("@os_label", coa);
                cmd.Parameters.AddWithValue("@comments", comments);

                cmd.Parameters.AddWithValue("@bluetooth", bluetooth);
                cmd.Parameters.AddWithValue("@wifi", wifi);
                cmd.Parameters.AddWithValue("@camera", camera);
                cmd.Parameters.AddWithValue("@fpr", fpr);

                connection.Open();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                return string.Format("@MySQL: Log for Sale Order: {0} has been made.", so);
            }
            catch(Exception ex)
            {
                return "!!MySQL: " + ex.Message;
                throw;
               // return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }

}
