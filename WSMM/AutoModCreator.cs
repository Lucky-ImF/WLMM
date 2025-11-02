using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAssetAPI.Kismet.Bytecode.Expressions;

namespace WSMM
{
    public partial class AutoModCreator : Form
    {
        const string quote = "\"";

        private string LoadedWLVersion = string.Empty;
        private string LoadedUEVersion = string.Empty;
        private string LoadedWLPath = string.Empty;

        private bool mouseDown = false;
        private Point lastLocation;

        public List<string> NameMap = new List<string> { };
        string[] OutfitChars = null;
        string[] CustomizationChars = null;
        string[] FurChars = null;

        string CurrentlyEditing_Path = string.Empty;

        public ModCreator ModCreator_Form = null;

        //GroupBox, Label, Combobox, Label, Textbox, Label, Textbox, LinkLabel, LinkLabel
        GroupBox[] CharCust_GB = new GroupBox[50];
        Label[] CharCust_TargetLabel = new Label[50];
        ComboBox[] CharCust_Target = new ComboBox[50];
        Label[] CharCust_PathLabel = new Label[50];
        TextBox[] CharCust_Path = new TextBox[50];
        Label[] CharCust_NameLabel = new Label[50];
        TextBox[] CharCust_Name = new TextBox[50];
        Label[] CharCust_Physics_PathLabel = new Label[50];
        TextBox[] CharCust_Physics_Path = new TextBox[50];
        Label[] CharCust_Physics_NameLabel = new Label[50];
        TextBox[] CharCust_Physics_Name = new TextBox[50];
        LinkLabel[] CharCust_Dupe = new LinkLabel[50];
        LinkLabel[] CharCust_Remove = new LinkLabel[50];

        List<int> CharCust_Entries = new List<int>();
        int CharCust_CurrentEntryID = 0;

        public AutoModCreator()
        {
            InitializeComponent();
        }

        public void TransferInfo(string Path, string Version, string UEV, string Author, ModCreator MCF)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            LoadedUEVersion = UEV;
            ModCreator_Form = MCF;
            if (Author != "")
            {
                ModAuthor.Text = Author;
            }

            LoadBaseInfo();
        }

        private string GetSlice(string Txt, string Delimiter, int slice)
        {
            string[] TempArray = Txt.Split(Delimiter);
            if (slice == 999)
            {
                return TempArray[TempArray.Length - 1].Trim();
            }
            else
            {
                return TempArray[slice].Trim();
            }
        }

        private void LoadBaseInfo()
        {
            OutfitChars = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\Characters.txt");
            CustomizationChars = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\CustomizerCharacters.txt");
            FurChars = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\FurCharacters.txt");
            Character.Items.AddRange(OutfitChars);

            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\ConstraintProfiles.txt"))
            {
                Head_ConstraintProfileCB.Items.Clear();
                Hands_ConstraintProfileCB.Items.Clear();
                Chest_ConstraintProfileCB.Items.Clear();
                Legs_ConstraintProfileCB.Items.Clear();
                Feet_ConstraintProfileCB.Items.Clear();
                string[] ConstraintProfiles = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\ConstraintProfiles.txt");
                Head_ConstraintProfileCB.Items.AddRange(ConstraintProfiles);
                Hands_ConstraintProfileCB.Items.AddRange(ConstraintProfiles);
                Chest_ConstraintProfileCB.Items.AddRange(ConstraintProfiles);
                Legs_ConstraintProfileCB.Items.AddRange(ConstraintProfiles);
                Feet_ConstraintProfileCB.Items.AddRange(ConstraintProfiles);
            }
            if (File.Exists(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\MorphTargets.txt"))
            {
                Head_MorphTargetCB.Items.Clear();
                Hands_MorphTargetCB.Items.Clear();
                Chest_MorphTargetCB.Items.Clear();
                Legs_MorphTargetCB.Items.Clear();
                Feet_MorphTargetCB.Items.Clear();
                string[] MorphTargets = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\MorphTargets.txt");
                Head_MorphTargetCB.Items.AddRange(MorphTargets);
                Hands_MorphTargetCB.Items.AddRange(MorphTargets);
                Chest_MorphTargetCB.Items.AddRange(MorphTargets);
                Legs_MorphTargetCB.Items.AddRange(MorphTargets);
                Feet_MorphTargetCB.Items.AddRange(MorphTargets);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
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

        private void AutoModCreator_Load(object sender, EventArgs e)
        {

        }
        private void Head_Mesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Head_Mesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Head_SexMesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Head_SexMesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Head_Icon_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Head_Icon_Path.Text = "/Game/Textures/UI/Clothes/";
        }

        private void Chest_Mesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Chest_Mesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Chest_SexMesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Chest_SexMesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Chest_Icon_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Chest_Icon_Path.Text = "/Game/Textures/UI/Clothes/";
        }

        private void Hands_Mesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hands_Mesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Hands_SexMesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hands_SexMesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Hands_Icon_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hands_Icon_Path.Text = "/Game/Textures/UI/Clothes/";
        }

        private void Legs_Mesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Legs_Mesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Legs_SexMesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Legs_SexMesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Legs_Icon_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Legs_Icon_Path.Text = "/Game/Textures/UI/Clothes/";
        }

