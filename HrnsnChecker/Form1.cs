﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HrnsnChecker.Properties;

namespace HrnsnChecker
{
    public partial class HrnsnChecker : Form
    {

        //http://render-eu.worldofwarcraft.com/character/onyxia/49/108319537-profilemain.jpg
        //http://render-eu.worldofwarcraft.com/character/onyxia/49/108319537-mobile-profile.jpg
        //http://render-eu.worldofwarcraft.com/character/onyxia/49/108319537-thumbnail.jpg

        private bool firstClickDone = false;

        public HrnsnChecker()
        {
            InitializeComponent();
        }

        

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (!InputTextValid())
            {
                MessageBox.Show("Name ungültig");
                return;
            }

            pbAotc.Image = Resources.Loading_icon_klein;
            pbConquerer.Image = Resources.Loading_icon_klein;
            pbMaster.Image = Resources.Loading_icon_klein;
            pbOnik.Image = Resources.Loading_icon_klein;
            pbNightbane.Image = Resources.Loading_icon_klein;
            pbBonusTrait.Image = Resources.Loading_icon_klein;

            var character = new Character(tbName.Text);

            var apiRequest = new BlizzardAPI.WebAPI(character);
            var achievementsRootObjectTask = apiRequest.GetCharacterAchievementsAsync();
            var statisticsRootObjectTask = apiRequest.GetCharacterStatisticsAsync();
            var mountsRootObjectTask = apiRequest.GetCharacterMountsAsync();
            var auditRootObjectTask = apiRequest.GetCharacterAuditAsync();
            var itemsRootObjectTask = apiRequest.GetCharacterItemsAsync();

            var achievementsRootObject = await achievementsRootObjectTask;
            var statisticsRootObject = await statisticsRootObjectTask;
            var mountsRootObject = await mountsRootObjectTask;
            var auditRootObject = await auditRootObjectTask;
            var itemsRootObject = await itemsRootObjectTask;
            

            if (achievementsRootObject == null ||
                statisticsRootObject == null ||
                mountsRootObject == null ||
                auditRootObject == null ||
                itemsRootObject == null)
            {
                MessageBox.Show("WebAPI Error or Character not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var jsonDataFilter = new JSONDataFilter(achievementsRootObject, mountsRootObject, statisticsRootObject, null, null, auditRootObject, itemsRootObject);
           

            UpdatePanelAchievements(jsonDataFilter);
            UpdatePanelExp(jsonDataFilter);
            UpdatePanelGear(jsonDataFilter);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private bool InputTextValid()
        {
            if (tbName.Text != string.Empty && tbName.Text.Contains("-")) return true;
            return false;
        }

        private void UpdatePanelAchievements(JSONDataFilter datafilter)
        {
            //aotc
            if (datafilter.AchievementCompleted(11194))
                ToggleCheckBox(pbAotc, true);
            else
                ToggleCheckBox(pbAotc, false);

            //conquerer
            if (datafilter.AchievementCompleted(11185))
                ToggleCheckBox(pbConquerer, true);
            else
                ToggleCheckBox(pbConquerer, false);

            //master
            if (datafilter.AchievementCompleted(11162))
                ToggleCheckBox(pbMaster, true);
            else
                ToggleCheckBox(pbMaster, false);

            //one night in kara
            if (datafilter.AchievementCompleted(11430))
                ToggleCheckBox(pbOnik, true);
            else
                ToggleCheckBox(pbOnik, false);

            //nightbane mount
            if (datafilter.MountObtained(142552))
                ToggleCheckBox(pbNightbane, true);
            else
                ToggleCheckBox(pbNightbane, false);
        }
        private void UpdatePanelGear(JSONDataFilter datafilter)
        {
            lbItemLvl.Text = $"ItemLvl equipped: {datafilter.GearItemLevelManualCalc()}";
            lbTraitCount.Text = $"Traits Count: {datafilter.GearTraitCount()}";
            lbBonusTraitCount.Text = $"Bonus Trait Count: {datafilter.GearBonusTraitCount()}";
            lbSlotsMissingGems.Text = $"Slots missing gems: {datafilter.GearNoGemsCount()}";
            lbLastArmoryUpdate.Text = $"Last Armory update: {datafilter.ArmoryLastUpdate()}";

            

            if (datafilter.GearBonusTraitCount() > 0)
                pbBonusTrait.Image = Resources.y;
            else
                pbBonusTrait.Image = Resources.x;
        }

        //X
        private void UpdatePanelExp(JSONDataFilter datafilter)
        {
            var idList = new List<int>() {
                10880, //EoA
                10883, //DhT
                10886, //NL
                10889, //HoV
                10898, //VoW
                10901, //BRH
                10904, //MoS
                10907, //Arcway
                10910, //CoS
                11406, //Kara
            };

            //-----------
            var dict = datafilter.GetDungeonCount(idList);


            lbMPlusCount.Text = $"M+ Count: {dict["Gesamt"]}";
            lbDungeonEoA.Text = $"{dict["EoA"]}";
            lbDungeonDhT.Text = $"{dict["DhT"]}";
            lbDungeonNL.Text = $"{dict["NL"]}";
            lbDungeonHoV.Text = $"{dict["HoV"]}";
            lbDungeonVoW.Text = $"{dict["VoW"]}";
            lbDungeonBRH.Text = $"{dict["BRH"]}";
            lbDungeonMoS.Text = $"{dict["MoS"]}";
            lbDungeonArc.Text = $"{dict["Arcway"]}";
            lbDungeonCoS.Text = $"{dict["CoS"]}";
            lbDungeonKara.Text = $"{dict["Kara"]}";

        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            btnCheck_Click(this, EventArgs.Empty);
        }

        private void ToggleCheckBox(PictureBox pb, bool completed)
        {
            if (completed)
                pb.Image = Resources.y;
            else
                pb.Image = Resources.x;
        }

        private void tbName_Click(object sender, EventArgs e)
        {
            if(!firstClickDone)
                tbName.Text = string.Empty;
            firstClickDone = true;
        }
    }
}
