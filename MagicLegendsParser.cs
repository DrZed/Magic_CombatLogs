using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Globalization;

// ReSharper disable All


[assembly: AssemblyTitle("Magic Legends Parsing Plugin")]
[assembly: AssemblyDescription("A basic parser that reads the combat logs in Magic Legends.")]
[assembly: AssemblyCopyright("KeldonSlayer CC0")]
[assembly: AssemblyVersion("1.2.2.0")]


namespace MLParsing_Plugin
{
    public class MLParsing_Plugin : UserControl, IActPluginV1
    {

        #region Designer Created Code (Avoid editing)

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_mergeNPC = new System.Windows.Forms.CheckBox();
            this.checkBox_mergePets = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_clearAll = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_player = new System.Windows.Forms.TextBox();
            this.listBox_players = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Magic Legends parser plugin Options";
            // 
            // checkBox_mergeNPC
            // 
            this.checkBox_mergeNPC.AutoSize = true;
            this.checkBox_mergeNPC.Location = new System.Drawing.Point(6, 21);
            this.checkBox_mergeNPC.Name = "checkBox_mergeNPC";
            this.checkBox_mergeNPC.Size = new System.Drawing.Size(291, 17);
            this.checkBox_mergeNPC.TabIndex = 2;
            this.checkBox_mergeNPC.Text = "Merge all NPC combatants by removing NPC unique IDs";
            this.checkBox_mergeNPC.UseVisualStyleBackColor = true;
            this.checkBox_mergeNPC.MouseEnter += new System.EventHandler(this.checkBox_mergeNPC_MouseEnter);
            this.checkBox_mergeNPC.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // checkBox_mergePets
            // 
            this.checkBox_mergePets.AutoSize = true;
            this.checkBox_mergePets.Location = new System.Drawing.Point(6, 44);
            this.checkBox_mergePets.Name = "checkBox_mergePets";
            this.checkBox_mergePets.Size = new System.Drawing.Size(284, 17);
            this.checkBox_mergePets.TabIndex = 3;
            this.checkBox_mergePets.Text = "Merge all pet data to owner and remove pet from listing";
            this.checkBox_mergePets.UseVisualStyleBackColor = true;
            this.checkBox_mergePets.MouseEnter += new System.EventHandler(this.checkBox_mergePets_MouseEnter);
            this.checkBox_mergePets.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_clearAll);
            this.groupBox1.Controls.Add(this.button_remove);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.textBox_player);
            this.groupBox1.Controls.Add(this.listBox_players);
            this.groupBox1.Location = new System.Drawing.Point(15, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 188);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Detection";
            this.groupBox1.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.groupBox1.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add / Remove Player";
            this.label2.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // button_clearAll
            // 
            this.button_clearAll.Location = new System.Drawing.Point(296, 64);
            this.button_clearAll.Name = "button_clearAll";
            this.button_clearAll.Size = new System.Drawing.Size(60, 23);
            this.button_clearAll.TabIndex = 9;
            this.button_clearAll.Text = "Clear All";
            this.button_clearAll.UseVisualStyleBackColor = true;
            this.button_clearAll.Click += new System.EventHandler(this.button_clearAll_Click);
            this.button_clearAll.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.button_clearAll.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(225, 64);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(65, 23);
            this.button_remove.TabIndex = 8;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            this.button_remove.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.button_remove.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(185, 64);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(34, 23);
            this.button_add.TabIndex = 7;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            this.button_add.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.button_add.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // textBox_player
            // 
            this.textBox_player.Location = new System.Drawing.Point(185, 38);
            this.textBox_player.Name = "textBox_player";
            this.textBox_player.Size = new System.Drawing.Size(171, 20);
            this.textBox_player.TabIndex = 6;
            this.textBox_player.TextChanged += new System.EventHandler(this.textBox_player_TextChanged);
            this.textBox_player.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.textBox_player.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // listBox_players
            // 
            this.listBox_players.FormattingEnabled = true;
            this.listBox_players.Location = new System.Drawing.Point(6, 19);
            this.listBox_players.Name = "listBox_players";
            this.listBox_players.Size = new System.Drawing.Size(172, 160);
            this.listBox_players.TabIndex = 5;
            this.listBox_players.SelectedIndexChanged += new System.EventHandler(this.listBox_players_SelectedIndexChanged);
            this.listBox_players.MouseEnter += new System.EventHandler(this.playerNameControls_MouseEnter);
            this.listBox_players.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_mergeNPC);
            this.groupBox2.Controls.Add(this.checkBox_mergePets);
            this.groupBox2.Location = new System.Drawing.Point(15, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // ML_Parser
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ML_Parser";
            this.Size = new System.Drawing.Size(399, 380);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_mergeNPC;
        private System.Windows.Forms.CheckBox checkBox_mergePets;
        private GroupBox groupBox1;
        private TextBox textBox_player;
        private ListBox listBox_players;
        private GroupBox groupBox2;
        private Button button_clearAll;
        private Button button_remove;
        private Button button_add;
        private Label label2;

        #endregion

        public MLParsing_Plugin()
        {
            InitializeComponent();
        }

        internal static string[] separatorLog = new string[] { "::", "," };

        // NOTE: The values of "Unknown" and "UNKNOWN" short-circuit the ally determination code.  Must use one of these two names.
        //       Information from EQAditu.
        internal static string unknown = "UNKNOWN", unknownID = "C[0 Unknown]", unknownAbility = "Unknown Ability";

        internal static CultureInfo cultureLog = new CultureInfo("en-US");

        // This is for SQL syntax; do not change
        internal static CultureInfo usCulture = new CultureInfo("en-US");

        private PetOwnerRegistery petOwnerRegistery = new PetOwnerRegistery();
        private EntityOwnerRegistery entityOwnerRegistery = new EntityOwnerRegistery();

        private UnmatchedShieldLines unmatchedShieldLines = new UnmatchedShieldLines();

        // For tracking source of Chaotic Growth heals.
        private Dictionary<string, ChaoticGrowthInfo> magicMissileLastHit = new Dictionary<string, ChaoticGrowthInfo>();

        private Dictionary<string, bool> playerCharacterNames = new Dictionary<string, bool>();
        private bool playersCharacterFound = false;

        // Instant when the current combat action took place
        private DateTime curActionTime = DateTime.MinValue;

        Label lblStatus = null;

        TreeNode optionsNode = null;

        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "neverwinter.config.xml");
        SettingsSerializer xmlSettings;

        private int parsedLineCount = 0;
        private int errorLineCount = 0;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            // Push the option screen into the option tab
            int dcIndex = -1;
            for (int i = 0; i < ActGlobals.oFormActMain.OptionsTreeView.Nodes.Count; i++)
            {
                if (ActGlobals.oFormActMain.OptionsTreeView.Nodes[i].Text == "Magic Legends")
                    dcIndex = i;
            }
            if (dcIndex != -1)
            {
                optionsNode = ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Nodes.Add("General");
                ActGlobals.oFormActMain.OptionsControlSets.Add(@"Magic Legends\General", new List<Control> { this });
                Label lblConfig = new Label();
                lblConfig.AutoSize = true;
                lblConfig.Text = "Find the applicable options in the Options tab, Magic Legends section.";
                pluginScreenSpace.Controls.Add(lblConfig);
            }
            else
            {
                ActGlobals.oFormActMain.OptionsTreeView.Nodes.Add("Magic Legends");
                dcIndex = ActGlobals.oFormActMain.OptionsTreeView.Nodes.Count - 1;
                optionsNode = ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Nodes.Add("General");
                ActGlobals.oFormActMain.OptionsControlSets.Add(@"Magic Legends\General", new List<Control> { this });
                Label lblConfig = new Label();
                lblConfig.AutoSize = true;
                lblConfig.Text = "Find the applicable options in the Options tab, Magic Legends section.";
                pluginScreenSpace.Controls.Add(lblConfig);
            }
            ActGlobals.oFormActMain.OptionsTreeView.Nodes[dcIndex].Expand();

            // Magic Legends settings file
            xmlSettings = new SettingsSerializer(this);
            LoadSettings();

            // Setting this Regex will allow ACT to extract the character's name from the file name as the first capture group
            // when opening new log files. We'll say the log file name may look like "20080706-Player.log"
            ActGlobals.oFormActMain.LogPathHasCharName = false;

            // A windows file system filter to search updated log files with.
            ActGlobals.oFormActMain.LogFileFilter = "Combat*.log";

            // If all log files are in a single folder, this isn't an issue. If log files are split into different folders,
            // enter the parent folder name here. This way ACT will monitor that base folder and all sub-folders for updated files.
            ActGlobals.oFormActMain.LogFileParentFolderName = "GameClient";

            // Then to apply the settings and restart the log checking thread
            try
            {
                ActGlobals.oFormActMain.ResetCheckLogs();
            }
            catch
            {
                // Ignore when no log file is currently open
            }

            // This is the absolute path of where you wish ACT generated macro exports to be put. I'll leave it up to you
            // to determine this path programatically. If left blank, ACT will attempt to find EQ2 by registry or log file parents.
            // ActGlobals.oFormActMain.GameMacroFolder = @"C:\Program Files\Game Company\Game Folder";

            // Lets say that the log file time stamp is like: "[13:42:57]"
            // ACT needs to know the length of the timestamp and spacing at the beginning of the log line
            ActGlobals.oFormActMain.TimeStampLen = 19; // Remember to include spaces after the time stamp

            // Replace ACT's default DateTime parser with your own implementation matching your format
            ActGlobals.oFormActMain.GetDateTimeFromLog = new FormActMain.DateTimeLogParser(ParseDateTime);

            // This Regex is only used by a quick parsing method to find the current zone name based on a file position
            // If you do not define this correctly, the quick parser will fail and take a while to do so.
            // You still need to implement a zone change parser in your engine regardless of this
            // ActGlobals.oFormActMain.ZoneChangeRegex = new Regex(@"You have entered: (.+)\.", RegexOptions.Compiled);

            // All of your parsing engine will be based off of this event
            // You should not use Before/AfterCombatAction as you may enter infinite loops. AfterLogLineRead is okay, but not recommended
            ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(oFormActMain_BeforeLogLineRead);

            // Hooks for periodic pet cache purge
            ActGlobals.oFormActMain.OnCombatEnd += new CombatToggleEventDelegate(oFormActMain_OnCombatEnd);
            ActGlobals.oFormActMain.LogFileChanged += new LogFileChangedDelegate(oFormActMain_LogFileChanged);

            FixupCombatDataStructures();

            // Set status text to successfully loaded
            lblStatus = pluginStatusText;
            lblStatus.Text = "Magic Legends ACT plugin loaded";
        }

        
        
        private string GetIDCommas()
        {
            return ActGlobals.mainTableShowCommas ? "#,0" : "0";
        }

        private string GetFloatCommas()
        {
            return ActGlobals.mainTableShowCommas ? "#,0.00" : "0.00";
        }
        
        private string GetCellDataBaseDamage(MasterSwing Data)
        {
            object damBaseObj;

            if (Data.Tags.TryGetValue("BaseDamage", out damBaseObj))
            {
                float d = (float)damBaseObj;
                if (d == 0) return "";
                return d.ToString("F1");
            }

            return "";
        }

        private string GetSqlDataBaseDamage(MasterSwing Data)
        {
            object damBaseObj;

            if (Data.Tags.TryGetValue("BaseDamage", out damBaseObj))
            {
                float d = (float)damBaseObj;
                return d.ToString();
            }

            return "0";
        }

        private int MasterSwingCompareBaseDamage(MasterSwing Left, MasterSwing Right)
        {
            object l;
            object r;

            bool lvalid = Left.Tags.TryGetValue("BaseDamage", out l);
            bool rvalid = Right.Tags.TryGetValue("BaseDamage", out r);

            if (lvalid && rvalid)
            {
                float dl = (float)l;
                float dr = (float)r;

                return dl.CompareTo(dr);
            }
            else
            {
                if (lvalid) { return 1; }
                else if (rvalid) { return -1; }
                else { return 0; }
            }
        }

        private string GetCellDataEffectiveness(MasterSwing Data)
        {
            object effObj;

            if (Data.Tags.TryGetValue("Effectiveness", out effObj))
            {
                float d = (float)effObj;
                return d.ToString("P1");
            }

            return "";
        }

        private string GetSqlDataEffectiveness(MasterSwing Data)
        {
            object effObj;

            if (Data.Tags.TryGetValue("Effectiveness", out effObj))
            {
                double d = (float)effObj;
                return d.ToString();
            }

            return "0";
        }

        private int MasterSwingCompareEffectiveness(MasterSwing Left, MasterSwing Right)
        {
            object l;
            object r;

            bool lvalid = Left.Tags.TryGetValue("Effectiveness", out l);
            bool rvalid = Right.Tags.TryGetValue("Effectiveness", out r);

            if (lvalid && rvalid)
            {
                float dl = (float)l;
                float dr = (float)r;

                return dl.CompareTo(dr);
            }
            else
            {
                if (lvalid) { return 1; }
                else if (rvalid) { return -1; }
                else { return 0; }
            }
        }

        private string GetCellDataDamage(MasterSwing Data)
        {
            object d;
            if (Data.Tags.TryGetValue("DamageF", out d))
            {
                float df = (float)d;
                if (df > 0.0)
                {
                    return df.ToString("F1");
                }
            }

            return Data.Damage.ToString();
        }

        private float GetDmgToShieldValue(MasterSwing Data)
        {
            object d;
            if (Data.Tags.TryGetValue("ShieldDmgF", out d))
            {
                float df = (float)d;
                return df;
            }
            else
            {
                return 0;
            }
        }

        private string GetCellDataDmgToShield(MasterSwing Data)
        {
            return GetDmgToShieldValue(Data).ToString("F1");
        }

        private string GetSqlDataDmgToShield(MasterSwing Data)
        {
            return GetDmgToShieldValue(Data).ToString("F1");
        }

        private int MasterSwingCompareDmgToShield(MasterSwing Left, MasterSwing Right)
        {
            return GetDmgToShieldValue(Left).CompareTo(GetDmgToShieldValue(Right));
        }

        private float GetShieldPValue(MasterSwing Data)
        {
            object d;
            if (Data.Tags.TryGetValue("ShieldP", out d))
            {
                float df = (float)d;
                return df;
            }
            else
            {
                return 0;
            }
        }

        private string GetCellDataShieldP(MasterSwing Data)
        {
            return GetShieldPValue(Data).ToString("P1");
        }

        private string GetSqlDataShieldP(MasterSwing Data)
        {
            return GetShieldPValue(Data).ToString("P1");
        }

        private int MasterSwingCompareShieldP(MasterSwing Left, MasterSwing Right)
        {
            return GetShieldPValue(Left).CompareTo(GetShieldPValue(Right));
        }

        private double GetDTEffectivenessValue(DamageTypeData Data)
        {
            if (Data.Items.Count == 0) return Double.NaN;

            AttackType at = Data.Items["All"];
            return GetAAEffectiveness(at);
        }

        private string GetCellDataEffectiveness(DamageTypeData Data)
        {
            return GetDTEffectivenessValue(Data).ToString("P1");
        }

        private string GetSqlDataEffectiveness(DamageTypeData Data)
        {
            return GetDTEffectivenessValue(Data).ToString("P1");
        }

        private double GetAAEffectiveness(AttackType Data)
        {
            double dmgTotal = 0;
            double baseDmgTotal = 0;
            double effectiveness = 0.0;

            if (Data.Items.Count == 0) return Double.NaN;
            
            int count = Data.Items.Count;

            for (int i=0; i<count; i++)
            {
                MasterSwing ms = Data.Items[i];

                object damBaseObj;
                object damObj;

                if (ms.Tags.TryGetValue("BaseDamage", out damBaseObj))
                {
                    ms.Tags.TryGetValue("DamageF", out damObj);

                    float bd = (float)damBaseObj;
                    float d = (float)damObj;

                    if (bd > 0)
                    {
                        dmgTotal += d;
                        baseDmgTotal += bd;
                    }
                }
            }

            effectiveness = (double) dmgTotal / (double) baseDmgTotal;

            Data.Tags["effectivenessCacheCount"] = count;
            Data.Tags["effectivenessCacheValue"] = effectiveness;

            return effectiveness;
        }

        private string GetCellDataEffectiveness(AttackType Data)
        {
            return GetAAEffectiveness(Data).ToString("P1");
        }

        private string GetSqlDataEffectiveness(AttackType Data)
        {
            return GetAAEffectiveness(Data).ToString("P1");
        }

        private int AttackTypeCompareEffectiveness(AttackType Left, AttackType Right)
        {
            return GetAAEffectiveness(Left).CompareTo(GetAAEffectiveness(Right));
        }

        private string GetCellDataDmgEffectPrec(CombatantData Data)
        {
            return GetCellDataEffectiveness(Data.Items["Outgoing Damage"]);
        }

        private string GetSqlDataDmgEffectPrec(CombatantData Data)
        {
            return GetSqlDataEffectiveness(Data.Items["Outgoing Damage"]);
        }

        private int CDCompareDmgEffectPrec(CombatantData Left, CombatantData Right)
        {
            return GetDTEffectivenessValue(Left.Items["Outgoing Damage"]).CompareTo(GetDTEffectivenessValue(Right.Items["Outgoing Damage"]));
        }

        private string GetCellDataDmgTakenEffectPrec(CombatantData Data)
        {
            return GetCellDataEffectiveness(Data.Items["Incoming Damage"]);
        }

        private string GetSqlDataDmgTakenEffectPrec(CombatantData Data)
        {
            return GetSqlDataEffectiveness(Data.Items["Incoming Damage"]);
        }

        private int CDCompareDmgTakenEffectPrec(CombatantData Left, CombatantData Right)
        {
            return GetDTEffectivenessValue(Left.Items["Incoming Damage"]).CompareTo(GetDTEffectivenessValue(Right.Items["Incoming Damage"]));
        }


        private void FixupCombatDataStructures()
        {
            // - Remove data types that do not apply to Magic Legends combat logs.
            // - Add new data types just for Magic Legends.

            EncounterData.ColumnDefs.Clear();
            EncounterData.ColumnDefs.Add("EncId", new EncounterData.ColumnDef("EncId", false, "CHAR(8)", "EncId", (Data) => { return string.Empty; }, (Data) => { return Data.EncId; }));
            EncounterData.ColumnDefs.Add("Title", new EncounterData.ColumnDef("Title", true, "VARCHAR(64)", "Title", (Data) => { return Data.Title; }, (Data) => { return Data.Title; }));
            EncounterData.ColumnDefs.Add("StartTime", new EncounterData.ColumnDef("StartTime", true, "TIMESTAMP", "StartTime", (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : String.Format("{0} {1}", Data.StartTime.ToShortDateString(), Data.StartTime.ToLongTimeString()); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString("u").TrimEnd(new char[] { 'Z' }); }));
            EncounterData.ColumnDefs.Add("EndTime", new EncounterData.ColumnDef("EndTime", true, "TIMESTAMP", "EndTime", (Data) => { return Data.EndTime == DateTime.MinValue ? "--:--:--" : Data.EndTime.ToString("T"); }, (Data) => { return Data.EndTime == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString("u").TrimEnd(new char[] { 'Z' }); }));
            EncounterData.ColumnDefs.Add("Duration", new EncounterData.ColumnDef("Duration", true, "INT", "Duration", (Data) => { return Data.DurationS; }, (Data) => { return Data.Duration.TotalSeconds.ToString("0"); }));
            EncounterData.ColumnDefs.Add("Damage", new EncounterData.ColumnDef("Damage", true, "BIGINT", "Damage", (Data) => { return (Data.Damage / 10).ToString(GetIDCommas()); }, (Data) => { return Data.Damage.ToString(); }));
            EncounterData.ColumnDefs.Add("EncDPS", new EncounterData.ColumnDef("EncDPS", true, "DOUBLE", "EncDPS", (Data) => { return Data.DPS.ToString(GetFloatCommas()); }, (Data) => { return Data.DPS.ToString(usCulture); }));
            EncounterData.ColumnDefs.Add("Zone", new EncounterData.ColumnDef("Zone", false, "VARCHAR(64)", "Zone", (Data) => { return Data.ZoneName; }, (Data) => { return Data.ZoneName; }));
            EncounterData.ColumnDefs.Add("Kills", new EncounterData.ColumnDef("Kills", true, "INT", "Kills", (Data) => { return Data.AlliedKills.ToString(GetIDCommas()); }, (Data) => { return Data.AlliedKills.ToString(); }));
            EncounterData.ColumnDefs.Add("Deaths", new EncounterData.ColumnDef("Deaths", true, "INT", "Deaths", (Data) => { return Data.AlliedDeaths.ToString(); }, (Data) => { return Data.AlliedDeaths.ToString(); }));

            EncounterData.ExportVariables.Clear();
            EncounterData.ExportVariables.Add("n", new EncounterData.TextExportFormatter("n", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-newline"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-newline"].DisplayedText, (Data, SelectiveAllies, Extra) => { return "\n"; }));
            EncounterData.ExportVariables.Add("t", new EncounterData.TextExportFormatter("t", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tab"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tab"].DisplayedText, (Data, SelectiveAllies, Extra) => { return "\t"; }));
            EncounterData.ExportVariables.Add("title", new EncounterData.TextExportFormatter("title", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-title"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-title"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "title", Extra); }));
            EncounterData.ExportVariables.Add("duration", new EncounterData.TextExportFormatter("duration", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-duration"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-duration"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "duration", Extra); }));
            EncounterData.ExportVariables.Add("DURATION", new EncounterData.TextExportFormatter("DURATION", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DURATION"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DURATION"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "DURATION", Extra); }));
            EncounterData.ExportVariables.Add("damage", new EncounterData.TextExportFormatter("damage", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "damage", Extra); }));
            EncounterData.ExportVariables.Add("damage-m", new EncounterData.TextExportFormatter("damage-m", "Damage M", "Damage divided by 1,000,000 (with two decimal places)", (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "damage-m", Extra); }));
            EncounterData.ExportVariables.Add("DAMAGE-k", new EncounterData.TextExportFormatter("DAMAGE-k", "Short Damage K", "Damage divided by 1,000 (with no decimal places)", (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "DAMAGE-k", Extra); }));
            EncounterData.ExportVariables.Add("DAMAGE-m", new EncounterData.TextExportFormatter("DAMAGE-m", "Short Damage M", "Damage divided by 1,000,000 (with no decimal places)", (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "DAMAGE-m", Extra); }));
            EncounterData.ExportVariables.Add("dps", new EncounterData.TextExportFormatter("dps", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-dps"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-dps"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "dps", Extra); }));
            EncounterData.ExportVariables.Add("DPS", new EncounterData.TextExportFormatter("DPS", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DPS"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DPS"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "DPS", Extra); }));
            EncounterData.ExportVariables.Add("DPS-k", new EncounterData.TextExportFormatter("DPS-k", "DPS K", "DPS divided by 1,000 (with no decimal places)", (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "DPS-k", Extra); }));
            EncounterData.ExportVariables.Add("encdps", new EncounterData.TextExportFormatter("encdps", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-extdps"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-extdps"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "encdps", Extra); }));
            EncounterData.ExportVariables.Add("ENCDPS", new EncounterData.TextExportFormatter("ENCDPS", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTDPS"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTDPS"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "ENCDPS", Extra); }));
            EncounterData.ExportVariables.Add("ENCDPS-k", new EncounterData.TextExportFormatter("ENCDPS-k", "Short DPS K", "ENCDPS divided by 1,000 (with no decimal places)", (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "ENCDPS-k", Extra); }));
            EncounterData.ExportVariables.Add("hits", new EncounterData.TextExportFormatter("hits", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hits"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hits"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "hits", Extra); }));
            EncounterData.ExportVariables.Add("crithits", new EncounterData.TextExportFormatter("crithits", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithits"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithits"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "crithits", Extra); }));
            EncounterData.ExportVariables.Add("crithit%", new EncounterData.TextExportFormatter("crithit%", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithit%"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithit%"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "crithit%", Extra); }));
            EncounterData.ExportVariables.Add("misses", new EncounterData.TextExportFormatter("misses", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-misses"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-misses"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "misses", Extra); }));
            EncounterData.ExportVariables.Add("hitfailed", new EncounterData.TextExportFormatter("hitfailed", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hitfailed"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hitfailed"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "hitfailed", Extra); }));
            EncounterData.ExportVariables.Add("swings", new EncounterData.TextExportFormatter("swings", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-swings"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-swings"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "swings", Extra); }));
            EncounterData.ExportVariables.Add("tohit", new EncounterData.TextExportFormatter("tohit", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tohit"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tohit"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "tohit", Extra); }));
            EncounterData.ExportVariables.Add("TOHIT", new EncounterData.TextExportFormatter("TOHIT", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-TOHIT"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-TOHIT"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "TOHIT", Extra); }));
            EncounterData.ExportVariables.Add("maxhit", new EncounterData.TextExportFormatter("maxhit", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhit"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhit"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "maxhit", Extra); }));
            EncounterData.ExportVariables.Add("MAXHIT", new EncounterData.TextExportFormatter("MAXHIT", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHIT"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHIT"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "MAXHIT", Extra); }));
            EncounterData.ExportVariables.Add("healed", new EncounterData.TextExportFormatter("healed", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "healed", Extra); }));
            EncounterData.ExportVariables.Add("enchps", new EncounterData.TextExportFormatter("enchps", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-exthps"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-exthps"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "enchps", Extra); }));
            EncounterData.ExportVariables.Add("ENCHPS", new EncounterData.TextExportFormatter("ENCHPS", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTHPS"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTHPS"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "ENCHPS", Extra); }));
            EncounterData.ExportVariables.Add("ENCHPS-k", new EncounterData.TextExportFormatter("ENCHPS", "Short ENCHPS K", "ENCHPS divided by 1,000 (with no decimal places)", (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "ENCHPS-k", Extra); }));
            EncounterData.ExportVariables.Add("critheals", new EncounterData.TextExportFormatter("critheals", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheals"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheals"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "critheals", Extra); }));
            EncounterData.ExportVariables.Add("critheal%", new EncounterData.TextExportFormatter("critheal%", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheal%"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheal%"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "critheal%", Extra); }));
            EncounterData.ExportVariables.Add("heals", new EncounterData.TextExportFormatter("heals", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-heals"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-heals"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "heals", Extra); }));
            EncounterData.ExportVariables.Add("maxheal", new EncounterData.TextExportFormatter("maxheal", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxheal"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxheal"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "maxheal", Extra); }));
            EncounterData.ExportVariables.Add("MAXHEAL", new EncounterData.TextExportFormatter("MAXHEAL", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEAL"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEAL"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "MAXHEAL", Extra); }));
            //EncounterData.ExportVariables.Add("maxhealward", new EncounterData.TextExportFormatter("maxhealward", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhealward"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhealward"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "maxhealward", Extra); }));
            //EncounterData.ExportVariables.Add("MAXHEALWARD", new EncounterData.TextExportFormatter("MAXHEALWARD", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEALWARD"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEALWARD"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "MAXHEALWARD", Extra); }));
            EncounterData.ExportVariables.Add("damagetaken", new EncounterData.TextExportFormatter("damagetaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damagetaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damagetaken"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "damagetaken", Extra); }));
            EncounterData.ExportVariables.Add("healstaken", new EncounterData.TextExportFormatter("healstaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healstaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healstaken"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "healstaken", Extra); }));
            //EncounterData.ExportVariables.Add("powerdrain", new EncounterData.TextExportFormatter("powerdrain", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerdrain"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerdrain"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "powerdrain", Extra); }));
            EncounterData.ExportVariables.Add("powerheal", new EncounterData.TextExportFormatter("powerheal", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerheal"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerheal"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "powerheal", Extra); }));
            EncounterData.ExportVariables.Add("kills", new EncounterData.TextExportFormatter("kills", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-kills"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-kills"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "kills", Extra); }));
            EncounterData.ExportVariables.Add("deaths", new EncounterData.TextExportFormatter("deaths", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-deaths"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-deaths"].DisplayedText, (Data, SelectiveAllies, Extra) => { return EncounterFormatSwitch(Data, SelectiveAllies, "deaths", Extra); }));


            CombatantData.ColumnDefs.Clear();
            CombatantData.ColumnDefs.Add("EncId", new CombatantData.ColumnDef("EncId", false, "CHAR(8)", "EncId", (Data) => { return string.Empty; }, (Data) => { return Data.Parent.EncId; }, (Left, Right) => { return 0; }));
            CombatantData.ColumnDefs.Add("Ally", new CombatantData.ColumnDef("Ally", false, "CHAR(1)", "Ally", (Data) => { return Data.Parent.GetAllies().Contains(Data).ToString(); }, (Data) => { return Data.Parent.GetAllies().Contains(Data) ? "T" : "F"; }, (Left, Right) => { return Left.Parent.GetAllies().Contains(Left).CompareTo(Right.Parent.GetAllies().Contains(Right)); }));
            CombatantData.ColumnDefs.Add("Name", new CombatantData.ColumnDef("Name", true, "VARCHAR(64)", "Name", (Data) => { return Data.Name; }, (Data) => { return Data.Name; }, (Left, Right) => { return Left.Name.CompareTo(Right.Name); }));
            CombatantData.ColumnDefs.Add("StartTime", new CombatantData.ColumnDef("StartTime", true, "TIMESTAMP", "StartTime", (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString("u").TrimEnd(new char[] { 'Z' }); }, (Left, Right) => { return Left.StartTime.CompareTo(Right.StartTime); }));
            CombatantData.ColumnDefs.Add("EndTime", new CombatantData.ColumnDef("EndTime", false, "TIMESTAMP", "EndTime", (Data) => { return Data.EndTime == DateTime.MinValue ? "--:--:--" : Data.StartTime.ToString("T"); }, (Data) => { return Data.EndTime == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString("u").TrimEnd(new char[] { 'Z' }); }, (Left, Right) => { return Left.EndTime.CompareTo(Right.EndTime); }));
            CombatantData.ColumnDefs.Add("Duration", new CombatantData.ColumnDef("Duration", true, "INT", "Duration", (Data) => { return Data.DurationS; }, (Data) => { return Data.Duration.TotalSeconds.ToString("0"); }, (Left, Right) => { return Left.Duration.CompareTo(Right.Duration); }));
            CombatantData.ColumnDefs.Add("Damage", new CombatantData.ColumnDef("Damage", true, "BIGINT", "Damage", (Data) => { return Data.Damage.ToString(GetIDCommas()); }, (Data) => { return Data.Damage.ToString(); }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));
            CombatantData.ColumnDefs.Add("Damage%", new CombatantData.ColumnDef("Damage%", true, "VARCHAR(4)", "DamagePerc", (Data) => { return Data.DamagePercent; }, (Data) => { return Data.DamagePercent; }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));
            CombatantData.ColumnDefs.Add("Kills", new CombatantData.ColumnDef("Kills", false, "INT", "Kills", (Data) => { return Data.Kills.ToString(GetIDCommas()); }, (Data) => { return Data.Kills.ToString(); }, (Left, Right) => { return Left.Kills.CompareTo(Right.Kills); }));
            CombatantData.ColumnDefs.Add("Healed", new CombatantData.ColumnDef("Healed", false, "BIGINT", "Healed", (Data) => { return Data.Healed.ToString(GetIDCommas()); }, (Data) => { return Data.Healed.ToString(); }, (Left, Right) => { return Left.Healed.CompareTo(Right.Healed); }));
            CombatantData.ColumnDefs.Add("Healed%", new CombatantData.ColumnDef("Healed%", false, "VARCHAR(4)", "HealedPerc", (Data) => { return Data.HealedPercent; }, (Data) => { return Data.HealedPercent; }, (Left, Right) => { return Left.Healed.CompareTo(Right.Healed); }));