        private void Feet_Mesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feet_Mesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Feet_SexMesh_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feet_SexMesh_Path.Text = "/Game/Meshes/Characters/" + Character.Text + "/Costumes/";
        }

        private void Feet_Icon_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feet_Icon_Path.Text = "/Game/Textures/UI/Clothes/";
        }

        private void Head_Furmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Head_Furmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Head_SexFurmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Head_SexFurmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Chest_Furmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Chest_Furmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Chest_SexFurmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Chest_SexFurmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Hands_Furmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hands_Furmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Hands_SexFurmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hands_SexFurmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Legs_Furmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Legs_Furmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Legs_SexFurmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Legs_SexFurmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Feet_Furmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feet_Furmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Feet_SexFurmask_Path_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Feet_SexFurmask_Path.Text = "/Game/Textures/Characters/Costumes/FurMasks/";
        }

        private void Head_FurmaskInclude_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAllFurmasks(Head_FurmaskInclude.Checked);
        }

        private void Chest_FurmaskInclude_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAllFurmasks(Chest_FurmaskInclude.Checked);
        }

        private void Hands_FurmaskInclude_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAllFurmasks(Hands_FurmaskInclude.Checked);
        }

        private void Legs_FurmaskInclude_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAllFurmasks(Legs_FurmaskInclude.Checked);
        }

        private void Feet_FurmaskInclude_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAllFurmasks(Feet_FurmaskInclude.Checked);
        }

        private void ToggleAllFurmasks(bool State)
        {
            Head_FurmaskInclude.Checked = State;
            Chest_FurmaskInclude.Checked = State;
            Hands_FurmaskInclude.Checked = State;
            Legs_FurmaskInclude.Checked = State;
            Feet_FurmaskInclude.Checked = State;
        }

        private void ResetFurmasks()
        {
            Head_Furmask_Path.Text = "None";
            Head_Furmask_Name.Text = "None";
            Head_SexFurmask_Path.Text = "None";
            Head_SexFurmask_Name.Text = "None";

            Chest_Furmask_Path.Text = "None";
            Chest_Furmask_Name.Text = "None";
            Chest_SexFurmask_Path.Text = "None";
            Chest_SexFurmask_Name.Text = "None";

            Hands_Furmask_Path.Text = "None";
            Hands_Furmask_Name.Text = "None";
            Hands_SexFurmask_Path.Text = "None";
            Hands_SexFurmask_Name.Text = "None";

            Legs_Furmask_Path.Text = "None";
            Legs_Furmask_Name.Text = "None";
            Legs_SexFurmask_Path.Text = "None";
            Legs_SexFurmask_Name.Text = "None";

            Feet_Furmask_Path.Text = "None";
            Feet_Furmask_Name.Text = "None";
            Feet_SexFurmask_Path.Text = "None";
            Feet_SexFurmask_Name.Text = "None";
        }

        private void WriteMod_Click(object sender, EventArgs e)
        {
            try
            {
                NameMap.Clear();
                string ModString = "ModName: " + ModName.Text + "\n";
                ModString += "Author: " + ModAuthor.Text + "\n";
                ModString += "Variant: " + Variant.Text + "\n";

                if (Variant.Text == "Add")
                {
                    ModString += "NameMap: [NAMEMAPREPLACE]" + "\n";
                    ModString += "Character: " + Character.Text + "\n";
                    ModString += "[CLOTHING_ID]: " + OutfitID.Text + "\n";
                    AddToNameMap(OutfitID.Text);
                    ModString += "[CLOTHING_NAME]: " + OutfitName.Text + "\n";
                    AddToNameMap(OutfitName.Text);

                    ModString += "[HEAD_MESH_PATH]: " + Head_Mesh_Path.Text + "\n";
                    AddToNameMap(Head_Mesh_Path.Text);
                    ModString += "[HEAD_MESH_NAME]: " + Head_Mesh_Name.Text + "\n";
                    AddToNameMap(Head_Mesh_Name.Text);
                    ModString += "[HEAD_SEX_MESH_PATH]: " + Head_SexMesh_Path.Text + "\n";
                    AddToNameMap(Head_SexMesh_Path.Text);
                    ModString += "[HEAD_SEX_MESH_NAME]: " + Head_SexMesh_Name.Text + "\n";
                    AddToNameMap(Head_SexMesh_Name.Text);
                    ModString += "[HEAD_ICON_PATH]: " + Head_Icon_Path.Text + "\n";
                    AddToNameMap(Head_Icon_Path.Text);
                    ModString += "[HEAD_ICON_NAME]: " + Head_Icon_Name.Text + "\n";
                    AddToNameMap(Head_Icon_Name.Text);

                    ModString += "[HEAD_PHYSICSAREAS]: " + Head_PhysAreas.Text + "\n";
                    if (Head_MorphTargetCB.Text != "null" && Head_MorphTargetCB.Text.Contains(quote) == false)
                    {
                        Head_MorphTargetCB.Text = Head_MorphTargetCB.Text.Insert(0, quote);
                        Head_MorphTargetCB.Text = Head_MorphTargetCB.Text.Insert(Head_MorphTargetCB.Text.Length, quote);
                    }
                    ModString += "[HEAD_MORPHTARGET]: " + Head_MorphTargetCB.Text + "\n";
                    ModString += "[HEAD_MORPHTARGETVALUE]: " + Head_MorphTargetVal.Text + "\n";
                    if (Head_ConstraintProfileCB.Text != "null" && Head_ConstraintProfileCB.Text.Contains(quote) == false)
                    {
                        Head_ConstraintProfileCB.Text = Head_ConstraintProfileCB.Text.Insert(0, quote);
                        Head_ConstraintProfileCB.Text = Head_ConstraintProfileCB.Text.Insert(Head_ConstraintProfileCB.Text.Length, quote);
                    }
                    ModString += "[HEAD_CONSTRAINTPROFILE]: " + Head_ConstraintProfileCB.Text + "\n";
                    ModString += "[HEAD_AROUSALBLEND]: " + Head_ArousalBlend.Text + "\n";
                    ModString += "[HEAD_FLEXREGIONS]: " + Head_FlexReg.Text + "\n";

                    if (Head_FurmaskInclude.Checked == true)
                    {
                        ModString += "[HEAD_FURMASK_PATH]: " + Head_Furmask_Path.Text + "\n";
                        AddToNameMap(Head_Furmask_Path.Text);
                        ModString += "[HEAD_FURMASK_NAME]: " + Head_Furmask_Name.Text + "\n";
                        AddToNameMap(Head_Furmask_Name.Text);
                        ModString += "[HEAD_SEX_FURMASK_PATH]: " + Head_SexFurmask_Path.Text + "\n";
                        AddToNameMap(Head_SexFurmask_Path.Text);
                        ModString += "[HEAD_SEX_FURMASK_NAME]: " + Head_SexFurmask_Name.Text + "\n";
                        AddToNameMap(Head_SexFurmask_Name.Text);
                    }

                    ModString += "[CHEST_MESH_PATH]: " + Chest_Mesh_Path.Text + "\n";
                    AddToNameMap(Chest_Mesh_Path.Text);
                    ModString += "[CHEST_MESH_NAME]: " + Chest_Mesh_Name.Text + "\n";
                    AddToNameMap(Chest_Mesh_Name.Text);
                    ModString += "[CHEST_SEX_MESH_PATH]: " + Chest_SexMesh_Path.Text + "\n";
                    AddToNameMap(Chest_SexMesh_Path.Text);
                    ModString += "[CHEST_SEX_MESH_NAME]: " + Chest_SexMesh_Name.Text + "\n";
                    AddToNameMap(Chest_SexMesh_Name.Text);
                    ModString += "[CHEST_ICON_PATH]: " + Chest_Icon_Path.Text + "\n";
                    AddToNameMap(Chest_Icon_Path.Text);
                    ModString += "[CHEST_ICON_NAME]: " + Chest_Icon_Name.Text + "\n";
                    AddToNameMap(Chest_Icon_Name.Text);

                    ModString += "[CHEST_PHYSICSAREAS]: " + Chest_PhysAreas.Text + "\n";
                    if (Chest_MorphTargetCB.Text != "null" && Chest_MorphTargetCB.Text.Contains(quote) == false)
                    {
                        Chest_MorphTargetCB.Text = Chest_MorphTargetCB.Text.Insert(0, quote);
                        Chest_MorphTargetCB.Text = Chest_MorphTargetCB.Text.Insert(Chest_MorphTargetCB.Text.Length, quote);
                    }
                    ModString += "[CHEST_MORPHTARGET]: " + Chest_MorphTargetCB.Text + "\n";
                    ModString += "[CHEST_MORPHTARGETVALUE]: " + Chest_MorphTargetVal.Text + "\n";
                    if (Chest_ConstraintProfileCB.Text != "null" && Chest_ConstraintProfileCB.Text.Contains(quote) == false)
                    {
                        Chest_ConstraintProfileCB.Text = Chest_ConstraintProfileCB.Text.Insert(0, quote);
                        Chest_ConstraintProfileCB.Text = Chest_ConstraintProfileCB.Text.Insert(Chest_ConstraintProfileCB.Text.Length, quote);
                    }
                    ModString += "[CHEST_CONSTRAINTPROFILE]: " + Chest_ConstraintProfileCB.Text + "\n";
                    ModString += "[CHEST_AROUSALBLEND]: " + Chest_ArousalBlend.Text + "\n";
                    ModString += "[CHEST_FLEXREGIONS]: " + Chest_FlexReg.Text + "\n";

                    if (Chest_FurmaskInclude.Checked == true)
                    {
                        ModString += "[CHEST_FURMASK_PATH]: " + Chest_Furmask_Path.Text + "\n";
                        AddToNameMap(Chest_Furmask_Path.Text);
                        ModString += "[CHEST_FURMASK_NAME]: " + Chest_Furmask_Name.Text + "\n";
                        AddToNameMap(Chest_Furmask_Name.Text);
                        ModString += "[CHEST_SEX_FURMASK_PATH]: " + Chest_SexFurmask_Path.Text + "\n";
                        AddToNameMap(Chest_SexFurmask_Path.Text);
                        ModString += "[CHEST_SEX_FURMASK_NAME]: " + Chest_SexFurmask_Name.Text + "\n";
                        AddToNameMap(Chest_SexFurmask_Name.Text);
                    }

                    ModString += "[HANDS_MESH_PATH]: " + Hands_Mesh_Path.Text + "\n";
                    AddToNameMap(Hands_Mesh_Path.Text);
                    ModString += "[HANDS_MESH_NAME]: " + Hands_Mesh_Name.Text + "\n";
                    AddToNameMap(Hands_Mesh_Name.Text);
                    ModString += "[HANDS_SEX_MESH_PATH]: " + Hands_SexMesh_Path.Text + "\n";
                    AddToNameMap(Hands_SexMesh_Path.Text);
                    ModString += "[HANDS_SEX_MESH_NAME]: " + Hands_SexMesh_Name.Text + "\n";
                    AddToNameMap(Hands_SexMesh_Name.Text);
                    ModString += "[HANDS_ICON_PATH]: " + Hands_Icon_Path.Text + "\n";
                    AddToNameMap(Hands_Icon_Path.Text);
                    ModString += "[HANDS_ICON_NAME]: " + Hands_Icon_Name.Text + "\n";
                    AddToNameMap(Hands_Icon_Name.Text);

                    ModString += "[HANDS_PHYSICSAREAS]: " + Hands_PhysAreas.Text + "\n";
                    if (Hands_MorphTargetCB.Text != "null" && Hands_MorphTargetCB.Text.Contains(quote) == false)
                    {
                        Hands_MorphTargetCB.Text = Hands_MorphTargetCB.Text.Insert(0, quote);
                        Hands_MorphTargetCB.Text = Hands_MorphTargetCB.Text.Insert(Hands_MorphTargetCB.Text.Length, quote);
                    }
                    ModString += "[HANDS_MORPHTARGET]: " + Hands_MorphTargetCB.Text + "\n";
                    ModString += "[HANDS_MORPHTARGETVALUE]: " + Hands_MorphTargetVal.Text + "\n";
                    if (Hands_ConstraintProfileCB.Text != "null" && Hands_ConstraintProfileCB.Text.Contains(quote) == false)
                    {
                        Hands_ConstraintProfileCB.Text = Hands_ConstraintProfileCB.Text.Insert(0, quote);
                        Hands_ConstraintProfileCB.Text = Hands_ConstraintProfileCB.Text.Insert(Hands_ConstraintProfileCB.Text.Length, quote);
                    }
                    ModString += "[HANDS_CONSTRAINTPROFILE]: " + Hands_ConstraintProfileCB.Text + "\n";
                    ModString += "[HANDS_AROUSALBLEND]: " + Hands_ArousalBlend.Text + "\n";
                    ModString += "[HANDS_FLEXREGIONS]: " + Hands_FlexReg.Text + "\n";

                    if (Hands_FurmaskInclude.Checked == true)
                    {
                        ModString += "[HANDS_FURMASK_PATH]: " + Hands_Furmask_Path.Text + "\n";
                        AddToNameMap(Hands_Furmask_Path.Text);
                        ModString += "[HANDS_FURMASK_NAME]: " + Hands_Furmask_Name.Text + "\n";
                        AddToNameMap(Hands_Furmask_Name.Text);
                        ModString += "[HANDS_SEX_FURMASK_PATH]: " + Hands_SexFurmask_Path.Text + "\n";
                        AddToNameMap(Hands_SexFurmask_Path.Text);
                        ModString += "[HANDS_SEX_FURMASK_NAME]: " + Hands_SexFurmask_Name.Text + "\n";
                        AddToNameMap(Hands_SexFurmask_Name.Text);
                    }

                    ModString += "[LEGS_MESH_PATH]: " + Legs_Mesh_Path.Text + "\n";
                    AddToNameMap(Legs_Mesh_Path.Text);
                    ModString += "[LEGS_MESH_NAME]: " + Legs_Mesh_Name.Text + "\n";
                    AddToNameMap(Legs_Mesh_Name.Text);
                    ModString += "[LEGS_SEX_MESH_PATH]: " + Legs_SexMesh_Path.Text + "\n";
                    AddToNameMap(Legs_SexMesh_Path.Text);
                    ModString += "[LEGS_SEX_MESH_NAME]: " + Legs_SexMesh_Name.Text + "\n";
                    AddToNameMap(Legs_SexMesh_Name.Text);
                    ModString += "[LEGS_ICON_PATH]: " + Legs_Icon_Path.Text + "\n";
                    AddToNameMap(Legs_Icon_Path.Text);
                    ModString += "[LEGS_ICON_NAME]: " + Legs_Icon_Name.Text + "\n";
                    AddToNameMap(Legs_Icon_Name.Text);

                    ModString += "[LEGS_PHYSICSAREAS]: " + Legs_PhysAreas.Text + "\n";
                    if (Legs_MorphTargetCB.Text != "null" && Legs_MorphTargetCB.Text.Contains(quote) == false)
                    {
                        Legs_MorphTargetCB.Text = Legs_MorphTargetCB.Text.Insert(0, quote);
                        Legs_MorphTargetCB.Text = Legs_MorphTargetCB.Text.Insert(Legs_MorphTargetCB.Text.Length, quote);
                    }
                    ModString += "[LEGS_MORPHTARGET]: " + Legs_MorphTargetCB.Text + "\n";
                    ModString += "[LEGS_MORPHTARGETVALUE]: " + Legs_MorphTargetVal.Text + "\n";
                    if (Legs_ConstraintProfileCB.Text != "null" && Legs_ConstraintProfileCB.Text.Contains(quote) == false)
                    {
                        Legs_ConstraintProfileCB.Text = Legs_ConstraintProfileCB.Text.Insert(0, quote);
                        Legs_ConstraintProfileCB.Text = Legs_ConstraintProfileCB.Text.Insert(Legs_ConstraintProfileCB.Text.Length, quote);
                    }
                    ModString += "[LEGS_CONSTRAINTPROFILE]: " + Legs_ConstraintProfileCB.Text + "\n";
                    ModString += "[LEGS_AROUSALBLEND]: " + Legs_ArousalBlend.Text + "\n";
                    ModString += "[LEGS_FLEXREGIONS]: " + Legs_FlexReg.Text + "\n";

                    if (Legs_FurmaskInclude.Checked == true)
                    {
                        ModString += "[LEGS_FURMASK_PATH]: " + Legs_Furmask_Path.Text + "\n";
                        AddToNameMap(Legs_Furmask_Path.Text);
                        ModString += "[LEGS_FURMASK_NAME]: " + Legs_Furmask_Name.Text + "\n";
                        AddToNameMap(Legs_Furmask_Name.Text);
                        ModString += "[LEGS_SEX_FURMASK_PATH]: " + Legs_SexFurmask_Path.Text + "\n";
                        AddToNameMap(Legs_SexFurmask_Path.Text);
                        ModString += "[LEGS_SEX_FURMASK_NAME]: " + Legs_SexFurmask_Name.Text + "\n";
                        AddToNameMap(Legs_SexFurmask_Name.Text);
                    }

                    ModString += "[FEET_MESH_PATH]: " + Feet_Mesh_Path.Text + "\n";
                    AddToNameMap(Feet_Mesh_Path.Text);
                    ModString += "[FEET_MESH_NAME]: " + Feet_Mesh_Name.Text + "\n";
                    AddToNameMap(Feet_Mesh_Name.Text);
                    ModString += "[FEET_SEX_MESH_PATH]: " + Feet_SexMesh_Path.Text + "\n";
                    AddToNameMap(Feet_SexMesh_Path.Text);
                    ModString += "[FEET_SEX_MESH_NAME]: " + Feet_SexMesh_Name.Text + "\n";
                    AddToNameMap(Feet_SexMesh_Name.Text);
                    ModString += "[FEET_ICON_PATH]: " + Feet_Icon_Path.Text + "\n";
                    AddToNameMap(Feet_Icon_Path.Text);
                    ModString += "[FEET_ICON_NAME]: " + Feet_Icon_Name.Text + "\n";
                    AddToNameMap(Feet_Icon_Name.Text);

                    ModString += "[FEET_PHYSICSAREAS]: " + Feet_PhysAreas.Text + "\n";
                    if (Feet_MorphTargetCB.Text != "null" && Feet_MorphTargetCB.Text.Contains(quote) == false)
                    {
                        Feet_MorphTargetCB.Text = Feet_MorphTargetCB.Text.Insert(0, quote);
                        Feet_MorphTargetCB.Text = Feet_MorphTargetCB.Text.Insert(Feet_MorphTargetCB.Text.Length, quote);
                    }
                    ModString += "[FEET_MORPHTARGET]: " + Feet_MorphTargetCB.Text + "\n";
                    ModString += "[FEET_MORPHTARGETVALUE]: " + Feet_MorphTargetVal.Text + "\n";
                    if (Feet_ConstraintProfileCB.Text != "null" && Feet_ConstraintProfileCB.Text.Contains(quote) == false)
                    {
                        Feet_ConstraintProfileCB.Text = Feet_ConstraintProfileCB.Text.Insert(0, quote);
                        Feet_ConstraintProfileCB.Text = Feet_ConstraintProfileCB.Text.Insert(Feet_ConstraintProfileCB.Text.Length, quote);
                    }
                    ModString += "[FEET_CONSTRAINTPROFILE]: " + Feet_ConstraintProfileCB.Text + "\n";
                    ModString += "[FEET_AROUSALBLEND]: " + Feet_ArousalBlend.Text + "\n";
                    ModString += "[FEET_FLEXREGIONS]: " + Feet_FlexReg.Text;

                    if (Feet_FurmaskInclude.Checked == true)
                    {
                        ModString += "\n[FEET_FURMASK_PATH]: " + Feet_Furmask_Path.Text + "\n";
                        AddToNameMap(Feet_Furmask_Path.Text);
                        ModString += "[FEET_FURMASK_NAME]: " + Feet_Furmask_Name.Text + "\n";
                        AddToNameMap(Feet_Furmask_Name.Text);
                        ModString += "[FEET_SEX_FURMASK_PATH]: " + Feet_SexFurmask_Path.Text + "\n";
                        AddToNameMap(Feet_SexFurmask_Path.Text);
                        ModString += "[FEET_SEX_FURMASK_NAME]: " + Feet_SexFurmask_Name.Text;
                        AddToNameMap(Feet_SexFurmask_Name.Text);
                    }

                    string NameMapString = string.Empty;
                    foreach (string itm in NameMap)
                    {
                        NameMapString += itm + ",";
                    }
                    NameMapString = NameMapString.TrimEnd(',');
                    ModString = ModString.Replace("[NAMEMAPREPLACE]", NameMapString);

                    string SavePath = string.Empty;
                    if (CurrentlyEditing_Path == string.Empty)
                    {
                        SavePath = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod\" + ModName.Text + "_" + OutfitID.Text + ".txt";
                    }
                    else
                    {
                        if (File.Exists(CurrentlyEditing_Path))
                        {
                            SavePath = CurrentlyEditing_Path;
                        }
                        else
                        {
                            MessageBox.Show("The file you are editing could not be found.\nMod write was unsuccessful.", "Wild Life Mod Manager");
                            return;
                        }
                    }

                    File.WriteAllText(SavePath, ModString);
                    ModCreator_Form.AddToAutoModList(SavePath);
                }
                else if (Variant.Text == "Port")
                {
                    ModString += "Character: " + Character.Text + "\n";
                    ModString += "[CLOTHING_ID]: " + OutfitID.Text + "\n";

                    string SavePath = string.Empty;
                    if (CurrentlyEditing_Path == string.Empty)
                    {
                        SavePath = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod\" + ModName.Text + "_" + OutfitID.Text + ".txt";
                    }
                    else
                    {
                        if (File.Exists(CurrentlyEditing_Path))
                        {
                            SavePath = CurrentlyEditing_Path;
                        }
                        else
                        {
                            MessageBox.Show("The file you are editing could not be found.\nMod write was unsuccessful.", "Wild Life Mod Manager");
                            return;
                        }
                    }

                    File.WriteAllText(SavePath, ModString);
                    ModCreator_Form.AddToAutoModList(SavePath);
                }
                else if (Variant.Text == "Character Customization")
                {
                    ModString += "NameMap: [NAMEMAPREPLACE]" + "\n";
                    ModString += "Character: " + Character.Text + "\n";

                    foreach (int i in CharCust_Entries)
                    {
                        if (CharCust_Target[i].Text == "Hair")
                        {
                            ModString += CharCust_Target[i].Text + ": " + CharCust_Path[i].Text + "," + CharCust_Name[i].Text + "," + CharCust_Physics_Path[i].Text + "," + CharCust_Physics_Name[i].Text + "\n";
                            AddToNameMap(CharCust_Path[i].Text);
                            AddToNameMap(CharCust_Name[i].Text);
                            AddToNameMap(CharCust_Physics_Path[i].Text);
                            AddToNameMap(CharCust_Physics_Name[i].Text);
                        }
                        else
                        {
                            ModString += CharCust_Target[i].Text + ": " + CharCust_Path[i].Text + "," + CharCust_Name[i].Text + "\n";
                            AddToNameMap(CharCust_Path[i].Text);
                            AddToNameMap(CharCust_Name[i].Text);
                        }
                    }
                    ModString = ModString.TrimEnd('\n');

                    string NameMapString = string.Empty;
                    foreach (string itm in NameMap)
                    {
                        NameMapString += itm + ",";
                    }
                    NameMapString = NameMapString.TrimEnd(',');
                    ModString = ModString.Replace("[NAMEMAPREPLACE]", NameMapString);

                    string SavePath = string.Empty;
                    if (CurrentlyEditing_Path == string.Empty)
                    {
                        SavePath = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod\" + ModName.Text + "_" + Character.Text + ".txt";
                    }
                    else
                    {
                        if (File.Exists(CurrentlyEditing_Path))
                        {
                            SavePath = CurrentlyEditing_Path;
                        }
                        else
                        {
                            MessageBox.Show("The file you are editing could not be found.\nMod write was unsuccessful.", "Wild Life Mod Manager");
                            return;
                        }
                    }

                    File.WriteAllText(SavePath, ModString);
                    ModCreator_Form.AddToAutoModList(SavePath);
                }
                else if (Variant.Text == "Fur Customization")
                {
                    ModString += "Character: " + Character.Text + "\n";

                    ModString += "bShowHairMesh: " + Fur_ShowHairMesh.Checked.ToString().ToLower() + "\n";
                    ModString += "bShowBeardMesh: " + Fur_ShowBeardMesh.Checked.ToString().ToLower() + "\n";
                    ModString += "LayerCount: " + Fur_LayerCount.Text + "\n";
                    ModString += "LOD_LayerCount: " + Fur_LayerCount_LOD.Text + "\n";
                    ModString += "LOD_physicsEnabled: " + Fur_PhysicsEnabled_LOD.Checked.ToString().ToLower() + "\n";
                    ModString += "FurLength: " + Fur_FurLength.Text + "\n";
                    ModString += "MinFurLength: " + Fur_MinFurLength.Text + "\n";
                    ModString += "bPhysicsEnabled: " + Fur_PhysicsEnabled.Checked.ToString().ToLower() + "\n";
                    ModString += "ForceDistribution: " + Fur_ForceDistribution.Text + "\n";
                    ModString += "Stiffness: " + Fur_Stiffness.Text + "\n";
                    ModString += "Damping: " + Fur_Damping.Text + "\n";
                    ModString += "ConstForce_X: " + Fur_ConstForce_X.Text + "\n";
                    ModString += "ConstForce_Y: " + Fur_ConstForce_Y.Text + "\n";
                    ModString += "ConstForce_Z: " + Fur_ConstForce_Z.Text + "\n";
                    ModString += "MaxForce: " + Fur_MaxForce.Text + "\n";
                    ModString += "MaxForceTorqueFactor: " + Fur_MaxForceTorqueFactor.Text + "\n";
                    ModString += "ReferenceHairBias: " + Fur_RefHairBias.Text + "\n";
                    ModString += "HairLengthForceUniformity: " + Fur_HairLengthForceUniformity.Text + "\n";

                    string SavePath = string.Empty;
                    if (CurrentlyEditing_Path == string.Empty)
                    {
                        SavePath = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod\" + ModName.Text + "_" + Character.Text + ".txt";
                    }
                    else
                    {
                        if (File.Exists(CurrentlyEditing_Path))
                        {
                            SavePath = CurrentlyEditing_Path;
                        }
                        else
                        {
                            MessageBox.Show("The file you are editing could not be found.\nMod write was unsuccessful.", "Wild Life Mod Manager");
                            return;
                        }
                    }

                    File.WriteAllText(SavePath, ModString);
                    ModCreator_Form.AddToAutoModList(SavePath);
                }
                else if (Variant.Text == "Props")
                {
                    ModString += "NameMap: [NAMEMAPREPLACE]" + "\n";

                    foreach (string s in Props_LB.Items)
                    {
                        ModString += "Prop: " + s + "\n";
                        AddToNameMap(GetSlice(s, " | ", 0)); // ID
                        string MeshPath = GetSlice(s, " | ", 4);
                        AddToNameMap(GetSlice(MeshPath, "/", 999)); // Mesh Name
                        AddToNameMap(MeshPath); // Mesh Path
                        string SkelMeshPath = GetSlice(s, " | ", 5);
                        AddToNameMap(GetSlice(SkelMeshPath, "/", 999)); // SkelMesh Name
                        AddToNameMap(SkelMeshPath); // SkelMesh Path
                        string ActorPath = GetSlice(s, " | ", 5);
                        AddToNameMap(GetSlice(ActorPath, "/", 999)); // Actor Name
                        AddToNameMap(ActorPath); // Actor Path
                        string Blueprint = GetSlice(s, " | ", 13);
                        AddToNameMap(Blueprint); // Blueprint
                    }
                    ModString = ModString.TrimEnd('\n');

                    string NameMapString = string.Empty;
                    foreach (string itm in NameMap)
                    {
                        NameMapString += itm + ",";
                    }
                    NameMapString = NameMapString.TrimEnd(',');
                    ModString = ModString.Replace("[NAMEMAPREPLACE]", NameMapString);

                    string SavePath = string.Empty;
                    if (CurrentlyEditing_Path == string.Empty)
                    {
                        SavePath = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod\" + ModName.Text + "_Props.txt";
                    }
                    else
                    {
                        if (File.Exists(CurrentlyEditing_Path))
                        {
                            SavePath = CurrentlyEditing_Path;
                        }
                        else
                        {
                            MessageBox.Show("The file you are editing could not be found.\nMod write was unsuccessful.", "Wild Life Mod Manager");
                            return;
                        }
                    }

                    File.WriteAllText(SavePath, ModString);
                    ModCreator_Form.AddToAutoModList(SavePath);
                }
                MessageBox.Show("Mod file created!", "AutoMod");
            }
            catch (Exception)
            {
                MessageBox.Show("Error writing to file.", "AutoMod");
            }
        }

        private void AddToNameMap(string txt)
        {
            if (txt != "null" && txt != "None")
            {
                if (isDupe(txt) == false)
                {
                    NameMap.Add(txt);
                }
            }
        }

        private bool isDupe(string txt)
        {
            foreach (string itm in NameMap)
            {
                if (itm == txt) return true;
            }
            return false;
        }

        private void Variant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Variant.Text == "Add")
            {
                tabControl1.Visible = true;
                CharCustomBox.Visible = false;
                FurCustomizationGB.Visible = false;
                tabControl1.Enabled = true;
                OutfitName.Enabled = true;
                OutfitID.Enabled = true;
                Character.Items.Clear();
                Character.Items.AddRange(OutfitChars);
                Character.SelectedIndex = 0;
                PropsGB.Visible = false;
                Character.Enabled = true;
            }
            else if (Variant.Text == "Port")
            {
                tabControl1.Visible = true;
                CharCustomBox.Visible = false;
                FurCustomizationGB.Visible = false;
                tabControl1.Enabled = false;
                OutfitName.Enabled = false;
                OutfitID.Enabled = true;
                Character.Items.Clear();
                Character.Items.AddRange(OutfitChars);
                Character.SelectedIndex = 0;
                PropsGB.Visible = false;
                Character.Enabled = true;
            }
            else if (Variant.Text == "Character Customization")
            {
                tabControl1.Visible = false;
                FurCustomizationGB.Visible = false;
                Character.Items.Clear();
                Character.Items.AddRange(CustomizationChars);
                Character.SelectedIndex = 0;
                CharCustomBox.Visible = true;
                OutfitID.Enabled = false;
                OutfitName.Enabled = false;
                PropsGB.Visible = false;
                Character.Enabled = true;
            }
            else if (Variant.Text == "Fur Customization")
            {
                tabControl1.Visible = false;
                Character.Items.Clear();
                Character.Items.AddRange(FurChars);
                CharCustomBox.Visible = false;
                Character.SelectedIndex = 0;
                FurCustomizationGB.Visible = true;
                OutfitID.Enabled = false;
                OutfitName.Enabled = false;
                PropsGB.Visible = false;
                Character.Enabled = true;
            }
            else if (Variant.Text == "Props")
            {
                tabControl1.Visible = false;
                FurCustomizationGB.Visible = false;
                Character.Items.Clear();
                Character.Enabled = false;
                CharCustomBox.Visible = false;
                OutfitID.Enabled = false;
                OutfitName.Enabled = false;
                PropsGB.Visible = true;
            }
        }

        public void LoadAutoMod(string ModPath)
        {
            ToggleAllFurmasks(false);
            ResetFurmasks();

            CurrentlyEditing_Path = ModPath;
            CurrentlyEditing_LL.Text = ModPath;
            WriteMod.Text = "Edit Mod File";
            StopEditing_LL.Show();

            string[] contents;
            contents = File.ReadAllLines(ModPath);

            foreach (string line in contents)
            {
                string[] TempArray = line.Split(':');
                if (TempArray[0].Trim() == "ModName") { ModName.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "Author") { ModAuthor.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "Variant") { Variant.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "Character") { Character.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "NameMap") { }
                else if (TempArray[0].Trim() == "[CLOTHING_ID]") { OutfitID.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CLOTHING_NAME]") { OutfitName.Text = TempArray[1].Trim(); }

                else if (TempArray[0].Trim() == "[HEAD_MESH_PATH]") { Head_Mesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_MESH_NAME]") { Head_Mesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_SEX_MESH_PATH]") { Head_SexMesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_SEX_MESH_NAME]") { Head_SexMesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_ICON_PATH]") { Head_Icon_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_ICON_NAME]") { Head_Icon_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_PHYSICSAREAS]") { Head_PhysAreas.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_MORPHTARGET]") { Head_MorphTargetCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_MORPHTARGETVALUE]") { Head_MorphTargetVal.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_CONSTRAINTPROFILE]") { Head_ConstraintProfileCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_AROUSALBLEND]") { Head_ArousalBlend.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_FLEXREGIONS]") { Head_FlexReg.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HEAD_FURMASK_PATH]") { Head_Furmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[HEAD_FURMASK_NAME]") { Head_Furmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[HEAD_SEX_FURMASK_PATH]") { Head_SexFurmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[HEAD_SEX_FURMASK_NAME]") { Head_SexFurmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }

                else if (TempArray[0].Trim() == "[CHEST_MESH_PATH]") { Chest_Mesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_MESH_NAME]") { Chest_Mesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_SEX_MESH_PATH]") { Chest_SexMesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_SEX_MESH_NAME]") { Chest_SexMesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_ICON_PATH]") { Chest_Icon_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_ICON_NAME]") { Chest_Icon_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_PHYSICSAREAS]") { Chest_PhysAreas.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_MORPHTARGET]") { Chest_MorphTargetCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_MORPHTARGETVALUE]") { Chest_MorphTargetVal.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_CONSTRAINTPROFILE]") { Chest_ConstraintProfileCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_AROUSALBLEND]") { Chest_ArousalBlend.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_FLEXREGIONS]") { Chest_FlexReg.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[CHEST_FURMASK_PATH]") { Chest_Furmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[CHEST_FURMASK_NAME]") { Chest_Furmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[CHEST_SEX_FURMASK_PATH]") { Chest_SexFurmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[CHEST_SEX_FURMASK_NAME]") { Chest_SexFurmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }

                else if (TempArray[0].Trim() == "[HANDS_MESH_PATH]") { Hands_Mesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_MESH_NAME]") { Hands_Mesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_SEX_MESH_PATH]") { Hands_SexMesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_SEX_MESH_NAME]") { Hands_SexMesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_ICON_PATH]") { Hands_Icon_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_ICON_NAME]") { Hands_Icon_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_PHYSICSAREAS]") { Hands_PhysAreas.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_MORPHTARGET]") { Hands_MorphTargetCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_MORPHTARGETVALUE]") { Hands_MorphTargetVal.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_CONSTRAINTPROFILE]") { Hands_ConstraintProfileCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_AROUSALBLEND]") { Hands_ArousalBlend.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_FLEXREGIONS]") { Hands_FlexReg.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[HANDS_FURMASK_PATH]") { Hands_Furmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[HANDS_FURMASK_NAME]") { Hands_Furmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[HANDS_SEX_FURMASK_PATH]") { Hands_SexFurmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[HANDS_SEX_FURMASK_NAME]") { Hands_SexFurmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }

                else if (TempArray[0].Trim() == "[LEGS_MESH_PATH]") { Legs_Mesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_MESH_NAME]") { Legs_Mesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_SEX_MESH_PATH]") { Legs_SexMesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_SEX_MESH_NAME]") { Legs_SexMesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_ICON_PATH]") { Legs_Icon_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_ICON_NAME]") { Legs_Icon_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_PHYSICSAREAS]") { Legs_PhysAreas.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_MORPHTARGET]") { Legs_MorphTargetCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_MORPHTARGETVALUE]") { Legs_MorphTargetVal.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_CONSTRAINTPROFILE]") { Legs_ConstraintProfileCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_AROUSALBLEND]") { Legs_ArousalBlend.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_FLEXREGIONS]") { Legs_FlexReg.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[LEGS_FURMASK_PATH]") { Legs_Furmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[LEGS_FURMASK_NAME]") { Legs_Furmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[LEGS_SEX_FURMASK_PATH]") { Legs_SexFurmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[LEGS_SEX_FURMASK_NAME]") { Legs_SexFurmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }

                else if (TempArray[0].Trim() == "[FEET_MESH_PATH]") { Feet_Mesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_MESH_NAME]") { Feet_Mesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_SEX_MESH_PATH]") { Feet_SexMesh_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_SEX_MESH_NAME]") { Feet_SexMesh_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_ICON_PATH]") { Feet_Icon_Path.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_ICON_NAME]") { Feet_Icon_Name.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_PHYSICSAREAS]") { Feet_PhysAreas.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_MORPHTARGET]") { Feet_MorphTargetCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_MORPHTARGETVALUE]") { Feet_MorphTargetVal.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_CONSTRAINTPROFILE]") { Feet_ConstraintProfileCB.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_AROUSALBLEND]") { Feet_ArousalBlend.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_FLEXREGIONS]") { Feet_FlexReg.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "[FEET_FURMASK_PATH]") { Feet_Furmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[FEET_FURMASK_NAME]") { Feet_Furmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[FEET_SEX_FURMASK_PATH]") { Feet_SexFurmask_Path.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }
                else if (TempArray[0].Trim() == "[FEET_SEX_FURMASK_NAME]") { Feet_SexFurmask_Name.Text = TempArray[1].Trim(); ToggleAllFurmasks(true); }

                else if (TempArray[0].Trim() == "bShowHairMesh" && TempArray[1].Trim() == "true") { Fur_ShowHairMesh.Checked = true; }
                else if (TempArray[0].Trim() == "bShowHairMesh" && TempArray[1].Trim() == "false") { Fur_ShowHairMesh.Checked = false; }
                else if (TempArray[0].Trim() == "bShowBeardMesh" && TempArray[1].Trim() == "true") { Fur_ShowBeardMesh.Checked = true; }
                else if (TempArray[0].Trim() == "bShowBeardMesh" && TempArray[1].Trim() == "false") { Fur_ShowBeardMesh.Checked = false; }
                else if (TempArray[0].Trim() == "LayerCount") { Fur_LayerCount.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "LOD_LayerCount") { Fur_LayerCount_LOD.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "LOD_physicsEnabled" && TempArray[1].Trim() == "true") { Fur_PhysicsEnabled_LOD.Checked = true; }
                else if (TempArray[0].Trim() == "LOD_physicsEnabled" && TempArray[1].Trim() == "false") { Fur_PhysicsEnabled_LOD.Checked = false; }
                else if (TempArray[0].Trim() == "FurLength") { Fur_FurLength.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "MinFurLength") { Fur_MinFurLength.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "bPhysicsEnabled" && TempArray[1].Trim() == "true") { Fur_PhysicsEnabled.Checked = true; }
                else if (TempArray[0].Trim() == "bPhysicsEnabled" && TempArray[1].Trim() == "false") { Fur_PhysicsEnabled.Checked = false; }
                else if (TempArray[0].Trim() == "ForceDistribution") { Fur_ForceDistribution.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "Stiffness") { Fur_Stiffness.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "Damping") { Fur_Damping.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "ConstForce_X") { Fur_ConstForce_X.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "ConstForce_Y") { Fur_ConstForce_Y.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "ConstForce_Z") { Fur_ConstForce_Z.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "MaxForce") { Fur_MaxForce.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "MaxForceTorqueFactor") { Fur_MaxForceTorqueFactor.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "ReferenceHairBias") { Fur_RefHairBias.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "HairLengthForceUniformity") { Fur_HairLengthForceUniformity.Text = TempArray[1].Trim(); }
                else if (TempArray[0].Trim() == "Prop")
                { 
                    Props_LB.Items.Add(TempArray[1].Trim());
                }
                else
                {
                    string[] TempArray2 = TempArray[1].Trim().Split(',');
                    if (TempArray[0] == "Hair")
                    {
                        if (TempArray2.Length > 2)
                        {
                            CreateCustCharEntry(99, TempArray[0], TempArray2[0], TempArray2[1], TempArray2[2], TempArray2[3]);
                        }
                        else
                        {
                            CreateCustCharEntry(99, TempArray[0], TempArray2[0], TempArray2[1]);
                        }
                    }
                    else
                    {
                        CreateCustCharEntry(99, TempArray[0], TempArray2[0], TempArray2[1]);
                    }
                }
            }
        }

        private void LoadMod_Click(object sender, EventArgs e)
        {
            ToggleAllFurmasks(false);
            ResetFurmasks();
            openFileDialog1.InitialDirectory = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadAutoMod(openFileDialog1.FileName);
            }
        }

        private void CreateCustCharEntry(int Dupe = 99, string setTarget = "Hair", string setPath = "/Game/Textures/...", string setName = "None", string setPhysicsPath = "None", string setPhysicsName = "None")
        {
            int EntryID = CharCust_CurrentEntryID;

            CharCust_GB[EntryID] = new GroupBox();
            CharCust_GB[EntryID].Text = "Entry #" + EntryID.ToString();
            CharCust_GB[EntryID].Size = new System.Drawing.Size(495, 235);
            CharCust_GB[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_GB[EntryID].Font = new Font(CharCust_GB[EntryID].Font.FontFamily, 8);
            CharCust_GB[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);

            CharCust_TargetLabel[EntryID] = new Label();
            CharCust_TargetLabel[EntryID].Text = "Target:";
            CharCust_TargetLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_TargetLabel[EntryID].AutoSize = true;
            CharCust_TargetLabel[EntryID].Location = new System.Drawing.Point(6, 16);

            CharCust_PathLabel[EntryID] = new Label();
            CharCust_PathLabel[EntryID].Text = "Path:";
            CharCust_PathLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_PathLabel[EntryID].AutoSize = true;
            CharCust_PathLabel[EntryID].Location = new System.Drawing.Point(6, 58);

            CharCust_NameLabel[EntryID] = new Label();
            CharCust_NameLabel[EntryID].Text = "Name:";
            CharCust_NameLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_NameLabel[EntryID].AutoSize = true;
            CharCust_NameLabel[EntryID].Location = new System.Drawing.Point(6, 97);

            CharCust_Physics_PathLabel[EntryID] = new Label();
            CharCust_Physics_PathLabel[EntryID].Text = "Physics Path:";
            CharCust_Physics_PathLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Physics_PathLabel[EntryID].AutoSize = true;
            CharCust_Physics_PathLabel[EntryID].Location = new System.Drawing.Point(6, 146);

            CharCust_Physics_NameLabel[EntryID] = new Label();
            CharCust_Physics_NameLabel[EntryID].Text = "Physics Name:";
            CharCust_Physics_NameLabel[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Physics_NameLabel[EntryID].AutoSize = true;
            CharCust_Physics_NameLabel[EntryID].Location = new System.Drawing.Point(6, 185);

            CharCust_Target[EntryID] = new ComboBox();
            CharCust_Target[EntryID].Items.AddRange(new string[] { "Hair", "Beard", "Skin", "PubicHair", "Eyes", "EyeLiner", "EyeShadow", "Lipstick", "Tanlines" });
            CharCust_Target[EntryID].SelectedIndex = 0;
            CharCust_Target[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);
            CharCust_Target[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Target[EntryID].Size = new System.Drawing.Size(464, 21);
            CharCust_Target[EntryID].Location = new System.Drawing.Point(14, 32);
            CharCust_Target[EntryID].Text = setTarget.ToString();
            CharCust_Target[EntryID].Tag = EntryID;
            CharCust_Target[EntryID].SelectedValueChanged += CharCust_Target_SelectedValueChanged;

            CharCust_Path[EntryID] = new TextBox();
            CharCust_Path[EntryID].Text = "None";
            CharCust_Path[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);
            CharCust_Path[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Path[EntryID].Size = new System.Drawing.Size(464, 20);
            CharCust_Path[EntryID].Location = new System.Drawing.Point(14, 74);
            CharCust_Path[EntryID].Text = setPath.ToString();

            CharCust_Name[EntryID] = new TextBox();
            CharCust_Name[EntryID].Text = "None";
            CharCust_Name[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);
            CharCust_Name[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Name[EntryID].Size = new System.Drawing.Size(464, 20);
            CharCust_Name[EntryID].Location = new System.Drawing.Point(14, 113);
            CharCust_Name[EntryID].Text = setName.ToString();

            CharCust_Physics_Path[EntryID] = new TextBox();
            CharCust_Physics_Path[EntryID].Text = "None";
            CharCust_Physics_Path[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);
            CharCust_Physics_Path[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Physics_Path[EntryID].Size = new System.Drawing.Size(464, 20);
            CharCust_Physics_Path[EntryID].Location = new System.Drawing.Point(14, 162);
            CharCust_Physics_Path[EntryID].Text = setPhysicsPath.ToString();

            CharCust_Physics_Name[EntryID] = new TextBox();
            CharCust_Physics_Name[EntryID].Text = "None";
            CharCust_Physics_Name[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);
            CharCust_Physics_Name[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Physics_Name[EntryID].Size = new System.Drawing.Size(464, 20);
            CharCust_Physics_Name[EntryID].Location = new System.Drawing.Point(14, 201);
            CharCust_Physics_Name[EntryID].Text = setPhysicsName.ToString();

            CharCust_Dupe[EntryID] = new LinkLabel();
            CharCust_Dupe[EntryID].AutoSize = true;
            CharCust_Dupe[EntryID].Text = "Duplicate";
            CharCust_Dupe[EntryID].LinkColor = System.Drawing.SystemColors.MenuHighlight;
            CharCust_Dupe[EntryID].VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            CharCust_Dupe[EntryID].ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            CharCust_Dupe[EntryID].Location = new System.Drawing.Point(322, 0);
            CharCust_Dupe[EntryID].Tag = EntryID;
            CharCust_Dupe[EntryID].Click += CharCust_DupeClick;
            CharCust_Dupe[EntryID].Font = new Font(CharCust_Dupe[EntryID].Font.FontFamily, 10);

            CharCust_Remove[EntryID] = new LinkLabel();
            CharCust_Remove[EntryID].AutoSize = true;
            CharCust_Remove[EntryID].Text = "Remove";
            CharCust_Remove[EntryID].LinkColor = System.Drawing.Color.LightCoral;
            CharCust_Remove[EntryID].VisitedLinkColor = System.Drawing.Color.LightCoral;
            CharCust_Remove[EntryID].ActiveLinkColor = System.Drawing.Color.Red;
            CharCust_Remove[EntryID].Location = new System.Drawing.Point(407, 0);
            CharCust_Remove[EntryID].Tag = EntryID;
            CharCust_Remove[EntryID].Click += CharCust_RemoveClick;
            CharCust_Remove[EntryID].Font = new Font(CharCust_Remove[EntryID].Font.FontFamily, 10);

            CharCust_GB[EntryID].Controls.Add(CharCust_TargetLabel[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_PathLabel[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_NameLabel[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Physics_PathLabel[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Physics_NameLabel[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Target[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Path[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Name[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Physics_Path[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Physics_Name[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Dupe[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Remove[EntryID]);

            if (Dupe != 99)
            {
                CharCust_Target[EntryID].Text = CharCust_Target[Dupe].Text;
                CharCust_Path[EntryID].Text = CharCust_Path[Dupe].Text;
                CharCust_Name[EntryID].Text = CharCust_Name[Dupe].Text;
            }

            if (CharCust_Target[EntryID].Text == "Hair")
            {
                CharCust_GB[EntryID].Size = new System.Drawing.Size(495, 235);
            }
            else
            {
                CharCust_GB[EntryID].Size = new System.Drawing.Size(495, 145);
            }

            CharCustomFlow.Controls.Add(CharCust_GB[EntryID]);
            CharCust_Entries.Add(EntryID);
            CharCust_CurrentEntryID += 1;
        }

        private void CharCust_Target_SelectedValueChanged(object? sender, EventArgs e)
        {
            ComboBox Casted = sender as ComboBox;
            int EntryID = int.Parse(Casted.Tag.ToString());

            if (Casted.Text == "Hair")
            {
                CharCust_GB[EntryID].Size = new System.Drawing.Size(495, 235);
            }
            else
            {
                CharCust_GB[EntryID].Size = new System.Drawing.Size(495, 145);
            }
        }

        private void CharCust_RemoveClick(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            int EntryID = int.Parse(Casted.Tag.ToString());

            CharCust_TargetLabel[EntryID].Dispose();
            CharCust_PathLabel[EntryID].Dispose();
            CharCust_NameLabel[EntryID].Dispose();

            CharCust_Target[EntryID].Dispose();
            CharCust_Path[EntryID].Dispose();
            CharCust_Name[EntryID].Dispose();

            CharCust_Dupe[EntryID].Dispose();
            CharCust_Remove[EntryID].Dispose();

            CharCust_GB[EntryID].Dispose();
            CharCust_Entries.Remove(EntryID);

            if (CharCust_Entries.Count == 0)
            {
                CharCust_CurrentEntryID = 0;
            }
        }

        private void CharCust_Add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateCustCharEntry();
        }

        private void CharCust_DupeClick(object sender, EventArgs e)
        {
            LinkLabel Casted = sender as LinkLabel;
            CreateCustCharEntry(int.Parse(Casted.Tag.ToString()));
        }

        private void Head_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Head_ExtraPanel.Visible == false) { Head_ExtraPanel.Visible = true; }
            else { Head_ExtraPanel.Visible = false; }

            if (Head_LoadEntry_CB.Items.Count == 0)
            {
                ExtractAllEntries();
            }
        }

        private void Chest_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Chest_ExtraPanel.Visible == false) { Chest_ExtraPanel.Visible = true; }
            else { Chest_ExtraPanel.Visible = false; }

            if (Chest_LoadEntry_CB.Items.Count == 0)
            {
                ExtractAllEntries();
            }
        }

        private void Hands_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Hands_ExtraPanel.Visible == false) { Hands_ExtraPanel.Visible = true; }
            else { Hands_ExtraPanel.Visible = false; }

            if (Hands_LoadEntry_CB.Items.Count == 0)
            {
                ExtractAllEntries();
            }
        }

        private void Legs_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Legs_ExtraPanel.Visible == false) { Legs_ExtraPanel.Visible = true; }
            else { Legs_ExtraPanel.Visible = false; }

            if (Legs_LoadEntry_CB.Items.Count == 0)
            {
                ExtractAllEntries();
            }
        }

        private void Feet_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Feet_ExtraPanel.Visible == false) { Feet_ExtraPanel.Visible = true; }
            else { Feet_ExtraPanel.Visible = false; }

            if (Feet_LoadEntry_CB.Items.Count == 0)
            {
                ExtractAllEntries();
            }
        }

        private void Head_Dupe_Click(object sender, EventArgs e)
        {
            if (Head_DupeTo.Text == "All" || Head_DupeTo.Text == "Chest")
            {
                Chest_Mesh_Path.Text = Head_Mesh_Path.Text;
                Chest_Mesh_Name.Text = Head_Mesh_Name.Text;
                Chest_SexMesh_Path.Text = Head_SexMesh_Path.Text;
                Chest_SexMesh_Name.Text = Head_SexMesh_Name.Text;
                Chest_Icon_Path.Text = Head_Icon_Path.Text;
                Chest_Icon_Name.Text = Head_Icon_Name.Text;
                Chest_Furmask_Path.Text = Head_Furmask_Path.Text;
                Chest_Furmask_Name.Text = Head_Furmask_Name.Text;
                Chest_SexFurmask_Path.Text = Head_SexFurmask_Path.Text;
                Chest_SexFurmask_Name.Text = Head_SexFurmask_Name.Text;
                Chest_PhysAreas.Text = Head_PhysAreas.Text;
                Chest_MorphTargetCB.Text = Head_MorphTargetCB.Text;
                Chest_ConstraintProfileCB.Text = Head_ConstraintProfileCB.Text;
                Chest_MorphTargetVal.Text = Head_MorphTargetVal.Text;
                Chest_ArousalBlend.Text = Head_ArousalBlend.Text;
                Chest_FlexReg.Text = Head_FlexReg.Text;
            }
            if (Head_DupeTo.Text == "All" || Head_DupeTo.Text == "Hands")
            {
                Hands_Mesh_Path.Text = Head_Mesh_Path.Text;
                Hands_Mesh_Name.Text = Head_Mesh_Name.Text;
                Hands_SexMesh_Path.Text = Head_SexMesh_Path.Text;
                Hands_SexMesh_Name.Text = Head_SexMesh_Name.Text;
                Hands_Icon_Path.Text = Head_Icon_Path.Text;
                Hands_Icon_Name.Text = Head_Icon_Name.Text;
                Hands_Furmask_Path.Text = Head_Furmask_Path.Text;
                Hands_Furmask_Name.Text = Head_Furmask_Name.Text;
                Hands_SexFurmask_Path.Text = Head_SexFurmask_Path.Text;
                Hands_SexFurmask_Name.Text = Head_SexFurmask_Name.Text;
                Hands_PhysAreas.Text = Head_PhysAreas.Text;
                Hands_MorphTargetCB.Text = Head_MorphTargetCB.Text;
                Hands_ConstraintProfileCB.Text = Head_ConstraintProfileCB.Text;
                Hands_MorphTargetVal.Text = Head_MorphTargetVal.Text;
                Hands_ArousalBlend.Text = Head_ArousalBlend.Text;
                Hands_FlexReg.Text = Head_FlexReg.Text;
            }
            if (Head_DupeTo.Text == "All" || Head_DupeTo.Text == "Legs")
            {
                Legs_Mesh_Path.Text = Head_Mesh_Path.Text;
                Legs_Mesh_Name.Text = Head_Mesh_Name.Text;
                Legs_SexMesh_Path.Text = Head_SexMesh_Path.Text;
                Legs_SexMesh_Name.Text = Head_SexMesh_Name.Text;
                Legs_Icon_Path.Text = Head_Icon_Path.Text;
                Legs_Icon_Name.Text = Head_Icon_Name.Text;
                Legs_Furmask_Path.Text = Head_Furmask_Path.Text;
                Legs_Furmask_Name.Text = Head_Furmask_Name.Text;
                Legs_SexFurmask_Path.Text = Head_SexFurmask_Path.Text;
                Legs_SexFurmask_Name.Text = Head_SexFurmask_Name.Text;
                Legs_PhysAreas.Text = Head_PhysAreas.Text;
                Legs_MorphTargetCB.Text = Head_MorphTargetCB.Text;
                Legs_ConstraintProfileCB.Text = Head_ConstraintProfileCB.Text;
                Legs_MorphTargetVal.Text = Head_MorphTargetVal.Text;
                Legs_ArousalBlend.Text = Head_ArousalBlend.Text;
                Legs_FlexReg.Text = Head_FlexReg.Text;
            }
            if (Head_DupeTo.Text == "All" || Head_DupeTo.Text == "Feet")
            {
                Feet_Mesh_Path.Text = Head_Mesh_Path.Text;
                Feet_Mesh_Name.Text = Head_Mesh_Name.Text;
                Feet_SexMesh_Path.Text = Head_SexMesh_Path.Text;
                Feet_SexMesh_Name.Text = Head_SexMesh_Name.Text;
                Feet_Icon_Path.Text = Head_Icon_Path.Text;
                Feet_Icon_Name.Text = Head_Icon_Name.Text;
                Feet_Furmask_Path.Text = Head_Furmask_Path.Text;
                Feet_Furmask_Name.Text = Head_Furmask_Name.Text;
                Feet_SexFurmask_Path.Text = Head_SexFurmask_Path.Text;
                Feet_SexFurmask_Name.Text = Head_SexFurmask_Name.Text;
                Feet_PhysAreas.Text = Head_PhysAreas.Text;
                Feet_MorphTargetCB.Text = Head_MorphTargetCB.Text;
                Feet_ConstraintProfileCB.Text = Head_ConstraintProfileCB.Text;
                Feet_MorphTargetVal.Text = Head_MorphTargetVal.Text;
                Feet_ArousalBlend.Text = Head_ArousalBlend.Text;
                Feet_FlexReg.Text = Head_FlexReg.Text;
            }
            Head_DupeTo.Text = "Done";
        }

        private void Chest_Dupe_Click(object sender, EventArgs e)
        {
            if (Head_DupeTo.Text == "All" || Chest_DupeTo.Text == "Head")
            {
                Head_Mesh_Path.Text = Chest_Mesh_Path.Text;
                Head_Mesh_Name.Text = Chest_Mesh_Name.Text;
                Head_SexMesh_Path.Text = Chest_SexMesh_Path.Text;
                Head_SexMesh_Name.Text = Chest_SexMesh_Name.Text;
                Head_Icon_Path.Text = Chest_Icon_Path.Text;
                Head_Icon_Name.Text = Chest_Icon_Name.Text;
                Head_Furmask_Path.Text = Chest_Furmask_Path.Text;
                Head_Furmask_Name.Text = Chest_Furmask_Name.Text;
                Head_SexFurmask_Path.Text = Chest_SexFurmask_Path.Text;
                Head_SexFurmask_Name.Text = Chest_SexFurmask_Name.Text;
                Head_PhysAreas.Text = Chest_PhysAreas.Text;
                Head_MorphTargetCB.Text = Chest_MorphTargetCB.Text;
                Head_ConstraintProfileCB.Text = Chest_ConstraintProfileCB.Text;
                Head_MorphTargetVal.Text = Chest_MorphTargetVal.Text;
                Head_ArousalBlend.Text = Chest_ArousalBlend.Text;
                Head_FlexReg.Text = Chest_FlexReg.Text;
            }
            if (Chest_DupeTo.Text == "All" || Chest_DupeTo.Text == "Hands")
            {
                Hands_Mesh_Path.Text = Chest_Mesh_Path.Text;
                Hands_Mesh_Name.Text = Chest_Mesh_Name.Text;
                Hands_SexMesh_Path.Text = Chest_SexMesh_Path.Text;
                Hands_SexMesh_Name.Text = Chest_SexMesh_Name.Text;
                Hands_Icon_Path.Text = Chest_Icon_Path.Text;
                Hands_Icon_Name.Text = Chest_Icon_Name.Text;
                Hands_Furmask_Path.Text = Chest_Furmask_Path.Text;
                Hands_Furmask_Name.Text = Chest_Furmask_Name.Text;
                Hands_SexFurmask_Path.Text = Chest_SexFurmask_Path.Text;
                Hands_SexFurmask_Name.Text = Chest_SexFurmask_Name.Text;
                Hands_PhysAreas.Text = Chest_PhysAreas.Text;
                Hands_MorphTargetCB.Text = Chest_MorphTargetCB.Text;
                Hands_ConstraintProfileCB.Text = Chest_ConstraintProfileCB.Text;
                Hands_MorphTargetVal.Text = Chest_MorphTargetVal.Text;
                Hands_ArousalBlend.Text = Chest_ArousalBlend.Text;
                Hands_FlexReg.Text = Chest_FlexReg.Text;
            }
            if (Chest_DupeTo.Text == "All" || Chest_DupeTo.Text == "Legs")
            {
                Legs_Mesh_Path.Text = Chest_Mesh_Path.Text;
                Legs_Mesh_Name.Text = Chest_Mesh_Name.Text;
                Legs_SexMesh_Path.Text = Chest_SexMesh_Path.Text;
                Legs_SexMesh_Name.Text = Chest_SexMesh_Name.Text;
                Legs_Icon_Path.Text = Chest_Icon_Path.Text;
                Legs_Icon_Name.Text = Chest_Icon_Name.Text;
                Legs_Furmask_Path.Text = Chest_Furmask_Path.Text;
                Legs_Furmask_Name.Text = Chest_Furmask_Name.Text;
                Legs_SexFurmask_Path.Text = Chest_SexFurmask_Path.Text;
                Legs_SexFurmask_Name.Text = Chest_SexFurmask_Name.Text;
                Legs_PhysAreas.Text = Chest_PhysAreas.Text;
                Legs_MorphTargetCB.Text = Chest_MorphTargetCB.Text;
                Legs_ConstraintProfileCB.Text = Chest_ConstraintProfileCB.Text;
                Legs_MorphTargetVal.Text = Chest_MorphTargetVal.Text;
                Legs_ArousalBlend.Text = Chest_ArousalBlend.Text;
                Legs_FlexReg.Text = Chest_FlexReg.Text;
            }
            if (Chest_DupeTo.Text == "All" || Chest_DupeTo.Text == "Feet")
            {
                Feet_Mesh_Path.Text = Chest_Mesh_Path.Text;
                Feet_Mesh_Name.Text = Chest_Mesh_Name.Text;
                Feet_SexMesh_Path.Text = Chest_SexMesh_Path.Text;
                Feet_SexMesh_Name.Text = Chest_SexMesh_Name.Text;
                Feet_Icon_Path.Text = Chest_Icon_Path.Text;
                Feet_Icon_Name.Text = Chest_Icon_Name.Text;
                Feet_Furmask_Path.Text = Chest_Furmask_Path.Text;
                Feet_Furmask_Name.Text = Chest_Furmask_Name.Text;
                Feet_SexFurmask_Path.Text = Chest_SexFurmask_Path.Text;
                Feet_SexFurmask_Name.Text = Chest_SexFurmask_Name.Text;
                Feet_PhysAreas.Text = Chest_PhysAreas.Text;
                Feet_MorphTargetCB.Text = Chest_MorphTargetCB.Text;
                Feet_ConstraintProfileCB.Text = Chest_ConstraintProfileCB.Text;
                Feet_MorphTargetVal.Text = Chest_MorphTargetVal.Text;
                Feet_ArousalBlend.Text = Chest_ArousalBlend.Text;
                Feet_FlexReg.Text = Chest_FlexReg.Text;
            }
            Chest_DupeTo.Text = "Done";
        }

        private void Hands_Dupe_Click(object sender, EventArgs e)
        {
            if (Hands_DupeTo.Text == "All" || Hands_DupeTo.Text == "Chest")
            {
                Chest_Mesh_Path.Text = Hands_Mesh_Path.Text;
                Chest_Mesh_Name.Text = Hands_Mesh_Name.Text;
                Chest_SexMesh_Path.Text = Hands_SexMesh_Path.Text;
                Chest_SexMesh_Name.Text = Hands_SexMesh_Name.Text;
                Chest_Icon_Path.Text = Hands_Icon_Path.Text;
                Chest_Icon_Name.Text = Hands_Icon_Name.Text;
                Chest_Furmask_Path.Text = Hands_Furmask_Path.Text;
                Chest_Furmask_Name.Text = Hands_Furmask_Name.Text;
                Chest_SexFurmask_Path.Text = Hands_SexFurmask_Path.Text;
                Chest_SexFurmask_Name.Text = Hands_SexFurmask_Name.Text;
                Chest_PhysAreas.Text = Hands_PhysAreas.Text;
                Chest_MorphTargetCB.Text = Hands_MorphTargetCB.Text;
                Chest_ConstraintProfileCB.Text = Hands_ConstraintProfileCB.Text;
                Chest_MorphTargetVal.Text = Hands_MorphTargetVal.Text;
                Chest_ArousalBlend.Text = Hands_ArousalBlend.Text;
                Chest_FlexReg.Text = Hands_FlexReg.Text;
            }
            if (Head_DupeTo.Text == "All" || Hands_DupeTo.Text == "Hands")
            {
                Head_Mesh_Path.Text = Hands_Mesh_Path.Text;
                Head_Mesh_Name.Text = Hands_Mesh_Name.Text;
                Head_SexMesh_Path.Text = Hands_SexMesh_Path.Text;
                Head_SexMesh_Name.Text = Hands_SexMesh_Name.Text;
                Head_Icon_Path.Text = Hands_Icon_Path.Text;
                Head_Icon_Name.Text = Hands_Icon_Name.Text;
                Head_Furmask_Path.Text = Hands_Furmask_Path.Text;
                Head_Furmask_Name.Text = Hands_Furmask_Name.Text;
                Head_SexFurmask_Path.Text = Hands_SexFurmask_Path.Text;
                Head_SexFurmask_Name.Text = Hands_SexFurmask_Name.Text;
                Head_PhysAreas.Text = Hands_PhysAreas.Text;
                Head_MorphTargetCB.Text = Hands_MorphTargetCB.Text;
                Head_ConstraintProfileCB.Text = Hands_ConstraintProfileCB.Text;
                Head_MorphTargetVal.Text = Hands_MorphTargetVal.Text;
                Head_ArousalBlend.Text = Hands_ArousalBlend.Text;
                Head_FlexReg.Text = Hands_FlexReg.Text;
            }
            if (Hands_DupeTo.Text == "All" || Hands_DupeTo.Text == "Legs")
            {
                Legs_Mesh_Path.Text = Hands_Mesh_Path.Text;
                Legs_Mesh_Name.Text = Hands_Mesh_Name.Text;
                Legs_SexMesh_Path.Text = Hands_SexMesh_Path.Text;
                Legs_SexMesh_Name.Text = Hands_SexMesh_Name.Text;
                Legs_Icon_Path.Text = Hands_Icon_Path.Text;
                Legs_Icon_Name.Text = Hands_Icon_Name.Text;
                Legs_Furmask_Path.Text = Hands_Furmask_Path.Text;
                Legs_Furmask_Name.Text = Hands_Furmask_Name.Text;
                Legs_SexFurmask_Path.Text = Hands_SexFurmask_Path.Text;
                Legs_SexFurmask_Name.Text = Hands_SexFurmask_Name.Text;
                Legs_PhysAreas.Text = Hands_PhysAreas.Text;
                Legs_MorphTargetCB.Text = Hands_MorphTargetCB.Text;
                Legs_ConstraintProfileCB.Text = Hands_ConstraintProfileCB.Text;
                Legs_MorphTargetVal.Text = Hands_MorphTargetVal.Text;
                Legs_ArousalBlend.Text = Hands_ArousalBlend.Text;
                Legs_FlexReg.Text = Hands_FlexReg.Text;
            }
            if (Hands_DupeTo.Text == "All" || Hands_DupeTo.Text == "Feet")
            {
                Feet_Mesh_Path.Text = Hands_Mesh_Path.Text;
                Feet_Mesh_Name.Text = Hands_Mesh_Name.Text;
                Feet_SexMesh_Path.Text = Hands_SexMesh_Path.Text;
                Feet_SexMesh_Name.Text = Hands_SexMesh_Name.Text;
                Feet_Icon_Path.Text = Hands_Icon_Path.Text;
                Feet_Icon_Name.Text = Hands_Icon_Name.Text;
                Feet_Furmask_Path.Text = Hands_Furmask_Path.Text;
                Feet_Furmask_Name.Text = Hands_Furmask_Name.Text;
                Feet_SexFurmask_Path.Text = Hands_SexFurmask_Path.Text;
                Feet_SexFurmask_Name.Text = Hands_SexFurmask_Name.Text;
                Feet_PhysAreas.Text = Hands_PhysAreas.Text;
                Feet_MorphTargetCB.Text = Hands_MorphTargetCB.Text;
                Feet_ConstraintProfileCB.Text = Hands_ConstraintProfileCB.Text;
                Feet_MorphTargetVal.Text = Hands_MorphTargetVal.Text;
                Feet_ArousalBlend.Text = Hands_ArousalBlend.Text;
                Feet_FlexReg.Text = Hands_FlexReg.Text;
            }
            Hands_DupeTo.Text = "Done";
        }

        private void Legs_Dupe_Click(object sender, EventArgs e)
        {
            if (Legs_DupeTo.Text == "All" || Legs_DupeTo.Text == "Chest")
            {
                Chest_Mesh_Path.Text = Legs_Mesh_Path.Text;
                Chest_Mesh_Name.Text = Legs_Mesh_Name.Text;
                Chest_SexMesh_Path.Text = Legs_SexMesh_Path.Text;
                Chest_SexMesh_Name.Text = Legs_SexMesh_Name.Text;
                Chest_Icon_Path.Text = Legs_Icon_Path.Text;
                Chest_Icon_Name.Text = Legs_Icon_Name.Text;
                Chest_Furmask_Path.Text = Legs_Furmask_Path.Text;
                Chest_Furmask_Name.Text = Legs_Furmask_Name.Text;
                Chest_SexFurmask_Path.Text = Legs_SexFurmask_Path.Text;
                Chest_SexFurmask_Name.Text = Legs_SexFurmask_Name.Text;
                Chest_PhysAreas.Text = Legs_PhysAreas.Text;
                Chest_MorphTargetCB.Text = Legs_MorphTargetCB.Text;
                Chest_ConstraintProfileCB.Text = Legs_ConstraintProfileCB.Text;
                Chest_MorphTargetVal.Text = Legs_MorphTargetVal.Text;
                Chest_ArousalBlend.Text = Legs_ArousalBlend.Text;
                Chest_FlexReg.Text = Legs_FlexReg.Text;
            }
            if (Legs_DupeTo.Text == "All" || Legs_DupeTo.Text == "Hands")
            {
                Hands_Mesh_Path.Text = Legs_Mesh_Path.Text;
                Hands_Mesh_Name.Text = Legs_Mesh_Name.Text;
                Hands_SexMesh_Path.Text = Legs_SexMesh_Path.Text;
                Hands_SexMesh_Name.Text = Legs_SexMesh_Name.Text;
                Hands_Icon_Path.Text = Legs_Icon_Path.Text;
                Hands_Icon_Name.Text = Legs_Icon_Name.Text;
                Hands_Furmask_Path.Text = Legs_Furmask_Path.Text;
                Hands_Furmask_Name.Text = Legs_Furmask_Name.Text;
                Hands_SexFurmask_Path.Text = Legs_SexFurmask_Path.Text;
                Hands_SexFurmask_Name.Text = Legs_SexFurmask_Name.Text;
                Hands_PhysAreas.Text = Legs_PhysAreas.Text;
                Hands_MorphTargetCB.Text = Legs_MorphTargetCB.Text;
                Hands_ConstraintProfileCB.Text = Legs_ConstraintProfileCB.Text;
                Hands_MorphTargetVal.Text = Legs_MorphTargetVal.Text;
                Hands_ArousalBlend.Text = Legs_ArousalBlend.Text;
                Hands_FlexReg.Text = Legs_FlexReg.Text;
            }
            if (Head_DupeTo.Text == "All" || Legs_DupeTo.Text == "Legs")
            {
                Head_Mesh_Path.Text = Legs_Mesh_Path.Text;
                Head_Mesh_Name.Text = Legs_Mesh_Name.Text;
                Head_SexMesh_Path.Text = Legs_SexMesh_Path.Text;
                Head_SexMesh_Name.Text = Legs_SexMesh_Name.Text;
                Head_Icon_Path.Text = Legs_Icon_Path.Text;
                Head_Icon_Name.Text = Legs_Icon_Name.Text;
                Head_Furmask_Path.Text = Legs_Furmask_Path.Text;
                Head_Furmask_Name.Text = Legs_Furmask_Name.Text;
                Head_SexFurmask_Path.Text = Legs_SexFurmask_Path.Text;
                Head_SexFurmask_Name.Text = Legs_SexFurmask_Name.Text;
                Head_PhysAreas.Text = Legs_PhysAreas.Text;
                Head_MorphTargetCB.Text = Legs_MorphTargetCB.Text;
                Head_ConstraintProfileCB.Text = Legs_ConstraintProfileCB.Text;
                Head_MorphTargetVal.Text = Legs_MorphTargetVal.Text;
                Head_ArousalBlend.Text = Legs_ArousalBlend.Text;
                Head_FlexReg.Text = Legs_FlexReg.Text;
            }
            if (Legs_DupeTo.Text == "All" || Legs_DupeTo.Text == "Feet")
            {
                Feet_Mesh_Path.Text = Legs_Mesh_Path.Text;
                Feet_Mesh_Name.Text = Legs_Mesh_Name.Text;
                Feet_SexMesh_Path.Text = Legs_SexMesh_Path.Text;
                Feet_SexMesh_Name.Text = Legs_SexMesh_Name.Text;
                Feet_Icon_Path.Text = Legs_Icon_Path.Text;
                Feet_Icon_Name.Text = Legs_Icon_Name.Text;
                Feet_Furmask_Path.Text = Legs_Furmask_Path.Text;
                Feet_Furmask_Name.Text = Legs_Furmask_Name.Text;
                Feet_SexFurmask_Path.Text = Legs_SexFurmask_Path.Text;
                Feet_SexFurmask_Name.Text = Legs_SexFurmask_Name.Text;
                Feet_PhysAreas.Text = Legs_PhysAreas.Text;
                Feet_MorphTargetCB.Text = Legs_MorphTargetCB.Text;
                Feet_ConstraintProfileCB.Text = Legs_ConstraintProfileCB.Text;
                Feet_MorphTargetVal.Text = Legs_MorphTargetVal.Text;
                Feet_ArousalBlend.Text = Legs_ArousalBlend.Text;
                Feet_FlexReg.Text = Legs_FlexReg.Text;
            }
            Legs_DupeTo.Text = "Done";
        }

        private void Feet_Dupe_Click(object sender, EventArgs e)
        {
            if (Feet_DupeTo.Text == "All" || Feet_DupeTo.Text == "Chest")
            {
                Chest_Mesh_Path.Text = Feet_Mesh_Path.Text;
                Chest_Mesh_Name.Text = Feet_Mesh_Name.Text;
                Chest_SexMesh_Path.Text = Feet_SexMesh_Path.Text;
                Chest_SexMesh_Name.Text = Feet_SexMesh_Name.Text;
                Chest_Icon_Path.Text = Feet_Icon_Path.Text;
                Chest_Icon_Name.Text = Feet_Icon_Name.Text;
                Chest_Furmask_Path.Text = Feet_Furmask_Path.Text;
                Chest_Furmask_Name.Text = Feet_Furmask_Name.Text;
                Chest_SexFurmask_Path.Text = Feet_SexFurmask_Path.Text;
                Chest_SexFurmask_Name.Text = Feet_SexFurmask_Name.Text;
                Chest_PhysAreas.Text = Feet_PhysAreas.Text;
                Chest_MorphTargetCB.Text = Feet_MorphTargetCB.Text;
                Chest_ConstraintProfileCB.Text = Feet_ConstraintProfileCB.Text;
                Chest_MorphTargetVal.Text = Feet_MorphTargetVal.Text;
                Chest_ArousalBlend.Text = Feet_ArousalBlend.Text;
                Chest_FlexReg.Text = Feet_FlexReg.Text;
            }
            if (Feet_DupeTo.Text == "All" || Feet_DupeTo.Text == "Hands")
            {
                Hands_Mesh_Path.Text = Feet_Mesh_Path.Text;
                Hands_Mesh_Name.Text = Feet_Mesh_Name.Text;
                Hands_SexMesh_Path.Text = Feet_SexMesh_Path.Text;
                Hands_SexMesh_Name.Text = Feet_SexMesh_Name.Text;
                Hands_Icon_Path.Text = Feet_Icon_Path.Text;
                Hands_Icon_Name.Text = Feet_Icon_Name.Text;
                Hands_Furmask_Path.Text = Feet_Furmask_Path.Text;
                Hands_Furmask_Name.Text = Feet_Furmask_Name.Text;
                Hands_SexFurmask_Path.Text = Feet_SexFurmask_Path.Text;
                Hands_SexFurmask_Name.Text = Feet_SexFurmask_Name.Text;
                Hands_PhysAreas.Text = Feet_PhysAreas.Text;
                Hands_MorphTargetCB.Text = Feet_MorphTargetCB.Text;
                Hands_ConstraintProfileCB.Text = Feet_ConstraintProfileCB.Text;
                Hands_MorphTargetVal.Text = Feet_MorphTargetVal.Text;
                Hands_ArousalBlend.Text = Feet_ArousalBlend.Text;
                Hands_FlexReg.Text = Feet_FlexReg.Text;
            }
            if (Feet_DupeTo.Text == "All" || Feet_DupeTo.Text == "Legs")
            {
                Legs_Mesh_Path.Text = Feet_Mesh_Path.Text;
                Legs_Mesh_Name.Text = Feet_Mesh_Name.Text;
                Legs_SexMesh_Path.Text = Feet_SexMesh_Path.Text;
                Legs_SexMesh_Name.Text = Feet_SexMesh_Name.Text;
                Legs_Icon_Path.Text = Feet_Icon_Path.Text;
                Legs_Icon_Name.Text = Feet_Icon_Name.Text;
                Legs_Furmask_Path.Text = Feet_Furmask_Path.Text;
                Legs_Furmask_Name.Text = Feet_Furmask_Name.Text;
                Legs_SexFurmask_Path.Text = Feet_SexFurmask_Path.Text;
                Legs_SexFurmask_Name.Text = Feet_SexFurmask_Name.Text;
                Legs_PhysAreas.Text = Feet_PhysAreas.Text;
                Legs_MorphTargetCB.Text = Feet_MorphTargetCB.Text;
                Legs_ConstraintProfileCB.Text = Feet_ConstraintProfileCB.Text;
                Legs_MorphTargetVal.Text = Feet_MorphTargetVal.Text;
                Legs_ArousalBlend.Text = Feet_ArousalBlend.Text;
                Legs_FlexReg.Text = Feet_FlexReg.Text;
            }
            if (Head_DupeTo.Text == "All" || Feet_DupeTo.Text == "Feet")
            {
                Head_Mesh_Path.Text = Feet_Mesh_Path.Text;
                Head_Mesh_Name.Text = Feet_Mesh_Name.Text;
                Head_SexMesh_Path.Text = Feet_SexMesh_Path.Text;
                Head_SexMesh_Name.Text = Feet_SexMesh_Name.Text;
                Head_Icon_Path.Text = Feet_Icon_Path.Text;
                Head_Icon_Name.Text = Feet_Icon_Name.Text;
                Head_Furmask_Path.Text = Feet_Furmask_Path.Text;
                Head_Furmask_Name.Text = Feet_Furmask_Name.Text;
                Head_SexFurmask_Path.Text = Feet_SexFurmask_Path.Text;
                Head_SexFurmask_Name.Text = Feet_SexFurmask_Name.Text;
                Head_PhysAreas.Text = Feet_PhysAreas.Text;
                Head_MorphTargetCB.Text = Feet_MorphTargetCB.Text;
                Head_ConstraintProfileCB.Text = Feet_ConstraintProfileCB.Text;
                Head_MorphTargetVal.Text = Feet_MorphTargetVal.Text;
                Head_ArousalBlend.Text = Feet_ArousalBlend.Text;
                Head_FlexReg.Text = Feet_FlexReg.Text;
            }
            Feet_DupeTo.Text = "Done";
        }

        private string GetCleanValue(string line)
        {
            string[] TempArray = line.Split(':');
            string CleanValue = TempArray[1].Trim();
            CleanValue = CleanValue.Replace(",", "");
            CleanValue = CleanValue.Replace("\"", "");
            CleanValue = CleanValue.Replace("+", "");
            return CleanValue;
        }

        private void Fur_LoadDefaultValues_Click(object sender, EventArgs e)
        {
            string State = "";
            StringBuilder stringBuilder = new StringBuilder();

            var logFile = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_GFur_Default.json");
            var logList = new List<string>(logFile);
            string PreviousLine = "";

            foreach (string line in logList)
            {
                if (State == "")
                {
                    if (line.Contains("\"Name\": \"" + Character.Text + "\","))
                    {
                        State = "FindShowHairMesh";
                    }
                }
                else if (State == "FindShowHairMesh")
                {
                    if (line.Contains("\"Name\": \"bShowHairMesh\","))
                    {
                        State = "FoundShowHairMesh";
                    }
                }
                else if (State == "FoundShowHairMesh")
                {
                    if (line.Contains("\"Value\": true"))
                    {
                        Fur_ShowHairMesh.Checked = true;
                        State = "FindShowBeardMesh";
                    }
                    else if (line.Contains("\"Value\": false"))
                    {
                        Fur_ShowHairMesh.Checked = false;
                        State = "FindShowBeardMesh";
                    }
                }
                else if (State == "FindShowBeardMesh")
                {
                    if (line.Contains("\"Name\": \"bShowBeardMesh\","))
                    {
                        State = "FoundShowBeardMesh";
                    }
                }
                else if (State == "FoundShowBeardMesh")
                {
                    if (line.Contains("\"Value\": true"))
                    {
                        Fur_ShowBeardMesh.Checked = true;
                        State = "FindShowBeardMesh";
                    }
                    else if (line.Contains("\"Value\": false"))
                    {
                        Fur_ShowBeardMesh.Checked = false;
                        State = "FindLayerCount";
                    }
                }
                else if (State == "FindLayerCount")
                {
                    if (line.Contains("\"Name\": \"LayerCount\","))
                    {
                        State = "FoundLayerCount";
                    }
                }
                else if (State == "FoundLayerCount")
                {
                    if (line.Contains("\"Value\":"))
                    {
                        Fur_LayerCount.Text = GetCleanValue(line);
                        State = "FindLODS";
                    }
                }
                else if (State == "FindLODS")
                {
                    if (line.Contains("\"Name\": \"Lods\","))
                    {
                        State = "FindLODLayerCount";
                    }
                }
                else if (State == "FindLODLayerCount")
                {
                    if (line.Contains("\"Name\": \"LayerCount\","))
                    {
                        State = "FoundLODLayerCount";
                    }
                }
                else if (State == "FoundLODLayerCount")
                {
                    if (line.Contains("\"Value\":"))
                    {
                        Fur_LayerCount_LOD.Text = GetCleanValue(line);
                        State = "FindLODPhysics";
                    }
                }
                else if (State == "FindLODPhysics")
                {
                    if (line.Contains("\"Name\": \"physicsEnabled\","))
                    {
                        State = "FoundLODPhysics";
                    }
                }
                else if (State == "FoundLODPhysics")
                {
                    if (line.Contains("\"Value\": true"))
                    {
                        Fur_PhysicsEnabled_LOD.Checked = true;
                        State = "FindFurLength";
                    }
                    else if (line.Contains("\"Value\": false"))
                    {
                        Fur_PhysicsEnabled_LOD.Checked = false;
                        State = "FindFurLength";
                    }
                }
                else if (State == "FindFurLength")
                {
                    if (line.Contains("\"Name\": \"FurLength\","))
                    {
                        Fur_FurLength.Text = GetCleanValue(PreviousLine);
                        State = "FindMinFurLength";
                    }
                }
                else if (State == "FindMinFurLength")
                {
                    if (line.Contains("\"Name\": \"MinFurLength\","))
                    {
                        Fur_MinFurLength.Text = GetCleanValue(PreviousLine);
                        State = "FindPhysics";
                    }
                }
                else if (State == "FindPhysics")
                {
                    if (line.Contains("\"Name\": \"bPhysicsEnabled\","))
                    {
                        State = "FoundPhysics";
                    }
                }
                else if (State == "FoundPhysics")
                {
                    if (line.Contains("\"Value\": true"))
                    {
                        Fur_PhysicsEnabled.Checked = true;
                        State = "FindForceDistribution";
                    }
                    else if (line.Contains("\"Value\": false"))
                    {
                        Fur_PhysicsEnabled.Checked = false;
                        State = "FindForceDistribution";
                    }
                }
                else if (State == "FindForceDistribution")
                {
                    if (line.Contains("\"Name\": \"ForceDistribution\","))
                    {
                        Fur_ForceDistribution.Text = GetCleanValue(PreviousLine);
                        State = "FindStiffness";
                    }
                }
                else if (State == "FindStiffness")
                {
                    if (line.Contains("\"Name\": \"Stiffness\","))
                    {
                        Fur_Stiffness.Text = GetCleanValue(PreviousLine);
                        State = "FindDamping";
                    }
                }
                else if (State == "FindDamping")
                {
                    if (line.Contains("\"Name\": \"Damping\","))
                    {
                        Fur_Damping.Text = GetCleanValue(PreviousLine);
                        State = "FindConstantForce";
                    }
                }
                else if (State == "FindConstantForce")
                {
                    if (line.Contains("\"Name\": \"ConstantForce\","))
                    {
                        State = "FoundConstantForce";
                    }
                }
                else if (State == "FoundConstantForce")
                {
                    if (line.Contains("\"X\":"))
                    {
                        Fur_ConstForce_X.Text = GetCleanValue(line);
                    }
                    else if (line.Contains("\"Y\":"))
                    {
                        Fur_ConstForce_Y.Text = GetCleanValue(line);
                    }
                    else if (line.Contains("\"Z\":"))
                    {
                        Fur_ConstForce_Z.Text = GetCleanValue(line);
                        State = "FindMaxForce";
                    }
                }
                else if (State == "FindMaxForce")
                {
                    if (line.Contains("\"Name\": \"MaxForce\","))
                    {
                        Fur_MaxForce.Text = GetCleanValue(PreviousLine);
                        State = "FindMaxForceTorqueFactor";
                    }
                }
                else if (State == "FindMaxForceTorqueFactor")
                {
                    if (line.Contains("\"Name\": \"MaxForceTorqueFactor\","))
                    {
                        Fur_MaxForceTorqueFactor.Text = GetCleanValue(PreviousLine);
                        State = "FindReferenceHairBias";
                    }
                }
                else if (State == "FindReferenceHairBias")
                {
                    if (line.Contains("\"Name\": \"ReferenceHairBias\","))
                    {
                        Fur_RefHairBias.Text = GetCleanValue(PreviousLine);
                        State = "FindReferenceHairBias";
                    }
                }
                else if (State == "FindHairLengthForceUniformity")
                {
                    if (line.Contains("\"Name\": \"HairLengthForceUniformity\","))
                    {
                        Fur_HairLengthForceUniformity.Text = GetCleanValue(PreviousLine);
                        State = "Done";
                    }
                }

                PreviousLine = line;
                if (State == "Done")
                {
                    return;
                }
            }
        }

        private void CurrentlyEditing_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentlyEditing_Path == string.Empty)
            {
                Process.Start("explorer.exe", Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod");
            }
            else
            {
                string Dir = Path.GetDirectoryName(CurrentlyEditing_Path);
                if (Directory.Exists(Dir))
                {
                    Process.Start("explorer.exe", Dir);
                }
                else
                {
                    MessageBox.Show("Directory for the file was not found.", "Wild Life Mod Manager");
                }
            }
        }

        private void StopEditing_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentlyEditing_Path = string.Empty;
            CurrentlyEditing_LL.Text = "New File";
            WriteMod.Text = "Write Mod File";
            StopEditing_LL.Hide();
        }

        private void AutoModCreator_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ExtractAllEntries()
        {
            string State = "";

            var logFile = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Default.json");
            var logList = new List<string>(logFile);

            foreach (string line in logList)
            {
                if (State == "")
                {
                    if (line.Contains("\"StructType\": \"ClothesOutfitData\","))
                    {
                        // Found "StructType": "ClothesOutfitData",
                        State = "FindName";
                    }
                }
                else if (State == "FindName")
                {
                    if (line.Contains("\"Name\":"))
                    {
                        // Found Name
                        string CleanName = line.Replace("\"Name\": \"", "").Trim();
                        CleanName = CleanName.Replace("\",", "");

                        Head_LoadEntry_CB.Items.Add(CleanName);
                        Chest_LoadEntry_CB.Items.Add(CleanName);
                        Hands_LoadEntry_CB.Items.Add(CleanName);
                        Legs_LoadEntry_CB.Items.Add(CleanName);
                        Feet_LoadEntry_CB.Items.Add(CleanName);

                        State = "";
                    }
                }
            }
        }

        private void ExtractValues(string FromItem, string Slot)
        {
            ToggleAllFurmasks(false);
            int LineNR = 0;
            string State = "";
            bool ExtractAll = false;

            var logFile = File.ReadAllLines(Application.StartupPath + @"DataTables\" + LoadedWLVersion + @"\DT_ClothesOutfit_Default.json");
            var logList = new List<string>(logFile);

            Dictionary<string, string> MeshPaths = new Dictionary<string, string>();
            Dictionary<string, string> SexMeshPaths = new Dictionary<string, string>();
            Dictionary<string, string> IconPaths = new Dictionary<string, string>();
            Dictionary<string, string> FurmaskPaths = new Dictionary<string, string>();
            Dictionary<string, string> SexFurmaskPaths = new Dictionary<string, string>();
            Dictionary<string, string> PhysAreas = new Dictionary<string, string>();
            Dictionary<string, string> MorphTargets = new Dictionary<string, string>();
            Dictionary<string, string> MorphTargetValues = new Dictionary<string, string>();
            Dictionary<string, string> ConstraintProfiles = new Dictionary<string, string>();
            Dictionary<string, string> ArousalBlends = new Dictionary<string, string>();
            Dictionary<string, string> FlexRegs = new Dictionary<string, string>();

            string CurrentSlot = Slot;

            if (Slot == "All")
            {
                CurrentSlot = "Head";
                ExtractAll = true;
            }

            foreach (string line in logList)
            {
                if (State == "")
                {
                    if (line.Contains("\"Name\": \"" + FromItem + "\","))
                    {
                        // Found Item
                        State = "FindSlot";
                    }
                }
                else if (State == "FindSlot")
                {
                    if (line.Contains("\"Name\": \"" + CurrentSlot + "\","))
                    {
                        // Found Slot
                        State = "FindMeshPath";
                    }
                }
                else if (State == "FindMeshPath")
                {
                    if (line.Contains("\"PackageName\": "))
                    {
                        // Found MeshPath
                        string CleanString = line.Replace("\"PackageName\": \"", "").Trim();
                        CleanString = CleanString.Replace("\",", "");
                        MeshPaths.Add(CurrentSlot, CleanString);
                        State = "FindSexMeshPath";
                    }
                }
                else if (State == "FindSexMeshPath")
                {
                    if (line.Contains("\"PackageName\": "))
                    {
                        // Found MeshPath
                        string CleanString = line.Replace("\"PackageName\": \"", "").Trim();
                        CleanString = CleanString.Replace("\",", "");
                        SexMeshPaths.Add(CurrentSlot, CleanString);
                        State = "FindIconPath";
                    }
                }
                else if (State == "FindIconPath")
                {
                    if (line.Contains("\"PackageName\": "))
                    {
                        // Found IconPath
                        string CleanString = line.Replace("\"PackageName\": \"", "").Trim();
                        CleanString = CleanString.Replace("\",", "");
                        IconPaths.Add(CurrentSlot, CleanString);
                        State = "FindPhysicsAreas";
                    }
                }
                else if (State == "FindPhysicsAreas")
                {
                    if (line.Contains("\"Name\": \"physicsAreas\","))
                    {
                        // Found Name
                        State = "FindPhysicsAreas_Value";
                    }
                }
                else if (State == "FindPhysicsAreas_Value")
                {
                    if (line.Contains("\"Value\": "))
                    {
                        // Found Value
                        string CleanString = line.Replace("\"Value\": ", "").Trim();
                        PhysAreas.Add(CurrentSlot, CleanString);
                        State = "FindMorphTarget";
                    }
                }
                else if (State == "FindMorphTarget")
                {
                    if (line.Contains("\"Name\": \"MorphTarget\","))
                    {
                        // Found Name
                        State = "FindMorphTarget_Value";
                    }
                }
                else if (State == "FindMorphTarget_Value")
                {
                    if (line.Contains("\"Value\": "))
                    {
                        // Found Value
                        string CleanString = line.Replace("\"Value\": ", "").Trim();
                        CleanString = CleanString.Replace(",", "");
                        MorphTargets.Add(CurrentSlot, CleanString);
                        State = "FindMorphTargetValue";
                    }
                }
                else if (State == "FindMorphTargetValue")
                {
                    if (line.Contains("\"Name\": \"MorphTargetValue\","))
                    {
                        // Found Name
                        string CleanString = logList[LineNR - 1].Replace("\"Value\": ", "").Trim();
                        CleanString = CleanString.Replace(",", "");
                        MorphTargetValues.Add(CurrentSlot, CleanString);
                        State = "FindConstraintProfile";
                    }
                }
                else if (State == "FindConstraintProfile")
                {
                    if (line.Contains("\"Name\": \"ConstraintProfile\","))
                    {
                        // Found Name
                        State = "FindConstraintProfile_Value";
                    }
                }
                else if (State == "FindConstraintProfile_Value")
                {
                    if (line.Contains("\"Value\": "))
                    {
                        // Found Value
                        string CleanString = line.Replace("\"Value\": ", "").Trim();
                        CleanString = CleanString.Replace(",", "");
                        ConstraintProfiles.Add(CurrentSlot, CleanString);
                        State = "FindArousalBlend";
                    }
                }
                else if (State == "FindArousalBlend")
                {
                    if (line.Contains("\"Name\": \"ArousalBlend\","))
                    {
                        // Found Name
                        string CleanString = logList[LineNR - 1].Replace("\"Value\": ", "").Trim();
                        CleanString = CleanString.Replace(",", "");
                        CleanString = CleanString.Replace("\"", "");
                        CleanString = CleanString.Replace("+", "");
                        ArousalBlends.Add(CurrentSlot, CleanString);
                        State = "FindFlexReg";
                    }
                }
                else if (State == "FindFlexReg")
                {
                    if (line.Contains("\"Name\": \"MuscleFlexRegions\","))
                    {
                        // Found Name
                        State = "FindFlexReg_Value";
                    }
                }
                else if (State == "FindFlexReg_Value")
                {
                    if (line.Contains("\"Value\": "))
                    {
                        // Found Value
                        string CleanString = line.Replace("\"Value\": ", "").Trim();
                        FlexRegs.Add(CurrentSlot, CleanString);

                        State = "FindFurMask";
                    }
                }
                else if (State == "FindFurMask")
                {
                    if (line.Contains("\"Name\": \"FurMasks\","))
                    {
                        // Found Name
                        State = "FindFurMask_Value";
                        Debug.WriteLine("Found FurMask");
                    }
                }
                else if (State == "FindFurMask_Value")
                {
                    if (line.Contains("\"Value\": []"))
                    {
                        // No FurMask
                        if (ExtractAll == false)
                        {
                            State = "Done";
                        }
                        else
                        {
                            if (CurrentSlot == "Feet")
                            {
                                CurrentSlot = "Head";
                                State = "Done";
                            }
                            else if (CurrentSlot == "Legs")
                            {
                                CurrentSlot = "Feet";
                                State = "FindSlot";
                            }
                            else if (CurrentSlot == "Hands")
                            {
                                CurrentSlot = "Legs";
                                State = "FindSlot";
                            }
                            else if (CurrentSlot == "Chest")
                            {
                                CurrentSlot = "Hands";
                                State = "FindSlot";
                            }
                            else if (CurrentSlot == "Head")
                            {
                                CurrentSlot = "Chest";
                                State = "FindSlot";
                            }
                        }
                    }
                    else if (line.Contains("\"Value\": ["))
                    {
                        State = "FindFurMask_Path";
                    }
                }
                else if (State == "FindFurMask_Path")
                {
                    if (line.Contains("\"PackageName\": "))
                    {
                        // Found FurMask Path
                        string CleanString = line.Replace("\"PackageName\": \"", "").Trim();
                        CleanString = CleanString.Replace("\",", "");
                        FurmaskPaths.Add(CurrentSlot, CleanString);
                        State = "FindFurMaskSex_Path";
                    }
                }
                else if (State == "FindFurMaskSex_Path")
                {
                    if (line.Contains("\"PackageName\": "))
                    {
                        // Found FurMask Path
                        string CleanString = line.Replace("\"PackageName\": \"", "").Trim();
                        CleanString = CleanString.Replace("\",", "");
                        SexFurmaskPaths.Add(CurrentSlot, CleanString);

                        if (ExtractAll == false)
                        {
                            State = "Done";
                        }
                        else
                        {
                            if (CurrentSlot == "Feet")
                            {
                                CurrentSlot = "Head";
                                State = "Done";
                            }
                            else if (CurrentSlot == "Legs")
                            {
                                CurrentSlot = "Feet";
                                State = "FindSlot";
                            }
                            else if (CurrentSlot == "Hands")
                            {
                                CurrentSlot = "Legs";
                                State = "FindSlot";
                            }
                            else if (CurrentSlot == "Chest")
                            {
                                CurrentSlot = "Hands";
                                State = "FindSlot";
                            }
                            else if (CurrentSlot == "Head")
                            {
                                CurrentSlot = "Chest";
                                State = "FindSlot";
                            }
                        }
                    }
                }

                else if (State == "Done")
                {
                    if (CurrentSlot == "Head")
                    {
                        Head_Mesh_Path.Text = MeshPaths[CurrentSlot];
                        Head_Mesh_Name.Text = GetSlice(MeshPaths[CurrentSlot], "/", 999);

                        Head_SexMesh_Path.Text = SexMeshPaths[CurrentSlot];
                        Head_SexMesh_Name.Text = GetSlice(SexMeshPaths[CurrentSlot], "/", 999);

                        Head_Icon_Path.Text = IconPaths[CurrentSlot];
                        Head_Icon_Name.Text = GetSlice(IconPaths[CurrentSlot], "/", 999);

                        Head_PhysAreas.Text = PhysAreas[CurrentSlot];
                        Head_MorphTargetCB.Text = MorphTargets[CurrentSlot];
                        Head_MorphTargetVal.Text = MorphTargetValues[CurrentSlot];
                        Head_ConstraintProfileCB.Text = ConstraintProfiles[CurrentSlot];
                        Head_ArousalBlend.Text = ArousalBlends[CurrentSlot];
                        Head_FlexReg.Text = FlexRegs[CurrentSlot];

                        if (FurmaskPaths.ContainsKey(CurrentSlot) == true)
                        {
                            Head_Furmask_Path.Text = FurmaskPaths[CurrentSlot];
                            Head_Furmask_Name.Text = GetSlice(FurmaskPaths[CurrentSlot], "/", 999);
                            Head_SexFurmask_Path.Text = SexFurmaskPaths[CurrentSlot];
                            Head_SexFurmask_Name.Text = GetSlice(SexFurmaskPaths[CurrentSlot], "/", 999);
                            ToggleAllFurmasks(true);
                        }
                        else
                        {
                            Head_Furmask_Path.Text = "None";
                            Head_Furmask_Name.Text = "None";
                            Head_SexFurmask_Path.Text = "None";
                            Head_SexFurmask_Name.Text = "None";
                        }
                        if (ExtractAll == true)
                        {
                            CurrentSlot = "Chest";
                        }
                    }
                    if (CurrentSlot == "Chest")
                    {
                        Chest_Mesh_Path.Text = MeshPaths[CurrentSlot];
                        Chest_Mesh_Name.Text = GetSlice(MeshPaths[CurrentSlot], "/", 999);

                        Chest_SexMesh_Path.Text = SexMeshPaths[CurrentSlot];
                        Chest_SexMesh_Name.Text = GetSlice(SexMeshPaths[CurrentSlot], "/", 999);

                        Chest_Icon_Path.Text = IconPaths[CurrentSlot];
                        Chest_Icon_Name.Text = GetSlice(IconPaths[CurrentSlot], "/", 999);

                        Chest_PhysAreas.Text = PhysAreas[CurrentSlot];
                        Chest_MorphTargetCB.Text = MorphTargets[CurrentSlot];
                        Chest_MorphTargetVal.Text = MorphTargetValues[CurrentSlot];
                        Chest_ConstraintProfileCB.Text = ConstraintProfiles[CurrentSlot];
                        Chest_ArousalBlend.Text = ArousalBlends[CurrentSlot];
                        Chest_FlexReg.Text = FlexRegs[CurrentSlot];

                        if (FurmaskPaths.ContainsKey(CurrentSlot) == true)
                        {
                            Chest_Furmask_Path.Text = FurmaskPaths[CurrentSlot];
                            Chest_Furmask_Name.Text = GetSlice(FurmaskPaths[CurrentSlot], "/", 999);
                            Chest_SexFurmask_Path.Text = SexFurmaskPaths[CurrentSlot];
                            Chest_SexFurmask_Name.Text = GetSlice(SexFurmaskPaths[CurrentSlot], "/", 999);
                            ToggleAllFurmasks(true);
                        }
                        else
                        {
                            Chest_Furmask_Path.Text = "None";
                            Chest_Furmask_Name.Text = "None";
                            Chest_SexFurmask_Path.Text = "None";
                            Chest_SexFurmask_Name.Text = "None";
                        }
                        if (ExtractAll == true)
                        {
                            CurrentSlot = "Hands";
                        }
                    }
                    if (CurrentSlot == "Hands")
                    {
                        Hands_Mesh_Path.Text = MeshPaths[CurrentSlot];
                        Hands_Mesh_Name.Text = GetSlice(MeshPaths[CurrentSlot], "/", 999);

                        Hands_SexMesh_Path.Text = SexMeshPaths[CurrentSlot];
                        Hands_SexMesh_Name.Text = GetSlice(SexMeshPaths[CurrentSlot], "/", 999);

                        Hands_Icon_Path.Text = IconPaths[CurrentSlot];
                        Hands_Icon_Name.Text = GetSlice(IconPaths[CurrentSlot], "/", 999);

                        Hands_PhysAreas.Text = PhysAreas[CurrentSlot];
                        Hands_MorphTargetCB.Text = MorphTargets[CurrentSlot];
                        Hands_MorphTargetVal.Text = MorphTargetValues[CurrentSlot];
                        Hands_ConstraintProfileCB.Text = ConstraintProfiles[CurrentSlot];
                        Hands_ArousalBlend.Text = ArousalBlends[CurrentSlot];
                        Hands_FlexReg.Text = FlexRegs[CurrentSlot];

                        if (FurmaskPaths.ContainsKey(CurrentSlot) == true)
                        {
                            Hands_Furmask_Path.Text = FurmaskPaths[CurrentSlot];
                            Hands_Furmask_Name.Text = GetSlice(FurmaskPaths[CurrentSlot], "/", 999);
                            Hands_SexFurmask_Path.Text = SexFurmaskPaths[CurrentSlot];
                            Hands_SexFurmask_Name.Text = GetSlice(SexFurmaskPaths[CurrentSlot], "/", 999);
                            ToggleAllFurmasks(true);
                        }
                        else
                        {
                            Hands_Furmask_Path.Text = "None";
                            Hands_Furmask_Name.Text = "None";
                            Hands_SexFurmask_Path.Text = "None";
                            Hands_SexFurmask_Name.Text = "None";
                        }
                        if (ExtractAll == true)
                        {
                            CurrentSlot = "Legs";
                        }
                    }
                    if (CurrentSlot == "Legs")
                    {
                        Legs_Mesh_Path.Text = MeshPaths[CurrentSlot];
                        Legs_Mesh_Name.Text = GetSlice(MeshPaths[CurrentSlot], "/", 999);

                        Legs_SexMesh_Path.Text = SexMeshPaths[CurrentSlot];
                        Legs_SexMesh_Name.Text = GetSlice(SexMeshPaths[CurrentSlot], "/", 999);

                        Legs_Icon_Path.Text = IconPaths[CurrentSlot];
                        Legs_Icon_Name.Text = GetSlice(IconPaths[CurrentSlot], "/", 999);

                        Legs_PhysAreas.Text = PhysAreas[CurrentSlot];
                        Legs_MorphTargetCB.Text = MorphTargets[CurrentSlot];
                        Legs_MorphTargetVal.Text = MorphTargetValues[CurrentSlot];
                        Legs_ConstraintProfileCB.Text = ConstraintProfiles[CurrentSlot];
                        Legs_ArousalBlend.Text = ArousalBlends[CurrentSlot];
                        Legs_FlexReg.Text = FlexRegs[CurrentSlot];

                        if (FurmaskPaths.ContainsKey(CurrentSlot) == true)
                        {
                            Legs_Furmask_Path.Text = FurmaskPaths[CurrentSlot];
                            Legs_Furmask_Name.Text = GetSlice(FurmaskPaths[CurrentSlot], "/", 999);
                            Legs_SexFurmask_Path.Text = SexFurmaskPaths[CurrentSlot];
                            Legs_SexFurmask_Name.Text = GetSlice(SexFurmaskPaths[CurrentSlot], "/", 999);
                            ToggleAllFurmasks(true);
                        }
                        else
                        {
                            Legs_Furmask_Path.Text = "None";
                            Legs_Furmask_Name.Text = "None";
                            Legs_SexFurmask_Path.Text = "None";
                            Legs_SexFurmask_Name.Text = "None";
                        }
                        if (ExtractAll == true)
                        {
                            CurrentSlot = "Feet";
                        }
                    }
                    if (CurrentSlot == "Feet")
                    {
                        Feet_Mesh_Path.Text = MeshPaths[CurrentSlot];
                        Feet_Mesh_Name.Text = GetSlice(MeshPaths[CurrentSlot], "/", 999);

                        Feet_SexMesh_Path.Text = SexMeshPaths[CurrentSlot];
                        Feet_SexMesh_Name.Text = GetSlice(SexMeshPaths[CurrentSlot], "/", 999);

                        Feet_Icon_Path.Text = IconPaths[CurrentSlot];
                        Feet_Icon_Name.Text = GetSlice(IconPaths[CurrentSlot], "/", 999);

                        Feet_PhysAreas.Text = PhysAreas[CurrentSlot];
                        Feet_MorphTargetCB.Text = MorphTargets[CurrentSlot];
                        Feet_MorphTargetVal.Text = MorphTargetValues[CurrentSlot];
                        Feet_ConstraintProfileCB.Text = ConstraintProfiles[CurrentSlot];
                        Feet_ArousalBlend.Text = ArousalBlends[CurrentSlot];
                        Feet_FlexReg.Text = FlexRegs[CurrentSlot];

                        if (FurmaskPaths.ContainsKey(CurrentSlot) == true)
                        {
                            Feet_Furmask_Path.Text = FurmaskPaths[CurrentSlot];
                            Feet_Furmask_Name.Text = GetSlice(FurmaskPaths[CurrentSlot], "/", 999);
                            Feet_SexFurmask_Path.Text = SexFurmaskPaths[CurrentSlot];
                            Feet_SexFurmask_Name.Text = GetSlice(SexFurmaskPaths[CurrentSlot], "/", 999);
                            ToggleAllFurmasks(true);
                        }
                        else
                        {
                            Feet_Furmask_Path.Text = "None";
                            Feet_Furmask_Name.Text = "None";
                            Feet_SexFurmask_Path.Text = "None";
                            Feet_SexFurmask_Name.Text = "None";
                        }
                    }
                    return;
                }

                LineNR += 1;
            }
        }

        private void Head_LoadEntry_CB_TextChanged(object sender, EventArgs e)
        {
            Head_LoadEntry_CB.DroppedDown = false;
        }

        private void Head_LoadEntry_Button_Click(object sender, EventArgs e)
        {
            if (Head_LoadEntry_CB.Text != "")
            {
                ExtractValues(Head_LoadEntry_CB.Text, "Head");
            }
        }

        private void Head_LoadEntryAll_Button_Click(object sender, EventArgs e)
        {
            if (Head_LoadEntry_CB.Text != "")
            {
                ExtractValues(Head_LoadEntry_CB.Text, "All");
            }
        }

        private void Chest_LoadEntry_CB_TextChanged(object sender, EventArgs e)
        {
            Chest_LoadEntry_CB.DroppedDown = false;
        }

        private void Hands_LoadEntry_CB_TextChanged(object sender, EventArgs e)
        {
            Hands_LoadEntry_CB.DroppedDown = false;
        }

        private void Legs_LoadEntry_CB_TextChanged(object sender, EventArgs e)
        {
            Legs_LoadEntry_CB.DroppedDown = false;
        }

        private void Feet_LoadEntry_CB_TextChanged(object sender, EventArgs e)
        {
            Feet_LoadEntry_CB.DroppedDown = false;
        }

        private void Chest_LoadEntry_Button_Click(object sender, EventArgs e)
        {
            if (Chest_LoadEntry_CB.Text != "")
            {
                ExtractValues(Chest_LoadEntry_CB.Text, "Chest");
            }
        }

        private void Chest_LoadEntryAll_Button_Click(object sender, EventArgs e)
        {
            if (Chest_LoadEntry_CB.Text != "")
            {
                ExtractValues(Chest_LoadEntry_CB.Text, "All");
            }
        }

        private void Hands_LoadEntry_Button_Click(object sender, EventArgs e)
        {
            if (Hands_LoadEntry_CB.Text != "")
            {
                ExtractValues(Hands_LoadEntry_CB.Text, "Hands");
            }
        }

        private void Hands_LoadEntryAll_Button_Click(object sender, EventArgs e)
        {
            if (Hands_LoadEntry_CB.Text != "")
            {
                ExtractValues(Hands_LoadEntry_CB.Text, "All");
            }
        }

        private void Legs_LoadEntry_Button_Click(object sender, EventArgs e)
        {
            if (Legs_LoadEntry_CB.Text != "")
            {
                ExtractValues(Legs_LoadEntry_CB.Text, "Legs");
            }
        }

        private void Legs_LoadEntryAll_Button_Click(object sender, EventArgs e)
        {
            if (Legs_LoadEntry_CB.Text != "")
            {
                ExtractValues(Legs_LoadEntry_CB.Text, "All");
            }
        }

        private void Feet_LoadEntry_Button_Click(object sender, EventArgs e)
        {
            if (Feet_LoadEntry_CB.Text != "")
            {
                ExtractValues(Feet_LoadEntry_CB.Text, "Feet");
            }
        }

        private void Feet_LoadEntryAll_Button_Click(object sender, EventArgs e)
        {
            if (Feet_LoadEntry_CB.Text != "")
            {
                ExtractValues(Feet_LoadEntry_CB.Text, "All");
            }
        }

        private void PropIcon_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PropIcon_TB.Text = "/Game/Textures/UI/Icons/Sandbox/PropIcons/T_FriedMeatFIcon";
        }

        private void PropMesh_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PropMesh_TB.Text = "/Game/Meshes/Environment/Props/X_Props/X_Props_S/SM_Prop_Fried_Meat_F";
        }

        private void PropCustomBlueprint_Ex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PropCustomBlueprint_TB.Text = "/Game/Blueprints/Sandbox/Props/BP_SandboxProp_XPropBase";
        }

        private void Props_Add_Button_Click(object sender, EventArgs e)
        {
            string PropEntry = PropID_TB.Text + " | " + PropName_TB.Text + " | " + PropCategory_CB.Text + " | " + PropIcon_TB.Text + " | " + PropMesh_TB.Text + " | " + PropSkelMesh_TB.Text
                + " | " + PropActor_TB.Text + " | " + PropPivotOffset_X.Value.ToString() + "," + PropPivotOffset_Y.Value.ToString() + "," + PropPivotOffset_Z.Value.ToString() + " | "
                + PropPlacementOffset_X.Value.ToString() + "," + PropPlacementOffset_Y.Value.ToString() + "," + PropPlacementOffset_Z.Value.ToString() + " | "
                + PropCollision_CB.Checked.ToString() + " | " + PropColOffset_X.Value.ToString() + "," + PropColOffset_X.Value.ToString() + "," + PropColOffset_X.Value.ToString() + " | "
                + PropColRotation_Pitch.Value.ToString() + "," + PropColRotation_Yaw.Value.ToString() + "," + PropColRotation_Roll.Value.ToString() + " | "
                + PropColExtents_X.Value.ToString() + "," + PropColExtents_X.Value.ToString() + "," + PropColExtents_X.Value.ToString() + " | "
                + PropCustomBlueprint_TB.Text + " | " + PropCustomBlueprintName_TB.Text + " | " + PropADFL_CB.Checked.ToString();

            int existingIndex = -1;
            for (int i = 0; i < Props_LB.Items.Count; i++)
            {
                string item = Props_LB.Items[i].ToString();
                if (GetSlice(item," | ", 0).Trim() == PropID_TB.Text)
                {
                    existingIndex = i;
                    break;
                }
            }

            if (existingIndex >= 0)
            {
                Props_LB.Items[existingIndex] = PropEntry;
                Props_LB.SelectedIndex = existingIndex;
            }
            else
            {
                Props_LB.Items.Add(PropEntry);
                Props_LB.SelectedIndex = Props_LB.Items.Count - 1;
            }
        }

        private void Props_Remove_Button_Click(object sender, EventArgs e)
        {
            if (Props_LB.SelectedIndex != -1)
            {
                Props_LB.Items.RemoveAt(Props_LB.SelectedIndex);
            }
        }

        private void Props_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Props_LB.SelectedIndex != -1)
            {
                string PropEntry = Props_LB.SelectedItem.ToString();
                string[] SplitEntry = PropEntry.Split(" | ");
                PropID_TB.Text = SplitEntry[0];
                PropName_TB.Text = SplitEntry[1];
                PropCategory_CB.Text = SplitEntry[2];
                PropIcon_TB.Text = SplitEntry[3];
                PropMesh_TB.Text = SplitEntry[4];
                PropSkelMesh_TB.Text = SplitEntry[5];
                PropActor_TB.Text = SplitEntry[6];
                string[] PivotOffset = SplitEntry[7].Split(",");
                PropPivotOffset_X.Value = Decimal.Parse(PivotOffset[0]);
                PropPivotOffset_Y.Value = Decimal.Parse(PivotOffset[1]);
                PropPivotOffset_Z.Value = Decimal.Parse(PivotOffset[2]);
                string[] PlacementOffset = SplitEntry[8].Split(",");
                PropPlacementOffset_X.Value = Decimal.Parse(PlacementOffset[0]);
                PropPlacementOffset_Y.Value = Decimal.Parse(PlacementOffset[1]);
                PropPlacementOffset_Z.Value = Decimal.Parse(PlacementOffset[2]);
                PropCollision_CB.Checked = Boolean.Parse(SplitEntry[9]);
                string[] ColOffset = SplitEntry[10].Split(",");
                PropColOffset_X.Value = Decimal.Parse(ColOffset[0]);
                PropColOffset_Y.Value = Decimal.Parse(ColOffset[1]);
                PropColOffset_Z.Value = Decimal.Parse(ColOffset[2]);
                string[] ColRotation = SplitEntry[11].Split(",");
                PropColRotation_Pitch.Value = Decimal.Parse(ColRotation[0]);
                PropColRotation_Yaw.Value = Decimal.Parse(ColRotation[1]);
                PropColRotation_Roll.Value = Decimal.Parse(ColRotation[2]);
                string[] ColExtents = SplitEntry[12].Split(",");
                PropColExtents_X.Value = Decimal.Parse(ColExtents[0]);
                PropColExtents_Y.Value = Decimal.Parse(ColExtents[1]);
                PropColExtents_Z.Value = Decimal.Parse(ColExtents[2]);
                PropCustomBlueprint_TB.Text = SplitEntry[13];
                PropCustomBlueprintName_TB.Text = SplitEntry[14];
                PropADFL_CB.Checked = Boolean.Parse(SplitEntry[15]);
            }
        }
    }
}
