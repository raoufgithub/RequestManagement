using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class AspNetUsers
    {
        //public string NbreMessageC
        //{
        //    get
        //    {
        //        try
        //        {
        //            using (requeteEntities req = new requeteEntities())
        //            {
        //                try
        //                {
        //                    int tracelinq = (from Messages in req.Message_Request
        //                                     join Users in req.AspNetUsers
        //                                     on Messages.id_user equals Users.Id
        //                                     where ((Messages.id_user == this.Id && Messages.Id_User_Destination == IdUser_Receiving
        //                                     || Messages.id_user == IdUser_Receiving && Messages.Id_User_Destination == IdUser_Sending)
        //                                     && Messages.NumRequest == NumRequest && Messages.YearRequest == Request_Year && Messages.num_wilayaRequest == NumWilaya)
        //                                     orderby (Messages.Date_Message) descending
        //                                     select Messages).Count();
        //                    return tracelinq;
        //                }
        //                catch (Exception e)
        //                {

        //                    return 0;
        //                }


        //                return req.Missions.Where(c => c.num.Equals(this.num_mission)).FirstOrDefault().mission1;
        //            }
        //        }
        //        catch
        //        {
        //            return "";
        //        };
        //    }
        //}
    }
}
