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
    public class Relance_Controller
    {

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static relance getRelanceByKey(string id_relance)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.relances.Where(r => r.id_relances.Equals(id_relance)).FirstOrDefault();
            }
        }




        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<relance> getAllRelances(int id_Request, int NumWilaya_Request, int Year_Request)
        {
            using (requeteEntities req = new requeteEntities())
            {
                List<relance> relance_list = (from rel in req.relances where (rel.id_requete == id_Request && rel.NumWilaya_Request==NumWilaya_Request && rel.Year_Request==Year_Request) select rel).ToList();

                return relance_list;


                //return req.dispositif.OrderBy(r => r.dispositif1).ToList();
            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertRelance(relance r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.relances.Add(r);

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
        public static bool deleteRelance(int guid)
        {
            try
            {

                return true;
            }
            catch
            {

                return false;
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool updateRelance(int guid)
        {
            try
            {

                return true;
            }
            catch
            {

                return false;
            }

        }

        public static bool DeleteRelanceByRequestKey(requeteEntities req, int NumWilaya, int Year, int IdRequest)
        {
            
                try
                {
                    List<relance> rel = getAllRelances(IdRequest, NumWilaya, Year);
                    foreach (relance r in rel)
                    {
                        req.relances.Remove(r);
                    }
                    
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
