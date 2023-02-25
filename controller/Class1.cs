using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model ;
using System.Security.Claims;

namespace controller
{
    [DataObject(true)]
    public class Class1
    {
        [DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public Request getRequestByNum(int Num)
        {
            using (requeteEntities req = new requeteEntities())
            {
                
                return req.Requests.Where(r => r.num.Equals(Num)).FirstOrDefault();
            }
        }


        static void main(string [] args)
        {
            var claim = new Claim(ClaimTypes.Role,"administrateur");

        }
    }
}
