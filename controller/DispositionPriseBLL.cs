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
    public class DispositionPriseBLL
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<DispositionPrise> getDispositionPriseByMotif(Guid ObjectId)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                DispositionPrise dis = new DispositionPrise();
                dis.DispositionPriseId = Guid.Empty;
                dis.DispositionName = " ";
                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                List<DispositionPrise> Disposition_list = (from d in req.DispositionPrise join o in req.Objet_Disp on d.ObjectId equals o.id_objet where (d.ObjectId.Equals(ObjectId.ToString())) select d).ToList();

                List<DispositionPrise> Disposition_list1 = new List<DispositionPrise>();
                Disposition_list1.Add(dis);

                //foreach (PhaseObject m in Phase_list)
                //{
                //    Phase_list1.Add(m);
                //}
                Disposition_list1.AddRange(Disposition_list);
                return Disposition_list1;
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<DispositionPrise> getAllDispositionPrise()
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                return req.DispositionPrise.ToList();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertDispositionPrise(DispositionPrise r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //dispositif dis = req.dispositif.Where(d => d.num.Equals(num_dispositif)).FirstOrDefault();
                    //r.dispositif.Add(dis);
                    req.DispositionPrise.Add(r);

                    req.SaveChanges();
                    return true;
                }

                catch (Exception e)
                {

                    return false;
                }
            }
        }

    }
}