//            CombatantData.ColumnDefs.Add("CritHeals", new CombatantData.ColumnDef("CritHeals", false, "INT", "CritHeals", (Data) => { return Data.CritHeals.ToString(GetIDCommas()); }, (Data) => { return Data.CritHeals.ToString(); }, (Left, Right) => { return Left.CritHeals.CompareTo(Right.CritHeals); }));
            CombatantData.ColumnDefs.Add("Heals", new CombatantData.ColumnDef("Heals", false, "INT", "Heals", (Data) => { return Data.Heals.ToString(GetIDCommas()); }, (Data) => { return Data.Heals.ToString(); }, (Left, Right) => { return Left.Heals.CompareTo(Right.Heals); }));
            //CombatantData.ColumnDefs.Add("PowerDrain", new CombatantData.ColumnDef("PowerDrain", true, "BIGINT", "PowerDrain", (Data) => { return Data.PowerDamage.ToString(GetIDCommas()); }, (Data) => { return Data.PowerDamage.ToString(); }, (Left, Right) => { return Left.PowerDamage.CompareTo(Right.PowerDamage); }));
            CombatantData.ColumnDefs.Add("PowerReplenish", new CombatantData.ColumnDef("PowerReplenish", false, "BIGINT", "PowerReplenish", (Data) => { return Data.PowerReplenish.ToString(GetIDCommas()); }, (Data) => { return Data.PowerReplenish.ToString(); }, (Left, Right) => { return Left.PowerReplenish.CompareTo(Right.PowerReplenish); }));
            CombatantData.ColumnDefs.Add("DPS", new CombatantData.ColumnDef("DPS", false, "DOUBLE", "DPS", (Data) => { return Data.DPS.ToString(GetFloatCommas()); }, (Data) => { return Data.DPS.ToString(usCulture); }, (Left, Right) => { return Left.DPS.CompareTo(Right.DPS); }));
            CombatantData.ColumnDefs.Add("EncDPS", new CombatantData.ColumnDef("EncDPS", true, "DOUBLE", "EncDPS", (Data) => { return Data.EncDPS.ToString(GetFloatCommas()); }, (Data) => { return Data.EncDPS.ToString(usCulture); }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));
            CombatantData.ColumnDefs.Add("EncHPS", new CombatantData.ColumnDef("EncHPS", true, "DOUBLE", "EncHPS", (Data) => { return Data.EncHPS.ToString(GetFloatCommas()); }, (Data) => { return Data.EncHPS.ToString(usCulture); }, (Left, Right) => { return Left.Healed.CompareTo(Right.Healed); }));
            CombatantData.ColumnDefs.Add("Hits", new CombatantData.ColumnDef("Hits", false, "INT", "Hits", (Data) => { return Data.Hits.ToString(GetIDCommas()); }, (Data) => { return Data.Hits.ToString(); }, (Left, Right) => { return Left.Hits.CompareTo(Right.Hits); }));
