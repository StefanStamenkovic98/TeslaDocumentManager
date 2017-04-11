using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TeslaDocumentManager
{
    public class UserLogIn
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserGroupId { get; set; }
        public string UserGroup { get; set; }
        public int AccessLevel { get; set; }
        public bool Active { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public static string ErrMessage { get; set; }

        public List<UserLogIn> AllUsers;

        public UserLogIn() { AllUsers = new List<UserLogIn>();  }

        public UserLogIn(DataRow dr)
        {
            InicijalizujPolja(dr);
        }

        public void InicijalizujPolja(DataRow dr)
        {
            Id = dr["ID"].ToString();
            FullName = dr["Fullname"].ToString();
            UserName = dr["Username"].ToString();
            Email = dr["Email"].ToString();
            UserGroupId = dr["UserGroupID"].ToString();
            UserGroup = dr["Name"].ToString();
            AccessLevel = Convert.ToInt32(dr["AccessLevel"]);
            Active = Convert.ToBoolean(dr["Active"]);
            if (dr["Phone"] != DBNull.Value)
                Phone = dr["Phone"].ToString();
            if (dr["Note"] != DBNull.Value)
                Note = dr["Note"].ToString();
        }

        public static bool LogInUser(HttpResponse response, string username, string password)
        {
            try
            {
                //active user
                SqlCommand cmd = DBConnection.GetCommand;               
                cmd.CommandText = "select u.Id,u.Fullname,g.AccessLevel from Users as u " +
                                    "inner join UserGroups as g on u.UserGroupID = g.Id " + 
                            "where Username = @username and Password = @password and Active = 1";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        HttpCookie cookieFullName = new HttpCookie("FullName");
                        cookieFullName.Expires = DateTime.Now.AddMinutes(60);
                        cookieFullName.Value = dt.Rows[0]["Fullname"].ToString();
                        response.Cookies.Add(cookieFullName);

                        HttpCookie cookieUserId = new HttpCookie("Id");
                        cookieUserId.Expires = DateTime.Now.AddMinutes(60);
                        cookieUserId.Value = dt.Rows[0]["Id"].ToString();
                        response.Cookies.Add(cookieUserId);

                        HttpCookie cookieAccessLevel = new HttpCookie("AccessLevel");
                        cookieAccessLevel.Expires = DateTime.Now.AddMinutes(60);
                        cookieAccessLevel.Value = dt.Rows[0]["AccessLevel"].ToString();
                        response.Cookies.Add(cookieAccessLevel);
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                ErrMessage = "Nije uspelo logovanje";
                return false;
            }
        }

        public static bool LogOutUser(HttpResponse response)
        {
            HttpCookie cookieFullName = new HttpCookie("FullName");
            cookieFullName.Expires = DateTime.Now.AddMinutes(-1);
            response.Cookies.Add(cookieFullName);

            HttpCookie cookieUserId = new HttpCookie("Id");
            cookieUserId.Expires = DateTime.Now.AddMinutes(-1);
            response.Cookies.Add(cookieUserId);

            HttpCookie cookieAccessLevel = new HttpCookie("AccessLevel");
            cookieAccessLevel.Expires = DateTime.Now.AddMinutes(-1);
            response.Cookies.Add(cookieAccessLevel);
            return true;
        }

        public static bool UserLogInCheck(HttpRequest request)
        {
            if (request != null && request.Cookies != null)
            {
                if (request.Cookies["Id"] != null)
                {
                    var value = request.Cookies["id"].Value;
                    try
                    {
                        SqlCommand cmd = DBConnection.GetCommand;
                        cmd.Parameters.AddWithValue("@id", value);
                        cmd.CommandText = "select Id from Users " +
                        "where Id = @id and Active = 1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        ErrMessage = "Nije uspelo logovanje";
                        return false;
                    }
                }
            }
            return false;
        }


        public static UserLogIn UserLoggedIn(HttpRequest request)
        {
            if (request != null && request.Cookies != null)
            {
                if (request.Cookies["Id"] != null)
                {
                    var value = request.Cookies["Id"].Value;
                    try
                    {
                        SqlCommand cmd = DBConnection.GetCommand;
                        cmd.Parameters.AddWithValue("@id", value);
                        cmd.CommandText = "select u.Id, u.Fullname,g.AccessLevel from Users as u " +
                            "inner join UserGroups as g on u.UserGroupID = g.Id " +
                        "where u.Id = @id and u.Active = 1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                UserLogIn user = new UserLogIn();
                                user.Id = dt.Rows[0]["Id"].ToString();
                                user.FullName = dt.Rows[0]["Fullname"].ToString();
                                user.AccessLevel = Convert.ToInt32(dt.Rows[0]["AccessLevel"]);
                                return user;
                            }
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrMessage = "Nije uspelo logovanje";
                        return null;
                    }
                }
            }
            return null;
        }

        public bool LoadAllUsers()
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;
                cmd.CommandText = "select u.*,g.Name,g.AccessLevel from Users as u " +
                                    "inner join UserGroups as g on u.UserGroupID = g.Id ";
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            UserLogIn user = new UserLogIn(dr);

                            AllUsers.Add(user);
                        }
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