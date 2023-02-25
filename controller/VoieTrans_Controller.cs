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
    public class VoieTrans_Controller
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Voie_Transmission getVoieModeTransmissionByNum(Guid Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.Voie_Transmission.Where(r => r.id_voie.Equals(Num.ToString())).FirstOrDefault();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Voie_Transmission> getAllVoieModeTransmission()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Voie_Transmission trans = new Voie_Transmission();

                trans.id_voie = " ";
                trans.voie_trans = " ";

                //List<Voie_Transmission> transmission_list = req.Voie_Transmission.OrderBy(r => r.id_voie).ToList();
                List<Voie_Transmission> transmission_list = req.Voie_Transmission.ToList();
                List<Voie_Transmission> transmission_list1 = new List<Voie_Transmission>();
                transmission_list1.Add(trans);

                foreach (Voie_Transmission s in transmission_list)
                {
                    transmission_list1.Add(s);
                }
                return transmission_list1;



                //return req.Transmission.OrderBy(r => r.mode_trans).ToList();

            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Voie_Transmission> getAllVoieModeTransmissionFooter()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Voie_Transmission trans = new Voie_Transmission();

                trans.id_voie = " ";
                trans.voie_trans = " ";

                //List<Voie_Transmission> transmission_list = req.Voie_Transmission.OrderBy(r => r.id_voie).ToList();
                List<Voie_Transmission> transmission_list = req.Voie_Transmission.ToList();
                List<Voie_Transmission> transmission_list1 = new List<Voie_Transmission>();
                if(transmission_list.Count==0)transmission_list1.Add(trans);

                foreach (Voie_Transmission s in transmission_list)
                {
                    transmission_list1.Add(s);
                }
                return transmission_list1;



                //return req.Transmission.OrderBy(r => r.mode_trans).ToList();

            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertVoieModeTransmission(Voie_Transmission r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Voie_Transmission.Add(r);

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
        public static bool deleteVoieModeTransmission(string guid)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //requerant r2 = getRequerantByNum(guid);
                    Voie_Transmission r1 = new Voie_Transmission();

                    r1.id_voie = guid.ToString();
                    req.Voie_Transmission.Attach(r1);
                    req.Voie_Transmission.Remove(r1);
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
        public static bool updateVoieModeTransmission(Voie_Transmission r)
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
