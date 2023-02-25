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
    public class Type_Controller
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static types getTypeByNum(Guid Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.types.Where(r => r.id_types.Equals(Num.ToString())).FirstOrDefault();
            }
        }


        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<types> getAllType()
        {
            using (requeteEntities req = new requeteEntities())
            {
                types typ = new types();
                typ.id_types = " ";
                typ.type = " ";


                List<types> types_list = req.types.OrderBy(r => r.id_types).ToList();
                List<types> types_list1 = new List<types>();
                types_list1.Add(typ);


                foreach (types s in types_list)
                {
                    types_list1.Add(s);
                }
                return types_list1;



                //return req.wilayas.OrderBy(r => r.num).ToList();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<types> getAllTypeFooter()
        {
            using (requeteEntities req = new requeteEntities())
            {
                types typ = new types();
                typ.id_types = " ";
                typ.type = " ";


                List<types> types_list = req.types.OrderBy(r => r.id_types).ToList();
                List<types> types_list1 = new List<types>();
                if(types_list.Count==0)types_list1.Add(typ);


                foreach (types s in types_list)
                {
                    types_list1.Add(s);
                }
                return types_list1;



                //return req.wilayas.OrderBy(r => r.num).ToList();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertType(types r)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.types.Add(r);

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
        public static bool deleteType(string guid)
        {

            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    types r1 = new types();
                    r1.id_types = guid.ToString();
                    req.types.Attach(r1);
                    req.types.Remove(r1);
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
        public static bool updateType(types r)
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
