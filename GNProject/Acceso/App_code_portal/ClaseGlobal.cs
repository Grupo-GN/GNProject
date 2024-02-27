using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Globalization;

using System.Data;
using System.ComponentModel;
using System.Collections;
//para portal
using Capas.Portal.Entidad;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

/// <summary>
/// Descripción breve de ClaseGlobal
/// </summary>

namespace GNProject.Acceso.App_code_portal
{
    public static class ClaseGlobal
    {
        public static String Get_UserName(Page pg)
        {
            String[] arr_Usuario_Perfil = pg.User.Identity.Name.Split('|');
            String user_name = arr_Usuario_Perfil[0].ToString();
            return user_name;
        }
        public static String Get_NombreCompleto(Page pg)
        {
            String[] arr_Usuario_Perfil = pg.User.Identity.Name.Split('|');
            String no_usuario = arr_Usuario_Perfil[1].ToString();
            return no_usuario;
        }
        public static Int32 Get_PermisoID(Page pg)
        {
            String[] arr_Usuario_Perfil = pg.User.Identity.Name.Split('|');
            Int32 permiso_id = Convert.ToInt32(arr_Usuario_Perfil[2]);
            return permiso_id;
        }
        public static String Get_RutaFoto(Page pg)
        {
            String[] arr_Usuario_Perfil = pg.User.Identity.Name.Split('|');
            String ruta_foto = arr_Usuario_Perfil[3].ToString();
            return ruta_foto;
        }
        //public static String Get_UserID(Page pg)
        //{
        //    String[] arr_Usuario_Perfil = pg.User.Identity.Name.Split('|');
        //    String User_Id = arr_Usuario_Perfil[4].ToString();
        //    return User_Id;
        //}
        public static String Get_UserID()
        {
            String[] arr_Usuario_Perfil = HttpContext.Current.User.Identity.Name.Split('|');
            String User_Id = arr_Usuario_Perfil[4].ToString();
            return User_Id;
        }