//            CombatantData.ColumnDefs.Add("CritHits", new CombatantData.ColumnDef("CritHits", false, "INT", "CritHits", (Data) => { return Data.CritHits.ToString(GetIDCommas()); }, (Data) => { return Data.CritHits.ToString(); }, (Left, Right) => { return Left.CritHits.CompareTo(Right.CritHits); }));
//            CombatantData.ColumnDefs.Add("Avoids", new CombatantData.ColumnDef("Avoids", false, "INT", "Blocked", (Data) => { return Data.Blocked.ToString(GetIDCommas()); }, (Data) => { return Data.Blocked.ToString(); }, (Left, Right) => { return Left.Blocked.CompareTo(Right.Blocked); }));
//            CombatantData.ColumnDefs.Add("Misses", new CombatantData.ColumnDef("Misses", false, "INT", "Misses", (Data) => { return Data.Misses.ToString(GetIDCommas()); }, (Data) => { return Data.Misses.ToString(); }, (Left, Right) => { return Left.Misses.CompareTo(Right.Misses); }));
            CombatantData.ColumnDefs.Add("Swings", new CombatantData.ColumnDef("Swings", false, "INT", "Swings", (Data) => { return Data.Swings.ToString(GetIDCommas()); }, (Data) => { return Data.Swings.ToString(); }, (Left, Right) => { return Left.Swings.CompareTo(Right.Swings); }));
            CombatantData.ColumnDefs.Add("HealingTaken", new CombatantData.ColumnDef("HealingTaken", false, "BIGINT", "HealsTaken", (Data) => { return Data.HealsTaken.ToString(GetIDCommas()); }, (Data) => { return Data.HealsTaken.ToString(); }, (Left, Right) => { return Left.HealsTaken.CompareTo(Right.HealsTaken); }));
            CombatantData.ColumnDefs.Add("DamageTaken", new CombatantData.ColumnDef("DamageTaken", true, "BIGINT", "DamageTaken", (Data) => { return Data.DamageTaken.ToString(GetIDCommas()); }, (Data) => { return Data.DamageTaken.ToString(); }, (Left, Right) => { return Left.DamageTaken.CompareTo(Right.DamageTaken); }));
            CombatantData.ColumnDefs.Add("Deaths", new CombatantData.ColumnDef("Deaths", true, "INT", "Deaths", (Data) => { return Data.Deaths.ToString(GetIDCommas()); }, (Data) => { return Data.Deaths.ToString(); }, (Left, Right) => { return Left.Deaths.CompareTo(Right.Deaths); }));
//            CombatantData.ColumnDefs.Add("ToHit%", new CombatantData.ColumnDef("ToHit%", false, "FLOAT", "ToHit", (Data) => { return Data.ToHit.ToString(GetFloatCommas()); }, (Data) => { return Data.ToHit.ToString(usCulture); }, (Left, Right) => { return Left.ToHit.CompareTo(Right.ToHit); }));
            //CombatantData.ColumnDefs.Add("FCritHit%", new CombatantData.ColumnDef("FCritHit%", true, "VARCHAR(8)", "FCritHitPerc", (Data) => { return GetFilteredCritChance(Data).ToString("0'%"); }, (Data) => { return GetFilteredCritChance(Data).ToString("0'%"); }, (Left, Right) => { return GetFilteredCritChance(Left).CompareTo(GetFilteredCritChance(Right)); }));
//            CombatantData.ColumnDefs.Add("CritDam%", new CombatantData.ColumnDef("CritDam%", false, "VARCHAR(8)", "CritDamPerc", (Data) => { return Data.CritDamPerc.ToString("0'%"); }, (Data) => { return Data.CritDamPerc.ToString("0'%"); }, (Left, Right) => { return Left.CritDamPerc.CompareTo(Right.CritDamPerc); }));
//            CombatantData.ColumnDefs.Add("CritHeal%", new CombatantData.ColumnDef("CritHeal%", false, "VARCHAR(8)", "CritHealPerc", (Data) => { return Data.CritHealPerc.ToString("0'%"); }, (Data) => { return Data.CritHealPerc.ToString("0'%"); }, (Left, Right) => { return Left.CritHealPerc.CompareTo(Right.CritHealPerc); }));
            
            CombatantData.ColumnDefs.Add("DmgEffect%",
                new CombatantData.ColumnDef("DmgEffect%", false, "VARCHAR(8)", "DmgEffectPrec", GetCellDataDmgEffectPrec, GetSqlDataDmgEffectPrec, CDCompareDmgEffectPrec));
            CombatantData.ColumnDefs.Add("DmgTakenEffect%",
                new CombatantData.ColumnDef("DmgTakenEffect%", false, "VARCHAR(8)", "DmgTakenEffectPrec", GetCellDataDmgTakenEffectPrec, GetSqlDataDmgTakenEffectPrec, CDCompareDmgTakenEffectPrec));


            CombatantData.OutgoingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
		{
			//{"Auto-Attack (Out)", new CombatantData.DamageTypeDef("Auto-Attack (Out)", -1, Color.DarkGoldenrod)},
			//{"Skill/Ability (Out)", new CombatantData.DamageTypeDef("Skill/Ability (Out)", -1, Color.DarkOrange)},
			{"Outgoing Damage", new CombatantData.DamageTypeDef("Outgoing Damage", 0, Color.Orange)},
			{"Healed (Out)", new CombatantData.DamageTypeDef("Healed (Out)", 1, Color.Blue)},
			//{"Power Drain (Out)", new CombatantData.DamageTypeDef("Power Drain (Out)", -1, Color.Purple)},
			{"Power Replenish (Out)", new CombatantData.DamageTypeDef("Power Replenish (Out)", 1, Color.Violet)},
			{"All Outgoing (Ref)", new CombatantData.DamageTypeDef("All Outgoing (Ref)", 0, Color.Black)}
		};
            CombatantData.IncomingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
		{
			{"Incoming Damage", new CombatantData.DamageTypeDef("Incoming Damage", -1, Color.Red)},
			{"Healed (Inc)",new CombatantData.DamageTypeDef("Healed (Inc)", 1, Color.LimeGreen)},
			//{"Power Drain (Inc)",new CombatantData.DamageTypeDef("Power Drain (Inc)", -1, Color.Magenta)},
			{"Power Replenish (Inc)",new CombatantData.DamageTypeDef("Power Replenish (Inc)", 1, Color.MediumPurple)},
			{"All Incoming (Ref)",new CombatantData.DamageTypeDef("All Incoming (Ref)", 0, Color.Black)}
		};
            CombatantData.SwingTypeToDamageTypeDataLinksOutgoing = new SortedDictionary<int, List<string>>
		{ 
			{1, new List<string> { "Outgoing Damage" } },
			{2, new List<string> { "Outgoing Damage" } },
			{3, new List<string> { "Healed (Out)" } },
			{13, new List<string> { "Power Replenish (Out)" } }
		};
            CombatantData.SwingTypeToDamageTypeDataLinksIncoming = new SortedDictionary<int, List<string>>
		{ 
			{1, new List<string> { "Incoming Damage" } },
			{2, new List<string> { "Incoming Damage" } },
			{3, new List<string> { "Healed (Inc)" } },
			{13, new List<string> { "Power Replenish (Inc)" } }
		};

            CombatantData.DamageSwingTypes = new List<int> { 1, 2 };
            CombatantData.HealingSwingTypes = new List<int> { 3 };

            CombatantData.DamageTypeDataNonSkillDamage = "Auto-Attack (Out)";
            CombatantData.DamageTypeDataOutgoingDamage = "Outgoing Damage";
            CombatantData.DamageTypeDataOutgoingHealing = "Healed (Out)";
            CombatantData.DamageTypeDataIncomingDamage = "Incoming Damage";
            CombatantData.DamageTypeDataIncomingHealing = "Healed (Inc)";


            CombatantData.ExportVariables.Clear();
            CombatantData.ExportVariables.Add("n", new CombatantData.TextExportFormatter("n", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-newline"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-newline"].DisplayedText, (Data, Extra) => { return "\n"; }));
            CombatantData.ExportVariables.Add("t", new CombatantData.TextExportFormatter("t", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tab"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tab"].DisplayedText, (Data, Extra) => { return "\t"; }));
            CombatantData.ExportVariables.Add("name", new CombatantData.TextExportFormatter("name", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-name"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-name"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "name", Extra); }));
            CombatantData.ExportVariables.Add("NAME", new CombatantData.TextExportFormatter("NAME", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME", Extra); }));
            CombatantData.ExportVariables.Add("duration", new CombatantData.TextExportFormatter("duration", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-duration"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-duration"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "duration", Extra); }));
            CombatantData.ExportVariables.Add("DURATION", new CombatantData.TextExportFormatter("DURATION", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DURATION"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DURATION"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "DURATION", Extra); }));
            CombatantData.ExportVariables.Add("damage", new CombatantData.TextExportFormatter("damage", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "damage", Extra); }));
            CombatantData.ExportVariables.Add("damage-m", new CombatantData.TextExportFormatter("damage-m", "Damage M", "Damage divided by 1,000,000 (with two decimal places)", (Data, Extra) => { return CombatantFormatSwitch(Data, "damage-m", Extra); }));
            CombatantData.ExportVariables.Add("DAMAGE-k", new CombatantData.TextExportFormatter("DAMAGE-k", "Short Damage K", "Damage divided by 1,000 (with no decimal places)", (Data, Extra) => { return CombatantFormatSwitch(Data, "DAMAGE-k", Extra); }));
            CombatantData.ExportVariables.Add("DAMAGE-m", new CombatantData.TextExportFormatter("DAMAGE-m", "Short Damage M", "Damage divided by 1,000,000 (with no decimal places)", (Data, Extra) => { return CombatantFormatSwitch(Data, "DAMAGE-m", Extra); }));
            CombatantData.ExportVariables.Add("damage%", new CombatantData.TextExportFormatter("damage%", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damage%"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damage%"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "damage%", Extra); }));
            CombatantData.ExportVariables.Add("dps", new CombatantData.TextExportFormatter("dps", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-dps"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-dps"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "dps", Extra); }));
            CombatantData.ExportVariables.Add("DPS", new CombatantData.TextExportFormatter("DPS", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-DPS"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-DPS"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "DPS", Extra); }));
            CombatantData.ExportVariables.Add("DPS-k", new CombatantData.TextExportFormatter("DPS-k", "Short DPS K", "Short DPS divided by 1,000 (with no decimal places)", (Data, Extra) => { return CombatantFormatSwitch(Data, "DPS-k", Extra); }));
            CombatantData.ExportVariables.Add("encdps", new CombatantData.TextExportFormatter("encdps", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-extdps"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-extdps"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "encdps", Extra); }));
            CombatantData.ExportVariables.Add("ENCDPS", new CombatantData.TextExportFormatter("ENCDPS", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTDPS"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTDPS"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "ENCDPS", Extra); }));
            CombatantData.ExportVariables.Add("ENCDPS-k", new CombatantData.TextExportFormatter("ENCDPS-k", "Short Encounter DPS K", "Short Encounter DPS divided by 1,000 (with no decimal places)", (Data, Extra) => { return CombatantFormatSwitch(Data, "ENCDPS-k", Extra); }));
            CombatantData.ExportVariables.Add("hits", new CombatantData.TextExportFormatter("hits", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hits"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hits"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "hits", Extra); }));
//            CombatantData.ExportVariables.Add("crithits", new CombatantData.TextExportFormatter("crithits", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithits"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithits"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "crithits", Extra); }));
//            CombatantData.ExportVariables.Add("crithit%", new CombatantData.TextExportFormatter("crithit%", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-crithit%"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-crithit%"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "crithit%", Extra); }));
//            CombatantData.ExportVariables.Add("fcrithit%", new CombatantData.TextExportFormatter("fcrithit%", "Filtered Critical Hit Chance", "Critical Hit Chance filtered against AttackTypes that have the ability to critically hit.", (Data, Extra) => { return CombatantFormatSwitch(Data, "fcrithit%", Extra); }));
            CombatantData.ExportVariables.Add("misses", new CombatantData.TextExportFormatter("misses", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-misses"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-misses"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "misses", Extra); }));
            CombatantData.ExportVariables.Add("hitfailed", new CombatantData.TextExportFormatter("hitfailed", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-hitfailed"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-hitfailed"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "hitfailed", Extra); }));
            CombatantData.ExportVariables.Add("swings", new CombatantData.TextExportFormatter("swings", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-swings"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-swings"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "swings", Extra); }));
            CombatantData.ExportVariables.Add("tohit", new CombatantData.TextExportFormatter("tohit", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-tohit"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-tohit"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "tohit", Extra); }));
            CombatantData.ExportVariables.Add("TOHIT", new CombatantData.TextExportFormatter("TOHIT", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-TOHIT"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-TOHIT"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "TOHIT", Extra); }));
            CombatantData.ExportVariables.Add("maxhit", new CombatantData.TextExportFormatter("maxhit", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhit"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhit"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "maxhit", Extra); }));
            CombatantData.ExportVariables.Add("MAXHIT", new CombatantData.TextExportFormatter("MAXHIT", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHIT"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHIT"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "MAXHIT", Extra); }));
            CombatantData.ExportVariables.Add("healed", new CombatantData.TextExportFormatter("healed", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "healed", Extra); }));
            CombatantData.ExportVariables.Add("healed%", new CombatantData.TextExportFormatter("healed%", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healed%"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healed%"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "healed%", Extra); }));
            CombatantData.ExportVariables.Add("enchps", new CombatantData.TextExportFormatter("enchps", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-exthps"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-exthps"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "enchps", Extra); }));
            CombatantData.ExportVariables.Add("ENCHPS", new CombatantData.TextExportFormatter("ENCHPS", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-EXTHPS"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-EXTHPS"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "ENCHPS", Extra); }));
            CombatantData.ExportVariables.Add("ENCHPS-k", new CombatantData.TextExportFormatter("ENCHPS-k", "Short Encounter HPS K", "Short Encounter HPS divided by 1,000 (with no decimal places)", (Data, Extra) => { return CombatantFormatSwitch(Data, "ENCHPS-k", Extra); }));
