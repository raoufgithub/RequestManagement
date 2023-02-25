using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class BAL_User
    {
        public string UserNameSendingC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        return req.AspNetUsers.Where(c => c.Id.Equals(this.id_user)).FirstOrDefault().UserName;
                    }
                }
                catch
                {
                    return "";
                };
            }
        }

        public string UserNameReceivingC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        return req.AspNetUsers.Where(c => c.Id.Equals(this.Id_User_Destination)).FirstOrDefault().UserName;
                    }
                }
                catch
                {
                    return "";
                };
            }
        }
    }
}
