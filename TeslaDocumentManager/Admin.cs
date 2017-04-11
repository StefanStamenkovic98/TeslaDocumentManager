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
                            ug.name = dr[1].ToString();
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

        public UserLogIn UserPretraga()
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "select u.*,g.Name,g.AccessLevel from Users as u " +
                                    "inner join UserGroups as g on u.UserGroupID = g.Id " +
                                    "where u.ID = @id";
                cmd.Parameters.AddWithValue("@id", this.Id);
                using (cmd.Connection)
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        if(dt.Rows.Count == 1)
                        {
                            UserLogIn user = new UserLogIn(dt.Rows[0]);
                            return user;
                        }
                        else throw new Exception("User ne postoji");
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
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

        public bool CheckUserName(string name)
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "select u.Id from Users as u where u.Username = @username";
                cmd.Parameters.AddWithValue("@username", name);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrMessage = "Pristup korisnicima nije moguc.";
                return false;
            }
        }

        public bool CheckEmail(string email)
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "select u.Id from Users as u where u.Email = @email";
                cmd.Parameters.AddWithValue("@email", email);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrMessage = "Pristup korisnicima nije moguc.";
                return false;
            }
        }

        public bool CreateUser()
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "insert into Users " +
                "values(@id, @username, @fullname, @pass, @email, @active, @usergroupid, @phone, @note, @emailver)";
                cmd.Parameters.AddWithValue("@id", new Guid());
                cmd.Parameters.AddWithValue("@username", this.UserName);
                cmd.Parameters.AddWithValue("@fullname", this.FullName);
                cmd.Parameters.AddWithValue("@pass", this.Password);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@active", this.Active);
                cmd.Parameters.AddWithValue("@usergroupid", this.UserGroupId);
                if (this.Phone != string.Empty)
                    cmd.Parameters.AddWithValue("@phone", DBNull.Value);
                else cmd.Parameters.AddWithValue("@phone", this.Phone);
                if (this.Note != string.Empty)
                    cmd.Parameters.AddWithValue("@note", DBNull.Value);
                else cmd.Parameters.AddWithValue("@note", this.Note);
                cmd.Parameters.AddWithValue("@emailver", false);
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    int ok = cmd.ExecuteNonQuery();
                    if (ok == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrMessage = "Pristup korisnicima nije moguc.";
                return false;
            }
        }

        public bool UpdateUser()
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "update users set " +
                        "Fullname = @fullname, " +
                        "UserGroupID = @usergroupid, " +
                        "Active = @active, " +
                        "Phone = @phone, " +
                        "Note = @note " +
                        "where Id = @id";
                cmd.Parameters.AddWithValue("@id", this.Id);
                cmd.Parameters.AddWithValue("@fullname", this.FullName);
                if (this.Password != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@pass", this.Password);
                    cmd.CommandText = "update users set " +
                        "Fullname = @fullname, " +
                        "Password = @pass, " +
                        "UserGroupID = @usergroupid, " +
                        "Active = @active, " +
                        "Phone = @phone, " +
                        "Note = @note " +
                        "where Id = @id";
                }
                cmd.Parameters.AddWithValue("@active", this.Active);
                cmd.Parameters.AddWithValue("@usergroupid", this.UserGroupId);
                if (this.Phone != string.Empty)
                    cmd.Parameters.AddWithValue("@phone", this.Phone);
                else cmd.Parameters.AddWithValue("@phone", DBNull.Value);
                if (this.Note != string.Empty)
                    cmd.Parameters.AddWithValue("@note", this.Note);
                else cmd.Parameters.AddWithValue("@note", DBNull.Value);
                using (cmd.Connection)
                {
                    cmd.Connection.Open();
                    int ok = cmd.ExecuteNonQuery();
                    if (ok == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrMessage = "Pristup korisnicima nije moguc.";
                return false;
            }
        }
    }
}