//            CombatantData.ExportVariables.Add("critheals", new CombatantData.TextExportFormatter("critheals", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheals"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheals"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "critheals", Extra); }));
//            CombatantData.ExportVariables.Add("critheal%", new CombatantData.TextExportFormatter("critheal%", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-critheal%"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-critheal%"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "critheal%", Extra); }));
            CombatantData.ExportVariables.Add("heals", new CombatantData.TextExportFormatter("heals", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-heals"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-heals"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "heals", Extra); }));
            CombatantData.ExportVariables.Add("maxheal", new CombatantData.TextExportFormatter("maxheal", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxheal"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxheal"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "maxheal", Extra); }));
            CombatantData.ExportVariables.Add("MAXHEAL", new CombatantData.TextExportFormatter("MAXHEAL", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEAL"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEAL"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "MAXHEAL", Extra); }));
            //CombatantData.ExportVariables.Add("maxhealward", new CombatantData.TextExportFormatter("maxhealward", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-maxhealward"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-maxhealward"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "maxhealward", Extra); }));
            //CombatantData.ExportVariables.Add("MAXHEALWARD", new CombatantData.TextExportFormatter("MAXHEALWARD", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-MAXHEALWARD"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-MAXHEALWARD"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "MAXHEALWARD", Extra); }));
            CombatantData.ExportVariables.Add("damagetaken", new CombatantData.TextExportFormatter("damagetaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-damagetaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-damagetaken"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "damagetaken", Extra); }));
            CombatantData.ExportVariables.Add("healstaken", new CombatantData.TextExportFormatter("healstaken", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-healstaken"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-healstaken"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "healstaken", Extra); }));
            //CombatantData.ExportVariables.Add("powerdrain", new CombatantData.TextExportFormatter("powerdrain", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerdrain"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerdrain"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "powerdrain", Extra); }));
//            CombatantData.ExportVariables.Add("powerheal", new CombatantData.TextExportFormatter("powerheal", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-powerheal"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-powerheal"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "powerheal", Extra); }));
            CombatantData.ExportVariables.Add("kills", new CombatantData.TextExportFormatter("kills", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-kills"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-kills"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "kills", Extra); }));
            CombatantData.ExportVariables.Add("deaths", new CombatantData.TextExportFormatter("deaths", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-deaths"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-deaths"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "deaths", Extra); }));

//            CombatantData.ExportVariables.Add("NAME3", new CombatantData.TextExportFormatter("NAME3", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME3"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME3"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME3", Extra); }));
//            CombatantData.ExportVariables.Add("NAME4", new CombatantData.TextExportFormatter("NAME4", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME4"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME4"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME4", Extra); }));
//            CombatantData.ExportVariables.Add("NAME5", new CombatantData.TextExportFormatter("NAME5", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME5"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME5"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME5", Extra); }));
//            CombatantData.ExportVariables.Add("NAME6", new CombatantData.TextExportFormatter("NAME6", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME6"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME6"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME6", Extra); }));
//            CombatantData.ExportVariables.Add("NAME7", new CombatantData.TextExportFormatter("NAME7", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME7"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME7"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME7", Extra); }));
//            CombatantData.ExportVariables.Add("NAME8", new CombatantData.TextExportFormatter("NAME8", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME8"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME8"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME8", Extra); }));
//            CombatantData.ExportVariables.Add("NAME9", new CombatantData.TextExportFormatter("NAME9", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME9"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME9"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME9", Extra); }));
//            CombatantData.ExportVariables.Add("NAME10", new CombatantData.TextExportFormatter("NAME10", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME10"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME10"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME10", Extra); }));
//            CombatantData.ExportVariables.Add("NAME11", new CombatantData.TextExportFormatter("NAME11", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME11"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME11"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME11", Extra); }));
//            CombatantData.ExportVariables.Add("NAME12", new CombatantData.TextExportFormatter("NAME12", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME12"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME12"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME12", Extra); }));
//            CombatantData.ExportVariables.Add("NAME13", new CombatantData.TextExportFormatter("NAME13", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME13"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME13"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME13", Extra); }));
//            CombatantData.ExportVariables.Add("NAME14", new CombatantData.TextExportFormatter("NAME14", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME14"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME14"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME14", Extra); }));
//            CombatantData.ExportVariables.Add("NAME15", new CombatantData.TextExportFormatter("NAME15", ActGlobals.ActLocalization.LocalizationStrings["exportFormattingLabel-NAME15"].DisplayedText, ActGlobals.ActLocalization.LocalizationStrings["exportFormattingDesc-NAME15"].DisplayedText, (Data, Extra) => { return CombatantFormatSwitch(Data, "NAME15", Extra); }));


            DamageTypeData.ColumnDefs.Clear();
            DamageTypeData.ColumnDefs.Add("EncId", new DamageTypeData.ColumnDef("EncId", false, "CHAR(8)", "EncId", (Data) => { return string.Empty; }, (Data) => { return Data.Parent.Parent.EncId; }));
            DamageTypeData.ColumnDefs.Add("Combatant", new DamageTypeData.ColumnDef("Combatant", false, "VARCHAR(64)", "Combatant", (Data) => { return Data.Parent.Name; }, (Data) => { return Data.Parent.Name; }));
            DamageTypeData.ColumnDefs.Add("Grouping", new DamageTypeData.ColumnDef("Grouping", false, "VARCHAR(92)", "Grouping", (Data) => { return string.Empty; }, GetDamageTypeGrouping));
            DamageTypeData.ColumnDefs.Add("Type", new DamageTypeData.ColumnDef("Type", true, "VARCHAR(64)", "Type", (Data) => { return Data.Type; }, (Data) => { return Data.Type; }));
            DamageTypeData.ColumnDefs.Add("StartTime", new DamageTypeData.ColumnDef("StartTime", false, "TIMESTAMP", "StartTime", (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString("u").TrimEnd(new char[] { 'Z' }); }));
            DamageTypeData.ColumnDefs.Add("EndTime", new DamageTypeData.ColumnDef("EndTime", false, "TIMESTAMP", "EndTime", (Data) => { return Data.EndTime == DateTime.MinValue ? "--:--:--" : Data.StartTime.ToString("T"); }, (Data) => { return Data.EndTime == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString("u").TrimEnd(new char[] { 'Z' }); }));
            DamageTypeData.ColumnDefs.Add("Duration", new DamageTypeData.ColumnDef("Duration", false, "INT", "Duration", (Data) => { return Data.DurationS; }, (Data) => { return Data.Duration.TotalSeconds.ToString("0"); }));
            DamageTypeData.ColumnDefs.Add("Damage", new DamageTypeData.ColumnDef("Damage", true, "BIGINT", "Damage", (Data) => { return Data.Damage.ToString(GetIDCommas()); }, (Data) => { return Data.Damage.ToString(); }));
            DamageTypeData.ColumnDefs.Add("EncDPS", new DamageTypeData.ColumnDef("EncDPS", true, "DOUBLE", "EncDPS", (Data) => { return Data.EncDPS.ToString(GetFloatCommas()); }, (Data) => { return Data.EncDPS.ToString(usCulture); }));
            DamageTypeData.ColumnDefs.Add("CharDPS", new DamageTypeData.ColumnDef("CharDPS", false, "DOUBLE", "CharDPS", (Data) => { return Data.CharDPS.ToString(GetFloatCommas()); }, (Data) => { return Data.CharDPS.ToString(usCulture); }));
            DamageTypeData.ColumnDefs.Add("DPS", new DamageTypeData.ColumnDef("DPS", false, "DOUBLE", "DPS", (Data) => { return Data.DPS.ToString(GetFloatCommas()); }, (Data) => { return Data.DPS.ToString(usCulture); }));
            DamageTypeData.ColumnDefs.Add("Average", new DamageTypeData.ColumnDef("Average", true, "FLOAT", "Average", (Data) => { return Data.Average.ToString(GetFloatCommas()); }, (Data) => { return Data.Average.ToString(usCulture); }));
            DamageTypeData.ColumnDefs.Add("Median", new DamageTypeData.ColumnDef("Median", false, "INT", "Median", (Data) => { return Data.Median.ToString(GetIDCommas()); }, (Data) => { return Data.Median.ToString(); }));
            DamageTypeData.ColumnDefs.Add("MinHit", new DamageTypeData.ColumnDef("MinHit", true, "INT", "MinHit", (Data) => { return Data.MinHit.ToString(GetIDCommas()); }, (Data) => { return Data.MinHit.ToString(); }));
            DamageTypeData.ColumnDefs.Add("MaxHit", new DamageTypeData.ColumnDef("MaxHit", true, "INT", "MaxHit", (Data) => { return Data.MaxHit.ToString(GetIDCommas()); }, (Data) => { return Data.MaxHit.ToString(); }));
            DamageTypeData.ColumnDefs.Add("Hits", new DamageTypeData.ColumnDef("Hits", true, "INT", "Hits", (Data) => { return Data.Hits.ToString(GetIDCommas()); }, (Data) => { return Data.Hits.ToString(); }));
//            DamageTypeData.ColumnDefs.Add("CritHits", new DamageTypeData.ColumnDef("CritHits", false, "INT", "CritHits", (Data) => { return Data.CritHits.ToString(GetIDCommas()); }, (Data) => { return Data.CritHits.ToString(); }));
            DamageTypeData.ColumnDefs.Add("Swings", new DamageTypeData.ColumnDef("Swings", true, "INT", "Swings", (Data) => { return Data.Swings.ToString(GetIDCommas()); }, (Data) => { return Data.Swings.ToString(); }));
//            DamageTypeData.ColumnDefs.Add("ToHit", new DamageTypeData.ColumnDef("ToHit", false, "FLOAT", "ToHit", (Data) => { return Data.ToHit.ToString(GetFloatCommas()); }, (Data) => { return Data.ToHit.ToString(); }));
            DamageTypeData.ColumnDefs.Add("AvgDelay", new DamageTypeData.ColumnDef("AvgDelay", false, "FLOAT", "AverageDelay", (Data) => { return Data.AverageDelay.ToString(GetFloatCommas()); }, (Data) => { return Data.AverageDelay.ToString(); }));
//            DamageTypeData.ColumnDefs.Add("Crit%", new DamageTypeData.ColumnDef("Crit%", true, "VARCHAR(8)", "CritPerc", (Data) => { return Data.CritPerc.ToString("0'%"); }, (Data) => { return Data.CritPerc.ToString("0'%"); }));

            DamageTypeData.ColumnDefs.Add("Effectiveness",
                new DamageTypeData.ColumnDef("Effectiveness", true, "VARCHAR(8)", "Effectiveness", GetCellDataEffectiveness, GetSqlDataEffectiveness));


            AttackType.ColumnDefs.Clear();
            AttackType.ColumnDefs.Add("EncId", new AttackType.ColumnDef("EncId", false, "CHAR(8)", "EncId", (Data) => { return string.Empty; }, (Data) => { return Data.Parent.Parent.Parent.EncId; }, (Left, Right) => { return 0; }));
            AttackType.ColumnDefs.Add("Attacker", new AttackType.ColumnDef("Attacker", false, "VARCHAR(64)", "Attacker", (Data) => { return Data.Parent.Outgoing ? Data.Parent.Parent.Name : string.Empty; }, (Data) => { return Data.Parent.Outgoing ? Data.Parent.Parent.Name : string.Empty; }, (Left, Right) => { return 0; }));
            AttackType.ColumnDefs.Add("Victim", new AttackType.ColumnDef("Victim", false, "VARCHAR(64)", "Victim", (Data) => { return Data.Parent.Outgoing ? string.Empty : Data.Parent.Parent.Name; }, (Data) => { return Data.Parent.Outgoing ? string.Empty : Data.Parent.Parent.Name; }, (Left, Right) => { return 0; }));
            AttackType.ColumnDefs.Add("SwingType", new AttackType.ColumnDef("SwingType", false, "TINYINT", "SwingType", GetAttackTypeSwingType, GetAttackTypeSwingType, (Left, Right) => { return 0; }));
            AttackType.ColumnDefs.Add("Type", new AttackType.ColumnDef("Type", true, "VARCHAR(64)", "Type", (Data) => { return Data.Type; }, (Data) => { return Data.Type; }, (Left, Right) => { return Left.Type.CompareTo(Right.Type); }));
            AttackType.ColumnDefs.Add("StartTime", new AttackType.ColumnDef("StartTime", false, "TIMESTAMP", "StartTime", (Data) => { return Data.StartTime == DateTime.MaxValue ? "--:--:--" : Data.StartTime.ToString("T"); }, (Data) => { return Data.StartTime == DateTime.MaxValue ? "0000-00-00 00:00:00" : Data.StartTime.ToString("u").TrimEnd(new char[] { 'Z' }); }, (Left, Right) => { return Left.StartTime.CompareTo(Right.StartTime); }));
            AttackType.ColumnDefs.Add("EndTime", new AttackType.ColumnDef("EndTime", false, "TIMESTAMP", "EndTime", (Data) => { return Data.EndTime == DateTime.MinValue ? "--:--:--" : Data.EndTime.ToString("T"); }, (Data) => { return Data.EndTime == DateTime.MinValue ? "0000-00-00 00:00:00" : Data.EndTime.ToString("u").TrimEnd(new char[] { 'Z' }); }, (Left, Right) => { return Left.EndTime.CompareTo(Right.EndTime); }));
            AttackType.ColumnDefs.Add("Duration", new AttackType.ColumnDef("Duration", false, "INT", "Duration", (Data) => { return Data.DurationS; }, (Data) => { return Data.Duration.TotalSeconds.ToString("0"); }, (Left, Right) => { return Left.Duration.CompareTo(Right.Duration); }));
            AttackType.ColumnDefs.Add("Damage", new AttackType.ColumnDef("Damage", true, "BIGINT", "Damage", (Data) => { return Data.Damage.ToString(GetIDCommas()); }, (Data) => { return Data.Damage.ToString(); }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));
            AttackType.ColumnDefs.Add("EncDPS", new AttackType.ColumnDef("EncDPS", true, "DOUBLE", "EncDPS", (Data) => { return Data.EncDPS.ToString(GetFloatCommas()); }, (Data) => { return Data.EncDPS.ToString(usCulture); }, (Left, Right) => { return Left.EncDPS.CompareTo(Right.EncDPS); }));
            AttackType.ColumnDefs.Add("CharDPS", new AttackType.ColumnDef("CharDPS", false, "DOUBLE", "CharDPS", (Data) => { return Data.CharDPS.ToString(GetFloatCommas()); }, (Data) => { return Data.CharDPS.ToString(usCulture); }, (Left, Right) => { return Left.CharDPS.CompareTo(Right.CharDPS); }));
            AttackType.ColumnDefs.Add("DPS", new AttackType.ColumnDef("DPS", false, "DOUBLE", "DPS", (Data) => { return Data.DPS.ToString(GetFloatCommas()); }, (Data) => { return Data.DPS.ToString(usCulture); }, (Left, Right) => { return Left.DPS.CompareTo(Right.DPS); }));
            AttackType.ColumnDefs.Add("Average", new AttackType.ColumnDef("Average", true, "FLOAT", "Average", (Data) => { return Data.Average.ToString(GetFloatCommas()); }, (Data) => { return Data.Average.ToString(usCulture); }, (Left, Right) => { return Left.Average.CompareTo(Right.Average); }));
            AttackType.ColumnDefs.Add("Median", new AttackType.ColumnDef("Median", true, "INT", "Median", (Data) => { return Data.Median.ToString(GetIDCommas()); }, (Data) => { return Data.Median.ToString(); }, (Left, Right) => { return Left.Median.CompareTo(Right.Median); }));
            AttackType.ColumnDefs.Add("MinHit", new AttackType.ColumnDef("MinHit", true, "INT", "MinHit", (Data) => { return Data.MinHit.ToString(GetIDCommas()); }, (Data) => { return Data.MinHit.ToString(); }, (Left, Right) => { return Left.MinHit.CompareTo(Right.MinHit); }));
            AttackType.ColumnDefs.Add("MaxHit", new AttackType.ColumnDef("MaxHit", true, "INT", "MaxHit", (Data) => { return Data.MaxHit.ToString(GetIDCommas()); }, (Data) => { return Data.MaxHit.ToString(); }, (Left, Right) => { return Left.MaxHit.CompareTo(Right.MaxHit); }));
            AttackType.ColumnDefs.Add("Resist", new AttackType.ColumnDef("Resist", true, "VARCHAR(64)", "Resist", (Data) => { return Data.Resist; }, (Data) => { return Data.Resist; }, (Left, Right) => { return Left.Resist.CompareTo(Right.Resist); }));
            AttackType.ColumnDefs.Add("Hits", new AttackType.ColumnDef("Hits", true, "INT", "Hits", (Data) => { return Data.Hits.ToString(GetIDCommas()); }, (Data) => { return Data.Hits.ToString(); }, (Left, Right) => { return Left.Hits.CompareTo(Right.Hits); }));
