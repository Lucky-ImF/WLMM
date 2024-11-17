using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSMM
{
    public partial class MarketplaceEditor : Form
    {
        private bool mouseDown = false;
        private Point lastLocation;

        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;

        public MarketplaceEditor()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        public void TransferInfo(string Path, string Version, string UEV)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;

            LoadSupportedVersions();
            LoadCategories();
            LoadCharacters();
        }

        private string GetSlice(string Txt, string Delimiter, int slice)
        {
            string[] TempArray = Txt.Split(Delimiter);
            return TempArray[slice].Trim();
        }

        private void MarketplaceEditor_Load(object sender, EventArgs e)
        {

        }

        private void LoadSupportedVersions()
        {
            SupportedWLVersions_CLB.Items.Clear();
            if (File.Exists(Application.StartupPath + @"System\EngineVersions.ini"))
            {
                foreach (string line in File.ReadLines(Application.StartupPath + @"System\EngineVersions.ini"))
                {
                    SupportedWLVersions_CLB.Items.Add(GetSlice(line, "#", 0));
                }
            }
            if (File.Exists(Application.StartupPath + @"System\SupportedVersions.ini"))
            {
                SupportedWLVersions_CLB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"System\SupportedVersions.ini"));
            }
        }

        private void LoadCategories()
        {
            Categories_CLB.Items.Clear();
            if (File.Exists(Application.StartupPath + @"System\Categories.ini"))
            {
                Categories_CLB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"System\Categories.ini"));
            }
            else
            {
                Categories_CLB.Items.Add("Other");
            }
        }

        private void LoadCharacters()
        {
            AffectedCharacters_CLB.Items.Clear();
            AffectedCharacters_CLB.Items.Add("All");
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt"))
            {
                AffectedCharacters_CLB.Items.AddRange(File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt"));
            }
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt"))
            {
                foreach (string line in File.ReadLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\CustomizerCharacters.txt"))
                {
                    if (AffectedCharacters_CLB.Items.Contains(line) == false)
                    {
                        AffectedCharacters_CLB.Items.Add(line);
                    }
                }
            }
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void TitlePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_Button_MouseEnter(object sender, EventArgs e)
        {
            Close_Button.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void Close_Button_MouseLeave(object sender, EventArgs e)
        {
            Close_Button.Image = Properties.Resources.Close_Icon;
        }

        private void ModWLMMBrowse_Button_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ModWLMMPath_TB.Text = openFileDialog1.FileName;
                Directory.CreateDirectory(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp");
                // Load Metadata
                if (File.Exists(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat"))
                {
                    File.Delete(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");
                }
                using (ZipArchive zip = ZipFile.Open(openFileDialog1.FileName, ZipArchiveMode.Read))
                    foreach (ZipArchiveEntry entry in zip.Entries)
                        if (entry.Name == "Metadata.dat")
                            entry.ExtractToFile(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");

                //Read MetaData
                string SupVers = string.Empty;
                string Categories = string.Empty;
                string Characters = string.Empty;
                string[] MetaData = File.ReadAllLines(Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Temp\Metadata.dat");
                foreach (string meta in MetaData)
                {
                    if (meta.StartsWith("ModAuthor"))
                    {
                        ModAuthor_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("ModName"))
                    {
                        ModName_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("ModVersion"))
                    {
                        ModVersion_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("SupportedWLVersions"))
                    {
                        SupVers = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("ModURL"))
                    {
                        ModURL_TB.Text = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("Categories"))
                    {
                        Categories = GetSlice(meta, "=", 1);
                    }
                    else if (meta.StartsWith("Characters"))
                    {
                        Characters = GetSlice(meta, "=", 1);
                    }
                }

                //Clear Supported Versions
                for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                {
                    SupportedWLVersions_CLB.SetItemChecked(i, false);
                }
                //Clear Characters
                for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                {
                    AffectedCharacters_CLB.SetItemChecked(i, false);
                }
                //Clear Categories
                for (int i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                {
                    Categories_CLB.SetItemChecked(i, false);
                }

                if (SupVers.Contains("All Versions"))
                {
                    SupportedWLVersions_CLB.SetItemChecked(SupportedWLVersions_CLB.Items.Count - 1, true);
                }
                else
                {
                    if (SupVers.Contains(","))
                    {
                        string[] SplitSupVers = SupVers.Split(",");
                        foreach (string s in SplitSupVers)
                        {
                            string TrimmedS = s.Trim();
                            for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                            {
                                if (SupportedWLVersions_CLB.Items[i].ToString() == TrimmedS)
                                {
                                    SupportedWLVersions_CLB.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                        {
                            if (SupportedWLVersions_CLB.Items[i].ToString() == SupVers)
                            {
                                SupportedWLVersions_CLB.SetItemChecked(i, true);
                            }
                        }
                    }
                }

                // Characters
                if (Characters.Contains(","))
                {
                    string[] SplitChars = Characters.Split(",");
                    foreach (string s in SplitChars)
                    {
                        string TrimmedS = s.Trim();
                        for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                        {
                            if (AffectedCharacters_CLB.Items[i].ToString() == TrimmedS)
                            {
                                AffectedCharacters_CLB.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                    {
                        if (AffectedCharacters_CLB.Items[i].ToString() == Characters)
                        {
                            AffectedCharacters_CLB.SetItemChecked(i, true);
                        }
                    }
                }

                // Categories
                if (Categories.Contains(","))
                {
                    string[] SplitCats = Categories.Split(",");
                    foreach (string s in SplitCats)
                    {
                        string TrimmedS = s.Trim();
                        for (int i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                        {
                            if (Categories_CLB.Items[i].ToString() == TrimmedS)
                            {
                                Categories_CLB.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                    {
                        if (Categories_CLB.Items[i].ToString() == Categories)
                        {
                            Categories_CLB.SetItemChecked(i, true);
                        }
                    }
                }

                // Calculate mod size
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(openFileDialog1.FileName).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }
                string result = String.Format("{0:0.##} {1}", len, sizes[order]);
                ModSize_TB.Text = result.Replace(",", ".");

                // Last Update Day
                LastUpdate_TB.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            }
        }

        private void Screenshots_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Screenshots_LB.SelectedIndex != -1)
            {
                ScreenshotAdd_TB.Text = Screenshots_LB.SelectedItem.ToString();
                Screenshots_LB.Items.Remove(Screenshots_LB.SelectedItem);
            }
        }

        private void ScreenshotAdd_Button_Click(object sender, EventArgs e)
        {
            ScreenshotAdd_TB.ForeColor = SystemColors.ActiveCaption;
            if (ScreenshotAdd_TB.Text.ToLower().EndsWith(".jpg") || ScreenshotAdd_TB.Text.ToLower().EndsWith(".jpeg") || ScreenshotAdd_TB.Text.ToLower().EndsWith(".png"))
            {
                if (ScreenshotAdd_TB.Text.ToLower().StartsWith("https://") || ScreenshotAdd_TB.Text.ToLower().StartsWith("http://"))
                {
                    Screenshots_LB.Items.Add(ScreenshotAdd_TB.Text);
                }
                else
                {
                    ScreenshotAdd_TB.ForeColor = Color.LightCoral;
                    toolTip1.Show("Not a valid URL.", ScreenshotAdd_TB, 3000);
                }
            }
            else
            {
                ScreenshotAdd_TB.ForeColor = Color.LightCoral;
                toolTip1.Show("Filetype not supported. Must be .jpg, .jpeg or .png.", ScreenshotAdd_TB, 3000);
            }
        }

        private void CopyData_Button_Click(object sender, EventArgs e)
        {
            Categories_CLB.ForeColor = SystemColors.ActiveCaption;
            AffectedCharacters_CLB.ForeColor = SystemColors.ActiveCaption;
            ModIconURL_TB.ForeColor = SystemColors.ActiveCaption;
            ModDescription_TB.ForeColor = SystemColors.ActiveCaption;
            ModDLURL_TB.ForeColor = SystemColors.ActiveCaption;

            bool ModValid = true;
            // Check Categories have ateleast 1 selected
            if (Categories_CLB.CheckedItems.Count <= 0)
            {
                ModValid = false;
                Categories_CLB.ForeColor = Color.LightCoral;
                toolTip1.Show("Atleast 1 category must be selected.", Categories_CLB, 3000);
            }

            if (AffectedCharacters_CLB.CheckedItems.Count == 0)
            {
                ModValid = false;
                AffectedCharacters_CLB.ForeColor = Color.LightCoral;
                toolTip1.Show("Atleast 1 character must be selected.", AffectedCharacters_CLB, 3000);
            }

            // Check Mod Icon ends with valid extension
            if (ModIconURL_TB.Text.EndsWith(".jpg") || ModIconURL_TB.Text.EndsWith(".jpeg") || ModIconURL_TB.Text.EndsWith(".png"))
            {
                if (ModIconURL_TB.Text.StartsWith("https://") == false && ModIconURL_TB.Text.StartsWith("http://") == false)
                {
                    ModValid = false;
                    ModIconURL_TB.ForeColor = Color.LightCoral;
                    toolTip1.Show("Not a valid URL.", ModIconURL_TB, 3000);
                }
            }
            else 
            { 
                ModValid = false;
                ModIconURL_TB.ForeColor = Color.LightCoral;
                toolTip1.Show("Filetype not supported. Must be .jpg, .jpeg or .png.", ModIconURL_TB, 3000);
            }

            // Check Mod Description more than 0 lenght
            if (ModDescription_TB.Text.Length <= 0 && ModDescription_TB.Text.Contains(":") == false && ModDescription_TB.Text.Contains(",") == false && ModDescription_TB.Text.Contains("*") == false)
            {
                ModValid = false;
                ModDescription_TB.ForeColor = Color.LightCoral;
                toolTip1.Show("Description can't contain : , *", ModDescription_TB, 3000);
            }

            // Check Download Link is Mega.nz
            if (ModDLURL_TB.Text.StartsWith("https://mega.nz/") == false)
            {
                ModValid = false;
                ModDLURL_TB.ForeColor = Color.LightCoral;
                toolTip1.Show("Not a valid Mega.nz URL.", ModDLURL_TB, 3000);
            }

            // Write Data
            if (ModValid == true)
            {
                string SupportedVersions = "";
                int i;
                for (i = 0; i <= (SupportedWLVersions_CLB.Items.Count - 1); i++)
                {
                    if (SupportedWLVersions_CLB.GetItemChecked(i))
                    {
                        SupportedVersions += SupportedWLVersions_CLB.Items[i].ToString() + "*";
                    }
                }
                if (SupportedVersions.Contains("All Versions"))
                {
                    SupportedVersions = "All Versions";
                }
                else
                {
                    SupportedVersions = SupportedVersions.TrimEnd('*');
                }

                string Categories = "";
                i = 0;
                for (i = 0; i <= (Categories_CLB.Items.Count - 1); i++)
                {
                    if (Categories_CLB.GetItemChecked(i))
                    {
                        Categories += Categories_CLB.Items[i].ToString() + "*";
                    }
                }
                Categories = Categories.TrimEnd('*');

                string Characters = "";
                i = 0;
                for (i = 0; i <= (AffectedCharacters_CLB.Items.Count - 1); i++)
                {
                    if (AffectedCharacters_CLB.GetItemChecked(i))
                    {
                        Characters += AffectedCharacters_CLB.Items[i].ToString() + "*";
                    }
                }
                Characters = Characters.TrimEnd('*');

                string Screenshots = "";
                i = 0;
                for (i = 0; i <= (Screenshots_LB.Items.Count - 1); i++)
                {
                    Screenshots += Screenshots_LB.Items[i].ToString() + "*";
                }
                Screenshots = Screenshots.TrimEnd('*');

                string Metadata = "ModName:" + ModName_TB.Text + ",ModAuthor:" + ModAuthor_TB.Text +
                    ",ModVersion:" + ModVersion_TB.Text + ",SupportedVersions:" + SupportedVersions +
                    ",ModLink:" + ModURL_TB.Text + ",ModSize:" + ModSize_TB.Text + ",Category:" + Categories +
                    ",Characters:" + Characters +
                    ",LastUpdate:" + LastUpdate_TB.Text + ",ModIcon:" + ModIconURL_TB.Text +
                    ",ModDescription:" + ModDescription_TB.Text + ",DownloadLink:" + ModDLURL_TB.Text;

                if (Screenshots != "")
                {
                    Metadata += ",Screenshots:" + Screenshots;
                }

                Clipboard.SetText(Metadata);
                MessageBox.Show("Marketplace Data copied to clipboard.", "Wild Life Mod Manager");
            }
        }
    }
}
