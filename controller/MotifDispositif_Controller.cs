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
    public class MotifDispositif_Controller
    {
        static string error_message;

        public static void SetError_Message(string error)
        {
            error_message = error;
        }
        public static string getError_Message()
        {
            return error_message;
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Guid getIdDispositifOfMotifByNum(Guid id_objet)
        {
            using (requeteEntities req = new requeteEntities())
            {


                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                List<PhaseObject> motif_list = (from m in req.Objet_Disp join p in req.PhaseObject on m.PhaseId equals p.PhaseId where (m.id_objet.Equals(id_objet.ToString())) select p).ToList();
                Guid num_dispoMotif = default(Guid);

                foreach (PhaseObject s in motif_list)
                {
                    num_dispoMotif = s.PhaseId;
                    break;
                }
                return num_dispoMotif;


            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Objet_Disp getMotifDispositifByNum(Guid Num)
        {
            using (requeteEntities req = new requeteEntities())
            {
                return (from motif in req.Motif join obj in req.Objet_Disp on motif.ObjectId equals obj.id_objet where (motif.MotifId.Equals(Num)) select obj).FirstOrDefault();
                //return req.Objet_Disp.Where(r => r.id_objet.Equals(Num.ToString())).FirstOrDefault();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Objet_Disp> getAllMotifDispositif()
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {
                List<Objet_Disp> motiflinq = (from m in req.Objet_Disp join p in req.PhaseObject on m.PhaseId equals p.PhaseId orderby m.ObjectNum select m).ToList();
                //List<MotifOfDispositif> requestlinq = (from m in req.Motif join d in m. on m.id_motif equals m. where (reclam.id_state == 2 || reclam.id_state == 3) select reclam).ToList();
                return motiflinq;
            }
        }






        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Objet_Disp> getMotifByPhase(Guid PhaseId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {
                
                ///////////////////////////////////////////////////////////////////////////
                Objet_Disp mot = new Objet_Disp();
                mot.id_objet = "00000000-0000-0000-0000-000000000000";
                mot.objet = " ";

                //List<Objet_Disp> motif_list = (from m in req.Objet_Disp join d in req.Missions on m.num_mission equals d.num where (m.num_mission.Equals(num_mission.ToString())) select m).ToList();
                List<Objet_Disp> motif_list = (from m in req.Objet_Disp join p in req.PhaseObject on m.PhaseId.Value equals p.PhaseId where (m.PhaseId.Value.Equals(PhaseId)) select m).ToList();

                List<Objet_Disp> motif_list1 = new List<Objet_Disp>();
                motif_list1.Add(mot);

                //foreach (Objet_Disp m in motif_list)
                //{
                //    motif_list1.Add(m);
                //}
                motif_list1.AddRange(motif_list);
                return motif_list1;
            }
        }
        public static Objet_Disp getObjectByMotif(Guid MotifId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                Objet_Disp objet = (from mot in req.Motif join obj in req.Objet_Disp on mot.ObjectId equals obj.id_objet where(mot.MotifId.Equals(MotifId))select obj).FirstOrDefault();


                return objet;
            }
        }






        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertMotifDispositif(Objet_Disp r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //dispositif dis = req.dispositif.Where(d => d.num.Equals(num_dispositif)).FirstOrDefault();
                    //r.dispositif.Add(dis);
                    req.Objet_Disp.Add(r);

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
        public static bool deleteMotifDispositif(string guid)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    Objet_Disp r1 = new Objet_Disp();
                    r1.id_objet = guid.ToString();
                    req.Objet_Disp.Attach(r1);
                    req.Objet_Disp.Remove(r1);
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
        public bool updateMotifDispositif(Objet_Disp r)
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
