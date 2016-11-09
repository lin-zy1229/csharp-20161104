using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Access
{
    class AccessSQL
    {
        private string mConnectionString;
        private OleDbConnection mSqlConnection;
        #region Constructor
        public AccessSQL(string dbPath)
        {
            mConnectionString = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", dbPath);
            mSqlConnection = new OleDbConnection(mConnectionString);
           
        }
        #endregion

        #region Methods for Db
        public DataTable Select(string query)
        {
            DataTable dt = new DataTable();
            mSqlConnection.Open();
            try
            {
                OleDbDataAdapter mSqlAdapter = new OleDbDataAdapter(query, mSqlConnection);

                OleDbDataReader reader = mSqlAdapter.SelectCommand.ExecuteReader();
                dt.Load(reader);
                
            }
            catch (Exception ex) //gert added
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                mSqlConnection.Close();
            }
            return dt;

        }

        
        public List<T> SelectSingleColumn<T>(string query)
        {
            List<T> mReturn = new List<T>();

            DataTable dt = Select(query);
            if (dt != null)
                foreach (DataRow row in dt.Rows)
                {
                    mReturn.Add((T)Convert.ChangeType(row[0], typeof(T)));
                }

            return mReturn;
        }

        public int Insert(string tableName, Dictionary<string, string> insertDictionary)
        {
            string firstPart = string.Format("INSERT INTO {0} ", tableName);
            string keys = "(";
            string values = "(";
            string insString;
            string lastPart;
            for (int i = 0; i < insertDictionary.Count; i++)
            {
                if (i == insertDictionary.Count - 1)
                {
                    keys += insertDictionary.Keys.ElementAt(i).ToString() + ")";
                    values +="\'"+insertDictionary.Values.ElementAt(i).ToString() + "\')";

                }
                else
                {
                    keys += insertDictionary.Keys.ElementAt(i).ToString() + ",";
                    values +="\'"+ insertDictionary.Values.ElementAt(i).ToString() + "\',";

                }
            }
            lastPart = keys + " VALUES " + values;
            insString = firstPart + lastPart;
            mSqlConnection.Open();
            int affectedRows = 0;
            try
            {
                OleDbCommand cmd = new OleDbCommand(insString, mSqlConnection);
                affectedRows = cmd.ExecuteNonQuery();
            }
            finally
            {
                mSqlConnection.Close();
            }
            return affectedRows;
        }

        public int Update(string tableName, Dictionary<string, string> termsDictionary, Dictionary<string, string> updateDictionary)
        {
            string firstPart = string.Format("UPDATE {0} ", tableName);
            string lastPart = "SET ";
            string conditionPart = "WHERE ";
            for (int i = 0; i < updateDictionary.Count; i++)
            {
                if (i == updateDictionary.Count - 1)
                {
                    lastPart += updateDictionary.Keys.ElementAt<string>(i).ToString() + "=\'" + updateDictionary.Values.ElementAt(i).ToString() + "\' ";
                }
                else
                {
                    lastPart += updateDictionary.Keys.ElementAt<string>(i).ToString() + "=\'" + updateDictionary.Values.ElementAt(i).ToString() + "\',";
                }

            }
            for (int i = 0; i < termsDictionary.Count; i++)
            {
                if (i == termsDictionary.Count - 1)
                {
                    conditionPart += termsDictionary.Keys.ElementAt<string>(i).ToString() + "=" + termsDictionary.Values.ElementAt<string>(i).ToString() + "";
                }
                else
                {
                    conditionPart += termsDictionary.Keys.ElementAt<string>(i).ToString() + "=" + termsDictionary.Values.ElementAt<string>(i).ToString() + " AND";
                }

            }
            string final = firstPart + lastPart + conditionPart;
            mSqlConnection.Open();
            int affectedRows = 0;
            try
            {
                OleDbCommand cmd = new OleDbCommand(final, mSqlConnection);
                affectedRows = cmd.ExecuteNonQuery();
            }
            finally
            {
                mSqlConnection.Close();
            }
            return affectedRows;
        }

        public int Delete(string tableName, Dictionary<string, string> termsDictionary)
        {
            string firstpart = string.Format("DELETE FROM {0} ", tableName);
            if (termsDictionary.Count != 0)
            {
                firstpart += "WHERE ";
            }
            for (int i = 0; i < termsDictionary.Count; i++)
            {
                if (i == termsDictionary.Count - 1)
                {
                    firstpart += termsDictionary.Keys.ElementAt(i).ToString() + "=\'" + termsDictionary.Values.ElementAt(i).ToString() + "\';";

                }
                else
                {
                    firstpart += termsDictionary.Keys.ElementAt(i).ToString() + "=\'" + termsDictionary.Values.ElementAt(i).ToString() + "\' AND ";
                }

            }
            mSqlConnection.Open();
            int affectedRows = 0;
            try
            {
                OleDbCommand cmd = new OleDbCommand(firstpart, mSqlConnection);
                affectedRows = cmd.ExecuteNonQuery();
            }
            finally
            {
                mSqlConnection.Close();
            }
            return affectedRows;
        }

        public bool isConnectionExist()
        {
            if (mSqlConnection == null)
                return false;

            try
            {
                mSqlConnection.Open();
                mSqlConnection.Close();
                return true;
            } catch (Exception ex)
            {
                throw ex;
                //return false;
            }

        }

        public object selectSingleObject(string pQuery)
        {
            object value = null;
            try
            {
                mSqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(pQuery, mSqlConnection);
                value = cmd.ExecuteScalar();

            }
            finally
            {
                mSqlConnection.Close();
             
            }
            return value;
            
            
        }
        #endregion
        #region Get field values
        public static string getString(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return "";

                }
                return pValue.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getString()\n" + ex.Message);
            }
        }

        public static int getInt(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return 0;

                }
                return int.Parse(pValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getInt()\n" + ex.Message);
            }
        }

        public static bool getBool(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return false;

                }
                return bool.Parse(pValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getBool()\n" + ex.Message);
            }
        }

        public static decimal getDecimal(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return 0;

                }
                return decimal.Parse(pValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getDecimal()\n" + ex.Message);
            }
        }

        public static DateTime getDateTime(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return DateTime.Today;

                }
                return DateTime.Parse(pValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getDateTime()\n" + ex.Message);
            }
        }

        public static double getDouble(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return 0.0;

                }
                return double.Parse(pValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getDouble()\n" + ex.Message);
            }
        }

        public static long getLong(object pValue)
        {
            try
            {
                if (pValue == null || DBNull.Value.Equals(pValue))
                {
                    return 0;

                }
                return long.Parse(pValue.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getLong()\n" + ex.Message);
            }
        }
        #endregion
    }
}
