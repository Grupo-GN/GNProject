using GNProject.Entity.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Entity.BL
{
    public class PlantillaDocBL
    {
        PlantillaDocDA oPlantillaDocDA = new PlantillaDocDA();
        public PlantillaDocBEList Get_ListaPlantillaDoc(PlantillaDocBE oPlantillaDocBE)
        {
            try
            {
                return oPlantillaDocDA.Get_ListaPlantillaDoc(oPlantillaDocBE);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public PlantillaDoc_CaracteristicaBEList Get_ListaPlantillaDoc_Caracteristica(Int32 id_plantilla_veh)
        {
            try
            {
                return oPlantillaDocDA.Get_ListaPlantillaDoc_Caracteristica(id_plantilla_veh);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public PlantillaDoc_FileBEList Get_ListaPlantillaDoc_File(Int32 id_plantilla_veh)
        {
            try
            {
                return oPlantillaDocDA.Get_ListaPlantillaDoc_File(id_plantilla_veh);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarPlantillaDoc(PlantillaDocBE oPlantillaDocBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPlantillaDocDA.GuardarPlantillaDoc(oPlantillaDocBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarPlantillaDoc(PlantillaDocBE oPlantillaDocBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPlantillaDocDA.EliminarPlantillaDoc(oPlantillaDocBE, out retorno, out msg_retorno);
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