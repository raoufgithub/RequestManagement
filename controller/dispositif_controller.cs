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
    public class dispositif_controller
    {

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Mission getDispositifByNum(Guid Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.Missions.Where(r => r.num.Equals(Num.ToString())).FirstOrDefault();
            }
        }
        public static string getIDMissionOfObject(string ObjectId)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    Mission mis = (from o in req.Objet_Disp
                                                   join p in req.PhaseObject on o.PhaseId equals p.PhaseId
                                                   join m in req.Missions on p.MissionId equals m.num
                                                   where (o.id_objet.Equals(ObjectId))
                                                   select m).FirstOrDefault();
                    return mis.num;


                }
                catch (Exception e)
                {
                    return " ";
                }
            }
        }

        public static string getIDMissionOfPhase(string PhaseId)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    Guid PhaseIdGuid = Guid.Parse(PhaseId);
                    Mission mis = (from p in req.PhaseObject
                                   join m in req.Missions on p.MissionId equals m.num
                                   where (p.PhaseId.Equals(PhaseIdGuid))
                                   select m).FirstOrDefault();
                    return mis.num;


                }
                catch (Exception e)
                {
                    return " ";
                }
            }
        }

        public static Mission getMissionOfMotif(Guid MotifId)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    Mission mis = (from mot in req.Motif
                                   join o in req.Objet_Disp on mot.ObjectId equals o.id_objet
                                   join p in req.PhaseObject on o.PhaseId equals p.PhaseId
                                   join m in req.Missions on p.MissionId equals m.num
                                   where (mot.MotifId.Equals(MotifId))
                                   select m).FirstOrDefault();
                    return mis;


                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Mission> getAllDispositif()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Mission miss = new Mission();
                miss.num = Guid.Empty.ToString() ;
                miss.mission1 = " ";

                List<Mission> Mission_list = req.Missions.OrderBy(r => r.mission1).ToList();
                //List<Mission> Mission_list = req.Missions.ToList();
                List<Mission> Mission_list1 = new List<Mission>();
                Mission_list1.Add(miss);

                foreach (Mission s in Mission_list)
                {
                    Mission_list1.Add(s);
                }
                return Mission_list1;



                //return req.dispositif.OrderBy(r => r.dispositif1).ToList();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Mission> getAllDispositifFooter()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Mission miss = new Mission();
                miss.num = " ";
                miss.mission1 = " ";

                List<Mission> Mission_list = req.Missions.OrderBy(r => r.mission1).ToList();
                //List<Mission> Mission_list = req.Missions.ToList();
                List<Mission> Mission_list1 = new List<Mission>();
                if(Mission_list.Count==0)Mission_list1.Add(miss);

                foreach (Mission s in Mission_list)
                {
                    Mission_list1.Add(s);
                }
                return Mission_list1;



                //return req.dispositif.OrderBy(r => r.dispositif1).ToList();
            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertDispositif(Mission r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Missions.Add(r);

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
        public static bool deleteDispositif(string guid)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //requerant r2 = getRequerantByNum(guid);
                    Mission r1 = new Mission();
                    r1.num = guid.ToString();
                    req.Missions.Attach(r1);
                    req.Missions.Remove(r1);
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
        public bool updateDispositif(Mission r)
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
