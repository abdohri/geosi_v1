using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using System.Data.SqlClient;

namespace GeoSI.Website.Common
{
    public class Form : PageBase
    {
        #region Variable global
        //--------------------- Début ----------------------------
        public string NomTable;
        public string NomTableJointure;
        public int JointureId = 0;
        public string _TableModule;
        public FormPanel UserForm = new FormPanel();
        public string IdTableModule = null;
        private Boolean issetClientid = false;
        public IDictionary<string, string> FormData = new Dictionary<string, string>();
        public IDictionary<string, string> ShemaTable = new Dictionary<string, string>();

        //--------------------- Fin ------------------------------
        #endregion

        #region Constructeur
        //--------------------- Début ----------------------------
        public Form()
        {
        }
        #endregion

        #region Methodes
        //--------------------- Début ----------------------------

        public void InitForm(string _Val, FormPanel _UserForm, int _CleintId)
        {
            string _req = "select * from " + this._TableModule + " where " + this.IdTableModule + "=" + _Val + " and actif=1 and ClientId=" + _CleintId;
            SqlDataReader dr = this.Select(_req);
            //List<string> _ListAction = new List<string>();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    for (int j = 0; j < _UserForm.Items.Count; j++)
                    {
                        if (_UserForm.Items[j].ID == dr.GetName(i))
                        {
                            if (_UserForm.Items[j].GetType().Name.Trim() == "Image")
                            {

                                ((Ext.Net.Image)_UserForm.Items[j]).ImageUrl = "../../Ressources/Images/imagesupload/" + dr[i].ToString();
                            }

                            else if (_UserForm.Items[j].GetType().Name == "TextField")
                            {
                                if (_UserForm.Items[j].ID != "pwd")
                                {
                                    ((Ext.Net.TextField)_UserForm.Items[j]).Text = dr[i].ToString();
                                }
                                else
                                {
                                    ((Ext.Net.TextField)_UserForm.Items[j]).Text = "gpeowdm";
                                }
                            }
                            else if (_UserForm.Items[j].GetType().Name == "ComboBox")
                            {

                                if (dr[i].ToString() != "" && dr[i].ToString() != "0")
                                {
                                    ((Ext.Net.ComboBox)_UserForm.Items[j]).SetValue((int)dr[i]);
                                }

                            }
                            else if (_UserForm.Items[j].GetType().Name == "TextArea")
                            {
                                ((Ext.Net.TextArea)_UserForm.Items[j]).Text = dr[i].ToString();
                            }
                            else if (_UserForm.Items[j].GetType().Name == "DateField")
                            {

                                if (dr[i].ToString() != "" && dr[i].ToString() != "01/01/1900 00:00:00")
                                {

                                    ((Ext.Net.DateField)_UserForm.Items[j]).Text = dr[i].ToString();
                                }
                            }
                            else if (_UserForm.Items[j].GetType().Name == "NumberField")
                            {
                                if (dr[i].ToString() != "")
                                {
                                    ((Ext.Net.NumberField)_UserForm.Items[j]).Text = dr[i].ToString();
                                }
                            }
                        }
                    }
                }
            }
            dr.Close();
        }
        public void InitForm(string _Val, FormPanel _UserForm)
        {
            string _req = "select * from " + this._TableModule + " where " + this.IdTableModule + "=" + _Val + " and actif=1";

            SqlDataReader dr = this.Select(_req);
            //List<string> _ListAction = new List<string>();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    for (int j = 0; j < _UserForm.Items.Count; j++)
                    {
                        if (_UserForm.Items[j].ID == dr.GetName(i))
                        {
                            if (_UserForm.Items[j].GetType().Name.Trim() == "Image")
                            {

                                ((Ext.Net.Image)_UserForm.Items[j]).ImageUrl = "../../Ressources/Images/imagesupload/" + dr[i].ToString();
                            }

                            else if (_UserForm.Items[j].GetType().Name == "TextField")
                            {
                                if (_UserForm.Items[j].ID != "pwd")
                                {
                                    ((Ext.Net.TextField)_UserForm.Items[j]).Text = dr[i].ToString();
                                }
                                else
                                {
                                    ((Ext.Net.TextField)_UserForm.Items[j]).Text = "gpeowdm";
                                }
                            }
                            else if (_UserForm.Items[j].GetType().Name == "ComboBox")
                            {

                                if (dr[i].ToString() != "" && dr[i].ToString() != "0")
                                {
                                    ((Ext.Net.ComboBox)_UserForm.Items[j]).SetValue((int)dr[i]);
                                }

                            }
                            else if (_UserForm.Items[j].GetType().Name == "TextArea")
                            {
                                ((Ext.Net.TextArea)_UserForm.Items[j]).Text = dr[i].ToString();
                            }
                            else if (_UserForm.Items[j].GetType().Name == "DateField")
                            {

                                if (dr[i].ToString() != "" && dr[i].ToString() != "01/01/1900 00:00:00")
                                {

                                    ((Ext.Net.DateField)_UserForm.Items[j]).Text = dr[i].ToString();
                                }
                            }
                            else if (_UserForm.Items[j].GetType().Name == "NumberField")
                            {
                                if (dr[i].ToString() != "")
                                {
                                    ((Ext.Net.NumberField)_UserForm.Items[j]).Text = dr[i].ToString();
                                }
                            }
                        }
                    }
                }
            }
            dr.Close();
        }
        public int Save(HttpRequest _Request)
        {
            Boolean _Requestclient = false;
            int retourSave = -1;
            for (int i = 0; i < _Request.Form.Count; i++)
            {
                if (_Request.Form.GetKey(i) == "pwd") { if (_Request.Form.Get(i) != "gpeowdm") { FormData.Add(_Request.Form.GetKey(i), Hash(_Request.Form.Get(i))); } }
                else {
                    if (_Request.Form.GetKey(i) == "clientid") { _Requestclient = true; }
                    FormData.Add(_Request.Form.GetKey(i), _Request.Form.Get(i)); }
            }
            FormData.Add("actif", "1");
            FormData.Add("date_modif", DateTime.Now.ToString());
            string colonnes = "";
            string valeurs = "";
            string ChaineUpdate = "";

            if (_TableModule == "client")
            {
                FormData.Add("revendeurid", this.getCurrentUser().getRevendeurId().ToString());
            }
            else
            {
                if (!_Requestclient)
                {
                    if (issetClientid)
                    {
                        FormData.Add("clientid", this.getCurrentUser().getClientId().ToString());
                    }
                }
            }

            for (int i = 0; i < FormData.Count; i++)
            {
                string ligne = FormData.ElementAt(i).Key;

                for (int j = 0; j < this.ShemaTable.Count; j++)
                {

                    string lignedb = this.ShemaTable.ElementAt(j).Key;
                    if (lignedb.ToLower().Trim() == ligne.ToLower().Trim())
                    {
                        if (i != 0)
                        {
                            colonnes += lignedb.ToLower().Trim() + ",";
                            valeurs += "'" + FormData.ElementAt(i).Value + "',";
                            ChaineUpdate += FormData.ElementAt(i).Key.Trim() + "='" + FormData.ElementAt(i).Value + "',";
                        }
                    }
                }

            }
            colonnes = colonnes.Substring(0, colonnes.Length - 1);
            valeurs = valeurs.Substring(0, valeurs.Length - 1);
            ChaineUpdate = ChaineUpdate.Substring(0, ChaineUpdate.Length - 1);

            string _ValIdTable = FormData.ElementAt(0).Value;

            if (_ValIdTable == "" && GeHabilitationAction("ajouter"))
            {
                string _req = "insert into " + this._TableModule + " (" + colonnes + ") values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                retourSave = this.InsertRetourId(_req);
            }
            else if (_ValIdTable != "0" && GeHabilitationAction("modifier"))
            {
                if (_TableModule == "client")
                {
                    string _req = "update " + this._TableModule + " set " + ChaineUpdate + " where " + FormData.ElementAt(0).Key + "=" + _ValIdTable + " and revendeurid=" + this.getCurrentUser().getRevendeur().ToString();
                    retourSave = this.Update(_req);
                }
                else
                {
                    if (issetClientid)
                    {
                        string _req = "update " + this._TableModule + " set " + ChaineUpdate + " where " + FormData.ElementAt(0).Key + "=" + _ValIdTable + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                        retourSave = this.Update(_req);
                    }
                    else if (!issetClientid)
                    {
                        string _req = "update " + this._TableModule + " set " + ChaineUpdate + " where " + FormData.ElementAt(0).Key + "=" + _ValIdTable;
                        retourSave = this.Update(_req);
                    }
                    else { }
                }


                if (retourSave != 0) { retourSave = int.Parse(_ValIdTable); }
            }
            else
            {

            }
            return retourSave;
        }
        //Traitement Requete
        public int SaveFile(HttpRequest _Request, FileUploadField FileUpload1)
        {
            int retourSave = -1;
            for (int i = 0; i < _Request.Form.Count; i++)
            {
                if (_Request.Form.GetKey(i) == "pwd") { FormData.Add(_Request.Form.GetKey(i), Hash(_Request.Form.Get(i))); }
                else { FormData.Add(_Request.Form.GetKey(i), _Request.Form.Get(i)); }
            }
            FormData.Add("actif", "1");//actif=1
            FormData.Add("date_modif", DateTime.Now.ToString());//date-modif= date système

            if (_TableModule == "client")
            {
                FormData.Add("revendeurid", this.getCurrentUser().getRevendeurId().ToString());
            }
            else
            {
                if (issetClientid)
                {
                    FormData.Add("clientid", this.getCurrentUser().getClientId().ToString());
                }
            }

            Boolean fileOK = false;
            string filename = null;
            String path = Server.MapPath("~/Ressources/Images/imagesupload/");
            for (int i = 0; i < _Request.Files.Count; i++)
            {
                if (FileUpload1.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                    for (int ii = 0; ii < allowedExtensions.Length; ii++)
                    {
                        if (fileExtension == allowedExtensions[ii] && FileUpload1.PostedFile.ContentLength < 1048576)
                        {
                            fileOK = true;
                            filename = Guid.NewGuid().ToString() + ((DateTime.Now.ToString().Replace(":", "")).Replace("/", "")).Replace(" ", "") + fileExtension;
                            FormData.Add(_Request.Files.GetKey(i), filename);
                        }
                    }
                }
            }

            string colonnes = "";
            string valeurs = "";
            string ChaineUpdate = "";
            for (int i = 0; i < FormData.Count; i++)
            {
                string ligne = FormData.ElementAt(i).Key;

                for (int j = 0; j < this.ShemaTable.Count; j++)
                {

                    string lignedb = this.ShemaTable.ElementAt(j).Key;
                    if (lignedb.ToLower().Trim() == ligne.ToLower().Trim())
                    {
                        if (i != 0)
                        {
                            colonnes += lignedb.ToLower().Trim() + ",";
                            valeurs += "'" + FormData.ElementAt(i).Value + "',";
                            ChaineUpdate += FormData.ElementAt(i).Key.Trim() + "='" + FormData.ElementAt(i).Value + "',";
                        }
                    }
                }

            }
            colonnes = colonnes.Substring(0, colonnes.Length - 1);
            valeurs = valeurs.Substring(0, valeurs.Length - 1);
            ChaineUpdate = ChaineUpdate.Substring(0, ChaineUpdate.Length - 1);

            string _ValIdTable = FormData.ElementAt(0).Value;

            if (_ValIdTable == "" && GeHabilitationAction("ajouter"))
            {
                string _req = "insert into " + this._TableModule + " (" + colonnes + ") values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                retourSave = this.InsertRetourId(_req);

                if (retourSave != -1)
                {

                    if (fileOK)
                    {
                        try
                        {
                            for (int i = 0; i < _Request.Files.Count; i++)
                            {
                                FileUpload1.PostedFile.SaveAs(path + filename);
                            }

                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }

                }
            }
            else if (_ValIdTable != "0" && GeHabilitationAction("modifier"))
            {
                string _recupereancienlogo = "SELECT " + _Request.Files.GetKey(0) + " from " + this._TableModule + " where " + _Request.Form.GetKey(0) + "=" + _ValIdTable;
                SqlDataReader resulat = this.Select(_recupereancienlogo);
                resulat.Read();
                string ancienlogo = resulat[0].ToString();
                resulat.Close();

                if (_TableModule == "client")
                {
                    string _req = "update " + this._TableModule + " set " + ChaineUpdate + " where " + FormData.ElementAt(0).Key + "=" + _ValIdTable + " and revendeurid=" + this.getCurrentUser().getRevendeurId().ToString();
                    retourSave = this.Update(_req);
                }
                else
                {
                    if (issetClientid)
                    {
                        string _req = "update " + this._TableModule + " set " + ChaineUpdate + " where " + FormData.ElementAt(0).Key + "=" + _ValIdTable + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                        retourSave = this.Update(_req);
                    }
                    else if (!issetClientid)
                    {
                        string _req = "update " + this._TableModule + " set " + ChaineUpdate + " where " + FormData.ElementAt(0).Key + "=" + _ValIdTable;
                        retourSave = this.Update(_req);
                    }
                    else { }
                }


                if (retourSave != 0) { retourSave = int.Parse(_ValIdTable); }
                if (retourSave != -1 && retourSave != 0)
                {
                    for (int i = 0; i < _Request.Files.Count; i++)
                    {
                        try
                        {
                            FileUpload1.PostedFile.SaveAs(path + filename);
                            System.IO.File.Delete(path + ancienlogo);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                }
            }
            else
            {

            }
            return retourSave;
        }
        //Schéma de la table 
        public void PreSchema(string _TableModule, string _IdTableModule)
        {
            this._TableModule = _TableModule.ToLower();
            this.IdTableModule = _IdTableModule.ToLower();

            string _req = "select COLUMN_NAME as name,IS_NULLABLE is_null,DATA_TYPE as type,CHARACTER_MAXIMUM_LENGTH as size from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + this._TableModule + "'";
            SqlDataReader resulat = this.Select(_req);
            string _size = "";
            while (resulat.Read())
            {
                try
                {
                    _size = resulat[3].ToString();
                }
                catch (Exception)
                {
                    _size = "";
                }

                if (resulat.GetString(0) == "clientid")
                {
                    issetClientid = true;
                }
                ShemaTable.Add(resulat.GetString(0), resulat.GetString(1) + ',' + resulat.GetString(2) + ',' + _size);
            }
            resulat.Close();
        }
        private void Page_PreInit(Object sender, EventArgs e)
        {
        }
        //Affectation 
        public int Affectation(string _TableAssociatf, string colonneid1, string colonneid2, int _valueId1, int _valueId2)
        {
            int retourAffectation = -1;
            string _req = "SELECT COUNT(" + colonneid2 + ") FROM " + _TableAssociatf + " WHERE " + colonneid2 + "=" + _valueId2 + " AND clientid=" + this.getCurrentUser().getClientId() + " AND actif='1'";
            SqlDataReader resulat = this.Select(_req);
            resulat.Read();
            int retour = int.Parse(resulat[0].ToString());
            resulat.Close();
            if (retour == 0)
            {
                try
                {
                    //string _reqUpdate = "update " + _TableAssociatf + " set actif='0',date_desaffectation='" + DateTime.Now + "' where clientId=" + this.getCurrentUser().getClientId() + " and " + colonneid1 + "=" + _valueId1 + " and actif='1' SELECT IDENT_CURRENT('" + _TableAssociatf + "')";
                    //this.Update(_reqUpdate);
                    string _reqInsert = "insert into " + _TableAssociatf + "(" + colonneid2 + "," + colonneid1 + ",actif, clientid, date_affectation,date_desaffectation) values (" + _valueId2 + "," + _valueId1 + ",'1'," + this.getCurrentUser().getClientId() + ",'" + DateTime.Now + "','') SELECT IDENT_CURRENT('" + _TableAssociatf + "')";
                    retourAffectation = this.Insert(_reqInsert);
                }
                catch (Exception)
                {
                    retourAffectation = -1;
                }

            }


            return retourAffectation;

        }
        //Actualiser les champs Affectation courante
        public void AffectationCourante(string _req, Label label1, Label label2, Label label3, Button button1)
        {
            //Affectation des champs
            SqlDataReader resulat = this.Select(_req);
            if (resulat.Read())
            {
                label1.Text = resulat[0].ToString();
                label2.Text = resulat[1].ToString();
                label3.Text = resulat[2].ToString();
            }
            else
            {
                label1.Text = "--------";
                label2.Text = "--------";
                label3.Text = "--------";
                button1.Hidden = true;
            }
            resulat.Close();
        }
        //Actualiser les champs Desaffectation 
        public void Desaffectation(string _TableAssociatif, int _id, Label label1, Label label2, Label label3, Button button1)
        {
            string _req = "update " + _TableAssociatif + " set actif='0',date_desaffectation='" + DateTime.Now + "' where clientId=" + this.getCurrentUser().getClientId() + " and " + IdTableModule + "=" + _id + " and actif='1'";
            int resulat1 = this.Update(_req);
            if (resulat1 != -1)
            {
                label1.Text = "--------";
                label2.Text = "--------";
                label3.Text = "--------";
                button1.Hidden = true;
            }
        }
        //Méthide désaffectation
        public void Methodedesaffec(string _TableAssociatif, int _id)
        {
            string _req = "update " + _TableAssociatif + " set actif='0',date_desaffectation='" + DateTime.Now + "' where clientId=" + this.getCurrentUser().getClientId() + " and id=" + _id + " and actif='1'";
            int resulat1 = this.Update(_req);
        }
        //   --------------------- Fin ------------------------------
        #endregion
    }
}