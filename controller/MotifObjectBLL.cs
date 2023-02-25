using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller
{
    [DataObject(true)]
    public class MotifObjectBLL
    {
        static string error_message;

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Motif> getMotifObjectByObject(Guid ObjectId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                Motif mot = new Motif();
                mot.MotifId = Guid.Empty;
                mot.MotifName = " ";
                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                List<Motif> Motif_list = (from m in req.Motif join o in req.Objet_Disp on m.ObjectId equals o.id_objet where (m.ObjectId.Equals(ObjectId.ToString())) select m).ToList();

                List<Motif> Motif_list1 = new List<Motif>();
                Motif_list1.Add(mot);

                //foreach (PhaseObject m in Phase_list)
                //{
                //    Phase_list1.Add(m);
                //}
                Motif_list1.AddRange(Motif_list);
                return Motif_list1;
            }
        }


        

        public static void SetError_Message(string error)
        {
            error_message = error;
        }
        public static string getError_Message()
        {
            return error_message;
        }
        

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Motif> getAllMotifOfObject()
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {
                List<Motif> motiflinq = (from m in req.Motif orderby m.MotifName select m).ToList();
                //List<MotifOfDispositif> requestlinq = (from m in req.Motif join d in m. on m.id_motif equals m. where (reclam.id_state == 2 || reclam.id_state == 3) select reclam).ToList();
                return motiflinq;
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertMotifOfObject(Motif r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //dispositif dis = req.dispositif.Where(d => d.num.Equals(num_dispositif)).FirstOrDefault();
                    //r.dispositif.Add(dis);
                    req.Motif.Add(r);

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
        public static bool deleteMotifOfObject(string guid)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    Motif m1 = new Motif();
                    m1.MotifId = Guid.Parse(guid);
                    req.Motif.Attach(m1);
                    req.Motif.Remove(m1);
                    req.SaveChanges();
                    return true;
                }

                catch (Exception e)
                {

                    SetError_Message(e.InnerException.InnerException.Message);
                    return false;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool updateMotifOfObject(Motif r)
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
