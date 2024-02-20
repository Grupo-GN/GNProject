using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlDocumentos.BE;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class DocumentoBL
    {
        DocumentoDA oDocumentoDA = new DocumentoDA();
        public DocumentoBEList Get_ListaDocumento(DocumentoBE oDocumentoBE)
        {
            try
            {
                return oDocumentoDA.Get_ListaDocumento(oDocumentoBE);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public DocumentoBE Get_DocumentoxID(Int32 id_documento)
        {
            try
            {
                DocumentoBE ent = new DocumentoBE();
                ent.id_documento = id_documento;
                ent.fl_activo = "1";
                return oDocumentoDA.Get_ListaDocumento(ent)[0];
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public Documento_CaracteristicaBEList Get_ListaDocumento_Caracteristica(Int32 id_Documento)
        {
            try
            {
                return oDocumentoDA.Get_ListaDocumento_Caracteristica(id_Documento);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarDocumento(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.GuardarDocumento(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void Archivar(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.Archivar(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void Desarchivar(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.Desarchivar(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarDocumento(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.EliminarDocumento(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void ActivarDocumento(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.ActivarDocumento(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarDocumentoFile(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.GuardarDocumentoFile(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void ArchivarFile(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.ArchivarFile(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void DesarchivarFile(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.DesarchivarFile(oDocumentoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public Documento_FileBEList Get_ListaDocumento_Files(Documento_FileBE oDocumentoFileBE, Int32 id_usuario)
        {
            try
            {
                return oDocumentoDA.Get_ListaDocumento_Files(oDocumentoFileBE, id_usuario);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void EliminarDocumento_File(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oDocumentoDA.EliminarDocumento_File(oDocumentoBE, out retorno, out msg_retorno);
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