//            AttackType.ColumnDefs.Add("CritHits", new AttackType.ColumnDef("CritHits", false, "INT", "CritHits", (Data) => { return Data.CritHits.ToString(GetIDCommas()); }, (Data) => { return Data.CritHits.ToString(); }, (Left, Right) => { return Left.CritHits.CompareTo(Right.CritHits); }));
            AttackType.ColumnDefs.Add("Avoids", new AttackType.ColumnDef("Avoids", false, "INT", "Blocked", (Data) => { return Data.Blocked.ToString(GetIDCommas()); }, (Data) => { return Data.Blocked.ToString(); }, (Left, Right) => { return Left.Blocked.CompareTo(Right.Blocked); }));
            AttackType.ColumnDefs.Add("Misses", new AttackType.ColumnDef("Misses", false, "INT", "Misses", (Data) => { return Data.Misses.ToString(GetIDCommas()); }, (Data) => { return Data.Misses.ToString(); }, (Left, Right) => { return Left.Misses.CompareTo(Right.Misses); }));
            AttackType.ColumnDefs.Add("Swings", new AttackType.ColumnDef("Swings", true, "INT", "Swings", (Data) => { return Data.Swings.ToString(GetIDCommas()); }, (Data) => { return Data.Swings.ToString(); }, (Left, Right) => { return Left.Swings.CompareTo(Right.Swings); }));
            AttackType.ColumnDefs.Add("ToHit", new AttackType.ColumnDef("ToHit", true, "FLOAT", "ToHit", (Data) => { return Data.ToHit.ToString(GetFloatCommas()); }, (Data) => { return Data.ToHit.ToString(usCulture); }, (Left, Right) => { return Left.ToHit.CompareTo(Right.ToHit); }));
            AttackType.ColumnDefs.Add("AvgDelay", new AttackType.ColumnDef("AvgDelay", false, "FLOAT", "AverageDelay", (Data) => { return Data.AverageDelay.ToString(GetFloatCommas()); }, (Data) => { return Data.AverageDelay.ToString(usCulture); }, (Left, Right) => { return Left.AverageDelay.CompareTo(Right.AverageDelay); }));
//            AttackType.ColumnDefs.Add("Crit%", new AttackType.ColumnDef("Crit%", true, "VARCHAR(8)", "CritPerc", (Data) => { return Data.CritPerc.ToString("0'%"); }, (Data) => { return Data.CritPerc.ToString("0'%"); }, (Left, Right) => { return Left.CritPerc.CompareTo(Right.CritPerc); }));

            AttackType.ColumnDefs.Add("Effectiveness",
                new AttackType.ColumnDef("Effectiveness", true, "VARCHAR(8)", "Effectiveness", GetCellDataEffectiveness, GetSqlDataEffectiveness, AttackTypeCompareEffectiveness));


            MasterSwing.ColumnDefs.Clear();
            MasterSwing.ColumnDefs.Add("EncId", new MasterSwing.ColumnDef("EncId", false, "CHAR(8)", "EncId", (Data) => { return string.Empty; }, (Data) => { return Data.ParentEncounter.EncId; }, (Left, Right) => { return 0; }));
            MasterSwing.ColumnDefs.Add("Time", new MasterSwing.ColumnDef("Time", true, "TIMESTAMP", "STime", (Data) => { return Data.Time.ToString("T"); }, (Data) => { return Data.Time.ToString("u").TrimEnd(new char[] { 'Z' }); }, (Left, Right) => { return Left.Time.CompareTo(Right.Time); }));
            MasterSwing.ColumnDefs.Add("Attacker", new MasterSwing.ColumnDef("Attacker", true, "VARCHAR(64)", "Attacker", (Data) => { return Data.Attacker; }, (Data) => { return Data.Attacker; }, (Left, Right) => { return Left.Attacker.CompareTo(Right.Attacker); }));
            MasterSwing.ColumnDefs.Add("SwingType", new MasterSwing.ColumnDef("SwingType", false, "TINYINT", "SwingType", (Data) => { return Data.SwingType.ToString(); }, (Data) => { return Data.SwingType.ToString(); }, (Left, Right) => { return Left.SwingType.CompareTo(Right.SwingType); }));
            MasterSwing.ColumnDefs.Add("AttackType", new MasterSwing.ColumnDef("AttackType", true, "VARCHAR(64)", "AttackType", (Data) => { return Data.AttackType; }, (Data) => { return Data.AttackType; }, (Left, Right) => { return Left.AttackType.CompareTo(Right.AttackType); }));
            MasterSwing.ColumnDefs.Add("DamageType", new MasterSwing.ColumnDef("DamageType", true, "VARCHAR(64)", "DamageType", (Data) => { return Data.DamageType; }, (Data) => { return Data.DamageType; }, (Left, Right) => { return Left.DamageType.CompareTo(Right.DamageType); }));
            MasterSwing.ColumnDefs.Add("Victim", new MasterSwing.ColumnDef("Victim", true, "VARCHAR(64)", "Victim", (Data) => { return Data.Victim; }, (Data) => { return Data.Victim; }, (Left, Right) => { return Left.Victim.CompareTo(Right.Victim); }));
            MasterSwing.ColumnDefs.Add("DamageNum", new MasterSwing.ColumnDef("DamageNum", false, "INT", "Damage", (Data) => { return ((int)Data.Damage).ToString(); }, (Data) => { return ((int)Data.Damage).ToString(); }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));
            //MasterSwing.ColumnDefs.Add("Damage", new MasterSwing.ColumnDef("Damage", true, "VARCHAR(128)", "DamageString", /* lambda */ (Data) => { return Data.Damage.ToString(); }, (Data) => { return Data.Damage.ToString(); }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));
            // As a C# lesson, the above lines(lambda expressions) can also be written as(anonymous methods):
            
            MasterSwing.ColumnDefs.Add("Damage",
                new MasterSwing.ColumnDef("Damage", true, "VARCHAR(128)", "DamageString", GetCellDataDamage, (Data) => { return Data.Damage.ToString(); }, (Left, Right) => { return Left.Damage.CompareTo(Right.Damage); }));

