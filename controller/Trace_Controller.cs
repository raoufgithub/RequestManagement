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
    public class Trace_Controller
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<State_Request> getAllState_Request()
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    State_Request state_request = new State_Request();
                    state_request.id_state = 0;
                    state_request.nom_state = " ";

                    List<State_Request> state_request_list = req.State_Request.OrderBy(r => r.id_state).ToList();
                    List<State_Request> state_request_list1 = new List<State_Request>();
                    state_request_list1.Add(state_request);

                    foreach (State_Request s in state_request_list)
                    {
                        state_request_list1.Add(s);
                    }
                    return state_request_list1;
                    //return req.State_Request.OrderBy(r => r.id_state).ToList();
                }
                catch (Exception e)
                {
                    
                    return null;
                }

            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static State_Request getStateRequestByNum(int Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.State_Request.Where(r => r.id_state.Equals(Num)).FirstOrDefault();
            }

        }




        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertState_Request(State_Request r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.State_Request.Add(r);

                    req.SaveChanges();
                    return true;
                }

                catch (Exception e)
                {
                    
                    return false;
                }
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool deleteState_Request(int guid)
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
        public static bool updateState_Request(int guid)
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

    }
}
