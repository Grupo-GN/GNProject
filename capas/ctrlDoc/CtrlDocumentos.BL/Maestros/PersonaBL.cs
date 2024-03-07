using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class PersonaBL
    {
        PersonaDA oPersonaDA = new PersonaDA();
        public PersonaBEList Get_ListaPersonas(PersonaBE oPersonaBE)
        {
            try
            {
                return oPersonaDA.Get_ListaPersonas(oPersonaBE);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarPersona(PersonaBE oPersonaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.GuardarPersona(oPersonaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarFotoPersona(PersonaBE oPersonaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.GuardarFotoPersona(oPersonaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarPersona(PersonaBE oPersonaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.EliminarPersona(oPersonaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        //Direcciones
        public PersonaDireccionBEList Get_ListaDirecciones_Persona(Int32 idPersona)
        {
            try
            {
                return oPersonaDA.Get_ListaDirecciones_Persona(idPersona);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarDireccion(PersonaDireccionBE oPersonaDireccionBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.GuardarDireccion(oPersonaDireccionBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarDireccion(PersonaDireccionBE oPersonaDireccionBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.EliminarDireccion(oPersonaDireccionBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        //Files de persona
        public void GuardarPersona_File(PersonaFileBE oPersonaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.GuardarPersona_File(oPersonaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public PersonaFileBEList Get_ListaPersona_Files(Int32 id_persona)
        {
            try
            {
                return oPersonaDA.Get_ListaPersona_Files(id_persona);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarPersona_File(PersonaFileBE oPersonaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPersonaDA.EliminarPersona_File(oPersonaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

    }
}