//            MasterSwing.ColumnDefs.Add("Critical", new MasterSwing.ColumnDef("Critical", true, "CHAR(1)", "Critical", /* anonymous */ delegate(MasterSwing Data) { return Data.Critical.ToString(); }, delegate(MasterSwing Data) { return Data.Critical.ToString(usCulture)[0].ToString(); }, delegate(MasterSwing Left, MasterSwing Right) { return Left.Critical.CompareTo(Right.Critical); }));
            // Or also written as(delegated methods):
            MasterSwing.ColumnDefs.Add("Special", new MasterSwing.ColumnDef("Special", true, "VARCHAR(64)", "Special", /* delegate */ GetCellDataSpecial, GetSqlDataSpecial, MasterSwingCompareSpecial));
            
            MasterSwing.ColumnDefs.Add("BaseDamage",
                new MasterSwing.ColumnDef("BaseDamage", true, "INT", "BaseDamageString", GetCellDataBaseDamage, GetSqlDataBaseDamage, MasterSwingCompareBaseDamage));
            MasterSwing.ColumnDefs.Add("Effectiveness",
                new MasterSwing.ColumnDef("Effectiveness", true, "VARCHAR(8)", "EffectivenessString", GetCellDataEffectiveness, GetSqlDataEffectiveness, MasterSwingCompareEffectiveness));
            MasterSwing.ColumnDefs.Add("DmgToShield",
                new MasterSwing.ColumnDef("DmgToShield", false, "VARCHAR(128)", "DmgToShieldstring", GetCellDataDmgToShield, GetSqlDataDmgToShield, MasterSwingCompareDmgToShield));
            MasterSwing.ColumnDefs.Add("ShieldP",
                new MasterSwing.ColumnDef("ShieldP", false, "VARCHAR(8)", "ShieldPDtring", GetCellDataShieldP, GetSqlDataShieldP, MasterSwingCompareShieldP));


            ActGlobals.oFormActMain.ValidateLists();
            ActGlobals.oFormActMain.ValidateTableSetup();
        }

        #region ImportedFromEQ2Plugin

        // Needed to import this code to allow a setup from a blank state instead of the default state.
        // Blank state setup is the only way to enable the plugin when switching from some other plugin
        // that changed the default state.

        private string EncounterFormatSwitch(EncounterData Data, List<CombatantData> SelectiveAllies, string VarName, string Extra)
        {
            long damage = 0;
            long healed = 0;
            int swings = 0;
            int hits = 0;
            int crits = 0;
            int heals = 0;
            int critheals = 0;
            int misses = 0;
            int hitfail = 0;
            float tohit = 0;
            double dps = 0;
            double hps = 0;
            long healstaken = 0;
            long damagetaken = 0;
            long powerdrain = 0;
            long powerheal = 0;
            int kills = 0;
            int deaths = 0;

            switch (VarName)
            {
                case "maxheal":
                    return Data.GetMaxHeal(true, false);
                case "MAXHEAL":
                    return Data.GetMaxHeal(false, false);
                case "maxhealward":
                    return Data.GetMaxHeal(true, true);
                case "MAXHEALWARD":
                    return Data.GetMaxHeal(false, true);
                case "maxhit":
                    return Data.GetMaxHit(true);
                case "MAXHIT":
                    return Data.GetMaxHit(false);
                case "duration":
                    return Data.DurationS;
                case "DURATION":
                    return Data.Duration.TotalSeconds.ToString("0");
                case "damage":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    return damage.ToString();
                case "damage-m":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    return (damage / 1000000.0).ToString("0.00");
                case "DAMAGE-k":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    return (damage / 1000.0).ToString("0");
                case "DAMAGE-m":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    return (damage / 1000000.0).ToString("0");
                case "healed":
                    foreach (CombatantData cd in SelectiveAllies)
                        healed += cd.Healed;
                    return healed.ToString();
                case "swings":
                    foreach (CombatantData cd in SelectiveAllies)
                        swings += cd.Swings;
                    return swings.ToString();
                case "hits":
                    foreach (CombatantData cd in SelectiveAllies)
                        hits += cd.Hits;
                    return hits.ToString();
                case "crithits":
                    foreach (CombatantData cd in SelectiveAllies)
                        crits += cd.CritHits;
                    return crits.ToString();
                case "crithit%":
                    foreach (CombatantData cd in SelectiveAllies)
                        crits += cd.CritHits;
                    foreach (CombatantData cd in SelectiveAllies)
                        hits += cd.Hits;
                    float critdamperc = (float)crits / (float)hits;
                    return critdamperc.ToString("0'%");
                case "heals":
                    foreach (CombatantData cd in SelectiveAllies)
                        heals += cd.Heals;
                    return heals.ToString();
                case "critheals":
                    foreach (CombatantData cd in SelectiveAllies)
                        critheals += cd.CritHits;
                    return critheals.ToString();
                case "critheal%":
                    foreach (CombatantData cd in SelectiveAllies)
                        critheals += cd.CritHeals;
                    foreach (CombatantData cd in SelectiveAllies)
                        heals += cd.Heals;
                    float crithealperc = (float)critheals / (float)heals;
                    return crithealperc.ToString("0'%");
                case "misses":
                    foreach (CombatantData cd in SelectiveAllies)
                        misses += cd.Misses;
                    return misses.ToString();
                case "hitfailed":
                    foreach (CombatantData cd in SelectiveAllies)
                        hitfail += cd.Blocked;
                    return hitfail.ToString();
                case "TOHIT":
                    foreach (CombatantData cd in SelectiveAllies)
                        tohit += cd.ToHit;
                    tohit /= SelectiveAllies.Count;
                    return tohit.ToString("0");
                case "DPS":
                case "ENCDPS":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    dps = damage / Data.Duration.TotalSeconds;
                    return dps.ToString("0");
                case "DPS-k":
                case "ENCDPS-k":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    dps = damage / Data.Duration.TotalSeconds;
                    return (dps / 1000.0).ToString("0");
                case "ENCHPS":
                    foreach (CombatantData cd in SelectiveAllies)
                        healed += cd.Healed;
                    hps = healed / Data.Duration.TotalSeconds;
                    return hps.ToString("0");
                case "ENCHPS-k":
                    foreach (CombatantData cd in SelectiveAllies)
                        healed += cd.Healed;
                    hps = healed / Data.Duration.TotalSeconds;
                    return (hps / 1000.0).ToString("0");
                case "tohit":
                    foreach (CombatantData cd in SelectiveAllies)
                        tohit += cd.ToHit;
                    tohit /= SelectiveAllies.Count;
                    return tohit.ToString("F");
                case "dps":
                case "encdps":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    dps = damage / Data.Duration.TotalSeconds;
                    return dps.ToString("F");
                case "dps-k":
                case "encdps-k":
                    foreach (CombatantData cd in SelectiveAllies)
                        damage += cd.Damage;
                    dps = damage / Data.Duration.TotalSeconds;
                    return (dps / 1000.0).ToString("F");
                case "enchps":
                    foreach (CombatantData cd in SelectiveAllies)
                        healed += cd.Healed;
                    hps = healed / Data.Duration.TotalSeconds;
                    return hps.ToString("F");
                case "enchps-k":
                    foreach (CombatantData cd in SelectiveAllies)
                        healed += cd.Healed;
                    hps = healed / Data.Duration.TotalSeconds;
                    return (hps / 1000.0).ToString("F");
                case "healstaken":
                    foreach (CombatantData cd in SelectiveAllies)
                        healstaken += cd.HealsTaken;
                    return healstaken.ToString();
                case "damagetaken":
                    foreach (CombatantData cd in SelectiveAllies)
                        damagetaken += cd.DamageTaken;
                    return damagetaken.ToString();
                case "powerdrain":
                    foreach (CombatantData cd in SelectiveAllies)
                        powerdrain += cd.PowerDamage;
                    return powerdrain.ToString();
                case "powerheal":
                    foreach (CombatantData cd in SelectiveAllies)
                        powerheal += cd.PowerReplenish;
                    return powerheal.ToString();
                case "kills":
                    foreach (CombatantData cd in SelectiveAllies)
                        kills += cd.Kills;
                    return kills.ToString();
                case "deaths":
                    foreach (CombatantData cd in SelectiveAllies)
                        deaths += cd.Deaths;
                    return deaths.ToString();
                case "title":
                    return Data.Title;

                default:
                    return VarName;
            }
        }

        private string CombatantFormatSwitch(CombatantData Data, string VarName, string Extra)
        {
            int len = 0;
            switch (VarName)
            {
                case "name":
                    return Data.Name;
                case "NAME":
                    len = Int32.Parse(Extra);
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME3":
                    len = 3;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME4":
                    len = 4;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME5":
                    len = 5;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME6":
                    len = 6;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME7":
                    len = 7;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME8":
                    len = 8;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME9":
                    len = 9;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME10":
                    len = 10;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME11":
                    len = 11;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME12":
                    len = 12;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME13":
                    len = 13;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME14":
                    len = 14;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "NAME15":
                    len = 15;
                    return Data.Name.Length - len > 0 ? Data.Name.Remove(len, Data.Name.Length - len).Trim() : Data.Name;
                case "DURATION":
                    return Data.Duration.TotalSeconds.ToString("0");
                case "duration":
                    return Data.DurationS;
                case "maxhit":
                    return Data.GetMaxHit(true);
                case "MAXHIT":
                    return Data.GetMaxHit(false);
                case "maxheal":
                    return Data.GetMaxHeal(true, false);
                case "MAXHEAL":
                    return Data.GetMaxHeal(false, false);
                case "maxhealward":
                    return Data.GetMaxHeal(true, true);
                case "MAXHEALWARD":
                    return Data.GetMaxHeal(false, true);
                case "damage":
                    return Data.Damage.ToString();
                case "damage-k":
                    return (Data.Damage / 1000.0).ToString("0.00");
                case "damage-m":
                    return (Data.Damage / 1000000.0).ToString("0.00");
                case "DAMAGE-k":
                    return (Data.Damage / 1000.0).ToString("0");
                case "DAMAGE-m":
                    return (Data.Damage / 1000000.0).ToString("0");
                case "healed":
                    return Data.Healed.ToString();
                case "swings":
                    return Data.Swings.ToString();
                case "hits":
                    return Data.Hits.ToString();
                case "crithits":
                    return Data.CritHits.ToString();
                case "critheals":
                    return Data.CritHeals.ToString();
                case "crithit%":
                    return Data.CritDamPerc.ToString("0'%");
                case "fcrithit%":
                    return GetFilteredCritChance(Data).ToString("0'%");
                case "critheal%":
                    return Data.CritHealPerc.ToString("0'%");
                case "heals":
                    return Data.Heals.ToString();
                case "TOHIT":
                    return Data.ToHit.ToString("0");
                case "DPS":
                    return Data.DPS.ToString("0");
                case "DPS-k":
                    return (Data.DPS / 1000.0).ToString("0");
                case "ENCDPS":
                    return Data.EncDPS.ToString("0");
                case "ENCDPS-k":
                    return (Data.EncDPS / 1000.0).ToString("0");
                case "ENCHPS":
                    return Data.EncHPS.ToString("0");
                case "ENCHPS-k":
                    return (Data.EncHPS / 1000.0).ToString("0");
                case "tohit":
                    return Data.ToHit.ToString("F");
                case "dps":
                    return Data.DPS.ToString("F");
                case "dps-k":
                    return (Data.DPS / 1000.0).ToString("F");
                case "encdps":
                    return Data.EncDPS.ToString("F");
                case "encdps-k":
                    return (Data.EncDPS / 1000.0).ToString("F");
                case "enchps":
                    return Data.EncHPS.ToString("F");
                case "enchps-k":
                    return (Data.EncHPS / 1000.0).ToString("F");
                case "healstaken":
                    return Data.HealsTaken.ToString();
                case "damagetaken":
                    return Data.DamageTaken.ToString();
                case "powerdrain":
                    return Data.PowerDamage.ToString();
                case "powerheal":
                    return Data.PowerReplenish.ToString();
                case "kills":
                    return Data.Kills.ToString();
                case "deaths":
                    return Data.Deaths.ToString();
                case "damage%":
                    return Data.DamagePercent;
                case "healed%":
                    return Data.HealedPercent;
                case "n":
                    return "\n";
                case "t":
                    return "\t";

                default:
                    return VarName;
            }
        }

        private string GetCellDataSpecial(MasterSwing Data)
        {
            return Data.Special;
        }

        private string GetSqlDataSpecial(MasterSwing Data)
        {
            return Data.Special;
        }

        private int MasterSwingCompareSpecial(MasterSwing Left, MasterSwing Right)
        {
            return Left.Special.CompareTo(Right.Special);
        }

        private string GetAttackTypeSwingType(AttackType Data)
        {
            int swingType = 100;
            List<int> swingTypes = new List<int>();
            List<MasterSwing> cachedItems = new List<MasterSwing>(Data.Items);
            for (int i = 0; i < cachedItems.Count; i++)
            {
                MasterSwing s = cachedItems[i];
                if (swingTypes.Contains(s.SwingType) == false)
                    swingTypes.Add(s.SwingType);
            }
            if (swingTypes.Count == 1)
                swingType = swingTypes[0];

            return swingType.ToString();
        }

        private string GetDamageTypeGrouping(DamageTypeData Data)
        {
            string grouping = string.Empty;

            int swingTypeIndex = 0;
            if (Data.Outgoing)
            {
                grouping += "attacker=" + Data.Parent.Name;
                foreach (KeyValuePair<int, List<string>> links in CombatantData.SwingTypeToDamageTypeDataLinksOutgoing)
                {
                    foreach (string damageTypeLabel in links.Value)
                    {
                        if (Data.Type == damageTypeLabel)
                        {
                            grouping += String.Format("&swingtype{0}={1}", swingTypeIndex++ == 0 ? string.Empty : swingTypeIndex.ToString(), links.Key);
                        }
                    }
                }
            }
            else
            {
                grouping += "victim=" + Data.Parent.Name;
                foreach (KeyValuePair<int, List<string>> links in CombatantData.SwingTypeToDamageTypeDataLinksIncoming)
                {
                    foreach (string damageTypeLabel in links.Value)
                    {
                        if (Data.Type == damageTypeLabel)
                        {
                            grouping += String.Format("&swingtype{0}={1}", swingTypeIndex++ == 0 ? string.Empty : swingTypeIndex.ToString(), links.Key);
                        }
                    }
                }
            }

            return grouping;
        }

        private float GetFilteredCritChance(CombatantData Data)
        {
            List<AttackType> allAttackTypes = new List<AttackType>();
            List<AttackType> filteredAttackTypes = new List<AttackType>();

            foreach (KeyValuePair<string, AttackType> item in Data.Items["Outgoing Damage"].Items)
                allAttackTypes.Add(item.Value);
            foreach (KeyValuePair<string, AttackType> item in Data.Items["Healed (Out)"].Items)
                allAttackTypes.Add(item.Value);

            foreach (AttackType item in allAttackTypes)
            {
                if (item.Type == ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText)
                    continue;
                if (item.CritPerc == 0.0f)
                    continue;

                string damageType = string.Empty;
                bool cont = false;
                for (int i = 0; i < item.Items.Count; i++)
                {
                    string itemDamageType = item.Items[i].DamageType;
                    if (String.IsNullOrEmpty(damageType))
                    {
                        damageType = itemDamageType;
                    }
                    else
                    {
                        if (itemDamageType == "melee")
                            continue;
                        if (itemDamageType == "non-melee")
                            continue;
                        if (itemDamageType != damageType)
                        {
                            cont = true;
                            break;
                        }
                    }
                }
                if (cont)
                    continue;
                filteredAttackTypes.Add(item);
            }

            if (filteredAttackTypes.Count == 0)
                return float.NaN;
            else
            {
                float hits = 0;
                float critHits = 0;
                for (int i = 0; i < filteredAttackTypes.Count; i++)
                {
                    AttackType item = filteredAttackTypes[i];
                    hits += item.Hits;
                    critHits += item.CritHits;
                }
                float perc = critHits / hits;
                float ratio = hits / (float)Data.AllOut[ActGlobals.ActLocalization.LocalizationStrings["attackTypeTerm-all"].DisplayedText].Hits;
                if (perc == 1)
                {
                    if (ratio > 0.25f)
                        return 100;
                    else
                        return float.NaN;
                }
                if (ratio > 0.25f)
                    return (int)(perc * 100f);
                else
                    return float.NaN;
            }
        }

        #endregion ImportedFromEQ2Plugin

        void oFormActMain_LogFileChanged(bool IsImport, string NewLogFileName)
        {
            curActionTime = DateTime.MinValue;
            //purgePetCache();
            petOwnerRegistery.Clear();
            entityOwnerRegistery.Clear();
            magicMissileLastHit.Clear();
            unmatchedShieldLines.Clear();

            playersCharacterFound = false;
        }

        void oFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            curActionTime = DateTime.MinValue;

            // Don't actually want this.  Maybe on zone changes.
            // purgePetCache();

            // Don't clear this.  PvP encounters can be split while Chaotic Growth is active.
            // magicMissileLastHit.Clear();

            unmatchedShieldLines.Clear();

            entityOwnerRegistery.Clear();
            playersCharacterFound = false;
        }

        // Must match LogLineEventDelegate signature
        void oFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            parsedLineCount++;

            if (logInfo.logLine.Length < 30 || logInfo.logLine[19] != ':' || logInfo.logLine[20] != ':')
            {
                logInfo.detectedType = Color.DarkGray.ToArgb();
                errorLineCount++;
                return;
            }

            if (logInfo.detectedTime != curActionTime)
            {
                // Different times mean new action block, any pending actions won't be related to those of the new block
                curActionTime = logInfo.detectedTime;
            }

            ParsedLine pl = new ParsedLine(logInfo);

            if (pl.error)
            {
                logInfo.detectedType = Color.DarkGray.ToArgb();
                errorLineCount++;
                return;
            }

            // Fix up the ParsedLine to be easy to process.
            ProcessBasic(pl);

            // Detect Player names..
            if ( ! (playersCharacterFound || isImport ) )
            {
                if (pl.ownEntityType == EntityType.Player)
                {
                    if (playerCharacterNames.ContainsKey(pl.OriginName))
                    {
                        ActGlobals.charName = pl.OriginName;
                        playersCharacterFound = true;
                    }
                }
            }

            // Do the real stuff..
            ProcessAction(pl);
        }

        private void ProcessNamesOST(ParsedLine line)
        {
            // Owner, Source (belongs to owner), Target
            petOwnerRegistery.Register(line);
            entityOwnerRegistery.Register(line);

            ProcessOwnerSourceNames(line);
            ProcessTargetNames(line);
        }

        private void ProcessNamesST(ParsedLine line)
        {
            // Source, Target: All independant
            ProcessSourceNames(line);
            ProcessTargetNames(line);
        }

        private void ProcessNamesTargetOnly(ParsedLine line)
        {
            // Target only
            ProcessTargetNames(line);
        }

        private void ProcessBasic(ParsedLine line)
        {
            //
            // Fix up the ParsedLine.
            // Add calculated data fields to the ParsedLine.
            //


            if (line.OriginName == "" && line.OriginID == "")
            {
                // Ugly fix for lines without an owner
                line.OriginName = MLParsing_Plugin.unknown;
                line.OriginID = MLParsing_Plugin.unknownID;
            }
            else if (line.OriginID[0] == 'P') { line.ownEntityType = EntityType.Player; }
            else if (line.OriginID[0] == 'C') 
            {
                // There should never be a Pet or Entity in this possition??
                line.ownEntityType = EntityType.Creature;
            }


            if (line.SourceID == "*")
            {
                line.SourceName = line.OriginName;
                line.SourceID = line.OriginID;
                line.SourceEntityType = line.ownEntityType;
            }
            else if ((line.SourceID == "") && (line.SourceName == ""))
            {
                //
                // // Ugly fix for lines without a source
                // // SourceName = ML_Parser.unknown;
                // // SourceID = ML_Parser.unknownID;
                // 

                line.SourceName = line.OriginName;
                line.SourceID = line.OriginID;
                line.SourceEntityType = line.ownEntityType;
            }
            else if (line.SourceID[0] == 'P')
            {
                line.SourceEntityType = EntityType.Player;
            }
            else if (line.SourceID[0] == 'C')
            {
                // Basic Pet and Entity detection..

                if (line.SourceID.Contains(" Pet_"))
                {
                    line.SourceEntityType = EntityType.Pet;
                }
                else if (line.SourceID.Contains(" Entity_"))
                {
                    line.SourceEntityType = EntityType.Entity;
                }
                else
                {
                    line.SourceEntityType = EntityType.Creature;
                }
            }

            if (line.TargetID == "*")
            {
                line.TargetName = line.SourceName;
                line.TargetID = line.SourceID;
                line.TargetEntityType = line.SourceEntityType;

                // If it is a Pet then the pet owner info needs to get set.
                // But first we can not do it here in case this is the first time we saw the owner.
                // Need to register owner of pet first...
            }
            else if ((line.TargetID == "") && (line.TargetName == ""))
            {
                // Ugly fix for lines without a target
                line.TargetName = MLParsing_Plugin.unknown;
                line.TargetID = MLParsing_Plugin.unknownID;
            }
            else if (line.TargetID[0] == 'P') { line.TargetEntityType = EntityType.Player; }
            else if (line.TargetID[0] == 'C') 
            {
                // Basic Pet and Entity detection..

                if (line.TargetID.Contains(" Pet_"))
                {
                    line.TargetEntityType = EntityType.Pet;
                }
                else if (line.TargetID.Contains(" Entity_"))
                {
                    line.TargetEntityType = EntityType.Entity;
                }
                else
                {
                    line.TargetEntityType = EntityType.Creature;
                }
            }

            // Defaults for the clean names.
            line.encAttackerName = line.OriginName;
            line.encTargetName = line.TargetName;
            line.unitAttackerName = line.OriginName;
            line.unitTargetName = line.TargetName;
        }

        private void ProcessOwnerSourceNames(ParsedLine line)
        {
            // Owner default:
            line.encAttackerName = line.OriginName;
            line.unitAttackerName = line.OriginName;

            // We assume the owner is the owner of the source for this processing.

            if (line.SourceEntityType == EntityType.Pet)
            {
                // Use the pet owner name for encounter name and filtering.
                line.encAttackerName = line.OriginName;

                // Pet name:
                line.unitAttackerName = line.SourceName + " [" + line.OriginName + "'s Pet]";
                if (this.checkBox_mergePets.Checked)
                {
                    line.unitAttackerName = line.OriginName;
                }
            }
            else if (line.ownEntityType == EntityType.Creature)
            {
                line.encAttackerName = line.OriginName;
                String creatureId = line.OriginID.Split()[0].Substring(2);

                if (checkBox_mergeNPC.Checked)
                {
                    // Merge all NPCs to a single name.
                    line.unitAttackerName = line.OriginName;
                }
                else
                {
                    // Separate each NPC with its unique creature ID added.
                    line.unitAttackerName = line.OriginName + " [" + creatureId + "]";
                }
            }
        }

        private void ProcessSourceNames(ParsedLine line)
        {
            switch (line.SourceEntityType)
            {
                case EntityType.Player:
                    {
                        line.encAttackerName = line.SourceName;
                        line.unitAttackerName = line.SourceName;
                        break;
                    }

                case EntityType.Pet:
                    {
                        OwnerInfo owner = petOwnerRegistery.Resolve(line.SourceID);

                        if (owner != null)
                        {

                            // Use the pet owner name for encounter name and filtering.
                            line.encAttackerName = owner.ownerName;

                            // Pet name:
                            line.unitAttackerName = line.SourceName + " [" + owner.ownerName + "'s Pet]";
                            if (this.checkBox_mergePets.Checked)
                            {
                                line.unitAttackerName = owner.ownerName;
                            }
                        }
                        else
                        {
                            // Pet with unknownnown owner.
                            // Register it under UNKNOWN until it resolves.
                            line.encAttackerName = unknown;
                            line.unitAttackerName = unknown;
                        }
                        break;
                    }
                case EntityType.Entity:
                    {
                        OwnerInfo owner = entityOwnerRegistery.Resolve(line.SourceID);
                        if (owner != null)
                        {
                            if (owner.ownerEntityType == EntityType.Creature)
                            {
                                line.encAttackerName = owner.ownerName;

                                if (checkBox_mergeNPC.Checked)
                                {
                                    // Merge all NPCs to a single name.
                                    line.unitAttackerName = owner.ownerName;
                                }
                                else
                                {
                                    // Separate each NPC with its unique creature ID added.
                                    String creatureId = owner.ownerID.Split()[0].Substring(2);
                                    line.unitAttackerName = owner.ownerName + " [" + creatureId + "]";
                                }
              
                            }
                            else
                            {
                                line.encAttackerName = owner.ownerName;
                                line.unitAttackerName = owner.ownerName;
                            }
                        }
                        else
                        {
                            line.encAttackerName = line.SourceName;
                            line.unitAttackerName = line.SourceName;
                        }
                        break;
                    }
                case EntityType.Creature:
                    {
                        line.encAttackerName = line.SourceName;
                        
                        if (checkBox_mergeNPC.Checked)
                        {
                            // Merge all NPCs to a single name.
                            line.unitAttackerName = line.SourceName;
                        }
                        else
                        {
                            // Separate each NPC with its unique creature ID added.
                            String creatureId = line.SourceID.Split()[0].Substring(2);
                            line.unitAttackerName = line.SourceName + " [" + creatureId + "]";
                        }
              
                        break;
                    }

                // case ParsedLine.EntityType.Unknown:
                default:
                    {
                        // Use the defaults.
                        line.encAttackerName = line.SourceName;
                        line.unitAttackerName = line.SourceName;
                        break;
                    }
            }
        }

        private void ProcessTargetNames(ParsedLine line)
        {
            switch (line.TargetEntityType)
            {
                case EntityType.Player:
                    {
                        line.encTargetName = line.TargetName;
                        line.unitTargetName = line.TargetName;
                        break;
                    }

                case EntityType.Pet:
                    {
                        line.TargetOwnerInfo = petOwnerRegistery.Resolve(line.TargetID);

                        if (line.TargetOwnerInfo != null)
                        {

                            // Use the pet owner name for encounter name and filtering.
                            line.encTargetName = line.TargetOwnerInfo.ownerName;

                            // Pet name:
                            line.unitTargetName = line.TargetName + " [" + line.TargetOwnerInfo.ownerName + "'s Pet]";
                            if (this.checkBox_mergePets.Checked)
                            {
                                line.unitTargetName = line.TargetOwnerInfo.ownerName;
                            }
                        }
                        else
                        {
                            // Pet with unknown owner.
                            // Register it under UNKNOWN until it resolves.
                            line.encTargetName = unknown;
                            line.unitTargetName = unknown;
                        }
                        break;
                    }
                case EntityType.Entity:
                    {
                        line.TargetOwnerInfo = entityOwnerRegistery.Resolve(line.TargetID);
                        if (line.TargetOwnerInfo != null)
                        {
                            // What does this mean???
                        }
                        break;
                    }
                case EntityType.Creature:
                    {
                        line.encTargetName = line.TargetName;
                        String creatureId = line.TargetID.Split()[0].Substring(2);

                        if (checkBox_mergeNPC.Checked)
                        {
                            // Merge all NPCs to a single name.
                            line.unitTargetName = line.TargetName;
                        }
                        else
                        {
                            // Separate each NPC with its unique creature ID added.
                            line.unitTargetName = line.TargetName + " [" + creatureId + "]";
                        }
                        break;
                    }

                // case ParsedLine.EntityType.Unknown:
                default:
                    {
                        // Use the defaults.
                        break;
                    }
            }
        }

        private void ProcessActionHeals(ParsedLine l)
        {
            int magAdj = (int)Math.Round(l.Magnitude);
            int magBaseAdj = (int)Math.Round(l.BaseMagnitude);

            l.logInfo.detectedType = l.critical ? Color.Green.ToArgb() : Color.DarkGreen.ToArgb();

            // NOTE: Do NOT use SetEncounter() on heals (i.e Non-Hostile Actions)

            // Heals can not start an encounter.
            if (ActGlobals.oFormActMain.InCombat)
            {
                ProcessNamesOST(l);

                if (l.AbilityID == "Pn.Hemuxg") // PvP Kill downed player
                {
                    // PVP finish off

                    // TODO:  Should this be recorded or ignored...
                }
                else
                {
                    // Default heal.

                    AddCombatActionML(
                        (int)SwingTypeEnum.Healing, l.critical, l.special, l.unitAttackerName,
                        l.attackType, new Dnum(-magAdj), -l.Magnitude, -l.BaseMagnitude, l.logInfo.detectedTime,
                        l.ts, l.unitTargetName, l.type);
                }
            }
        }

        private void ProcessActionShields(ParsedLine l)
        {
            int magAdj = (int)Math.Round(l.Magnitude);
            int magBaseAdj = (int)Math.Round(l.BaseMagnitude);

            //
            // Target prevented damage.
            //

            l.logInfo.detectedType = l.critical ? Color.Green.ToArgb() : Color.DarkGreen.ToArgb();

            ProcessNamesOST(l);

            // Use encounter names attacker and target here.  This allows filtering
            // Hostile action triggered.  Use SetEncounter().
            if (ActGlobals.oFormActMain.SetEncounter(l.logInfo.detectedTime, l.encAttackerName, l.encTargetName))
            {
                // Put the attacker and the attack type in the special field.
                string special = l.unitAttackerName + " : " + l.attackType;

                Dnum shielded = null;
                float mag = 0;
                float magBase = 0;

                // This is just weird...
                if (l.BaseMagnitude == 0) // Don't use magBaseAdj here.  Rounded to zero is not zero.
                {
                    shielded = new Dnum( -magAdj );
                    mag = -l.Magnitude;
                    magBase = -l.BaseMagnitude;
                }
                else
                {
                    shielded = new Dnum(-magBaseAdj);
                    mag = -l.BaseMagnitude;
                    magBase = -l.Magnitude;
                }

                // SwingType = Heal
                // special = attacker
                // attacker & victim = target
                MasterSwing ms = new MasterSwing(
                    (int)SwingTypeEnum.Healing,
                    l.critical, special, shielded, l.logInfo.detectedTime, l.ts, l.type, l.unitTargetName, l.type, l.unitTargetName);

                ms.Tags.Add("DamageF", mag);

                ActGlobals.oFormActMain.AddCombatAction(ms);

                unmatchedShieldLines.AddShield(ms, l);
            }
        }

        private void ProcessActionPower(ParsedLine l)
        {
            int magAdj = (int)Math.Round(l.Magnitude);
            //int magBaseAdj = (int)Math.Round(l.magBase * 10);

            l.logInfo.detectedType = Color.Black.ToArgb();

            // NOTE: Do NOT use SetEncounter() on power (i.e Non-Hostile Actions)

            if (ActGlobals.oFormActMain.InCombat)
            {
                // Normal Power case...
                ProcessNamesOST(l);

                AddCombatActionML(
                    (int)SwingTypeEnum.PowerHealing, l.critical, l.special,
                    l.unitAttackerName, l.attackType, new Dnum(-magAdj), -l.Magnitude, -l.BaseMagnitude,
                    l.logInfo.detectedTime, l.ts, l.unitTargetName, l.type);
            }
        }

        private void ProcessActionSPDN(ParsedLine l)
        {
            // Handle all the buff and proc buffs/debuffs

            l.logInfo.detectedType = Color.DarkTurquoise.ToArgb();

            // Default

            if (ActGlobals.oFormActMain.InCombat)
            {
                ProcessNamesOST(l);
                AddCombatActionHostile(l, (int)SwingTypeEnum.NonMelee, l.critical, l.special, l.attackType, Dnum.NoDamage, 0, l.type);
            }
        }

        private void ProcessActionDamage(ParsedLine l)
        {
            int magAdj = (int)Math.Round(l.Magnitude);
            int magBaseAdj = (int)Math.Round(l.BaseMagnitude);

            l.logInfo.detectedType = l.critical ? Color.Red.ToArgb() : Color.DarkRed.ToArgb();

            string special = l.special;

            MasterSwing msShielded = unmatchedShieldLines.MatchDamage(l);
            if (msShielded != null)
            {
                // Fix up the shield line.
                // Tags are about the only thing that can be altered on MS that is already added via AddCombatAction.
                // So do most of it with adding Tags.

                // Shield line:  add column for attack damage and % blocked
                // Attack line:  add amount shielded to the 'special' column.

                object val;
                if (msShielded.Tags.TryGetValue("DamageF", out val))
                {
                    float df = (float) val;
                    string shielNameecialText = "Shield(" + df.ToString("F1") + ")";

                    if (special == "None")
                    {
                        special = shielNameecialText;
                    }
                    else
                    {
                        special = l.special + " | " + shielNameecialText;
                    }

                    float shielded = df / l.Magnitude;
                    msShielded.Tags.Add("ShieldDmgF", l.Magnitude);
                    msShielded.Tags.Add("ShieldP", shielded);
                }
            }

            if (l.AbilityID == "Autodesc.Combatevent.Falling")
            {
                // Falling damage does not start combat...
                if (ActGlobals.oFormActMain.InCombat)
                {
                    ProcessNamesOST(l);
                    AddCombatActionHostile(l, l.swingType, l.critical, special, l.attackType, magAdj, l.Magnitude, l.type, l.BaseMagnitude);
                }
            }
            else if (l.AbilityID == "Pn.Wypyjw1") // Knight's Valor,
            {
                // "13:07:18:10:30:48.3::Largoevo,P[201228983@6531604 Largoevo@largoevo],Ugan the Abominable,C[1469 Mindflayer_Miniboss_Ugan],Largoevo,P[201228983@6531604 Largoevo@largoevo],Knight's Valor,Pn.Wypyjw1,Physical,,449.42,1195.48
                // Attack goes Source -> TRG and ignore the owner.  The Source is not the owner's pet.

                ProcessNamesST(l);
                AddCombatActionHostile(l, l.swingType, l.critical, special, l.attackType, magAdj, l.Magnitude, l.type, l.BaseMagnitude);
            }
            else
            {
                ProcessNamesOST(l);

                if ((l.AbilityID == "Pn.3t6cw8") && (magAdj > 0)) // Magic Missile
                {
                    ChaoticGrowthInfo cgi = null;
                    if (magicMissileLastHit.TryGetValue(l.TargetID, out cgi))
                    {
                        if (cgi.triggered)
                        {
                            TimeSpan t = l.logInfo.detectedTime - cgi.ts;
                            if (t.TotalSeconds > 10.0)
                            {
                                cgi.triggered = false;
                            }
                        }

                        if (!cgi.triggered)
                        {
                            cgi.encName = l.encAttackerName;
                            cgi.unitName = l.unitAttackerName;
                            cgi.ts = l.logInfo.detectedTime;
                        }
                    }
                    else
                    {
                        cgi = new ChaoticGrowthInfo();
                        cgi.encName = l.encAttackerName;
                        cgi.unitName = l.unitAttackerName;
                        cgi.triggered = false;
                        cgi.ts = l.logInfo.detectedTime;

                        magicMissileLastHit.Add(l.TargetID, cgi);
                    }
                }

                //
                // Note:  There seems to be many cases where dmgBase == 0 while damage is applied.
                //

                /*
                if (l.flags.Contains("Miss"))
                {
                    // TODO:  Not sure I have ever seen a "miss" in a log.  This actually valid?
                    AddCombatActionHostile(l, l.swingType, l.critical, l.special, l.attackType, Dnum.Miss, l.type, magBaseAdj);
                }
                else 
                */

                if (l.immune)
                {
                    if ((magAdj == 0) && (magBaseAdj == 0))
                    {
                        // 13:07:18:10:49:21.6::Tristan,C[2120 Pet_Dog],,*,Oll'noth the Dominator,C[1997 Mindflayer_Eventboss],Takedown,Pn.Ebxsjf,KnockBack,Immune,0,0

                        // Ignore these for now...
                        l.logInfo.detectedType = Color.Gray.ToArgb();
                    }
                    else
                    {
                        // Generally damaging attacks have mag=0 and magBase > 0 when Immune.
                        l.logInfo.detectedType = Color.Maroon.ToArgb();
                        AddCombatActionHostile(l, l.swingType, l.critical, special, l.attackType, Dnum.NoDamage, l.Magnitude, l.type, l.BaseMagnitude);
                    }
                }
                else if (l.dodge)
                {
                    // It really looks like Dodge does not stop all damage - just reduces it by about 80%...
                    // I have seen damaging attacks that are both Dodge and Kill in the flags.
                    // So the target dodged but still died.
                    l.logInfo.detectedType = Color.Maroon.ToArgb();
                    AddCombatActionHostile(l, l.swingType, l.critical, special, l.attackType, magAdj, l.Magnitude, l.type, l.BaseMagnitude);
                }
                else
                {
                    if ((magAdj == 0) && (magBaseAdj == 0))
                    {
                        // Ignore it...  This is generally a Non-Target entity getting AOE'd...
                        l.logInfo.detectedType = Color.Gray.ToArgb();
                    }
                    else
                    {
                        // NOT All attacks have a magBase (anymore).
                        AddCombatActionHostile(l, l.swingType, l.critical, special, l.attackType, magAdj, l.Magnitude, l.type, l.BaseMagnitude);
                    }
                }
            }
        }

        private void ProcessAction(ParsedLine l)
        {
            l.logInfo.detectedType = Color.Gray.ToArgb();

            if (l.type == "HitPoints")
            {
                ProcessActionHeals(l);
            }
            else if (l.type == "Shield")
            {
                ProcessActionShields(l);
            }
            else if (l.type == "Power")
            {
                ProcessActionPower(l);
            }
            else if (l.showPowerDisplayName)
            {
                // Non-damaging effects.
                ProcessActionSPDN(l);
            }
            else
            {
                // What is left should all be damage.
                ProcessActionDamage(l);
            }

            // add action Killing
            if (l.kill)
            {
                l.logInfo.detectedType = Color.Fuchsia.ToArgb();

                // Clean from last MM hit.
                // The Kill can come right before a proc.  Ordering isssue.
                // magicMissileLastHit.Remove(l.TargetID);

                // TODO: use TargetName or unitTargetName?
                ActGlobals.oFormSpellTimers.RemoveTimerMods(l.TargetName);
                ActGlobals.oFormSpellTimers.DispellTimerMods(l.TargetName);

                // AddCombatActionHostile(l, l.swingType, l.critical, l.special, "Killing", Dnum.Death, l.type);

                // Use encounter names attacker and target here.  This allows filtering
                if (ActGlobals.oFormActMain.SetEncounter(l.logInfo.detectedTime, l.encAttackerName, l.encTargetName))
                {
                    MasterSwing ms = 
                        new MasterSwing(l.swingType, l.critical, l.special, Dnum.Death, l.logInfo.detectedTime, l.ts, 
                            "Killing", l.unitAttackerName, "Death", l.unitTargetName);
                    ActGlobals.oFormActMain.AddCombatAction(ms);
                }
            }
        }

        // For hostile actions only.  Handles the SetEncounter().
        private void AddCombatActionHostile(
            ParsedLine line, int swingType, bool critical, string special, string theAttackType, Dnum Damage, float realDamage, string theDamageType, float baseDamage=0)
        {
            // Use encounter names attacker and target here.  This allows filtering
            if (ActGlobals.oFormActMain.SetEncounter(line.logInfo.detectedTime, line.encAttackerName, line.encTargetName))
            {
                string tempAttack = theAttackType;

                AddCombatActionML(
                    swingType, line.critical, special, line.unitAttackerName,
                    tempAttack, Damage, realDamage, baseDamage, line.logInfo.detectedTime,
                    line.ts, line.unitTargetName, theDamageType);
            }
        }

        // Wrapper around AddCombatAction to add extra Tags that are used in the ML plugin.
        private void AddCombatActionML(
            int swingType, bool critical, string special, string attacker, string theAttackType, 
            Dnum damage, float realDamage, float baseDamage,
            DateTime time, int timeSorter, string victim, string theDamageType)
        {
            MasterSwing ms = new MasterSwing(swingType, critical, special, damage, time, timeSorter, theAttackType, attacker, theDamageType, victim);

            ms.Tags.Add("DamageF", realDamage);
            ms.Tags.Add("BaseDamage", baseDamage);

            if (baseDamage > 0)
            {
                float eff = realDamage / baseDamage;
                ms.Tags.Add("Effectiveness", eff);
            }

            ActGlobals.oFormActMain.AddCombatAction(ms);
        }

        // Must match the DateTimeLogParser delegate signature
        private DateTime ParseDateTime(string FullLogLine)
        {
            if (FullLogLine.Length >= 21 && FullLogLine[19] == ':' && FullLogLine[20] == ':')
            {
                return DateTime.ParseExact(FullLogLine.Substring(0, 19), "yy':'MM':'dd':'HH':'mm':'ss'.'f", System.Globalization.CultureInfo.InvariantCulture);
            }
            return ActGlobals.oFormActMain.LastKnownTime;
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.BeforeLogLineRead -= oFormActMain_BeforeLogLineRead;
            ActGlobals.oFormActMain.OnCombatEnd -= oFormActMain_OnCombatEnd;
            ActGlobals.oFormActMain.LogFileChanged -= oFormActMain_LogFileChanged;

            if (optionsNode != null)
            {
                optionsNode.Remove();
                ActGlobals.oFormActMain.OptionsControlSets.Remove(@"Magic Legends\General");
            }

            for (int i = 0; i < ActGlobals.oFormActMain.OptionsTreeView.Nodes.Count; i++)
            {
                if (ActGlobals.oFormActMain.OptionsTreeView.Nodes[i].Text == "Magic Legends")
                    ActGlobals.oFormActMain.OptionsTreeView.Nodes[i].Remove();
            }

            SaveSettings();

            unmatchedShieldLines.Clear();
            entityOwnerRegistery.Clear();
            petOwnerRegistery.Clear();
            magicMissileLastHit.Clear();

            lblStatus.Text = "Magic Legends ACT plugin unloaded";
        }

        // Load option settings from file
        void LoadSettings()
        {

            xmlSettings.AddControlSetting(checkBox_mergeNPC.Name, checkBox_mergeNPC);
            xmlSettings.AddControlSetting(checkBox_mergePets.Name, checkBox_mergePets);
            xmlSettings.AddControlSetting(listBox_players.Name, listBox_players);

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }

            foreach (string i in listBox_players.Items)
            {
                playerCharacterNames.Add(i.ToString(), true);
            }
        }

        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");	// <Config>
            xWriter.WriteStartElement("SettingsSerializer");	// <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);	// Fill the SettingsSerializer XML
            xWriter.WriteEndElement();	// </SettingsSerializer>
            xWriter.WriteEndElement();	// </Config>
            xWriter.WriteEndDocument();	// Tie up loose ends (shouldn't be any)
            xWriter.Flush();	// Flush the file buffer to disk
            xWriter.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string name = textBox_player.Text;
            if ( ! listBox_players.Items.Contains(name) )
            {
                listBox_players.Items.Add(name);
                playerCharacterNames.Add(name, true);
                textBox_player.Clear();
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            string name = textBox_player.Text;
            if (listBox_players.Items.Contains(name))
            {
                listBox_players.Items.Remove(name);
                playerCharacterNames.Remove(name);
                textBox_player.Clear();
            }
        }

        private void button_clearAll_Click(object sender, EventArgs e)
        {
            listBox_players.Items.Clear();
            playerCharacterNames.Clear();
            textBox_player.Clear();
        }

        private void listBox_players_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_players.SelectedIndex != -1)
            {
                textBox_player.Text = listBox_players.SelectedItem.ToString();
            }
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            ActGlobals.oFormActMain.SetOptionsHelpText(String.Empty);
        }

        private void textBox_player_TextChanged(object sender, EventArgs e)
        {
            bool not_empty = (this.textBox_player.Text.Length > 0);
            this.button_remove.Enabled = this.button_add.Enabled = not_empty;

            if (!not_empty)
            {
                listBox_players.SelectedIndex = -1;
            }
        }

        private void playerNameControls_MouseEnter(object sender, EventArgs e)
        {
            ActGlobals.oFormActMain.SetOptionsHelpText("Add the names of your player characters.  This allows ACT to detect which player character is yours.  Spelling and capitalization must be exact.");
        }

        private void checkBox_mergeNPC_MouseEnter(object sender, EventArgs e)
        {
            ActGlobals.oFormActMain.SetOptionsHelpText("Select this option to merge NPC combatants by name.  This removes the instance number from the combatant name.  For example Orc [1], Orc [2], ... Orc [n] are all merged in Orc");
        }

        private void checkBox_mergePets_MouseEnter(object sender, EventArgs e)
        {
            ActGlobals.oFormActMain.SetOptionsHelpText("Merge a player's pet with the player and remove the pet as a combatant.");
        }
    }

    internal class OwnerInfo
    {
        public string ownerName;
        public string ownerID;
        public EntityType ownerEntityType;
        public string petName;
        public string petID;
    }

    internal interface OwnerRegistery
    {
        void Clear();
        void Register(ParsedLine line);
        OwnerInfo Resolve(string nameID);
    }

    internal class PetOwnerRegistery : OwnerRegistery
    {
        private Dictionary<string, OwnerInfo> petPlayerCache = new Dictionary<string, OwnerInfo>();
        private Dictionary<string, OwnerInfo> playerPetCache = new Dictionary<string, OwnerInfo>();

        public void Clear()
        {
            petPlayerCache.Clear();
            playerPetCache.Clear();
        }

        public void Register(ParsedLine line)
        {
            bool add = false;
            OwnerInfo OwnerInfo = null;

            // Record owner of all pets we see.
            if (line.SourceEntityType == EntityType.Pet)
            {
                if (petPlayerCache.TryGetValue(line.SourceID, out OwnerInfo))
                {
                    if (OwnerInfo.ownerID != line.OriginID)
                    {
                        // Pet Owner changed...  Not sure if possible... but just in case.
                        petPlayerCache.Remove(OwnerInfo.petID);
                        playerPetCache.Remove(OwnerInfo.ownerID);
                        add = true;
                    }
                }
                else
                {
                    // Check if this player had another pet registered and clean up.
                    // Only one pet is allowed.
                    if (playerPetCache.TryGetValue(line.OriginID, out OwnerInfo))
                    {
                        playerPetCache.Remove(line.OriginID);
                        petPlayerCache.Remove(OwnerInfo.petID);
                    }

                    add = true;
                }

                if (add)
                {
                    OwnerInfo = new OwnerInfo();
                    OwnerInfo.ownerName = line.OriginName;
                    OwnerInfo.ownerID = line.OriginID;
                    OwnerInfo.ownerEntityType = line.ownEntityType;
                    OwnerInfo.petName = line.SourceName;
                    OwnerInfo.petID = line.SourceID;

                    petPlayerCache.Add(line.SourceID, OwnerInfo);
                    playerPetCache.Add(line.OriginID, OwnerInfo);
                }
            }
        }

        public OwnerInfo Resolve(string nameID)
        {
            // Lookup the creature to see if it is a pet.

            OwnerInfo petOwner = null;
            if (petPlayerCache.TryGetValue(nameID, out petOwner))
            {
                return petOwner;
            }
            
            return null;
        }

    }

    internal class EntityOwnerRegistery : OwnerRegistery
    {
        private Dictionary<string, OwnerInfo> entityPlayerCache = new Dictionary<string, OwnerInfo>();

        public void Clear()
        {
            entityPlayerCache.Clear();
        }

        public void Register(ParsedLine line)
        {
            bool add = false;
            OwnerInfo OwnerInfo = null;

            // Record owner of all entities we see.
            if (line.SourceEntityType == EntityType.Entity)
            {
                if (entityPlayerCache.TryGetValue(line.SourceID, out OwnerInfo))
                {
                    if (OwnerInfo.ownerID != line.OriginID)
                    {
                        // Pet Owner changed...  Not sure if possible... but just in case.
                        entityPlayerCache.Remove(OwnerInfo.petID);
                        add = true;
                    }
                }
                else
                {
                    // Multiple entities may be owned by same owner.
                    add = true;
                }

                if (add)
                {
                    OwnerInfo = new OwnerInfo();
                    OwnerInfo.ownerName = line.OriginName;
                    OwnerInfo.ownerID = line.OriginID;
                    OwnerInfo.ownerEntityType = line.ownEntityType;
                    OwnerInfo.petName = line.SourceName;
                    OwnerInfo.petID = line.SourceID;

                    entityPlayerCache.Add(line.SourceID, OwnerInfo);
                }
            }
        }

        public OwnerInfo Resolve(string nameID)
        {
            // Lookup the creature to see if it is a pet.

            OwnerInfo petOwner = null;
            if (entityPlayerCache.TryGetValue(nameID, out petOwner))
            {
                return petOwner;
            }

            return null;
        }
    }

    internal class ChaoticGrowthInfo
    {
        public string encName;
        public string unitName;
        public bool triggered;
        public DateTime ts;
    }

    internal class ShieldLine
    {
        public MasterSwing ms;
        public ParsedLine line;
    }

    internal class UnmatchedShieldLines
    {
        // Added new lines to end to maintain FIFO/Time ordering.
        // Should act as a FIFO if 100% matches.
        private LinkedList<ShieldLine> active = new LinkedList<ShieldLine>();

        public UnmatchedShieldLines()
        {
        }

        public void Clear()
        {
            active.Clear();
        }

        public void AddShield(MasterSwing ms, ParsedLine line)
        {
            ShieldLine sl = new ShieldLine();
            sl.ms = ms;
            sl.line = line;

            active.AddLast(sl);
        }

        public MasterSwing MatchDamage(ParsedLine line)
        {
            LinkedListNode<ShieldLine> slnNext = active.First;

            while (slnNext != null)
            {
                LinkedListNode<ShieldLine> cur = slnNext;
                ShieldLine sl = cur.Value;
                slnNext = slnNext.Next;

                // Examaple:
                // 13:09:26:09:31:31.2::Lorne Fellbane,P[201332730@6101294 Lorne Fellbane@todesfaelle],,*,HeLLCaT,P[201327748@7398668 HeLLCaT@phantom3535],Bilethorn Weapon,Pn.Nhw1351,Shield,,-1.3,0
                // 13:09:26:09:31:31.2::Lorne Fellbane,P[201332730@6101294 Lorne Fellbane@todesfaelle],,*,HeLLCaT,P[201327748@7398668 HeLLCaT@phantom3535],Bilethorn Weapon,Pn.Nhw1351,Shield,,-10.9585,0
                // 13:09:26:09:31:31.2::Lorne Fellbane,P[201332730@6101294 Lorne Fellbane@todesfaelle],HeLLCaT,P[201327748@7398668 HeLLCaT@phantom3535],,*,Bilethorn Weapon,Pn.Nhw1351,Poison,,1.3,6.5
                // 13:09:26:09:31:31.2::Lorne Fellbane,P[201332730@6101294 Lorne Fellbane@todesfaelle],HeLLCaT,P[201327748@7398668 HeLLCaT@phantom3535],,*,Bilethorn Weapon,Pn.Nhw1351,Poison,,10.9585,54.7925

                // Notice that the Source field doesn't always match...

                /* Odd case of zero damage:
13:09:26:09:36:11.8::briserus,P[201401849@8271148 briserus@briserus],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Flaming Weapon,Pn.Mzftfj,Shield,,-2,-0.484209
13:09:26:09:36:11.8::briserus,P[201401849@8271148 briserus@briserus],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Flaming Weapon,Pn.Mzftfj,Shield,,-2,-0.242104
13:09:26:09:36:11.8::briserus,P[201401849@8271148 briserus@briserus],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Flaming Weapon,Pn.Mzftfj,Fire,Dodge,0,0
13:09:26:09:36:11.8::briserus,P[201401849@8271148 briserus@briserus],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Flaming Weapon,Pn.Mzftfj,Fire,,0,0
13:09:26:09:36:11.8::briserus,P[201401849@8271148 briserus@briserus],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Flaming Weapon,Pn.Mzftfj,Fire,,0.484209,2
13:09:26:09:36:11.8::briserus,P[201401849@8271148 briserus@briserus],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Flaming Weapon,Pn.Mzftfj,Fire,Dodge,0.242104,2
                */

                /* Two Shield lines for one damage line:  TODO: Handle this...
13:09:26:09:36:20.8::DRUGnROLL,P[200404637@6548010 DRUGnROLL@drugnroll],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Entangling Force,Pn.Oonws91,Shield,,-17.2139,-3.44278
13:09:26:09:36:20.8::DRUGnROLL,P[200404637@6548010 DRUGnROLL@drugnroll],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Entangling Force,Pn.Oonws91,Shield,,-340.835,0
13:09:26:09:36:20.8::Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],,*,,*,Health Steal,Pn.S6b30w1,HitPoints,,-0.0190611,0
13:09:26:09:36:20.8::Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],,*,,*,Health Steal,Pn.S6b30w1,HitPoints,,-0.117442,0
13:09:26:09:36:20.8::DRUGnROLL,P[200404637@6548010 DRUGnROLL@drugnroll],,*,Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],Entangling Force,Pn.Oonws91,Arcane,Critical,344.278,1721.39
13:09:26:09:36:20.9::Lord DopeVIII,P[200441364@6420568 Lord DopeVIII@lorddopeviii],,*,,*,Shielded Resurgence,Pn.Mrczs41,Null,ShowPowerDisplayName,0,0
                */

                // Compare
                if ((sl.line.AbilityID == line.AbilityID) &&
                        (sl.line.OriginID == line.OriginID) &&
                        // (sl.line.SourceID == line.SourceID) &&
                        (sl.line.TargetID == line.TargetID) &&
                        (line.type != "Shield") &&
                        (line.Magnitude > 0.0)  // <- Skip zero damage lines.
                    )
                {
                    // Matched
                    active.Remove(cur);
                    return sl.ms;
                }
                else
                {
                    // Check expired.
                    TimeSpan diff = line.logInfo.detectedTime - sl.ms.Time;

                    if (diff.TotalMilliseconds > 500)
                    {
                        // Drop old and unmatch shield lines.
                        // Generally shield line should match in <= 100ms.
                        active.Remove(cur);
                    }
                }
            }

            return null;
        }
    }

    internal enum EntityType
    {
        Player,
        Pet,
        Creature,
        Entity,
        Unknown
    }

    // Pre-parsed line
    internal class ParsedLine
    {

        public LogLineEventArgs logInfo;

        //
        // Parsed from the line.
        //

        public String OriginName, OriginID, SourceName, SourceID, TargetName, TargetID, AbilityName, AbilityID;
        public String type, attackType, special, flags;
        public int swingType, ts;
        public bool critical, dodge, immune, kill, showPowerDisplayName;
        public float Magnitude, BaseMagnitude;
        public bool error;

        //
        // Computed extra data.
        //

        public EntityType ownEntityType, SourceEntityType, TargetEntityType;
        public OwnerInfo TargetOwnerInfo = null;

        // The attacker name for encounters
        public String encAttackerName;

        // The target name for encounters
        public String encTargetName;

        // The attacker name for the combat action.
        public String unitAttackerName;

        // The target name for the combat action.
        public String unitTargetName;



        public ParsedLine(LogLineEventArgs logInfo)
        {
            //    Time            ::   ownName                                                              ,  ownID    ,     SourceName   ,   SourceID    ,   TargetName  ,           TargetID                        ,evtName,  evtID  ,type ,flags,mag,magBase
            //21:03:27:17:01:16.1::    Keldon Warlord,P[440730@31580857 Keldon Warlord@KeldonSlayer#31282],,*,Acolyte of Mishra,C[4194 Dom_Tolaria_Mishra_Hordeling_Acolyteofmishra],Magma Fist,Pn.Pyy1l21,Physical,,3936.48,0
            this.logInfo = logInfo;
            this.ts = ++ActGlobals.oFormActMain.GlobalTimeSorter;
            string[] split = logInfo.logLine.Split(MLParsing_Plugin.separatorLog, StringSplitOptions.None);
            OriginName = split[1];
            OriginID = split[2];
            SourceName = split[3];
            SourceID = split[4];
            TargetName = split[5];
            TargetID = split[6];
            AbilityName = split[7];
            AbilityID = split[8];
            type = split[9];
            flags = split[10];
            Magnitude = float.Parse(split[11], MLParsing_Plugin.cultureLog);
            BaseMagnitude = float.Parse(split[12], MLParsing_Plugin.cultureLog);
            if (split.Length != 13)
            {
                this.error = true;
            }

            ownEntityType = EntityType.Unknown;
            SourceEntityType = EntityType.Unknown;
            TargetEntityType = EntityType.Unknown;


            // Defaults for the clean names.
            encAttackerName = SourceName;
            encTargetName = TargetName;
            unitAttackerName = SourceName;
            unitTargetName = TargetName;


            kill = critical = dodge = immune = false;
            special = "None";
            if (flags.Length > 0)
            {
                int extraFlagCount = 0;
                string[] sflags = flags.Split('|');
                foreach (string sflag in sflags)
                {
                    switch (sflag)
                    {
                        case "Critical":
                            critical = true;
                            break;
                        case "Dodge":
                            dodge = true;
                            special = (extraFlagCount++ > 0) ? (special + " | " + sflag) : sflag;
                            break;
                        case "Immune":
                            immune = true;
                            special = (extraFlagCount++ > 0) ? (special + " | " + sflag) : sflag;
                            break;
                        case "Kill":
                            kill = true;
                            break;
                        case "ShowPowerDisplayName":
                            showPowerDisplayName = true;
                            break;

                        default:
                            special = (extraFlagCount++ > 0) ? (special + " | " + sflag) : sflag;
                            break;
                    }
                }
            }

            swingType = (int)SwingTypeEnum.NonMelee;

            attackType = AbilityName;
            if (attackType.Trim().Length == 0)
            {
                // Uggly fix for missing attack type
                attackType = MLParsing_Plugin.unknownAbility;
            }
        }
    }
}