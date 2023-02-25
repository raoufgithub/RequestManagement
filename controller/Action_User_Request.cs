using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace controller
{
    [DataObject(true)]
    public class Action_User_Request
    {
        //public static void addAction(string action, int id_request, string id_user)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {
        //            action_User_Request ac = new action_User_Request();
        //            ac.id_request = id_request;
        //            ac.action = action;
        //            ac.id_user = id_user;
        //            ac.date_action = DateTime.Now;
        //            req.action_User_Request.Add(ac);

        //            req.SaveChanges();

        //        }
        //        catch (Exception exp)
        //        {
        //            //message_exception = "Une réclamation portant le même numero existe déja.";


        //        }


        //    }
        //}

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<action_User_Request> getRequestActionsByNum(int Num_Request, int NumWilaya_Request, int Year_Request)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    List<action_User_Request> tracelinq = (from action in req.action_User_Request
                                                           where (action.id_request == Num_Request && action.NumWilaya_Request==NumWilaya_Request && action.Year_Request==Year_Request)
                                                           select action).ToList();
                    //List<reclamation> requestlinq1 = reqlinq;

                    return tracelinq;
                }
                catch (Exception e)
                {
                    
                    return null;
                }
            }

        }





        public static bool DeleteActionsByRequestKey(requeteEntities req, int NumWilaya, int Year, int IdRequest)
        {

            try
            {
                List<action_User_Request> act = getRequestActionsByNum(IdRequest, NumWilaya, Year);
                foreach (action_User_Request r in act)
                {
                    req.action_User_Request.Attach(r);
                    req.action_User_Request.Remove(r);
                }
               
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
