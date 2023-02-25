using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Objet_Disp
    {

        public string PhaseC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        return req.PhaseObject.Where(c => c.PhaseId.Equals(this.PhaseId.Value)).FirstOrDefault().PhaseName;
                    }
                }
                catch
                {
                    return "";
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
                        Mission mission = (from obj in req.Objet_Disp join ph in req.PhaseObject on obj.PhaseId equals ph.PhaseId join mis in req.Missions on ph.MissionId equals mis.num where (obj.id_objet.Equals(this.id_objet)) select mis).FirstOrDefault();
                        return mission.mission1;
                    }
                }
                catch
                {
                    return "";
                };
            }
        }
        //public string MissionId
        //{
        //    get
        //    {
        //        try
        //        {
        //            using (requeteEntities req = new requeteEntities())
        //            {
        //                Mission mission = (from obj in req.Objet_Disp join ph in req.PhaseObject on obj.PhaseId equals ph.PhaseId join mis in req.Missions on ph.MissionId equals mis.num where (obj.id_objet.Equals(this.id_objet)) select mis).FirstOrDefault();
        //                return mission.num;
        //            }
        //        }
        //        catch
        //        {
        //            return "";
        //        };
        //    }
        //}
    }
}
