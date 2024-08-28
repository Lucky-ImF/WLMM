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
        LinkLabel[] CharCust_Dupe = new LinkLabel[50];
        LinkLabel[] CharCust_Remove = new LinkLabel[50];

        List<int> CharCust_Entries = new List<int>();
        int CharCust_CurrentEntryID = 0;

        public AutoModCreator()
        {
            InitializeComponent();
        }

        public void TransferInfo(string Path, string Version, ModCreator MCF)
        {
            LoadedWLVersion = Version;
            LoadedWLPath = Path;
            ModCreator_Form = MCF;

            LoadBaseInfo();
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
                        ModString += CharCust_Target[i].Text + ": " + CharCust_Path[i].Text + "," + CharCust_Name[i].Text + "\n";
                        AddToNameMap(CharCust_Path[i].Text);
                        AddToNameMap(CharCust_Name[i].Text);
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
                        SavePath = Application.StartupPath + @"Mods\" + LoadedWLVersion + @"\Mod Creator\AutoMod\" + ModName.Text + ".txt";
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
            }
        }

        public void LoadAutoMod(string ModPath)
        {
            ToggleAllFurmasks(false);
            ResetFurmasks();

            CurrentlyEditing_Path = ModPath;
            CurrentlyEditing_LL.Text = ModPath;
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
                else
                {
                    string[] TempArray2 = TempArray[1].Trim().Split(',');
                    CreateCustCharEntry(99, TempArray[0], TempArray2[0], TempArray2[1]);
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

        private void CreateCustCharEntry(int Dupe = 99, string setTarget = "Hair", string setPath = "None", string setName = "None")
        {
            int EntryID = CharCust_CurrentEntryID;

            CharCust_GB[EntryID] = new GroupBox();
            CharCust_GB[EntryID].Text = "Entry #" + EntryID.ToString();
            CharCust_GB[EntryID].Size = new System.Drawing.Size(495, 145);
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

            CharCust_Target[EntryID] = new ComboBox();
            CharCust_Target[EntryID].Items.AddRange(new string[] { "Hair", "Skin", "PubicHair", "Eyes", "EyeLiner", "EyeShadow", "Lipstick", "Tanlines" });
            CharCust_Target[EntryID].SelectedIndex = 0;
            CharCust_Target[EntryID].BackColor = System.Drawing.Color.FromArgb(75, 68, 138);
            CharCust_Target[EntryID].ForeColor = System.Drawing.SystemColors.ActiveCaption;
            CharCust_Target[EntryID].Size = new System.Drawing.Size(464, 21);
            CharCust_Target[EntryID].Location = new System.Drawing.Point(14, 32);
            CharCust_Target[EntryID].Text = setTarget.ToString();

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
            CharCust_GB[EntryID].Controls.Add(CharCust_Target[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Path[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Name[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Dupe[EntryID]);
            CharCust_GB[EntryID].Controls.Add(CharCust_Remove[EntryID]);

            if (Dupe != 99)
            {
                CharCust_Target[EntryID].Text = CharCust_Target[Dupe].Text;
                CharCust_Path[EntryID].Text = CharCust_Path[Dupe].Text;
                CharCust_Name[EntryID].Text = CharCust_Name[Dupe].Text;
            }

            CharCustomFlow.Controls.Add(CharCust_GB[EntryID]);
            CharCust_Entries.Add(EntryID);
            CharCust_CurrentEntryID += 1;
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
        }

        private void Chest_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Chest_ExtraPanel.Visible == false) { Chest_ExtraPanel.Visible = true; }
            else { Chest_ExtraPanel.Visible = false; }
        }

        private void Hands_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Hands_ExtraPanel.Visible == false) { Hands_ExtraPanel.Visible = true; }
            else { Hands_ExtraPanel.Visible = false; }
        }

        private void Legs_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Legs_ExtraPanel.Visible == false) { Legs_ExtraPanel.Visible = true; }
            else { Legs_ExtraPanel.Visible = false; }
        }

        private void Feet_ExtraButton_Click(object sender, EventArgs e)
        {
            if (Feet_ExtraPanel.Visible == false) { Feet_ExtraPanel.Visible = true; }
            else { Feet_ExtraPanel.Visible = false; }
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
            StopEditing_LL.Hide();
        }
    }
}
