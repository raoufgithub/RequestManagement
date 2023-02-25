using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
namespace controller
{
    [DataObject(true)]
    public class MemberShipController
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static aspnet_Membership getRequerantByNum(string email)
        {
            using (requeteEntities1 req = new requeteEntities1())
            {
                return req.aspnet_Membership.Where(r=>r.Email.Equals(email)).FirstOrDefault();
                
            }

        }
        //[DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public static List<requerant> getRequerantDataSource(int Num)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        List<requerant> datasource = new List<requerant>();
        //        datasource.Add(req.requerant.Where(r => r.num.Equals(Num)).FirstOrDefault());
        //        return datasource;
        //    }
        //}

        //[DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public static List<requerant> getAllRequerant()
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {

        //        if ((req.requerant.OrderBy(r => r.num).ToList()) != null) return req.requerant.OrderBy(r => r.num).ToList();
        //        else
        //        {

        //            List<requerant> requerant1 = new List<requerant>();
        //            requerant r1 = new requerant();
        //            r1.agencebancaire = " ";
        //            r1.annéeAccord = " ";
        //            r1.anneePrime = " ";
        //            r1.CMT = " ";
        //            r1.Date_Accord_PBancaire = " ";
        //            r1.DATE_DEPOT = " ";
        //            r1.Date_Naissance = " ";
        //            r1.date_Prime = " ";
        //            r1.Des_Act = " ";
        //            r1.DES_SEC_ACT = " ";
        //            r1.DES_SEC_ACT2 = " ";
        //            r1.HANDICAPE = " ";
        //            r1.JourAccordBancaire = " ";
        //            r1.JourPrime = " ";
        //            r1.LIB_DR = " ";
        //            r1.LIB_SEXE = " ";
        //            r1.Lib_Sit_Fam = " ";
        //            r1.moisAccordBancaire = " ";
        //            r1.moisPrime = " ";
        //            r1.Montant_Prime = " ";
        //            r1.NBRE_ASSOCIES = 0;
        //            r1.NIVEAU = " ";
        //            r1.NOM_AGENCE_CNAC = " ";
        //            r1.Nom_Banque = " ";
        //            r1.NOM_COMMUNE = " ";
        //            r1.nom_requerant = " ";
        //            r1.num = 0;
        //            r1.NUM_CPT_BANC = " ";
        //            r1.prenom_requerant = " ";
        //            r1.prime = " ";

        //            r1.REGION = " ";
        //            r1.WILAYA = " ";
        //            r1.nom_requerant = " ";
        //            requerant1.Add(r1);
        //            return req.requerant.OrderBy(r => r.num).ToList();
        //        }
        //    }
        //}

        //string erreur = "";
        //[DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        //public bool insertRequerant(requerant r1)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {
        //            req.requerant.Add(r1);
        //            req.SaveChanges();
        //            return true;

        //        }

        //        catch (DbEntityValidationException e)
        //        {
        //            foreach (var eve in e.EntityValidationErrors)
        //            {

        //                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",

        //                    eve.Entry.Entity.GetType().Name, eve.Entry.State);

        //                foreach (var ve in eve.ValidationErrors)
        //                {

        //                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",

        //                        ve.PropertyName, ve.ErrorMessage);

        //                }

        //            }
        //            return false;
        //        }
        //    }
        //}
        //[DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        //public bool deleteRequerant(int guid)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {
        //            //requerant r2 = getRequerantByNum(guid);
        //            requerant r1 = new requerant();
        //            r1.num = guid;
        //            req.requerant.Attach(r1);
        //            req.requerant.Remove(r1);
        //            req.SaveChanges();
        //            return true;
        //        }
        //        catch (DbEntityValidationException e)
        //        {
        //            foreach (var eve in e.EntityValidationErrors)
        //            {

        //                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",

        //                    eve.Entry.Entity.GetType().Name, eve.Entry.State);

        //                foreach (var ve in eve.ValidationErrors)
        //                {

        //                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",

        //                        ve.PropertyName, ve.ErrorMessage);

        //                }

        //            }
        //            return false;
        //        }
        //    }
        //}

        //[DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        //public bool updateRequerant(requerant r)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {
        //        try
        //        {

        //            string aaa = r.prenom_requerant;
        //            req.Entry(r).State = System.Data.Entity.EntityState.Modified;
        //            req.SaveChanges();
        //            return true;
        //        }
        //        catch
        //        {

        //            return false;
        //        }

        //    }
        //}
    }
}
