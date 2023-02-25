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
    public class RequestMessagingBLL
    {
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

    }
}
