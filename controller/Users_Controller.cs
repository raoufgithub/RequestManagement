using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Dynamic;
using System.Globalization;

namespace controller
{
    [DataObject(true)]
    public class Users_Controller
    {


        public static string message_exception;

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<AspNetUsers> getAllUsers()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    //////////////////////////////////////////////////////////////////////////

                    return req.AspNetUsers.OrderBy(r => r.UserName).ToList();
                    //return req.reclamation.OrderBy(r => r.date).ToList();

                }
                catch (Exception e)
                {
                    
                    return null;
                }

            }
        }
        //[DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public static List<GetUsersMessagesSentReceived_Result1> getAllUsersOfUser()
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {

        //            //////////////////////////////////////////////////////////////////////////
        //            string userid = "23fd10c0-056e-4e64-a93f-302e92f43a94";
        //            var users = req.GetUsersMessagesSentReceived(userid,1,1,1).ToList();
        //            return users;
        //            //return req.AspNetUsers.OrderBy(r => r.UserName).ToList();


        //        }
        //        catch (Exception e)
        //        {

        //            return null;
        //        }

        //    }
        //}

        //get the which are not acheived
        //public static DateTime dateDu = new DateTime();
        //public static DateTime dateAu = new DateTime();
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<AspNetUsers> getFilteredUsers(string where_req)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    return (List<AspNetUsers>)((req.spproc_filter_users(where_req)).ToList());

                }
                catch (Exception e)
                {
                    
                    return null;
                }

            }
        }
        public static List<GetUsersStoredProcedure_Result> getFilteredUsersBySQLRequest(string query)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    var aa = req.GetUsersStoredProcedure(query).ToList();
                    //List<GetUsersMessagesSentReceived_Result1> aa = (List<GetUsersMessagesSentReceived_Result1>)req.spproc_SendSqlrequest(where_req).ToList();
                    //return (List<GetUsersMessagesSentReceived_Result1>)((req.spproc_SendSqlrequest(where_req)).ToList());
                    return aa;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }

        public static bool UpdateUserD(AspNetUsers user, UserManageStructure userManageStructure)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //AspNetUsers user = new AspNetUsers();
                    //user = getUserByID(usernameID);

                    //user.Matricule = matricule;
                    //user.Diplome = diplome;
                    //req.Entry(user).State = System.Data.Entity.EntityState.Modified;

                    req.Entry(user).State = System.Data.Entity.EntityState.Modified;

                    req.UserManageStructures.Add(userManageStructure);
                    req.SaveChanges();
                    return true;
                    
                }
                catch (Exception e)
                {
                    
                    return false;
                }

            }
        }
        //get the which are not acheived
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static string getUserIDByUserName(string username)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<AspNetUsers> Userslinq = (from user in req.AspNetUsers
                                                 
                                                 where (user.UserName==username)
                                                 select user).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return Userslinq.FirstOrDefault().Id.ToString();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static AspNetUsers getUserByID(string usernameID)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<AspNetUsers> Userslinq = (from user in req.AspNetUsers

                                                   where (user.Id == usernameID)
                                                   select user).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return Userslinq.FirstOrDefault();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static AspNetUsers getUserByUserName(string username)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<AspNetUsers> Userslinq = (from user in req.AspNetUsers

                                                   where (user.UserName == username)
                                                   select user).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return Userslinq.FirstOrDefault();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static bool UpdateUserByUserName(string username, string matricule)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    AspNetUsers user = getUserByUserName(username);
                    user.Matricule = matricule;
                    req.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    req.SaveChanges();

                    return true;

                }
                catch (Exception e)
                {

                    return false;
                }

            }
        }
        public static string getClaimValueUserByID(string ID)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<AspNetUserClaim> Claimlinq = (from claim in req.AspNetUserClaims

                                                       where (claim.UserId == ID && claim.ClaimType == "wilaya")
                                                       select claim).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return Claimlinq.FirstOrDefault().ClaimValue.ToString();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }

        public static bool insertUser(AspNetUsers r, string id_user, string name_user)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    
                    return true;
                }
                catch (Exception exp)
                {
                    message_exception = "Une réclamation portant le même numero existe déja.";
                    return false;

                }


            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool deleteUser(int guid)
        {
            try
            {

                return true;
            }
            catch
            {

                return false;
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool updateUser(AspNetUsers r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    req.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }

            }
        }

        public static bool updateUser(AspNetUsers r, string historique, string id_user)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    req.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }

            }
        }




        

    }
}
