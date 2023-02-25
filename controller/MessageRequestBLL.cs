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
    public class MessageRequestBLL
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static List<Message_Request> getMessages(string IdUser_Sending, string IdUser_Receiving, 
            int Request_Year, int NumWilaya, int NumRequest)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    List<Message_Request> tracelinq = (from Messages in req.Message_Request
                                                join Users in req.AspNetUsers
                                                on Messages.id_user equals Users.Id
                                                where ((Messages.id_user == IdUser_Sending
                                                && Messages.Id_User_Destination == IdUser_Receiving
                                                || Messages.id_user == IdUser_Receiving
                                                && Messages.Id_User_Destination == IdUser_Sending)
                                                && Messages.NumRequest==NumRequest && Messages.YearRequest==Request_Year && Messages.num_wilayaRequest==NumWilaya)
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
        public static List<Message_Request> getMessages_NotYetRead(string IdUser_Receiving)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    List<Message_Request> tracelinq = (from Messages in req.Message_Request
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
        //public static List<Message_Request> getMessages_NotYetRead(string IdUser_Receiving,
        //    int Request_Year, int NumWilaya, int NumRequest)
        //{
        //    using (requeteEntities req = new requeteEntities())
        //    {

        //        try
        //        {
        //            List<Message_Request> tracelinq = (from Messages in req.Message_Request
        //                                        join Users in req.AspNetUsers
        //                                        on Messages.id_user equals Users.Id
        //                                        where (Messages.Id_User_Destination == IdUser_Receiving
        //                                        && Messages.State_Message == "Non Lu"
        //                                        && Messages.NumRequest == NumRequest && Messages.YearRequest == Request_Year && Messages.num_wilayaRequest == NumWilaya)
        //                                        orderby (Messages.Date_Message) descending
        //                                        select Messages).ToList();
        //            return tracelinq;
        //        }
        //        catch (Exception e)
        //        {

        //            return null;
        //        }
        //    }
        //}
        public static int getMessages_NotYetReadCount(string IdUser_Receiving)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    int tracelinq = (from Messages in req.Message_Request
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
        public static int getMessagesCountByUser(string IdUser_Sending, string IdUser_Receiving,
            int Request_Year, int NumWilaya, int NumRequest)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    int tracelinq = (from Messages in req.Message_Request
                                     join Users in req.AspNetUsers
                                     on Messages.id_user equals Users.Id
                                     where ((Messages.id_user == IdUser_Sending && Messages.Id_User_Destination == IdUser_Receiving
                                     || Messages.id_user == IdUser_Receiving && Messages.Id_User_Destination == IdUser_Sending)
                                     && Messages.NumRequest == NumRequest && Messages.YearRequest == Request_Year && Messages.num_wilayaRequest == NumWilaya)
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
        public static Boolean InsertMessages(string IdUser_Sending, string IdUser_Receiving, string link, string message
            , int Request_Year, int NumWilaya, int NumRequest)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {
                    Message_Request SendMessage = new Message_Request();
                    Guid guid = Guid.NewGuid();
                    SendMessage.MessageId = guid.ToString();
                    SendMessage.id_user = IdUser_Sending;
                    SendMessage.Id_User_Destination = IdUser_Receiving;
                    SendMessage.link = link;
                    /////////
                    SendMessage.YearRequest = Request_Year;
                    SendMessage.num_wilayaRequest = NumWilaya;
                    SendMessage.NumRequest = NumRequest;
                    //////////
                    SendMessage.Message = message;
                    SendMessage.State_Message = "Non Lu";
                    DateTime DateNow = DateTime.Now;
                    SendMessage.Date_Message = DateNow;
                    req.Message_Request.Add(SendMessage);
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
        public Message_Request GetMessageByUserName(string IdUserName_Sending, string IdUserName_Receiving, DateTime DateSending
            , int Request_Year, int NumWilaya, int NumRequest)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {

                    Message_Request Mess = (from Message in req.Message_Request
                                     where (Message.Date_Message.Equals(DateSending))
                                     select Message).FirstOrDefault();

                    return Mess;
                }
                catch (Exception e)
                {

                    return null;
                }
            }

        }
        public static Message_Request GetMessageByIDMessage(string IDMessage)
        {
            using (requeteEntities req = new requeteEntities())
            {

                try
                {

                    Message_Request Mess = (from Message in req.Message_Request
                                     where (Message.MessageId == IDMessage)
                                     select Message).FirstOrDefault();

                    return Mess;
                }
                catch (Exception e)
                {

                    return null;
                }
            }

        }


        public static bool updateMessage(Message_Request message)
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
