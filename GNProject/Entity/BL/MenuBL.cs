using GNProject.Entity.DA;
using GNProject.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Entity.BL
{
    public class MenuBL
    {
        MenuDA oMenuDA = new MenuDA();
        public MenuBEList Get_Menu()
        {
            try
            {
                return oMenuDA.Get_Menu();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public MenuBEList Get_MenuxPerfil(Int32 id_perfil, String fl_con_padres = "")
        {
            try
            {
                return oMenuDA.Get_MenuxPerfil(id_perfil, fl_con_padres);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public TreeViewBEList Get_ArbolMenu()
        {
            try
            {
                MenuBEList oMenuBEList = oMenuDA.Get_Menu();
                TreeViewBEList objTreeView = this.Genera_ArbolTreeView(oMenuBEList, 0); //0: Padre

                return objTreeView;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        private TreeViewBEList Genera_ArbolTreeView(MenuBEList lista, int codPadre)
        {
            TreeViewBEList oListaArbol = new TreeViewBEList();

            foreach (MenuBE Item in lista)
            {
                if (Item.id_padre == codPadre)
                {
                    int papa = 0;
                    papa = Item.id_menu;

                    //Estado
                    arrayState oState = new arrayState();
                    oState.disabled = false;
                    oState.opened = true;
                    oState.selected = false;

                    //Elemento Principal
                    TreeViewBE oItem = new TreeViewBE();
                    oItem.id = Item.id_menu.ToString();
                    oItem.text = Item.tx_descripcion.ToString();
                    oItem.state = oState;
                    oItem.icon = "";

                    //Hijos
                    TreeViewBEList oHijos = new TreeViewBEList();
                    oHijos = this.Genera_ArbolTreeView(lista, papa);
                    oItem.children = oHijos;

                    //Final
                    oListaArbol.Add(oItem);
                }
            }
            return oListaArbol;
        }

        //-------Para treeView de plantillas con sub grupo y grupo de documentos
        public TreeViewBEList Get_ArbolPlantillasDoc()
        {
            try
            {
                List<ArbolBE> oLista_Arbol = new List<ArbolBE>();
                ComboBL oComboBL = new ComboBL();
                ComboBEList oGrupos = oComboBL.Get_Combo("CDOC_00006");

                ParametroBL oParametroBL = new ParametroBL();
                Int32 id_parametro = 9; //Sub Grupos
                ParametroDetalleBEList oSubGrupos = oParametroBL.Get_BandejaParametrosDetalle(id_parametro, 0, "1");

                PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
                PlantillaDocBE oPlantillaDocBE = new PlantillaDocBE();
                oPlantillaDocBE.fl_activo = "1";
                List<PlantillaDocBE> oPlantillasDoc = oPlantillaDocBL.Get_ListaPlantillaDoc(oPlantillaDocBE);

                foreach (ComboBE obj in oGrupos)
                {
                    ArbolBE oBE = new ArbolBE();
                    oBE.co_padre = "";
                    oBE.co_arbol = "G-" + obj.value;
                    oBE.tx_descripcion = "Grupo: " + obj.nombre;
                    oLista_Arbol.Add(oBE);
                }

                foreach (ParametroDetalleBE obj in oSubGrupos)
                {
                    ArbolBE oBE = new ArbolBE();
                    oBE.co_padre = "G-" + obj.no_valor4;
                    oBE.co_arbol = "SG-" + obj.no_valor3;
                    oBE.tx_descripcion = "Sub Grupo: " + obj.no_valor2;
                    oLista_Arbol.Add(oBE);
                }

                foreach (PlantillaDocBE obj in oPlantillasDoc)
                {
                    ArbolBE oBE = new ArbolBE();
                    oBE.co_padre = "SG-" + obj.co_sub_grupo_doc;
                    oBE.co_arbol = obj.id_plantilla_doc.ToString();
                    oBE.tx_descripcion = obj.no_plantilla_doc;
                    oLista_Arbol.Add(oBE);
                }

                TreeViewBEList objTreeView = this.Genera_ArbolTreeView_STR(oLista_Arbol, ""); //"": Padre

                return objTreeView;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        private TreeViewBEList Genera_ArbolTreeView_STR(List<ArbolBE> lista, string codPadre)
        {
            TreeViewBEList oListaArbol = new TreeViewBEList();

            foreach (ArbolBE Item in lista)
            {
                if (Item.co_padre == codPadre)
                {
                    string papa = "";
                    papa = Item.co_arbol;

                    //Estado
                    arrayState oState = new arrayState();
                    oState.disabled = false;
                    oState.opened = true;
                    oState.selected = false;

                    //Elemento Principal
                    TreeViewBE oItem = new TreeViewBE();
                    oItem.id = Item.co_arbol.ToString();
                    oItem.text = Item.tx_descripcion.ToString();
                    oItem.state = oState;
                    oItem.icon = "";

                    //Hijos
                    TreeViewBEList oHijos = new TreeViewBEList();
                    oHijos = this.Genera_ArbolTreeView_STR(lista, papa);
                    oItem.children = oHijos;

                    //Final
                    oListaArbol.Add(oItem);
                }
            }
            return oListaArbol;
        }
    }
}
public class ArbolBE
{
    public String co_arbol { get; set; }
    public String tx_descripcion { get; set; }
    public String co_padre { get; set; }
}