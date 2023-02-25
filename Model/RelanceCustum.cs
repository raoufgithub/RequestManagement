using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class relance
    {
        public string TransmissionRelanceC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        
                        //return req.State_Request.Where(c => c.id_state.Equals(this.id_state.Value)).FirstOrDefault().nom_state;
                        return req.Transmission.Where(c => c.id_trans.Equals(this.id_transmission)).FirstOrDefault().mode_trans;
                        
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
