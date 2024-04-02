using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Compania
    {
        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        string _Representante;

        public string Representante
        {
            get { return _Representante; }
            set { _Representante = value; }
        }
        string _Ruc;

        public string Ruc
        {
            get { return _Ruc; }
            set { _Ruc = value; }
        }
        string _Dpto;

        public string Dpto
        {
            get { return _Dpto; }
            set { _Dpto = value; }
        }
        string _Prov;

        public string Prov
        {
            get { return _Prov; }
            set { _Prov = value; }
        }
        string _Dist;

        public string Dist
        {
            get { return _Dist; }
            set { _Dist = value; }
        }
        string _Codigo_tel_soles;

        public string Codigo_tel_soles
        {
            get { return _Codigo_tel_soles; }
            set { _Codigo_tel_soles = value; }
        }
        string _Codigo_tel_dolares;

        public string Codigo_tel_dolares
        {
            get { return _Codigo_tel_dolares; }
            set { _Codigo_tel_dolares = value; }
        }
        string _Cta_soles;

        public string Cta_soles
        {
            get { return _Cta_soles; }
            set { _Cta_soles = value; }
        }
        string _Cta_dolares;

        public string Cta_dolares
        {
            get { return _Cta_dolares; }
            set { _Cta_dolares = value; }
        }
        string _Path;

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        string _Reg_Patronal;

        public string Reg_Patronal
        {
            get { return _Reg_Patronal; }
            set { _Reg_Patronal = value; }
        }
        string _Num_Telf;

        public string Num_Telf
        {
            get { return _Num_Telf; }
            set { _Num_Telf = value; }
        }
        string _Tip_cta_Id;

        public string Tip_cta_Id
        {
            get { return _Tip_cta_Id; }
            set { _Tip_cta_Id = value; }
        }
        string _Tipo_DocIde;

        public string Tipo_DocIde
        {
            get { return _Tipo_DocIde; }
            set { _Tipo_DocIde = value; }
        }
        string _Nro_DocIde;

        public string Nro_DocIde
        {
            get { return _Nro_DocIde; }
            set { _Nro_DocIde = value; }
        }
        string _Area_AFP;

        public string Area_AFP
        {
            get { return _Area_AFP; }
            set { _Area_AFP = value; }
        }
        string _Telf_Area_AFP;

        public string Telf_Area_AFP
        {
            get { return _Telf_Area_AFP; }
            set { _Telf_Area_AFP = value; }
        }
        string _Nro_Libro;

        public string Nro_Libro
        {
            get { return _Nro_Libro; }
            set { _Nro_Libro = value; }
        }
        string _Nro_Partida;

        public string Nro_Partida
        {
            get { return _Nro_Partida; }
            set { _Nro_Partida = value; }
        }
        string _CIIU_Id;

        public string CIIU_Id
        {
            get { return _CIIU_Id; }
            set { _CIIU_Id = value; }
        }
        Boolean _Cia_Default;

        public Boolean Cia_Default
        {
            get { return _Cia_Default; }
            set { _Cia_Default = value; }
        }
        Boolean _Flag_Pool_Proceso;

        public Boolean Flag_Pool_Proceso
        {
            get { return _Flag_Pool_Proceso; }
            set { _Flag_Pool_Proceso = value; }
        }

        string _LogoRuta;

        public string LogoRuta
        {
            get { return _LogoRuta; }
            set { _LogoRuta = value; }
        }
        byte[] _LogoImagen;

        public byte[] LogoImagen
        {
            get { return _LogoImagen; }
            set { _LogoImagen = value; }
        }

        byte[] _FirmaImagen;

        public byte[] FirmaImagen
        {
            get { return _FirmaImagen; }
            set { _FirmaImagen = value; }
        }

        public String SMTP_Host { get; set; }
        public Int32 SMTP_Port { get; set; }
        public Boolean SMTP_SSL { get; set; }
        public String SMTP_Mail_Address { get; set; }
        public String SMTP_Display_Name { get; set; }
        public String SMTP_User { get; set; }
        public String SMTP_Clave { get; set; }
    }
}
