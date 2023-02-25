using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class requerant
    {



        public string WilayaRequerantC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        return req.wilaya.Where(c => c.num.Equals(this.id_wilaya.Value)).FirstOrDefault().wilaya;
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
