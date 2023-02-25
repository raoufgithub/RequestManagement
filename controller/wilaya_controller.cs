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
    public class wilaya_controller
    {

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static wilayas getWilayaByNum(int Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.wilaya.Where(r => r.num.Equals(Num)).FirstOrDefault();
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static wilayas getWilayaByName(string Name)
        {
            using (requeteEntities req = new requeteEntities())
            {
                return req.wilaya.Where(r => r.wilaya.Equals(Name)).FirstOrDefault();
            }
        }
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<wilayas> getAllWilaya()
        {
            using (requeteEntities req = new requeteEntities())
            {
                wilayas wilay = new wilayas();
                wilay.num = 0;
                wilay.wilaya = " ";


                List<wilayas> wilayas_list = req.wilaya.OrderBy(r => r.num).ToList();
                List<wilayas> wilayas_list1 = new List<wilayas>();
                wilayas_list1.Add(wilay);
                

                //foreach (wilayas s in wilayas_list)
                //{
                //    wilayas_list1.Add(s);
                //}
                wilayas_list1.AddRange(wilayas_list);
                return wilayas_list1;



                //return req.wilayas.OrderBy(r => r.num).ToList();
            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<wilayas> getAllWilayaWithDG()
        {
            using (requeteEntities req = new requeteEntities())
            {
                wilayas wilay = new wilayas();
                wilay.num = 0;
                wilay.wilaya = " ";

                wilayas DG = new wilayas();
                DG.num = -1;
                DG.wilaya = "Cellule DG";

                List<wilayas> wilayas_list = req.wilaya.OrderBy(r => r.num).ToList();
                List<wilayas> wilayas_list1 = new List<wilayas>();
                wilayas_list1.Add(wilay);
                wilayas_list1.Add(DG);

                foreach (wilayas s in wilayas_list)
                {
                    wilayas_list1.Add(s);
                }
                return wilayas_list1;



                //return req.wilayas.OrderBy(r => r.num).ToList();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertWilaya(wilayas r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.wilaya.Add(r);
                    
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
        public static bool deleteWilaya(int guid)
        {
            
            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    wilayas r1 = new wilayas();
                    r1.num = guid;
                    req.wilaya.Attach(r1);
                    req.wilaya.Remove(r1);
                    req.SaveChanges();
                    return true;
                }
            
                catch
                {

                    return false;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool updateWilaya(wilayas r)
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
        public static List<wilayas> GetWilayasOfStructure(string UserName)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    wilayas wilay = new wilayas();
                    wilay.num = 0;
                    wilay.wilaya = " ";
                    List<wilayas> wilayas_list = new List<wilayas>();
                    wilayas_list.Add(wilay);
                    Structure structure = StructureBLL.getCurrentStructureByUserName(UserName);
                    List<wilayas> wilayList2 = (from structWil in req.StructureWilayas
                                     join wil in req.wilaya on structWil.WilayaNum.Value equals wil.num
                                     where structWil.StructureId.Value.Equals(structure.StructureId) orderby wil.num
                                     select wil).ToList();
                    wilayas_list.AddRange(wilayList2);
                    return wilayas_list;
                }

                catch(Exception e)
                {

                    return null;
                }
            }
        }

        public static int GetCountWilayasOfStructure(Structure structure)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    int CountWilay = (from structWil in req.StructureWilayas
                                           join wil in req.wilaya on structWil.WilayaNum.Value equals wil.num
                                           where structWil.StructureId.Value.Equals(structure.StructureId)
                                           select wil).Count();
                    return CountWilay;
                }

                catch(Exception e)
                {

                    return 0;
                }
            }
        }
    }
}