        /*Convierte una lista genérica a DataTable*/
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static List<MenuBE> GetMenuContenidos()
        {
            List<MenuBE> oMenuBEList = new List<MenuBE>();
            //////oMenuBEList.Add(new MenuBE { id_menu = -1, tx_descripcion = "Mi Cuenta", url_pagina = "~/Intranet/MiCuenta.aspx", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -2, tx_descripcion = "Nuestra Empresa", url_pagina = "~/Intranet/Contenidos.aspx?id=1", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -3, tx_descripcion = "Historia", url_pagina = "~/Intranet/Contenidos.aspx?id=8", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -4, tx_descripcion = "Misión", url_pagina = "~/Intranet/Contenidos.aspx?id=2", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -6, tx_descripcion = "Visión", url_pagina = "~/Intranet/Contenidos.aspx?id=3", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -7, tx_descripcion = "Valores", url_pagina = "~/Intranet/Contenidos.aspx?id=7", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -8, tx_descripcion = "Organigrama", url_pagina = "~/Intranet/Contenidos.aspx?id=6", id_padre = -1 });
            oMenuBEList.Add(new MenuBE { id_menu = -9, tx_descripcion = "Videos Organizacionales", url_pagina = "~/Intranet/Videos.aspx", id_padre = -1 });

            return oMenuBEList;
        }
        public static MenuBEList GetMenu()
        {
            Page page = HttpContext.Current.Handler as Page;
            Int32 Permiso_Id = Get_PermisoID(page);

            MenuBE oMenuBE;
            MenuBEList oMenuBEList = new MenuBEList();

            oMenuBE = new MenuBE();
            oMenuBE.id_menu = 1; oMenuBE.tx_descripcion = "Inicio"; oMenuBE.url_pagina = "~/Inicio/"; oMenuBE.id_padre = 0;
            oMenuBEList.Add(oMenuBE);

            if (Permiso_Id == 1)
            {
                oMenuBE = new MenuBE();
                //oMenuBE.id_menu = 2; oMenuBE.tx_descripcion = "Mantenimientos"; oMenuBE.url_pagina = "~/Mantenimientos/Default.aspx"; oMenuBE.id_padre = 0;
                oMenuBE.id_menu = 2; oMenuBE.tx_descripcion = "Mantenimientos"; oMenuBE.url_pagina = ""; oMenuBE.id_padre = 0;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 3; oMenuBE.tx_descripcion = "Contenidos"; oMenuBE.url_pagina = "~/Mantenimientos/MantContenidos.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 4; oMenuBE.tx_descripcion = "Usuarios"; oMenuBE.url_pagina = "~/Mantenimientos/MantUsuarios.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                //////oMenuBE = new MenuBE();
                //////oMenuBE.id_menu = 5; oMenuBE.tx_descripcion = "Reservación de Salas"; oMenuBE.url_pagina = "~/Mantenimientos/MantReservacionSalas.aspx"; oMenuBE.id_padre = 2;
                //////oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 6; oMenuBE.tx_descripcion = "Cronograma de Actividades"; oMenuBE.url_pagina = "~/Mantenimientos/MantCronogramaMes.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 7; oMenuBE.tx_descripcion = "Preguntas Frecuentes"; oMenuBE.url_pagina = "~/Mantenimientos/MantPregFrecuentes.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 8; oMenuBE.tx_descripcion = "Anuncios"; oMenuBE.url_pagina = "~/Mantenimientos/MantAnuncios.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 9; oMenuBE.tx_descripcion = "Boletines"; oMenuBE.url_pagina = "~/Mantenimientos/MantBoletines.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 10; oMenuBE.tx_descripcion = "Documentos"; oMenuBE.url_pagina = "~/Mantenimientos/MantDocumentos.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 11; oMenuBE.tx_descripcion = "Sistema Integrado de Gestión SIG"; oMenuBE.url_pagina = "~/Mantenimientos/OHSAS.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 12; oMenuBE.tx_descripcion = "Procedimientos y Normativas"; oMenuBE.url_pagina = "~/Mantenimientos/MantProcedimientos.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 13; oMenuBE.tx_descripcion = "Formatos"; oMenuBE.url_pagina = "~/Mantenimientos/MantFormatos.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 14; oMenuBE.tx_descripcion = "Eventos"; oMenuBE.url_pagina = "~/Mantenimientos/MantEventos.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 15; oMenuBE.tx_descripcion = "Encuestas"; oMenuBE.url_pagina = "~/Mantenimientos/MantEncuestas.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                //////oMenuBE = new MenuBE();
                //////oMenuBE.id_menu = 16; oMenuBE.tx_descripcion = "Inducción"; oMenuBE.url_pagina = "~/Mantenimientos/MantInduccion.aspx"; oMenuBE.id_padre = 2;
                //////oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 17; oMenuBE.tx_descripcion = "Enlaces"; oMenuBE.url_pagina = "~/Mantenimientos/MantEnlaces.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 18; oMenuBE.tx_descripcion = "Servicios y Beneficios"; oMenuBE.url_pagina = "~/Mantenimientos/MantServiciosBeneficios.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                oMenuBE = new MenuBE();
                oMenuBE.id_menu = 19; oMenuBE.tx_descripcion = "Videos"; oMenuBE.url_pagina = "~/Mantenimientos/MantVideos.aspx"; oMenuBE.id_padre = 2;
                oMenuBEList.Add(oMenuBE);
                //////oMenuBE = new MenuBE();
                //////oMenuBE.id_menu = 20; oMenuBE.tx_descripcion = "Actualización de Intranet"; oMenuBE.url_pagina = "~/Mantenimientos/MantActIntranet.aspx"; oMenuBE.id_padre = 2;
                //////oMenuBEList.Add(oMenuBE);
                oMenuBEList.Add(new MenuBE { id_menu = 20, tx_descripcion = "Plantillas Correo", url_pagina = "~/Mantenimientos/MantCorreos.aspx", id_padre = 2 });
            }
            oMenuBE = new MenuBE();
            oMenuBE.id_menu = 21; oMenuBE.tx_descripcion = "Sistema Integrado de Gestión SIG"; oMenuBE.url_pagina = ""; oMenuBE.id_padre = 0;
            oMenuBEList.Add(oMenuBE);
            //Para OHSAS_Detalle se coloca el parametro del ID = ?id=1
            oMenuBEList.Add(new MenuBE { id_menu = 22, tx_descripcion = "Políticas", url_pagina = "~/OHSAS/OHSAS_Detalle.aspx?id=1", id_padre = 21 });
            oMenuBEList.Add(new MenuBE { id_menu = 23, tx_descripcion = "Objetivos", url_pagina = "~/OHSAS/OHSAS_Detalle.aspx?id=2", id_padre = 21 });
            oMenuBEList.Add(new MenuBE { id_menu = 24, tx_descripcion = "Inducción", url_pagina = "~/OHSAS/OHSAS_Detalle.aspx?id=3", id_padre = 21 });
            oMenuBEList.Add(new MenuBE { id_menu = 25, tx_descripcion = "Capacitaciones", url_pagina = "~/OHSAS/OHSAS_Detalle.aspx?id=4", id_padre = 21 });
            oMenuBEList.Add(new MenuBE { id_menu = 26, tx_descripcion = "RISST", url_pagina = "~/OHSAS/OHSAS_Detalle.aspx?id=5", id_padre = 21 });
            oMenuBEList.Add(new MenuBE { id_menu = 27, tx_descripcion = "RIT", url_pagina = "~/OHSAS/OHSAS_Detalle.aspx?id=6", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 22, tx_descripcion = "Políticas", url_pagina = "~/OHSAS/Politicas.aspx", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 23, tx_descripcion = "Objetivos", url_pagina = "~/OHSAS/Objetivos.aspx", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 24, tx_descripcion = "Programas de Gestión", url_pagina = "~/OHSAS/ProgGestion.aspx", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 25, tx_descripcion = "Mapa de Proceso", url_pagina = "~/OHSAS/MapaProceso.aspx", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 26, tx_descripcion = "Procedimiento del Sistema", url_pagina = "~/OHSAS/ProcSistema.aspx", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 27, tx_descripcion = "Registros", url_pagina = "~/OHSAS/Registros.aspx", id_padre = 21 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 28, tx_descripcion = "Requisitos Legales", url_pagina = "~/OHSAS/RequisitosLegales.aspx", id_padre = 21 });

            oMenuBEList.Add(new MenuBE { id_menu = 29, tx_descripcion = "Conociéndonos", url_pagina = "", id_padre = 0 });
            oMenuBEList.Add(new MenuBE { id_menu = 30, tx_descripcion = "Directorio de Colaboradores", url_pagina = "~/Intranet/DirColaboradores.aspx", id_padre = 29 });
            oMenuBEList.Add(new MenuBE { id_menu = 31, tx_descripcion = "Distribución por " + Parametros.I_Texto_CategoriaAuxiliar, url_pagina = "~/Intranet/DistribucionxArea.aspx", id_padre = 29 });
            oMenuBEList.Add(new MenuBE { id_menu = 32, tx_descripcion = "Anuncios", url_pagina = "", id_padre = 0 }); /*Anuncios Intranet*/
            oMenuBEList.Add(new MenuBE { id_menu = 33, tx_descripcion = "Anuncios", url_pagina = "~/Intranet/Anuncios.aspx", id_padre = 32 });
            oMenuBEList.Add(new MenuBE { id_menu = 34, tx_descripcion = "Preguntas Frecuentes", url_pagina = "~/Intranet/PreguntasFrecuentes.aspx", id_padre = 32 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 35, tx_descripcion = "Reservación de Salas", url_pagina = "~/Intranet/ReservSalas.aspx", id_padre = 32 });
            oMenuBEList.Add(new MenuBE { id_menu = 36, tx_descripcion = "Cronograma de Actividades", url_pagina = "~/Intranet/CronogramaMes.aspx", id_padre = 32 });
            oMenuBEList.Add(new MenuBE { id_menu = 37, tx_descripcion = "Documentos", url_pagina = "", id_padre = 0 });
            oMenuBEList.Add(new MenuBE { id_menu = 38, tx_descripcion = "Manuales", url_pagina = "~/Intranet/Manuales.aspx", id_padre = 37 });
            oMenuBEList.Add(new MenuBE { id_menu = 39, tx_descripcion = "Procedimientos y Normativas", url_pagina = "~/Intranet/Procedimientos.aspx", id_padre = 37 });
            oMenuBEList.Add(new MenuBE { id_menu = 40, tx_descripcion = "Formatos", url_pagina = "~/Intranet/Formatos.aspx", id_padre = 37 });
            oMenuBEList.Add(new MenuBE { id_menu = 41, tx_descripcion = "Boletines", url_pagina = "~/Intranet/Boletines.aspx", id_padre = 37 });
            oMenuBEList.Add(new MenuBE { id_menu = 42, tx_descripcion = "Bienestar Social", url_pagina = "", id_padre = 0 });
            oMenuBEList.Add(new MenuBE { id_menu = 43, tx_descripcion = "Eventos", url_pagina = "~/Intranet/Eventos.aspx", id_padre = 42 });
            oMenuBEList.Add(new MenuBE { id_menu = 44, tx_descripcion = "Servicios y Beneficios", url_pagina = "~/Intranet/ServiciosyBeneficios.aspx", id_padre = 42 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 45, tx_descripcion = "Prog. Inducción", url_pagina = "", id_padre = 42 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 46, tx_descripcion = "Programa de Inducción", url_pagina = "~/Intranet/ProgInduccion.aspx", id_padre = 45 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 47, tx_descripcion = "Trabajadores con Inducción", url_pagina = "~/Intranet/TrabConInduccion.aspx", id_padre = 45 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 48, tx_descripcion = "Trabajadores sin Inducción", url_pagina = "~/Intranet/TrabSinInduccion.aspx", id_padre = 45 });
            //////oMenuBEList.Add(new MenuBE { id_menu = 49, tx_descripcion = "Consultas", url_pagina = "", id_padre = 0 });
            oMenuBEList.Add(new MenuBE { id_menu = 50, tx_descripcion = "Encuestas", url_pagina = "~/Intranet/Encuestas.aspx", id_padre = 42 });
            return oMenuBEList;
        }

