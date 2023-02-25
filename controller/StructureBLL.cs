using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace controller
{
    public class StructureBLL
    {
        public static List<Structure> getAllStructures()
        {
            using (requeteEntities req = new requeteEntities())
            {
                Structure structures = new Structure();
                structures.StructureId = Guid.Empty;
                structures.IntituleFr = " ";


                List<Structure> structures_list = req.Structures.OrderBy(r => r.IntituleFr).ToList();
                List<Structure> structures_list1 = new List<Structure>();
                structures_list1.Add(structures);


                foreach (Structure s in structures_list)
                {
                    structures_list1.Add(s);
                }
                return structures_list1;



                //return req.wilayas.OrderBy(r => r.num).ToList();
            }
        }

        public static Structure getStructureByIntituleFr(string IntituleFr)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.Structures.Where(s => s.IntituleFr.Equals(IntituleFr)).FirstOrDefault();
            }
        }

        public static Structure getCurrentStructureByUserName(string UserName)
        {
            using (requeteEntities req = new requeteEntities())
            {

                Structure structure = (from UserStruc in req.UserManageStructures
                                       join user in req.AspNetUsers on UserStruc.UserId equals user.Id
                                       join struc in req.Structures on UserStruc.StructureId equals struc.StructureId
                                       where (user.UserName.Equals(UserName) && UserStruc.DateEnd==null)
                                       select struc).FirstOrDefault();
                return structure;
            }
        }


        public static List<Structure> GetChildrenStructureOfAStructure(Structure structure)
        {
            using (requeteEntities req= new requeteEntities())
            {
                List<Structure> structures = (from struc in req.Structures where (struc.StructureParentId.Value.Equals(structure.StructureId)) select struc).ToList();
                return structures;
            }
        }

    }
}
