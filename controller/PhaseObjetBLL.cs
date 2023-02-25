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
    public class PhaseObjetBLL
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<PhaseObject> getPhaseByMission(Guid missionId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                PhaseObject phase = new PhaseObject();
                phase.PhaseId = Guid.Empty;
                phase.PhaseName = " ";
                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                List<PhaseObject> Phase_list = (from p in req.PhaseObject join d in req.Missions on p.MissionId equals d.num where (p.MissionId.Equals(missionId.ToString())) select p).ToList();

                List<PhaseObject> Phase_list1 = new List<PhaseObject>();
                Phase_list1.Add(phase);

                //foreach (PhaseObject m in Phase_list)
                //{
                //    Phase_list1.Add(m);
                //}
                Phase_list1.AddRange(Phase_list);
                return Phase_list1;
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static bool IsPhaseInMission(Guid missionId, Guid PhaseId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                PhaseObject ph = (from p in req.PhaseObject join d in req.Missions on p.MissionId equals d.num where (p.MissionId.Equals(missionId.ToString()) && p.PhaseId.Equals(PhaseId)) select p).FirstOrDefault();
                if (ph != null) return true;
                else return false;
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<PhaseObject> getPhaseByMission1()
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                PhaseObject phase = new PhaseObject();
                phase.PhaseId = Guid.Empty;
                phase.PhaseName = " ";
                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                List<PhaseObject> Phase_list = (from p in req.PhaseObject join d in req.Missions on p.MissionId equals d.num  select p).ToList();

                List<PhaseObject> Phase_list1 = new List<PhaseObject>();
                Phase_list1.Add(phase);

                //foreach (PhaseObject m in Phase_list)
                //{
                //    Phase_list1.Add(m);
                //}
                Phase_list1.AddRange(Phase_list);
                return Phase_list1;
            }
        }
        public static Guid getPhaseOfObject(Guid ObjectId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                PhaseObject Phase = (from objet in req.Objet_Disp join ph in req.PhaseObject on objet.PhaseId.Value equals ph.PhaseId where(objet.id_objet.Equals(ObjectId.ToString())) select ph).FirstOrDefault();

                
                return Phase.PhaseId;
            }
        }
        public static PhaseObject getPhaseOfMotif(Guid MotifId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                PhaseObject Phase = (from mot in req.Motif join objet in req.Objet_Disp on mot.ObjectId equals objet.id_objet join ph in req.PhaseObject on objet.PhaseId.Value equals ph.PhaseId where (mot.MotifId.Equals(MotifId)) select ph).FirstOrDefault();


                return Phase;
            }
        }
    }
}
