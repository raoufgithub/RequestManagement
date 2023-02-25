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
    public class requerant_controller
    {

        public static int getLastRequerant()
        {
            using (requeteEntities req = new requeteEntities())
            {

                int last_Num_Requerant = Convert.ToInt32( (from r in req.requerant orderby r.num descending select r.num).FirstOrDefault());
                return last_Num_Requerant + 1;
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static requerant getRequerantByNum(string Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.requerant.Where(r => r.num.Equals(Num)).FirstOrDefault();
            }

        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public static List<requerant> getRequerantDataSource(int Num, string nom, string prenom, datetime date)
        public static List<requerant> getRequerantDataSource(string Num)
        {
            using (requeteEntities req = new requeteEntities())
            {
                List<requerant> datasource = new List<requerant>();
                datasource.Add(req.requerant.Where(r => r.num.Equals(Num.ToString())).FirstOrDefault());
                return datasource;
            }
        }

        
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<requerant> getAllRequerant()
        {
            using (requeteEntities req = new requeteEntities())
            {

                //if ((req.requerant.OrderBy(r => r.num).ToList()).Count!=0) return req.requerant.OrderBy(r => r.num).ToList();
                
                    if ((req.requerant.ToList()).Count != 0) return req.requerant.OrderBy(r => r.num).ToList();
                    else
                    {
                        List<requerant> requerant1 = new List<requerant>();
                        requerant r1 = new requerant();
                        //r1.Date_Naissance=" ";
                        r1.SEXE = " ";
                        r1.nom_requerant = " ";
                        r1.num = " ";
                        r1.prenom_requerant = " ";
                        r1.Adresse = "";
                        r1.id_wilaya = 0;
                        r1.nom_requerant = " ";
                        requerant1.Add(r1);
                        return requerant1.ToList();
                    }
                
                
            }
        }

        string erreur = "";
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool insertRequerant(requerant r1)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.requerant.Add(r1);
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
        public bool deleteRequerant(string num)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    //requerant r2 = getRequerantByNum(guid);
                    requerant r1 = new requerant();
                    r1.num = num;
                    req.requerant.Attach(r1);
                    req.requerant.Remove(r1);
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
        public static bool updateRequerant(requerant r)
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
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<requerant> getFilteredRequerant(string where_req)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    int count_Requerant = ((List<requerant>)((req.spproc_filter_requerant(where_req)).ToList())).Count;
                    if (count_Requerant > 0) return (List<requerant>)((req.spproc_filter_requerant(where_req)).ToList());
                    else
                    {
                        List<requerant> r_list = new List<requerant>();
                        requerant r = new requerant();
                        r.num = " ";
                        
                        r_list.Add(r);
                        return r_list;
                    }
                }
                catch
                {

                    return null;
                }

            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<requerant> getFilteredRequerantByWilaya(int num_wilaya)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    //wilayas w=wilaya_controller.getWilayaByName(wilaya);
                    if (num_wilaya != -1)
                    {
                        int count_Requerant = ((List<requerant>)((req.spproc_filter_requerant("select * from Requerant pro  where(pro.id_wilaya = " + num_wilaya + ")")).ToList())).Count;
                        if (count_Requerant > 0) return (List<requerant>)((req.spproc_filter_requerant("select * from Requerant pro  where(pro.id_wilaya = " + num_wilaya + ")")).ToList());
                        else
                        {
                            List<requerant> r_list = new List<requerant>();
                            requerant r = new requerant();
                            r.num = " ";

                            r_list.Add(r);
                            return r_list;
                        }
                    }
                    else
                    {
                        return getAllRequerant();
                    }
                    
                }
                catch
                {

                    return null;
                }

            }
        }

    }
}
