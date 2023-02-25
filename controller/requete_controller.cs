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
    public class requete_controller
    {
        public static string message_exception;

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static string getIDMotifOfRequest(int id_recl, int NumWilaya_Request, int Year_Request)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    List<Objet_Disp> motif_list = (from reclam in req.Requests
                                                   join m in req.Motif on reclam.MotifId equals m.MotifId
                                                   join o in req.Objet_Disp on m.ObjectId equals o.id_objet
                                                   where (reclam.num == id_recl && reclam.Year == Year_Request && reclam.num_wilaya == NumWilaya_Request)
                                                   select o).ToList();
                    string id_motifRecl = " ";

                    foreach (Objet_Disp s in motif_list)
                    {
                        id_motifRecl = s.id_objet;
                        break;
                    }
                    return id_motifRecl;


                }
                catch (Exception e)
                {
                    return " ";
                }
            }
        }
        

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Request> getAllRequest()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    //////////////////////////////////////////////////////////////////////////

                    return req.Requests.OrderBy(r => r.num).ToList();
                    //return req.Requests.OrderBy(r => r.date).ToList();

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        //get the which are not acheived
        //public static DateTime dateDu = new DateTime();
        //public static DateTime dateAu = new DateTime();
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Request> getFilteredRequest(string where_req)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //int a = 5;
                    //if (!where_req.Equals("")) a = 5;
                    //List<Request> ddd = (List<Request>)((req.spproc_filter_requete(where_req)).ToList());
                    return (List<Request>)((req.spproc_filter_requete(where_req)).ToList());
                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<action_User_Request> GetUsersLate()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<action_User_Request> requestlinq = (from action in req.action_User_Request
                                                             join r in req.Requests on action.id_request equals r.num
                                                             where (action.NumWilaya_Request == r.num_wilaya && action.Year_Request == r.Year && r.id_state == 1 && action.action == "Insérée")
                                                             orderby (action.date_action)
                                                             select action).Take(5).ToList();
                    return requestlinq;

                }
                catch (Exception e)
                {
                    return null;
                }

            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<action_User_Request> GetUsersLateWilayaID(int IdWilaya)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<action_User_Request> requestlinq = (from action in req.action_User_Request
                                                             join r in req.Requests on action.id_request equals r.num
                                                             where (action.NumWilaya_Request == r.num_wilaya && action.Year_Request == r.Year && r.id_state == 1 && action.action == "Insérée" && r.num_wilaya == IdWilaya)
                                                             orderby (action.date_action)
                                                             select action).Take(5).ToList();
                    return requestlinq;

                }
                catch (Exception e)
                {
                    return null;
                }

            }
        }
        //get the which are not acheived
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Request> getAllTreatingRequest()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<Request> requestlinq = (from reclam in req.Requests
                                                 join s in req.State_Request
                                                 on reclam.id_state equals s.id_state
                                                 where (reclam.id_state == 1)
                                                 select reclam).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return requestlinq;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        public static List<Request> getAllTreatingRequestByIDWilaya(int NumWilaya)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<Request> requestlinq = (from reclam in req.Requests
                                                 join s in req.State_Request
                                                 on reclam.id_state equals s.id_state
                                                 where (reclam.id_state == 1 && reclam.num_wilaya == NumWilaya)
                                                 select reclam).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return requestlinq;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }

        //get the which are not acheived
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Request> getAllTreatingRequest(int num_wilaya)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<Request> requestlinq = (from reclam in req.Requests
                                                 join s in req.State_Request
                                                     on reclam.id_state equals s.id_state
                                                 where (reclam.id_state == 1 && reclam.num_wilaya == num_wilaya)
                                                 select reclam).ToList();
                    //List<Request> requestlinq1 = reqlinq;

                    return requestlinq;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }
        //get the which are acheived
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Request> getAllAchievedRequest()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    List<Request> requestlinq = (from reclam in req.Requests join s in req.State_Request on reclam.id_state equals s.id_state where (reclam.id_state == 2 || reclam.id_state == 3) select reclam).ToList();

                    return requestlinq;

                }
                catch (Exception e)
                {

                    return null;
                }

            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Request getRequestByNum(int Num, int NumWilaya_Request, int Year_Request)
        {
            using (requeteEntities req = new requeteEntities())
            {


                Request requestlinq = (from reclam in req.Requests where (reclam.num == Num && reclam.num_wilaya == NumWilaya_Request && reclam.Year == Year_Request) select reclam).FirstOrDefault();

                return requestlinq;
                //return req.Requests.Where(r => r.num.Equals(Num)).FirstOrDefault();
            }

        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Link> getRequestAttachments(int Num, int NumWilaya_Request, int Year_Request)
        {
            using (requeteEntities req = new requeteEntities())
            {
                List<Link> linklinq = (from lin in req.Links where (lin.Id_Request == Num && lin.NumWilaya_Request == NumWilaya_Request && lin.Year_Request == Year_Request) select lin).ToList();

                return linklinq;
                //return req.Requests.Where(r => r.num.Equals(Num)).FirstOrDefault();
            }

        }



        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        //public static bool insertRequest(Request r)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {

        //            req.Requests.Add(r);
        //            message_exception = "Votre requête a été ajoutée avec succès.";
        //            req.SaveChanges();
        //            return true;
        //        }
        //        catch(Exception exp)
        //        {
        //            message_exception = "Une réclamation portant le même numero existe déja.";
        //            return false;

        //        }


        //    }
        //}
        public static int GetCountAttachmentRequest(int Id_Request, int NumWilaya_Request, int Year)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_Attachment = (from lin in req.Links where (lin.Id_Request == Id_Request && lin.NumWilaya_Request == NumWilaya_Request && lin.Year_Request == Year) select lin).Count();



                    return recl_count_Attachment;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }
        
        public static bool insertRequest(Request r, string id_user, string name_user, List<string[]> FilesUpload)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    DateTime DateNow = DateTime.Now;
                    r.Date_Insertion = DateNow;
                    r.User_Inserted = name_user;
                    req.Requests.Add(r);


                    action_User_Request ac = new action_User_Request();
                    ac.id_action = Guid.NewGuid().ToString();
                    ac.id_request = r.num;
                    ac.Year_Request = r.Year;
                    ac.NumWilaya_Request = r.num_wilaya;
                    ac.action = "Insérée";
                    ac.id_user = id_user;

                    ac.date_action = DateNow;
                    req.action_User_Request.Add(ac);


                    ///Upload the files
                    foreach (string[] link in FilesUpload)
                    {
                        Link l = new Link();

                        l.Guid = link[0];
                        l.Id_Request = r.num;
                        l.Link1 = link[1];
                        l.extension = link[2];
                        l.NumWilaya_Request = r.num_wilaya;
                        l.Year_Request = r.Year;
                        req.Links.Add(l);
                    }

                    message_exception = "Votre requête a été ajoutée avec succès.";
                    req.SaveChanges();
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
        public static bool deleteRequest( int num_wilaya, int year, int num)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    
                    //Delete the Actions relied to this Request
                    
                    Action_User_Request.DeleteActionsByRequestKey(req, num_wilaya, year, num);
                    //delete relances
                    Relance_Controller.DeleteRelanceByRequestKey(req, num_wilaya, year, num);
                    //delete links
                    DeleteLinkByRequestKey(req, num_wilaya, year, num);
                    //req.Attach(r1);


                    Request r1 = new Request();
                    r1.num = num;
                    r1.num_wilaya = num_wilaya;
                    r1.Year = year;
                    req.Requests.Attach(r1);
                    req.Requests.Remove(r1);
                    req.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool updateRequest(Request r)
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

        public static bool updateRequest(Request r, string historique, string id_user, List<string[]> FileUpload_String, bool UpdateAttachments)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Entry(r).State = System.Data.Entity.EntityState.Modified;



                    action_User_Request ac = new action_User_Request();
                    ac.id_action = Guid.NewGuid().ToString();
                    ac.id_request = r.num;
                    ac.NumWilaya_Request = r.num_wilaya;
                    ac.Year_Request = r.Year;

                    ac.action = historique;
                    ac.id_user = id_user;
                    ac.date_action = DateTime.Now;
                    req.action_User_Request.Add(ac);

                    //update the Links if exist
                    if (UpdateAttachments)
                    {

                        if (FileUpload_String != null)
                        {
                            DeleteLinkByRequestKey(req, r.num_wilaya, r.Year, r.num);
                            List<Link> links = getRequestLinksByNum(r.num, r.num_wilaya, r.Year);
                            foreach (string[] link in FileUpload_String)
                            {
                                Link l = new Link();

                                l.Guid = link[0];
                                l.Id_Request = r.num;
                                l.Link1 = link[1];
                                l.extension = link[2];
                                l.NumWilaya_Request = r.num_wilaya;
                                l.Year_Request = r.Year;
                                req.Links.Add(l);
                            }
                        }
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


        public static int getCountRequestIntroduiteWilaya(int id_wilaya)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_state = (from reclam in req.Requests where (reclam.num_wilaya == id_wilaya) select reclam).Count();



                    return recl_count_state;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }


        public static int getCountRequestIntroduite()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_state = (from reclam in req.Requests select reclam).Count();



                    return recl_count_state;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }

        public static int getCountRequestTraitingWilaya(int id_wilaya)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_state = (from reclam in req.Requests where (reclam.num_wilaya == id_wilaya && reclam.id_state == 1) select reclam).Count();



                    return recl_count_state;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }

        public static int getCountRequestTraiting()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_state = (from reclam in req.Requests where (reclam.id_state == 1) select reclam).Count();



                    return recl_count_state;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static int getCountRequestWilaya(int id_wilaya, int id_state)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_state = (from reclam in req.Requests where (reclam.id_state == id_state && reclam.num_wilaya == id_wilaya) select reclam).Count();



                    return recl_count_state;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static int getCountRequest(int id_state)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int recl_count_state = (from reclam in req.Requests where (reclam.id_state == id_state) select reclam).Count();



                    return recl_count_state;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static int getNextNumRequest(int NumWilaya, int Year)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    int Request_Row = (from reclam in req.Requests where (reclam.num_wilaya == NumWilaya && reclam.Year == Year) orderby reclam.num descending select reclam.num).FirstOrDefault();



                    return Request_Row;
                }
                catch (Exception e)
                {

                    return 0;
                }

            }

        }


        public static List<Link> getRequestLinksByNum(int Num_Request, int NumWilaya_Request, int Year_Request)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    List<Link> tracelinq = (from link in req.Links
                                                           where (link.Id_Request == Num_Request && link.NumWilaya_Request == NumWilaya_Request && link.Year_Request == Year_Request)
                                                           select link).ToList();
                    
                    return tracelinq;
                }
                catch (Exception e)
                {

                    return null;
                }
            }

        }
        public static bool DeleteLinkByRequestKey(requeteEntities req, int NumWilaya, int Year, int IdRequest)
        {

            try
            {
                List<Link> lin = getRequestLinksByNum(IdRequest, NumWilaya, Year);
                foreach (Link l in lin)
                {
                    req.Links.Attach(l);
                    req.Links.Remove(l);
                }

                req.SaveChanges();
                return true;
            }

            catch (Exception e)
            {

                return false;
            }
        }


        public static bool IsDeletable(string NumWilaya, string Year, string IdRequest, string UserInserted)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int NumWilayaInt = Convert.ToInt32(NumWilaya);
                    int YearInt = Convert.ToInt32(Year);
                    int IdRequestInt = Convert.ToInt32(IdRequest);
                    string UserName = (from reclam in req.Requests where (reclam.num_wilaya == NumWilayaInt && reclam.Year == YearInt && reclam.num == IdRequestInt && reclam.id_state==1) select reclam.User_Inserted).FirstOrDefault();
                    if (UserName.Equals(UserInserted)) return true;
                    else return false;
                    
                }
                catch (Exception e)
                {

                    return false;
                }

            }
        }
        //public static bool IsUpdatable(string NumWilaya, string Year, string IdRequest, string UserInserted)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {
        //            int NumWilayaInt = Convert.ToInt32(NumWilaya);
        //            int YearInt = Convert.ToInt32(Year);
        //            int IdRequestInt = Convert.ToInt32(IdRequest);
        //            Request r = (from reclam in req.Requests where (reclam.num_wilaya == NumWilayaInt && reclam.Year == YearInt && reclam.num == IdRequestInt) select reclam).FirstOrDefault();
        //            if (r.User_Inserted.Equals(UserInserted)) return true;
        //            else
        //            {
        //                if (r.id_state == 1) return true;
        //                else return false;
        //            }



        //        }
        //        catch (Exception e)
        //        {

        //            return false;
        //        }

        //    }


        //}
        public static bool IsUpdatable(string NumWilaya, string Year, string IdRequest)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int NumWilayaInt = Convert.ToInt32(NumWilaya);
                    int YearInt = Convert.ToInt32(Year);
                    int IdRequestInt = Convert.ToInt32(IdRequest);
                    Request r = (from reclam in req.Requests where (reclam.num_wilaya == NumWilayaInt && reclam.Year == YearInt && reclam.num == IdRequestInt) select reclam).FirstOrDefault();
                    
                    if (r.id_state == 1) return true;
                    else return false;
                    



                }
                catch (Exception e)
                {

                    return false;
                }

            }


        }


        public static List<ACCESAgentList_> GetAllAgentACCES()
        {
            using (ribEntities r = new ribEntities())
            {
                List<ACCESAgentList_> agents = r.ACCESAgentList_.ToList();
                return agents;
            }
                
        }
    }
}
