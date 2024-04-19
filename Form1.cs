using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Windows.Forms;
using EPDM.Interop.epdm;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Diagnostics;
using CreatePicPDM;

namespace StandaloneApplicationCSharp
{
    public partial class Form1 : Form
    {
        SldWorks application;
        List<string> chekingList = new List<string>();
        List<string> listParts = new List<string>();
        private FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        private string folderName;
        IEdmVault5 vault;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(System.Object sender, System.EventArgs e)
        {
            //try
            //{

            //    //Create a file vault interface and log into a vault
            vault = new EdmVault5();
            vault.LoginAuto("PDM", this.Handle.ToInt32());

            //    //Get the vault's root folder interface
            //    string message = "";
            //    IEdmFile5 file = null;
            //    IEdmFolder5 folder = null;
            //    folder = vault.RootFolder;

            //    //Get position of first file in the root folder
            //    IEdmPos5 pos = null;
            //    pos = folder.GetFirstFilePosition();
            //    if (pos.IsNull)
            //    {
            //        message = ("The root folder of your vault does not contain any files.");
            //        MessageBox.Show(message);
            //        return;
            //    }
            //    message = ("The root folder of your vault contains these files: " + "\n");
            //    while (!pos.IsNull)
            //    {
            //        file = folder.GetNextFile(pos);
            //        message = message + file.Name + "\n";
            //    }

            //    //Show the names of all files in the root folder
            //    MessageBox.Show(message);

            //}

            //catch (System.Runtime.InteropServices.COMException ex)
            //{
            //    MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + "\n" + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            Form2 form = new Form2();
            form.Owner= this;

            IEdmSearch6 Search = (IEdmSearch6)vault.CreateSearch();
            if (Search == null)
                return;
            string valueName = "%" + textBox1.Text + "%" + "%.SLD%";
            Search.FindFiles = true;
            Search.SetToken(EdmSearchToken.Edmstok_FindFiles, true);
            Search.FileName = valueName;
            IEdmSearchResult5 result = Search.GetFirstResult();
            while ((result!=null))
            {
                form.listBoxSearchItem.Items.Add(result.Path);
                result= Search.GetNextResult();
            }
            form.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int[] indexes = listBox1.SelectedIndices.OfType<int>().OrderByDescending(i => i).ToArray();
            foreach (int i in indexes)
            {
                listBox1.Items.RemoveAt(i);
            }
        }

