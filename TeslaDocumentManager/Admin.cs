using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TeslaDocumentManager
{
    public class Admin : UserLogIn
    {
        public List<UserGroup> UserGroupsList;
        public string Message { get; set; }

        public bool LoadUserGroupList()
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    
                    cmd.CommandText = "select Id, Name from usergroups";
                    DataTable d = new DataTable();
                    UserGroupsList = new List<UserGroup>();
                    da.Fill(d);
                    if (d.Rows.Count > 0)
                    {
                        foreach (DataRow dr in d.Rows)
                        {
                            UserGroup ug = new UserGroup();
                            ug.id = dr[0].ToString();
                            ug.accesslevel = Convert.ToInt32(dr[1]);
                            UserGroupsList.Add(ug);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Message = "Pristup korisnicima nije moguc.";
                return false;
            }
        }
        public bool DeleteUser()
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "delete from users where Id = @id";
                cmd.Parameters.AddWithValue("@id", this.Id);
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    int ok = cmd.ExecuteNonQuery();
                    if (ok == 1)
                        return true;
                    else throw new Exception("User nije bre obrisan");
                }
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool CheckUser()//proveriti dali postoji user u bazi
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "";
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    int ok = cmd.ExecuteNonQuery();
                    if (ok == 1)
                        return true;
                    else throw new Exception("User postoji");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public bool CreateUser()//kreirati novog usera u bazi
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "";
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    int ok = cmd.ExecuteNonQuery();
                    if (ok == 1)
                        return true;
                    else throw new Exception("User nije upisan");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }
    }
}