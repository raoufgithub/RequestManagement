using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Request
    {
        
            public string EtatRequestC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.State_Request.Where(c => c.id_state.Equals(this.id_state.Value)).FirstOrDefault().nom_state;
                        }
                    }
                    catch
                    {
                        return "";
                    };
                }
            }



            public string ModeTransmissionC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.Transmission.Where(c => c.id_trans.Equals(this.id_trans)).FirstOrDefault().mode_trans;
                        }
                    }
                    catch
                    {
                        return "";
                    };
                }
            }

            public string WilayaC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.wilaya.Where(c => c.num.Equals(this.num_wilaya)).FirstOrDefault().wilaya;
                        }
                    }
                    catch
                    {
                        return "";
                    };
                }
            }
        public string CommuneC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        return req.Communes.Where(c => c.CommuneId.Equals(this.CommuneId.Value)).FirstOrDefault().NomCommune;
                    }
                }
                catch
                {
                    return "";
                };
            }
        }

        public string MotifC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return (from mot in req.Motif where (mot.MotifId.Equals(this.MotifId.Value)) select mot).FirstOrDefault().MotifName;
                            //return req.Objet_Disp.Where(c => c.id_objet.Equals(this.id_objet)).FirstOrDefault().objet;
                        }
                    }
                    catch(Exception e)
                    {
                        return "";
                    };
                }
            }

            public string DispositifC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                        //List<Mission> dispolinq = (from d in req.Missions join p in req.PhaseObject on d.num equals p.MissionId join m in req.Objet_Disp on p.PhaseId equals m.PhaseId where (m.id_objet == this.id_objet) select d).ToList();
                        //return dispolinq.Last<Mission>().mission1;
                        Mission dispolinq = (from mot in req.Motif join o in req.Objet_Disp on mot.ObjectId equals o.id_objet join phase in req.PhaseObject on o.PhaseId equals phase.PhaseId join mission in req.Missions on phase.MissionId equals mission.num select mission).FirstOrDefault();
                        return dispolinq.mission1;
                    }
                }
                    catch
                    {
                        return "";
                    };
                }
        }

        public string MotifDispositifC
        {
            get
            {
                try
                {
                    using (requeteEntities req = new requeteEntities())
                    {
                        return (from motif in req.Motif join obj in req.Objet_Disp on motif.ObjectId equals obj.id_objet where (motif.MotifId.Equals(this.MotifId.Value)) select obj).FirstOrDefault().objet;
                        
                    }
                }
                catch
                {
                    return "";
                };
            }
        }
        

        public string VoieTransC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.Voie_Transmission.Where(c => c.id_voie.Equals(this.id_Voie_Trans)).FirstOrDefault().voie_trans;
                        }
                    }
                    catch
                    {
                        return "";
                    };
                }
            }


            public string TypeRequestC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.types.Where(c => c.id_types.Equals(this.id_type)).FirstOrDefault().type;
                        }
                    }
                    catch
                    {
                        return "";
                    };
                }
            }



            public string NomRequerantC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.requerant.Where(c => c.num.Equals(this.num_requerant)).FirstOrDefault().nom_requerant;
                        }
                    }
                    catch
                    {
                        return "";
                    };
                }
            }

            public string PrenomRequerantC
            {
                get
                {
                    try
                    {
                        using (requeteEntities req = new requeteEntities())
                        {
                            return req.requerant.Where(c => c.num.Equals(this.num_requerant)).FirstOrDefault().prenom_requerant;
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