        private void buttonCreatePic_Click(object sender, EventArgs e)
        {
            application = (SldWorks)Marshal.GetActiveObject("SldWorks.Application.26");

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                int X=2;
                if (listBox1.Items[i].ToString().Contains(".SLDASM"))
                    X = 2;
                if (listBox1.Items[i].ToString().Contains(".sldasm"))
                    X = 2;
                if (listBox1.Items[i].ToString().Contains(".SLDPRT"))
                    X = 1;
                if (listBox1.Items[i].ToString().Contains(".sldprt"))
                    X = 1;
                int a = 0;
                int b = 0;
                application.OpenDoc6(listBox1.Items[i].ToString(), X, 1, "", ref a, ref b);
                application.ActivateDoc(listBox1.Items[i].ToString());
                ModelDoc2 SwModel = (ModelDoc2)application.IActiveDoc;
                CreatePic(SwModel);
                MessageBox.Show("Картинки созданы");
            }
        }
        public void Recursion(ModelDoc2 doc)
        {
            AssemblyDoc assemblyDoc = (AssemblyDoc)doc;
            object[] arraycomponent = (object[])assemblyDoc.GetComponents(false);
            if (arraycomponent == null) { return; }
            foreach (object componentObj in arraycomponent)
            {
                Component2 component2 = (Component2)componentObj;
                int X = component2.IGetModelDoc().GetType();
                int a = 0;
                int b = 0;
                application.OpenDoc6(component2.GetPathName().ToString(), X, 1, "", ref a, ref b);
                application.ActivateDoc(component2.GetPathName().ToString());
                CreatePic(doc);
                ModelDoc2 doc2 = (ModelDoc2)component2.IGetModelDoc();
                if (doc2.GetType() == 2) Recursion(doc2);
            }
        }
        public void listPartsAdd(ModelDoc2 doc)
        {
            AssemblyDoc assemblyDoc = (AssemblyDoc)doc;
            assemblyDoc.ResolveAllLightWeightComponents(true);
            object[] arraycomponent = (object[])assemblyDoc.GetComponents(true);
            if (arraycomponent == null) { return; }
            foreach (object componentObj in arraycomponent)
            {
                Component2 component2 = (Component2)componentObj;
                if (component2.IsSuppressed() == false && component2.IsVirtual==false)
                {
                    ModelDoc2 doc2 = (ModelDoc2)component2.IGetModelDoc();
                    string temporaryPathName = doc2.GetPathName();
                    if (listParts.Contains(temporaryPathName) == false)
                    {
                        listParts.Add(temporaryPathName);
                    }
                    if (doc2.GetType()==2)
                    { listPartsAdd(doc2); }
                }
            }
        }
        public void CreatePic (ModelDoc2 SwModel)
        {
            AssemblyDoc assemblyDoc = (AssemblyDoc)SwModel;
            object[] arraycomponent = (object[])assemblyDoc.GetComponents(true);
            if (arraycomponent == null) { return; }
            foreach (object componentObj in arraycomponent)
            {
                Component2 component2 = (Component2)componentObj;
                ModelDoc2 doc2 = (ModelDoc2)component2.IGetModelDoc();
                if (CheckFindList(doc2) == false)
                {
                    int a = 0;
                    int b = 0;
                    application.OpenDoc6(doc2.GetPathName().ToString(), 1, 1, "", ref a, ref b);
                    application.ActivateDoc(doc2.GetPathName().ToString());
                    if (doc2.GetType() == 2) Recursion(doc2);
                    SavePic(doc2);
                }
            }
            SavePic(SwModel);
        }
        bool CheckFindList(ModelDoc2 SwModel)
        {
            Configuration modelConf = SwModel.ConfigurationManager.ActiveConfiguration;
            Component2 root = modelConf.GetRootComponent3(false);
            if (chekingList.Contains(root.Name + "-" + modelConf.Name))
            { return true; }
            chekingList.Add(root.Name + "-" + modelConf.Name);
            return false;
        }
        void SavePic(ModelDoc2 SwModel)
        {
            Configuration modelConf = SwModel.ConfigurationManager.ActiveConfiguration;            
            Component2 root = modelConf.GetRootComponent3(false);
            ModelDocExtension swModelDocExt = (ModelDocExtension)SwModel.Extension;
            swModelDocExt.HideFeatureManager(true);
            SwModel.Extension.InsertScene(@"\scenes\01 basic scenes\11 white kitchen.p2s");
            SwModel.ForceRebuild3(true);
            SwModel.ShowNamedView2("*Диметрия", 9);
            SwModel.ViewDisplayHiddenremoved();
            SwModel.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swDisplayOrigins)), false);
            SwModel.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swDisplayTemporaryAxes)), false);
            SwModel.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swDisplayPlanes)), false);
            SwModel.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swDisplaySketches)), false);
            //SwModel.ShowNamedView2(textBox2.Text, -1);
            SwModel.ViewZoomtofit2();
            Thread.Sleep(1000);
            //SwModel.ViewZoomin();
            CustomPropertyManager cusPropMgr = modelConf.CustomPropertyManager;
            string[] PropNames = cusPropMgr.GetNames();
            string PicName = "";
            string ValOut = "";
            string ResolvedValOut="";
            for (int i = 0; i < PropNames.Length; i++)
            {
                if (PropNames[i] == "Обозначение")
                {
                    
                    cusPropMgr.Get2(PropNames[i], out ValOut, out ResolvedValOut);
                }
            }
            PicName = ResolvedValOut;
            int errors = 0;
            int warnings = 0;
            SwModel.SaveBMP(folderName + @"\" + PicName + ".bmp", 500, 500);
            SwModel.ViewDisplayShaded();
            swModelDocExt.SaveAs(folderName + @"\" + PicName + ".JPG",
                    (int)swSaveAsVersion_e.swSaveAsCurrentVersion,
                    (int)swSaveAsOptions_e.swSaveAsOptions_Silent,
                    null, ref errors, ref warnings);
            swModelDocExt.HideFeatureManager(false);
            Thread.Sleep(500);
            
        }
        private void buttonFolder_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = true;
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    string[] files = ofd.FileNames;
            //    foreach (string file in files)
            //    {
            //        listBox1.Items.Add(Path.GetFileName(file));
            //    }
            //}
            if (textBoxFolderPath.Text.Length > 3)
            {
                Process.Start("explorer.exe", textBoxFolderPath.Text);
            }
            if (textBoxFolderPath.Text.Length < 3)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textBoxFolderPath.Text = folderBrowserDialog1.SelectedPath;
                    folderName = folderBrowserDialog1.SelectedPath;
                }
            }            
        }

        private void buttonBrowsePDM_Click(object sender, EventArgs e)
        {
            if (vault == null)
            {
                vault = new EdmVault5();
            }
            if (!vault.IsLoggedIn)
            {
                //Log into selected vault as the current user
                vault.LoginAuto("PDM", this.Handle.ToInt32());
            }

            //Set the initial directory in the Open dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = vault.RootFolderPath;
            //Show the Open dialog
            System.Windows.Forms.DialogResult DialogResult;
            DialogResult = ofd.ShowDialog();
            //If the user didn't click Open, exit
            if (!(DialogResult == System.Windows.Forms.DialogResult.OK))
            {
                return;
            }

            foreach (string FileName in ofd.FileNames)
            {
                listBox1.Items.Add(FileName);
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                application = (SldWorks)Marshal.GetActiveObject("SldWorks.Application.26");
            }
            catch (Exception)
            {
                MessageBox.Show("Не запущен SolidWorks, попробуйте снова");
            }

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                int X = 2;
                if (listBox1.Items[i].ToString().Contains(".SLDASM"))
                    X = 2;
                if (listBox1.Items[i].ToString().Contains(".sldasm"))
                    X = 2;
                if (listBox1.Items[i].ToString().Contains(".SLDPRT"))
                    X = 1;
                if (listBox1.Items[i].ToString().Contains(".sldprt"))
                    X = 1;
                int a = 0;
                int b = 0;
                application.OpenDoc6(listBox1.Items[i].ToString(), X, 1, "", ref a, ref b);
                application.ActivateDoc(listBox1.Items[i].ToString());
                ModelDoc2 SwModel = (ModelDoc2)application.IActiveDoc;
                if (SwModel.GetType()==2)
                {                   
                    listPartsAdd(SwModel);
                }
                enumeratorConfigAndSavePic(SwModel);
                application.CloseDoc(listBox1.Items[i].ToString());
            }
            if (listParts.Count>1)
            {
                foreach (string item in listParts)
                {
                    int X = 2;
                    if (item.Contains(".SLDASM"))
                        X = 2;
                    if (item.Contains(".sldasm"))
                        X = 2;
                    if (item.Contains(".SLDPRT"))
                        X = 1;
                    if (item.Contains(".sldprt"))
                        X = 1;
                    int a = 0;
                    int b = 0;
                    application.OpenDoc6(item.ToString(), X, 1, "", ref a, ref b);
                    application.ActivateDoc(item.ToString());
                    ModelDoc2 SwModel = (ModelDoc2)application.IActiveDoc;
                    enumeratorConfigAndSavePic(SwModel);
                    application.CloseDoc(item.ToString());
                }
            }
            application.CloseAllDocuments(true);
            MessageBox.Show("Картинки созданы");
        }
        void enumeratorConfigAndSavePic(ModelDoc2 SwModel)
        {
            int Count = application.IActiveDoc.GetConfigurationCount();
            ConfigurationManager swConfMgr = (ConfigurationManager)SwModel.ConfigurationManager;
            string[] ConfigNames = SwModel.GetConfigurationNames();
            foreach (string item in ConfigNames)
            {
                //Configuration swConfig = (Configuration)SwModel.GetConfigurationByName(ConfigName);
                SwModel.ShowConfiguration2(item);
                SwModel.EditRebuild3();
                SwModel.GraphicsRedraw2();
                SavePic(SwModel);
            }
        }

        private void buttonCreateOnePic_Click(object sender, EventArgs e)
        {
            try
            {
                application = (SldWorks)Marshal.GetActiveObject("SldWorks.Application.26");
            }
            catch (Exception)
            {
                MessageBox.Show("Не запущен SolidWorks, попробуйте снова");
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                int X = 2;
                if (listBox1.Items[i].ToString().Contains(".SLDASM"))
                    X = 2;
                if (listBox1.Items[i].ToString().Contains(".sldasm"))
                    X = 2;
                if (listBox1.Items[i].ToString().Contains(".SLDPRT"))
                    X = 1;
                if (listBox1.Items[i].ToString().Contains(".sldprt"))
                    X = 1;
                int a = 0;
                int b = 0;
                application.OpenDoc6(listBox1.Items[i].ToString(), X, 1, "", ref a, ref b);
                application.ActivateDoc(listBox1.Items[i].ToString());
                ModelDoc2 SwModel = (ModelDoc2)application.IActiveDoc;
                enumeratorConfigAndSavePic(SwModel);
                application.CloseDoc(listBox1.Items[i].ToString());
            }
            //application.CloseAllDocuments(true);
            MessageBox.Show("Картинки созданы");
        }
    }
}