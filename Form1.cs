using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipbreaker_Custom_Controls
{
    public partial class Form1 : Form
    {
        private string installLocation;
        private string configFile = "user_config.ini";
        List<string> keys;
        List<string> mouse;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            installLocation = GetInstallLocation();

            Assembly assembly = Assembly.LoadFrom(installLocation + @"Shipbreaker_Data\Managed\InControl.dll");
            Type assemblyKeyType = assembly.GetType("InControl.Key");
            Type assemblyMouseType = assembly.GetType("InControl.Mouse");
            object keyInstance = Activator.CreateInstance(assemblyKeyType);
            object mouseInstance = Activator.CreateInstance(assemblyMouseType);

            keys = System.Enum.GetNames(keyInstance.GetType()).ToList();
            mouse = System.Enum.GetNames(mouseInstance.GetType()).ToList();

            keys.Remove("None");
            keys.Remove("Key0");
            keys.Remove("Backspace");
            keys.Remove("Escape");
            keys.Remove("Return");
            mouse.Remove("None");
            mouse.Remove("NegativeX");
            mouse.Remove("PositiveX");
            mouse.Remove("NegativeY");
            mouse.Remove("PositiveY");

            mouse.AddRange(keys);

            fire.DataSource = mouse.ToList();
            altFire.DataSource = mouse.ToList();
            rotateLeft.DataSource = mouse.ToList();
            rotateRight.DataSource = mouse.ToList();
            forward.DataSource = mouse.ToList();
            left.DataSource = mouse.ToList();
            backward.DataSource = mouse.ToList();
            right.DataSource = mouse.ToList();
            up.DataSource = mouse.ToList();
            down.DataSource = mouse;
            interact.DataSource = mouse.ToList();
            grapplePush.DataSource = mouse.ToList();
            leftGrab.DataSource = mouse.ToList();
            rightGrab.DataSource = mouse.ToList();
            scanner.DataSource = mouse.ToList();
            workOrder.DataSource = mouse.ToList();
            flashlight.DataSource = mouse.ToList();
            brake.DataSource = mouse.ToList();
            clearTethers.DataSource = mouse.ToList();
            cycleScanLeft.DataSource = mouse.ToList();
            cycleScanRight.DataSource = mouse.ToList();
            //playAudioLog.DataSource = mouse.ToList();
            //unequip.DataSource = mouse.ToList();
            equipGrapple.DataSource = mouse.ToList();
            equipCutter.DataSource = mouse.ToList();
            //toggleFps.DataSource = mouse.ToList();
            //pauseMenu.DataSource = mouse.ToList();

            ApplyDefaults();
            ApplyCurrentControls();
        }

        private void ApplyCurrentControls()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(installLocation + configFile);

            string configFire = data["Configurable Grapple Controls"]["14a) GrappleHoldPrimary"];
            if (!String.IsNullOrEmpty(configFire))
            {
                fire.SelectedItem = mouse.Where(x => x == configFire).First();
            }

            string configAltFire = data["Configurable Grapple Controls"]["15a) RetractBeamPrimary"];
            if (!String.IsNullOrEmpty(configAltFire))
            {
                altFire.SelectedItem = mouse.Where(x => x == configAltFire).First();
            }

            string configRotateLeft = data["Configurable Movement Controls"]["08a) RotateBodyLeftPrimary"];
            if (!String.IsNullOrEmpty(configRotateLeft))
            {
                rotateLeft.SelectedItem = mouse.Where(x => x == configRotateLeft).First();
            }

            string configRotateRight = data["Configurable Movement Controls"]["07a) RotateBodyRightPrimary"];
            if (!String.IsNullOrEmpty(configRotateRight))
            {
                rotateRight.SelectedItem = mouse.Where(x => x == configRotateRight).First();
            }

            string configForward = data["Configurable Movement Controls"]["01a) ThrustMoveForwardPrimary"];
            if (!String.IsNullOrEmpty(configForward))
            {
                forward.SelectedItem = mouse.Where(x => x == configForward).First();
            }

            string configLeft = data["Configurable Movement Controls"]["04a) ThrustMoveLeftPrimary"];
            if (!String.IsNullOrEmpty(configLeft))
            {
                left.SelectedItem = mouse.Where(x => x == configLeft).First();
            }

            string configBackward = data["Configurable Movement Controls"]["02a) ThrustMoveBackPrimary"];
            if (!String.IsNullOrEmpty(configBackward))
            {
                backward.SelectedItem = mouse.Where(x => x == configBackward).First();
            }

            string configRight = data["Configurable Movement Controls"]["03a) ThrustMoveRightPrimary"];
            if (!String.IsNullOrEmpty(configRight))
            {
                right.SelectedItem = mouse.Where(x => x == configRight).First();
            }

            string configUp = data["Configurable Movement Controls"]["05a) ThrustMoveUpPrimary"];
            if (!String.IsNullOrEmpty(configUp))
            {
                up.SelectedItem = mouse.Where(x => x == configUp).First();
            }

            string configDown = data["Configurable Movement Controls"]["06a) ThrustMoveDownPrimary"];
            if (!String.IsNullOrEmpty(configDown))
            {
                down.SelectedItem = mouse.Where(x => x == configDown).First();
            }

            string configInteract = data["Configurable Misc Controls"]["26a) InteractPrimary"];
            if (!String.IsNullOrEmpty(configInteract))
            {
                interact.SelectedItem = mouse.Where(x => x == configInteract).First();
            }

            string configPush = data["Configurable Grapple Controls"]["20a) PushPrimary"];
            if (!String.IsNullOrEmpty(configPush))
            {
                grapplePush.SelectedItem = mouse.Where(x => x == configPush).First();
            }

            string configLeftGrab = data["Configurable Misc Controls"]["30a) LeftHandGrabPrimary"];
            if (!String.IsNullOrEmpty(configLeftGrab))
            {
                leftGrab.SelectedItem = mouse.Where(x => x == configLeftGrab).First();
            }

            string configRightGrab = data["Configurable Misc Controls"]["29a) RightHandGrabPrimary"];
            if (!String.IsNullOrEmpty(configRightGrab))
            {
                rightGrab.SelectedItem = mouse.Where(x => x == configRightGrab).First();
            }

            string configScanner = data["Configurable Scanner Controls"]["10a) ActivateScannerPrimary"];
            if (!String.IsNullOrEmpty(configScanner))
            {
                scanner.SelectedItem = mouse.Where(x => x == configScanner).First();
            }

            string configWorkOrder = data["Configurable Misc Controls"]["28a) WorkOrderPrimary"];
            if (!String.IsNullOrEmpty(configWorkOrder))
            {
                workOrder.SelectedItem = mouse.Where(x => x == configWorkOrder).First();
            }

            string configFlashlight = data["Configurable Misc Controls"]["27a) ToggleFlashlightPrimary"];
            if (!String.IsNullOrEmpty(configFlashlight))
            {
                flashlight.SelectedItem = mouse.Where(x => x == configFlashlight).First();
            }

            string configBrake = data["Configurable Movement Controls"]["09a) ThrustBrakePrimary"];
            if (!String.IsNullOrEmpty(configBrake))
            {
                brake.SelectedItem = mouse.Where(x => x == configBrake).First();
            }

            string configClearTethers = data["Configurable Grapple Controls"]["22a) CancelTethersPrimary"];
            if (!String.IsNullOrEmpty(configClearTethers))
            {
                clearTethers.SelectedItem = mouse.Where(x => x == configClearTethers).First();
            }

            string configCycleScanLeft = data["Configurable Scanner Controls"]["12a) ScanCycleLeftPrimary"];
            if (!String.IsNullOrEmpty(configCycleScanLeft))
            {
                cycleScanLeft.SelectedItem = mouse.Where(x => x == configCycleScanLeft).First();
            }

            string configCycleScanRight = data["Configurable Scanner Controls"]["11a) ScanCycleRightPrimary"];
            if (!String.IsNullOrEmpty(configCycleScanRight))
            {
                cycleScanRight.SelectedItem = mouse.Where(x => x == configCycleScanRight).First();
            }

            //string configPlayAudioLog = data["Controls"]["PlayAudioLog"];
            //if (!String.IsNullOrEmpty(configPlayAudioLog))
            //{
            //    playAudioLog.SelectedItem = mouse.Where(x => x == configPlayAudioLog).First();
            //}

            //string configUnequip = data["Controls"]["Unequip"];
            //if (!String.IsNullOrEmpty(configUnequip))
            //{
            //    unequip.SelectedItem = mouse.Where(x => x == configUnequip).First();
            //}

            string configEquipGrapple = data["Configurable Grapple Controls"]["13a) EquipGrapplePrimary"];
            if (!String.IsNullOrEmpty(configEquipGrapple))
            {
                equipGrapple.SelectedItem = mouse.Where(x => x == configEquipGrapple).First();
            }

            string configEquipCutter = data["Configurable Cutter Controls"]["23a) EquipCutterPrimary"];
            if (!String.IsNullOrEmpty(configEquipCutter))
            {
                equipCutter.SelectedItem = mouse.Where(x => x == configEquipCutter).First();
            }

            //string configToggleFps = data["Controls"]["ToggleFps"];
            //if (!String.IsNullOrEmpty(configToggleFps))
            //{
            //    toggleFps.SelectedItem = mouse.Where(x => x == configToggleFps).First();
            //}

            //string configPauseMenu = data["Controls"]["PauseMenu"];
            //if (!String.IsNullOrEmpty(configPauseMenu))
            //{
            //    pauseMenu.SelectedItem = mouse.Where(x => x == configPauseMenu).First();
            //}
        }

        private void ApplyDefaults()
        {
            fire.SelectedItem = mouse.Where(x => x == "LeftButton").First();
            altFire.SelectedItem = mouse.Where(x => x == "RightButton").First();
            rotateLeft.SelectedItem = mouse.Where(x => x == "Q").First();
            rotateRight.SelectedItem = mouse.Where(x => x == "E").First();
            forward.SelectedItem = mouse.Where(x => x == "W").First();
            left.SelectedItem = mouse.Where(x => x == "A").First();
            backward.SelectedItem = mouse.Where(x => x == "S").First();
            right.SelectedItem = mouse.Where(x => x == "D").First();
            up.SelectedItem = mouse.Where(x => x == "Space").First();
            down.SelectedItem = mouse.Where(x => x == "Shift").First();
            interact.SelectedItem = mouse.Where(x => x == "F").First();
            grapplePush.SelectedItem = mouse.Where(x => x == "F").First();
            leftGrab.SelectedItem = mouse.Where(x => x == "Z").First();
            rightGrab.SelectedItem = mouse.Where(x => x == "X").First();
            scanner.SelectedItem = mouse.Where(x => x == "T").First();
            workOrder.SelectedItem = mouse.Where(x => x == "Tab").First();
            flashlight.SelectedItem = mouse.Where(x => x == "L").First();
            brake.SelectedItem = mouse.Where(x => x == "Control").First();
            clearTethers.SelectedItem = mouse.Where(x => x == "V").First();
            cycleScanLeft.SelectedItem = mouse.Where(x => x == "PositiveScrollWheel").First();
            cycleScanRight.SelectedItem = mouse.Where(x => x == "NegativeScrollWheel").First();
            //playAudioLog.SelectedItem = mouse.Where(x => x == "Tab").First();
            //unequip.SelectedItem = mouse.Where(x => x == "Backspace").First();
            equipGrapple.SelectedItem = mouse.Where(x => x == "Key1").First();
            equipCutter.SelectedItem = mouse.Where(x => x == "Key2").First();
            //toggleFps.SelectedItem = mouse.Where(x => x == "F4").First();
            //pauseMenu.SelectedItem = mouse.Where(x => x == "Escape").First();
        }

        private string GetInstallLocation()
        {
            try
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                {
                    foreach (var name in key.GetSubKeyNames())
                    {
                        RegistryKey subKey = key.OpenSubKey(name);
                        if (subKey != null)
                        {
                            foreach (var value in subKey.GetValueNames())
                            {
                                string game = subKey.GetValue("DisplayName") as string;
                                if (game == "Hardspace: Shipbreaker")
                                {
                                    string location = subKey.GetValue("InstallLocation") as string;

                                    if (location.LastIndexOf(@"\") != location.Length - 1)
                                    {
                                        location = location + @"\";
                                    }

                                    return location;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        private void applyControls_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(installLocation + configFile);

            data["Configurable Grapple Controls"]["14a) GrappleHoldPrimary"] = fire.SelectedItem.ToString();
            data["Configurable Cutter Controls"]["24a) ExecuteCutPrimary"] = fire.SelectedItem.ToString();

            data["Configurable Grapple Controls"]["15a) RetractBeamPrimary"] = altFire.SelectedItem.ToString();
            data["Configurable Grapple Controls"]["21a) PlaceTethersPrimary"] = altFire.SelectedItem.ToString();
            data["Configurable Grapple Controls"]["21b) PlaceTethersSecondary"] = altFire.SelectedItem.ToString();
            data["Configurable Cutter Controls"]["25a) RotateAnglePrimary"] = altFire.SelectedItem.ToString();
            data["Configurable Cutter Controls"]["25b) RotateAngleSecondary"] = altFire.SelectedItem.ToString();

            data["Configurable Movement Controls"]["08a) RotateBodyLeftPrimary"] = rotateLeft.SelectedItem.ToString();
            data["Configurable Movement Controls"]["09c) ThrustBrakeSecondary"] = rotateLeft.SelectedItem.ToString();

            data["Configurable Movement Controls"]["07a) RotateBodyRightPrimary"] = rotateRight.SelectedItem.ToString();
            data["Configurable Movement Controls"]["09d) ThrustBrakeSimultaneous"] = rotateRight.SelectedItem.ToString();

            data["Configurable Movement Controls"]["01a) ThrustMoveForwardPrimary"] = forward.SelectedItem.ToString();
            data["Configurable Movement Controls"]["01b) ThrustMoveForwardSecondary"] = forward.SelectedItem.ToString();
            data["Configurable Grapple Controls"]["16a) SwingUpPrimary"] = forward.SelectedItem.ToString();
            data["Configurable Menu Controls"]["36a) NavigateUpPrimary"] = forward.SelectedItem.ToString();
            data["Configurable Menu Controls"]["36b) NavigateUpSecondary"] = forward.SelectedItem.ToString();

            data["Configurable Movement Controls"]["04a) ThrustMoveLeftPrimary"] = left.SelectedItem.ToString();
            data["Configurable Movement Controls"]["04b) ThrustMoveLeftSecondary"] = left.SelectedItem.ToString();
            data["Configurable Grapple Controls"]["19a) SwingLeftPrimary"] = left.SelectedItem.ToString();
            data["Configurable Menu Controls"]["39a) NavigateLeftPrimary"] = left.SelectedItem.ToString();
            data["Configurable Menu Controls"]["39b) NavigateLeftSecondary"] = left.SelectedItem.ToString();

            data["Configurable Movement Controls"]["02a) ThrustMoveBackPrimary"] = backward.SelectedItem.ToString();
            data["Configurable Movement Controls"]["02b) ThrustMoveBackSecondary"] = backward.SelectedItem.ToString();
            data["Configurable Grapple Controls"]["17a) SwingDownPrimary"] = backward.SelectedItem.ToString();
            data["Configurable Menu Controls"]["37a) NavigateDownPrimary"] = backward.SelectedItem.ToString();
            data["Configurable Menu Controls"]["37b) NavigateDownSecondary"] = backward.SelectedItem.ToString();

            data["Configurable Movement Controls"]["03a) ThrustMoveRightPrimary"] = right.SelectedItem.ToString();
            data["Configurable Movement Controls"]["03b) ThrustMoveRightSecondary"] = right.SelectedItem.ToString();
            data["Configurable Grapple Controls"]["18a) SwingRightPrimary"] = right.SelectedItem.ToString();
            data["Configurable Menu Controls"]["38a) NavigateRightPrimary"] = right.SelectedItem.ToString();
            data["Configurable Menu Controls"]["38b) NavigateRightSecondary"] = right.SelectedItem.ToString();

            data["Configurable Movement Controls"]["05a) ThrustMoveUpPrimary"] = up.SelectedItem.ToString();

            data["Configurable Movement Controls"]["06a) ThrustMoveDownPrimary"] = down.SelectedItem.ToString();
            data["Configurable Movement Controls"]["06b) ThrustMoveDownSecondary"] = down.SelectedItem.ToString();

            data["Configurable Misc Controls"]["26a) InteractPrimary"] = interact.SelectedItem.ToString();

            data["Configurable Grapple Controls"]["20a) PushPrimary"] = grapplePush.SelectedItem.ToString();

            data["Configurable Misc Controls"]["30a) LeftHandGrabPrimary"] = leftGrab.SelectedItem.ToString();

            data["Configurable Misc Controls"]["29a) RightHandGrabPrimary"] = rightGrab.SelectedItem.ToString();

            data["Configurable Scanner Controls"]["10a) ActivateScannerPrimary"] = scanner.SelectedItem.ToString();
            data["Configurable Scanner Controls"]["10b) ActivateScannerSecondary"] = scanner.SelectedItem.ToString();

            data["Configurable Misc Controls"]["28a) WorkOrderPrimary"] = workOrder.SelectedItem.ToString();
            data["Configurable Misc Controls"]["28b) WorkOrderSecondary"] = workOrder.SelectedItem.ToString();

            data["Configurable Misc Controls"]["27a) ToggleFlashlightPrimary"] = flashlight.SelectedItem.ToString();
            data["Configurable Misc Controls"]["27b) ToggleFlashlightSecondary"] = flashlight.SelectedItem.ToString();

            data["Configurable Movement Controls"]["09a) ThrustBrakePrimary"] = brake.SelectedItem.ToString();

            data["Configurable Grapple Controls"]["22a) CancelTethersPrimary"] = clearTethers.SelectedItem.ToString();
            
            data["Configurable Scanner Controls"]["12a) ScanCycleLeftPrimary"] = cycleScanLeft.SelectedItem.ToString();
            data["Configurable Scanner Controls"]["12b) ScanCycleLeftSecondary"] = cycleScanLeft.SelectedItem.ToString();

            data["Configurable Scanner Controls"]["11a) ScanCycleRightPrimary"] = cycleScanRight.SelectedItem.ToString();
            data["Configurable Scanner Controls"]["11b) ScanCycleRightSecondary"] = cycleScanRight.SelectedItem.ToString();

            //data["Controls"]["PlayAudioLog"] = playAudioLog.SelectedItem.ToString();
            //data["Controls"]["Unequip"] = unequip.SelectedItem.ToString();
            
            data["Configurable Grapple Controls"]["13a) EquipGrapplePrimary"] = equipGrapple.SelectedItem.ToString();
            
            data["Configurable Cutter Controls"]["23a) EquipCutterPrimary"] = equipCutter.SelectedItem.ToString();
           
            //data["Controls"]["ToggleFps"] = toggleFps.SelectedItem.ToString();
            
            //data["Configurable Misc Controls"]["27a) PausePrimary"] = pauseMenu.SelectedItem.ToString();
            //data["Configurable Menu Controls"]["35a) BackPrimary"] = pauseMenu.SelectedItem.ToString();

            parser.WriteFile(installLocation + configFile, data);
        }

        private void resetDefaults_Click(object sender, EventArgs e)
        {
            ApplyDefaults();
        }
    }
}