        public enum TipoArchivo
        {
            Documentos,
            HojaCalculo,
            Word,
            PPT,
            PDF,
            Imagenes,
            PNG,
            Videos
        }
        public static String UploadFile(System.Web.UI.WebControls.FileUpload pFileUpload, String Prefijo, TipoArchivo oTipoArchivo
            , String pathServer, out string pNombreArchivo)
        {
            double KB_Upload_File = pFileUpload.PostedFile.ContentLength / 1024;

            String RutaServer;
            if (pathServer != String.Empty) RutaServer = pathServer.Replace("~", HttpContext.Current.Server.MapPath("~"));
            else RutaServer = Parametros.I_FileServerPath.Replace("~", HttpContext.Current.Server.MapPath("~"));

            if (!System.IO.Directory.Exists(RutaServer))
            {
                System.IO.Directory.CreateDirectory(RutaServer);
            }

            string AlternateNameFile = String.Format("{1:ddMMyyyyHHmmss}_{2}_{0}", pFileUpload.FileName.ToLower(), DateTime.Now, Prefijo);
            pNombreArchivo = string.Format("{0}_{1}", Prefijo, pFileUpload.FileName.ToLower());
            string ruta = String.Format("{0}{1}", RutaServer, pNombreArchivo);

            string MisExtensiones = String.Empty;
            if (oTipoArchivo == TipoArchivo.Documentos) MisExtensiones = ".DOC,.doc,.DOCX,.docx,.PPT,.ppt,.PPTX,.pptx,.PDF,.pdf,.XLS,.xls,.XLSX,";
            else if (oTipoArchivo == TipoArchivo.HojaCalculo) MisExtensiones = ".XLS,.xls,.XLSX,.xlsx,.csv,";
            else if (oTipoArchivo == TipoArchivo.Word) MisExtensiones = ".DOC,.doc,.DOCX,.docx,";
            else if (oTipoArchivo == TipoArchivo.PPT) MisExtensiones = ".PPT,.ppt,.PPTX,.pptx,";
            else if (oTipoArchivo == TipoArchivo.PDF) MisExtensiones = ".PDF,.pdf,";
            else if (oTipoArchivo == TipoArchivo.Imagenes) MisExtensiones = ".JPGE,.jpge,.JPG,.jpg,.GIF,.gif,.PNG,.png,";
            else if (oTipoArchivo == TipoArchivo.PNG) MisExtensiones = ".PNG,.png,";
            else if (oTipoArchivo == TipoArchivo.Videos) MisExtensiones = ".mp4,.MP4,.avi,.AVI,";

            String msg = string.Empty;
            if (!pFileUpload.HasFile)
                msg = "Debe adjuntar un archivo.";
            else if (!MisExtensiones.Contains(System.IO.Path.GetExtension(pFileUpload.FileName) + ","))
                msg = string.Format("Solo se admiten archivos con extensión [{0}]", MisExtensiones.Substring(0, MisExtensiones.Length - 1));
            else
            {
                if (System.IO.File.Exists(ruta))
                    pNombreArchivo = AlternateNameFile;
                //////try { System.IO.File.Delete(ruta); }
                //////catch { pNombreArchivo = AlternateNameFile; }
                ruta = String.Format("{0}{1}", RutaServer, pNombreArchivo);

                try
                {
                    Int32 I_KB_File_maximo;
                    if (oTipoArchivo == TipoArchivo.Imagenes || oTipoArchivo == TipoArchivo.PNG)
                    {
                        I_KB_File_maximo = Parametros.I_Max_Upload_Imagen;
                        if (KB_Upload_File > I_KB_File_maximo)
                        {
                            if (!System.IO.Directory.Exists(RutaServer + "Redimensionados"))
                            {
                                System.IO.Directory.CreateDirectory(RutaServer + "Redimensionados");
                            }
                            else
                            {
                                //Elimina los archivos redimenasionados
                                try
                                {
                                    System.IO.Directory.Delete(RutaServer + "Redimensionados", true);
                                    System.IO.Directory.CreateDirectory(RutaServer + "Redimensionados");
                                }
                                catch { }
                            }
                            String ruta_redimensionado = String.Format("{0}Redimensionados/{1}", RutaServer, pNombreArchivo);
                            //Guarda imagen original
                            pFileUpload.SaveAs(ruta_redimensionado);

                            //INICIO - Redimensionar imagen
                            //Obtenemos la imagen del filesystem
                            Image image = Image.FromFile(ruta_redimensionado);
                            //Redimensionamos la imagen
                            if (KB_Upload_File < 4096) // < 4MB
                                image = Redimensionar(image, 30, 30); //30% del tamaño de la imagen
                            else
                            {
                                image = Redimensionar(image, 10, 10); //10% del tamaño de la imagen
                                                                      //Int32 w = image.Width;
                                                                      //Int32 h = image.Height;
                                                                      //image = Redimensionar(image, 400, 400, Convert.ToInt32(image.HorizontalResolution)); //ancho 400px - alto 400px
                            }
                            //300 px IMAGEN ANUNCIOS

                            //Guardamos la imagen modificada
                            image.Save(ruta); //Se guarda el nuevo archivo redimensionado
                            image.Dispose();
                            //FIN - Redimensionar imagen
                        }
                        else
                        {
                            pFileUpload.SaveAs(ruta);
                        }
                    }
                    else
                    {
                        //////I_KB_File_maximo = Parametros.I_Max_Upload_File;
                        //////if (KB_Upload_File > I_KB_File_maximo)
                        //////{
                        //////    msg = string.Format("El archivo es muy pesado. Peso máximo: [{0}]", I_KB_File_maximo.ToString());
                        //////}
                        //////else 
                        pFileUpload.SaveAs(ruta);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }

            }
            return msg.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace("'", "").Replace("\\", "/");
        }

        private static Image Redimensionar(Image Imagen, int Ancho, int Alto, int resolucion)
        {
            //Bitmap sera donde trabajaremos los cambios
            using (Bitmap imagenBitmap = new Bitmap(Ancho, Alto, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(resolucion, resolucion);
                //Hacemos los cambios a ImagenBitmap usando a ImagenGraphics y la Imagen Original(Imagen)
                //ImagenBitmap se comporta como un objeto de referenciado
                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(Imagen, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Imagen.Width, Imagen.Height), GraphicsUnit.Pixel);
                    //todos los cambios hechos en imagenBitmap lo llevaremos un Image(Imagen) con nuevos datos a travez de un MemoryStream
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    Imagen = Image.FromStream(imagenMemoryStream);
                }
            }
            return Imagen;
        }
        private static Image Redimensionar(Image image, int SizeHorizontalPorcent, int SizeVerticalPorcent)
        {
            //Obntenemos el ancho y el alto a partir del porcentaje de tamaño solicitado
            int anchoDestino = image.Width * SizeHorizontalPorcent / 100;
            int altoDestino = image.Height * SizeVerticalPorcent / 100;
            //Obtenemos la resolucion original 
            int resolucion = Convert.ToInt32(image.HorizontalResolution);

            return Redimensionar(image, anchoDestino, altoDestino, resolucion);
        }

        #region "Manejo de errores no controlados por aplicativo"
        public static System.Exception LastError;

        public static string getMensajeError()
        {
            while (LastError.InnerException != null)
            {
                LastError = LastError.InnerException;
            }
            return LastError.Message;
        }
        #endregion

    }

    public class JQGridJsonResponse
    {
        public int CurrentPage = 1;
        public int RecordCount = 0;
        public List<JQGridJsonResponseRow> Items;
        public int PageCount = 0;
        public Hashtable userData = null;

        public JQGridJsonResponse(Int32 pageCount, Int32 currentPage, Int32 recordCount)
        {
            CurrentPage = currentPage;
            RecordCount = recordCount;
            PageCount = pageCount;
            Items = new List<JQGridJsonResponseRow>();
        }
    }

    public class JQGridJsonResponseRow
    {
        public string ID;
        public object Row;
    }
}
