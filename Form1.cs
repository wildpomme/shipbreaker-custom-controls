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
        public enum Mouse
        {
            LeftButton,
            RightButton,
            MiddleButton,
            NegativeX,
            Button4,
            Button5,
            Button6,
            Button7,
            Button8,
            Button9
        }

        private string installLocation;
        private string configFile = "user_config.ini";
        private string gameFile = @"Shipbreaker_Data\Managed\BBI.Unity.Game.dll";
        private string originalHash = "4a00822be256f3c25446979bec7ca3b1";
        private string newHash = "3d78de99758d1d6f2c3dd9cf31cd1621";
        private string currentHash;
        List<string> keys;
        List<string> mouse;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            installLocation = GetInstallLocation();
            UpdateHashes();

            Assembly assembly = Assembly.LoadFrom(installLocation + @"Shipbreaker_Data\Managed\InControl.dll");
            Type assemblyKeyType = assembly.GetType("InControl.Key");
            Type assemblyMouseType = assembly.GetType("InControl.Mouse");
            object keyInstance = Activator.CreateInstance(assemblyKeyType);
            object mouseInstance = Activator.CreateInstance(assemblyMouseType);

            keys = System.Enum.GetNames(keyInstance.GetType()).ToList();
            mouse = System.Enum.GetNames(mouseInstance.GetType()).ToList();

            keys.Remove("None");
            mouse.Remove("None");
            mouse.Remove("NegativeX");
            mouse.Remove("PositiveX");
            mouse.Remove("NegativeY");
            mouse.Remove("PositiveY");
            mouse.Remove("PositiveScrollWheel");
            mouse.Remove("NegativeScrollWheel");

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

            applyDefaults();
            applyCurrentControls();
        }

        private void applyCurrentControls()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(installLocation + configFile);

            string configFire = data["Controls"]["Fire"];
            if (!String.IsNullOrEmpty(configFire))
            {
                fire.SelectedItem = mouse.Where(x => x == configFire).First();
            }

            string configAltFire = data["Controls"]["AltFire"];
            if (!String.IsNullOrEmpty(configAltFire))
            {
                altFire.SelectedItem = mouse.Where(x => x == configAltFire).First();
            }

            string configRotateLeft = data["Controls"]["RotateLeft"];
            if (!String.IsNullOrEmpty(configRotateLeft))
            {
                rotateLeft.SelectedItem = mouse.Where(x => x == configRotateLeft).First();
            }

            string configRotateRight = data["Controls"]["RotateRight"];
            if (!String.IsNullOrEmpty(configRotateRight))
            {
                rotateRight.SelectedItem = mouse.Where(x => x == configRotateRight).First();
            }

            string configForward = data["Controls"]["Forward"];
            if (!String.IsNullOrEmpty(configForward))
            {
                forward.SelectedItem = mouse.Where(x => x == configForward).First();
            }

            string configLeft = data["Controls"]["Left"];
            if (!String.IsNullOrEmpty(configLeft))
            {
                left.SelectedItem = mouse.Where(x => x == configLeft).First();
            }

            string configBackward = data["Controls"]["Backward"];
            if (!String.IsNullOrEmpty(configBackward))
            {
                backward.SelectedItem = mouse.Where(x => x == configBackward).First();
            }

            string configRight = data["Controls"]["Right"];
            if (!String.IsNullOrEmpty(configRight))
            {
                right.SelectedItem = mouse.Where(x => x == configRight).First();
            }

            string configUp = data["Controls"]["Up"];
            if (!String.IsNullOrEmpty(configUp))
            {
                up.SelectedItem = mouse.Where(x => x == configUp).First();
            }

            string configDown = data["Controls"]["Down"];
            if (!String.IsNullOrEmpty(configDown))
            {
                down.SelectedItem = mouse.Where(x => x == configDown).First();
            }

            string configInteract = data["Controls"]["Interact"];
            if (!String.IsNullOrEmpty(configInteract))
            {
                interact.SelectedItem = mouse.Where(x => x == configInteract).First();
            }

            string configPush = data["Controls"]["Push"];
            if (!String.IsNullOrEmpty(configPush))
            {
                grapplePush.SelectedItem = mouse.Where(x => x == configPush).First();
            }

            string configLeftGrab = data["Controls"]["LeftGrab"];
            if (!String.IsNullOrEmpty(configLeftGrab))
            {
                leftGrab.SelectedItem = mouse.Where(x => x == configLeftGrab).First();
            }

            string configRightGrab = data["Controls"]["RightGrab"];
            if (!String.IsNullOrEmpty(configRightGrab))
            {
                rightGrab.SelectedItem = mouse.Where(x => x == configRightGrab).First();
            }

            string configScanner = data["Controls"]["Scanner"];
            if (!String.IsNullOrEmpty(configScanner))
            {
                scanner.SelectedItem = mouse.Where(x => x == configScanner).First();
            }

            string configWorkOrder = data["Controls"]["WorkOrder"];
            if (!String.IsNullOrEmpty(configWorkOrder))
            {
                workOrder.SelectedItem = mouse.Where(x => x == configWorkOrder).First();
            }

            string configFlashlight = data["Controls"]["Flashlight"];
            if (!String.IsNullOrEmpty(configFlashlight))
            {
                flashlight.SelectedItem = mouse.Where(x => x == configFlashlight).First();
            }

            string configBrake = data["Controls"]["Brake"];
            if (!String.IsNullOrEmpty(configBrake))
            {
                brake.SelectedItem = mouse.Where(x => x == configBrake).First();
            }

            string configClearTethers = data["Controls"]["ClearTethers"];
            if (!String.IsNullOrEmpty(configClearTethers))
            {
                clearTethers.SelectedItem = mouse.Where(x => x == configClearTethers).First();
            }
        }

        private void applyDefaults()
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
            down.SelectedItem = mouse.Where(x => x == "C").First();
            interact.SelectedItem = mouse.Where(x => x == "F").First();
            grapplePush.SelectedItem = mouse.Where(x => x == "F").First();
            leftGrab.SelectedItem = mouse.Where(x => x == "Z").First();
            rightGrab.SelectedItem = mouse.Where(x => x == "X").First();
            scanner.SelectedItem = mouse.Where(x => x == "T").First();
            workOrder.SelectedItem = mouse.Where(x => x == "Tab").First();
            flashlight.SelectedItem = mouse.Where(x => x == "L").First();
            brake.SelectedItem = mouse.Where(x => x == "Control").First();
            clearTethers.SelectedItem = mouse.Where(x => x == "V").First();
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

        private string GetGameMD5()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(installLocation + gameFile))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private void applyControls_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(installLocation + configFile);

            data["Controls"]["Fire"] = fire.SelectedItem.ToString();
            data["Controls"]["AltFire"] = altFire.SelectedItem.ToString();
            data["Controls"]["RotateLeft"] = rotateLeft.SelectedItem.ToString();
            data["Controls"]["RotateRight"] = rotateRight.SelectedItem.ToString();
            data["Controls"]["Forward"] = forward.SelectedItem.ToString();
            data["Controls"]["Left"] = left.SelectedItem.ToString();
            data["Controls"]["Backward"] = backward.SelectedItem.ToString();
            data["Controls"]["Right"] = right.SelectedItem.ToString();
            data["Controls"]["Up"] = up.SelectedItem.ToString();
            data["Controls"]["Down"] = down.SelectedItem.ToString();
            data["Controls"]["Interact"] = interact.SelectedItem.ToString();
            data["Controls"]["Push"] = grapplePush.SelectedItem.ToString();
            data["Controls"]["LeftGrab"] = leftGrab.SelectedItem.ToString();
            data["Controls"]["RightGrab"] = rightGrab.SelectedItem.ToString();
            data["Controls"]["Scanner"] = scanner.SelectedItem.ToString();
            data["Controls"]["WorkOrder"] = workOrder.SelectedItem.ToString();
            data["Controls"]["Flashlight"] = flashlight.SelectedItem.ToString();
            data["Controls"]["Brake"] = brake.SelectedItem.ToString();
            data["Controls"]["ClearTethers"] = clearTethers.SelectedItem.ToString();

            parser.WriteFile(installLocation + configFile, data);
        }

        private void applyPatch_Click(object sender, EventArgs e)
        {
            string game = installLocation + gameFile;
            string backup = installLocation + gameFile + ".bak";
            if (File.Exists(game) && !File.Exists(backup) && originalHash.Equals(currentHash, StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(game, backup);
            }

            byte[] file = File.ReadAllBytes(game);
            byte[] delta = File.ReadAllBytes("delta.file");

            byte[] patched = Fossil.Delta.Apply(file, delta);
            File.WriteAllBytes(game, patched);

            UpdateHashes();
        }

        private void UpdateHashes()
        {
            currentHash = GetGameMD5();

            if (originalHash.Equals(currentHash, StringComparison.OrdinalIgnoreCase))
            {
                patchApplied.Text = "Custom controls patch has not been applied.";
                applyPatch.Enabled = true;
            }
            else if (newHash.Equals(currentHash, StringComparison.OrdinalIgnoreCase))
            {
                patchApplied.Text = "Custom controls patch is applied.";
                applyPatch.Enabled = false;
            }
            else
            {
                patchApplied.Text = "The game must have been updated, so this mod will no longer work";
                applyPatch.Enabled = false;
            }

            string backup = installLocation + gameFile + ".bak";
            if (File.Exists(backup))
            {
                restoreBackup.Enabled = true;
            }
            else
            {
                restoreBackup.Enabled = false;
            }
        }

        private void restoreBackup_Click(object sender, EventArgs e)
        {
            string game = installLocation + gameFile;
            string backup = installLocation + gameFile + ".bak";
            if (File.Exists(game) && File.Exists(backup))
            {
                File.Copy(backup, game, true);
                File.Delete(backup);

                UpdateHashes();
            }
        }
    }
}
