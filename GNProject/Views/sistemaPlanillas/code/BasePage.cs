using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.code
{
    public class BasePage : Page
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// The name of the culture selection Image check in the common header.
        /// </summary>
        /// 
        public const string LanguageDropDownNameEsp = "ctl00$cphRight$LinkButtonEsp";
        public const string LanguageDropDownNameIng = "ctl00$cphRight$LinkButtonIng";
        public const string LanguageDropDownNamePor = "ctl00$cphRight$LinkButtonPor";
        public const string LanguageDropDownNameIta = "ctl00$cphRight$LinkButtonIta";
        public const string LanguageDropDownNamePol = "ctl00$cphRight$LinkButtonPol";
        public const string LanguageDropDownNameFra = "ctl00$cphRight$LinkButtonFra";


        /// <summary>
        /// The name of the culture selection dropdown list in the common header.
        /// </summary>
        /// 
        public const string DropDownLanguageSelector = "ctl00$cphHeader$Header1$LanguageSelector";

        /// es el valor que toma el control dropdown que está en el Header.ascx.
        /// <summary>
        /// Con esta constante recuperamos el nombre del evento que ha saltado 
        /// en el PostBack a través de:  Request.Form[PostBackEventTarget] .
        /// </summary>
        public const string PostBackEventTarget = "__EVENTTARGET";

        /// <SUMMARY>
        /// Sobreescribimos el método InitilizeCulture para poner la opción seleccionada como idioma
        /// actual. A este metodo se llama antes que a cualquier otro al cargar la página.
        /// </SUMMARY>
        protected override void InitializeCulture()
        {
            ///<remarks><REMARKS>
            ///Comprobamos manualmente si ha habido PostBack o no. No podemos usar IsPostBack en este método.
            ///</remarks>
            if (Request[PostBackEventTarget] != null)
            {
                string controlID = Request[PostBackEventTarget];

                //if (controlID.Equals(DropDownLanguageSelector))

                if (controlID.Equals(LanguageDropDownNameEsp) ||
                    controlID.Equals(LanguageDropDownNameIng) ||
                    controlID.Equals(LanguageDropDownNamePor) ||
                    controlID.Equals(LanguageDropDownNamePol) ||
                    controlID.Equals(LanguageDropDownNameFra) ||
                    controlID.Equals(LanguageDropDownNameIta))
                {

                    // string selectedValue = Request.Form[Request[PostBackEventTarget]].ToString();
                    string selectedValue = "";

                    if (controlID.Equals(LanguageDropDownNameEsp))
                    {
                        selectedValue = "0";
                    }
                    if (controlID.Equals(LanguageDropDownNameIng))
                    {
                        selectedValue = "1";
                    }
                    if (controlID.Equals(LanguageDropDownNamePor))
                    {
                        selectedValue = "2";
                    }
                    if (controlID.Equals(LanguageDropDownNameIta))
                    {
                        selectedValue = "3";
                    }
                    if (controlID.Equals(LanguageDropDownNamePol))
                    {
                        selectedValue = "4";
                    }
                    if (controlID.Equals(LanguageDropDownNameFra))
                    {
                        selectedValue = "5";
                    }


                    switch (selectedValue)
                    {
                        case "0":
                            SetCulture("es-PE", "es-PE");
                            break;
                        case "1":
                            SetCulture("en-US", "en-US");
                            break;
                        case "2":
                            SetCulture("pt-BR", "pt-BR");
                            break;
                        case "3":
                            SetCulture("it-IT", "it-IT");
                            break;
                        case "4":
                            SetCulture("pl-PL", "pl-PL");
                            break;
                        case "5":
                            SetCulture("fr-FR", "fr-FR");
                            break;

                        default: break;
                    }

                }

            }
            ///<remarks>
            ///Obtenemos la "cultura" de Session
            ///</remarks>
            ///

            if (Session["MyUICulture"] != null && Session["MyCulture"] != null)
            {
                Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["MyUICulture"];
                Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["MyCulture"];
            }

            else
            {


                string selectedValue = Lista_Usuario_Culture();

                switch (selectedValue)
                {
                    case "es":
                        SetCulture("es-PE", "es-PE");
                        break;
                    case "en":
                        SetCulture("en-US", "en-US");
                        break;
                    case "pt":
                        SetCulture("pt-PT", "pt-PT");
                        break;
                    case "it":
                        SetCulture("it-IT", "it-IT");
                        break;
                    case "pl":
                        SetCulture("pl-PL", "pl-PL");
                        break;
                    case "fr":
                        SetCulture("fr-FR", "fr-FR");
                        break;
                    default: break;
                }

                Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["MyUICulture"];
                Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["MyCulture"];

            }

            base.InitializeCulture();
        }



        /// <Summary>
        /// Seteamos CurrentUICulture y CurrentCulture en funcion de los argumentos name y locale, que los llama 
        /// InitializeCulture con los parámetros recuperados en función de la selección del dropdownlist.
        /// </Summary>
        /// <PARAM name="name"></PARAM>
        /// <PARAM name="locale"></PARAM>
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            ///<remarks>
            ///Guardamos en Session los valores de Culture y UICUlture actuales.
            ///</remarks>
            Session["MyUICulture"] = Thread.CurrentThread.CurrentUICulture;
            Session["MyCulture"] = Thread.CurrentThread.CurrentCulture;

        }


        private string Lista_Usuario_Culture()
        {
            var Culture = "es";
            return Culture;
        }

        /// <summary>
        /// 
        /// HighlightGridLine();
        /// 
        /// Define el color de Resalte que va a tener el cursor, para hacer el efecto del linea resaltada segun el cursor 
        /// Example: 
        /// 
        /// <NameGrilla>_ItemDataBound(object sender, GridItemEventArgs e)
        ///    if (e.Item is GridDataItem && e.Item.OwnerTableView.ParentItem == null)
        ///    {
        ///        TableRow row = e.Item as TableRow;
        ///        row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
        ///        row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        ///    }
        /// 
        /// </summary>
        public void HighlightGridLine()
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "resaltarFila",
                @"function setMouseOverColor(element) 
                    {
                       oldgridSelectedColor = element.style.backgroundColor;
                       element.style.backgroundColor='silver';
                    }
                    function setMouseOutColor(element) 
                    {
                       element.style.backgroundColor=oldgridSelectedColor;
                       element.style.textDecoration='none';
                    }", true);
        }

        /// <summary>
        /// Limpia todos los texboxes actuales 
        /// Example :
        /// 
        ///    CleanTextBoxes(this);
        ///    
        /// </summary>
        /// <param name="parent"></param>
        public void CleanTextBoxes(Control parent)
        {

            TextBox t;
            foreach (Control c in parent.Controls)
            {
                t = c as TextBox;
                if (t != null)
                {
                    t.Text = "";
                }
                if (c.Controls.Count > 0)
                {
                    CleanTextBoxes(c);
                }
            }
        }

        /// <summary>
        /// Habilitar o desabilitar los Obejetos TexBox
        /// Example :
        /// 
        ///    EnabledTextBoxes(this, true);
        ///    
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="valLogico"></param>
        public void EnabledTextBoxes(Control parent, bool valLogico)
        {

            TextBox t;
            foreach (Control c in parent.Controls)
            {
                t = c as TextBox;
                if (t != null)
                {
                    t.Enabled = valLogico;
                }
                if (c.Controls.Count > 0)
                {
                    EnabledTextBoxes(c, valLogico);
                }
            }
        }

        /// <summary>
        /// Visualiza, Oculta los Obejetos TexBox
        /// Example :
        /// 
        ///    VisibleTextBoxes(this, true);
        ///    
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="valLogico"></param>
        public void VisibleTextBoxes(Control parent, bool valLogico)
        {

            TextBox t;
            foreach (Control c in parent.Controls)
            {
                t = c as TextBox;
                if (t != null)
                {
                    t.Enabled = valLogico;
                }
                if (c.Controls.Count > 0)
                {
                    VisibleTextBoxes(c, valLogico);
                }
            }
        }
    }
}