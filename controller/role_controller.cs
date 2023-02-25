using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controller
{
    [DataObject(true)]
    public class role_controller
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static AspNetRoles getRoleByNum(string Num)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.AspNetRoles.Where(r => r.Id.Equals(Num)).FirstOrDefault();
            }
        }

        public static AspNetRoles getRoleByNom(string role)
        {
            using (requeteEntities req = new requeteEntities())
            {

                return req.AspNetRoles.Where(r => r.Name.Equals(role)).FirstOrDefault();
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<AspNetRoles> getAllRole()
        {
            using (requeteEntities req = new requeteEntities())
            {
                AspNetRoles role = new AspNetRoles();
                role.Id = "0";
                role.Name = " ";


                List<AspNetRoles> role_list = req.AspNetRoles.OrderBy(r => r.Id).ToList();
                List<AspNetRoles> role_list1 = new List<AspNetRoles>();
                role_list1.Add(role);


                foreach (AspNetRoles s in role_list)
                {
                    role_list1.Add(s);
                }
                return role_list1;



                //return req.wilayas.OrderBy(r => r.num).ToList();
            }
        }
        
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static bool insertRole(AspNetRoles r, List<Permissions_Role> permissions)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.AspNetRoles.Add(r);





                    //AddPermission(permissions);
                    foreach (Permissions_Role permission in permissions)
                    {


                        req.Permissions_Role.Add(permission);

                        

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






        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool deleteRole(string guid)
        {

            using (requeteEntities req = new requeteEntities())
            {
                try
                {

                    AspNetRoles r1 = getRoleByNum(guid);
                    
                    req.AspNetRoles.Attach(r1);
                    req.AspNetRoles.Remove(r1);

                    //delete permissions
                    List<Permissions_Role> permissions = getPermissions(guid);
                    foreach (Permissions_Role permission in permissions)
                    {
                        req.Permissions_Role.Attach(permission);
                        req.Permissions_Role.Remove(permission);
                    }

                    req.SaveChanges();
                    return true;
                }

                catch(Exception e)
                {

                    return false;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool updateRole(AspNetRoles r)
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
        public static List<Permissions_Role> getPermissions(string guid_role)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    return req.Permissions_Role.Where(r => r.Id_Role.Equals(guid_role)).ToList();
                    
                }

                catch (Exception e)
                {
                    
                    return null;
                }
            }

        }
    }

}
