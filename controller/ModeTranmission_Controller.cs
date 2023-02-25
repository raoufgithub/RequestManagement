using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using System.Data.Entity.Validation;

namespace controller
{
    [DataObject(true)]
    public class ModeTranmission_Controller
    {

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Transmission getModeTransmissionByNum(Guid Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.Transmission.Where(r => r.id_trans.Equals(Num.ToString())).FirstOrDefault();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Transmission> getAllModeTransmission()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Transmission trans = new Transmission();
                trans.id_trans = " ";
                trans.mode_trans = " ";

                //List<Transmission> transmission_list = req.Transmission.OrderBy(r => r.id_trans).ToList();
                List<Transmission> transmission_list = req.Transmission.ToList();
                List<Transmission> transmission_list1 = new List<Transmission>();
                transmission_list1.Add(trans);

                foreach (Transmission s in transmission_list)
                {
                    transmission_list1.Add(s);
                }
                return transmission_list1;



                //return req.Transmission.OrderBy(r => r.mode_trans).ToList();

            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Transmission> getAllModeTransmissionFooter()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Transmission trans = new Transmission();
                trans.id_trans = " ";
                trans.mode_trans = " ";

                //List<Transmission> transmission_list = req.Transmission.OrderBy(r => r.id_trans).ToList();
                List<Transmission> transmission_list = req.Transmission.ToList();
                List<Transmission> transmission_list1 = new List<Transmission>();
                if (transmission_list.Count == 0) transmission_list1.Add(trans);

                foreach (Transmission s in transmission_list)
                {
                    transmission_list1.Add(s);
                }
                return transmission_list1;



                //return req.Transmission.OrderBy(r => r.mode_trans).ToList();

            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertModeTransmission(Transmission r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Transmission.Add(r);

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
        public static bool deleteModeTransmission(string guid)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //requerant r2 = getRequerantByNum(guid);
                    Transmission r1 = new Transmission();
                    r1.id_trans = guid.ToString();
                    req.Transmission.Attach(r1);
                    req.Transmission.Remove(r1);
                    req.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool updateModeTransmission(Transmission r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {


                    req.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    req.SaveChanges();
                    return true;
                }
                catch
                {

                    return false;
                }

            }

        }
    }
}
