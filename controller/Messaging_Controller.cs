using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace controller
{
    [DataObject(true)]
    public class Messaging_Controller
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<BAL_User> getMessages(string IdUser_Sending, string IdUser_Receiving)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    List<BAL_User> tracelinq = (from Messages in req.BAL_User
                                                join Users in req.AspNetUsers
                                                on Messages.id_user equals Users.Id
                                                where (Messages.id_user == IdUser_Sending
                                                && Messages.Id_User_Destination == IdUser_Receiving
                                                || Messages.id_user == IdUser_Receiving
                                                && Messages.Id_User_Destination == IdUser_Sending)
                                                orderby (Messages.Date_Message) descending
                                                select Messages).ToList();
                    return tracelinq;
                }
                catch (Exception e)
                {

                    return null;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<BAL_User> getMessages_NotYetRead(string IdUser_Receiving)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    List<BAL_User> tracelinq = (from Messages in req.BAL_User
                                                join Users in req.AspNetUsers
                                                on Messages.id_user equals Users.Id
                                                where (Messages.Id_User_Destination == IdUser_Receiving
                                                && Messages.State_Message == "Non Lu")
                                                orderby (Messages.Date_Message) descending
                                                select Messages).ToList();
                    return tracelinq;
                }
                catch (Exception e)
                {

                    return null;
                }
            }
        }
        public static int getMessages_NotYetReadCount(string IdUser_Receiving)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    int tracelinq = (from Messages in req.BAL_User
                                                join Users in req.AspNetUsers
                                                on Messages.id_user equals Users.Id
                                                where (Messages.Id_User_Destination == IdUser_Receiving
                                                && Messages.State_Message == "Non Lu")
                                                orderby (Messages.Date_Message) descending
                                                select Messages).Count();
                    return tracelinq;
                }
                catch (Exception e)
                {

                    return 0;
                }
            }
        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static Boolean InsertMessages(string IdUser_Sending, string IdUser_Receiving, string link, string message)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    BAL_User SendMessage = new BAL_User();
                    Guid guid = Guid.NewGuid();
                    SendMessage.Id_Message = guid.ToString();
                    SendMessage.id_user = IdUser_Sending;
                    SendMessage.Id_User_Destination = IdUser_Receiving;
                    SendMessage.link = link;
                    SendMessage.Message = message;
                    SendMessage.State_Message = "Non Lu";
                    DateTime DateNow = DateTime.Now;
                    SendMessage.Date_Message = DateNow;
                    req.BAL_User.Add(SendMessage);
                    req.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }
            }

        }

        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public BAL_User GetMessageByUserName(string IdUserName_Sending, string IdUserName_Receiving, DateTime DateSending)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {

                     BAL_User Mess = (from Message in req.BAL_User
                                     where (Message.Date_Message.Value.Equals(DateSending))
                                     select Message).FirstOrDefault();
                    
                    return Mess;
                }
                catch (Exception e)
                {

                    return null;
                }
            }
            
        }
        public static BAL_User GetMessageByIDMessage(string IDMessage)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {

                    BAL_User Mess = (from Message in req.BAL_User
                                     where (Message.Id_Message==IDMessage)
                                     select Message).FirstOrDefault();

                    return Mess;
                }
                catch (Exception e)
                {

                    return null;
                }
            }

        }


        public static bool updateMessage(BAL_User message)
        {
            using (requeteEntities req = new requeteEntities())
            {
                try
                {
                    req.Entry(message).State = System.Data.Entity.EntityState.Modified;
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
