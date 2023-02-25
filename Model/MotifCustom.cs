using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Motif
    {

        public string PhaseC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        PhaseObject p = (from mot in req.Motif join obj in req.Objet_Disp on mot.ObjectId equals obj.id_objet join ph in req.PhaseObject on obj.PhaseId equals ph.PhaseId where (mot.MotifId.Equals(this.MotifId)) select ph).FirstOrDefault();
                        return p.PhaseName;

                    }
                }
                catch
                {
                    return "";
                };
            }
        }
        public Guid PhaseId
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        Objet_Disp o = (from mot in req.Motif join obj in req.Objet_Disp on mot.ObjectId equals obj.id_objet where (mot.MotifId.Equals(this.MotifId)) select obj).FirstOrDefault();
                        return o.PhaseId.Value;

                    }
                }
                catch
                {
                    return Guid.Empty;
                };
            }
        }
        public string MissionC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        Mission mission = (from mot in req.Motif join  obj in req.Objet_Disp on mot.ObjectId equals obj.id_objet join ph in req.PhaseObject on obj.PhaseId.Value equals ph.PhaseId join mis in req.Missions on ph.MissionId equals mis.num where (mot.MotifId.Equals(this.MotifId)) select mis).FirstOrDefault();
                        return mission.mission1;
                    }
                }
                catch
                {
                    return "";
                };
            }
        }
        public string MissionId
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        PhaseObject phase = (from mot in req.Motif join obj in req.Objet_Disp on mot.ObjectId equals obj.id_objet join ph in req.PhaseObject on obj.PhaseId.Value equals ph.PhaseId where (mot.MotifId.Equals(this.MotifId)) select ph).FirstOrDefault();
                        return phase.MissionId;
                    }
                }
                catch
                {
                    return "";
                };
            }
        }
    }
}
