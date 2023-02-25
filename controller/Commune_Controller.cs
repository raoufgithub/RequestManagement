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
    public class Commune_Controller
    {


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Communes> GetCommuneByWilaya(int num_wilaya)
        {
            //Using Extension methods
            using (requeteEntities req = new requeteEntities())
            {

                ///////////////////////////////////////////////////////////////////////////
                Communes commune = new Communes();
                commune.CommuneId = Guid.Empty;
                commune.NomCommune = " ";
                //List<Motif> motif_list = (from m in req.Motif from md in m.dispositif join d in req.dispositif on md.num equals d.num where (md.num == num_dispositif) select m).ToList();
                List<Communes> commune_list = (from comm in req.Communes join wil in req.wilaya on comm.Code_Wilaya equals wil.num where (wil.num==num_wilaya) orderby comm.NomCommune select comm).ToList();

                List<Communes> commune_list1 = new List<Communes>();
                commune_list1.Add(commune);

                foreach (Communes m in commune_list)
                {
                    commune_list1.Add(m);
                }
                return commune_list1;
            }
        }
    }
}
