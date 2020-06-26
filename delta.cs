private static Mouse ConvertStringToMouse(string mouseString)
{
    Mouse mouse;
    try { mouse = (Mouse)Enum.Parse(typeof(Mouse), mouseString, true); }
    catch { return Mouse.None; }
    return mouse;
}

private static Key[] ConvertStringToKey(string keyString1, string keyString2 = "")
{
    Key[] keys;

    Key? key1 = null;
    Key? key2 = null;
    try
    {
        key1 = (Key)Enum.Parse(typeof(Key), keyString1, true);

        if (!String.IsNullOrEmpty(keyString2))
        {
            key2 = (Key)Enum.Parse(typeof(Key), keyString2, true);
        }
    }
    catch { return null; }

    if (key2 != null)
    {
        keys = new Key[] { (Key)key1, (Key)key2 };
    }
    else
    {
        keys = new Key[] { (Key)key1 };
    }

    return keys;
}

public static string Fire
{
    get
    {
        return LynxControlsUserOptions.sFire;
    }
    set
    {
        LynxControlsUserOptions.sFire.Value = value;
    }
}

public static string AltFire
{
    get
    {
        return LynxControlsUserOptions.sAltFire;
    }
    set
    {
        LynxControlsUserOptions.sAltFire.Value = value;
    }
}

public static string RotateLeft
{
    get
    {
        return LynxControlsUserOptions.sRotateLeft;
    }
    set
    {
        LynxControlsUserOptions.sRotateLeft.Value = value;
    }
}

public static string RotateRight
{
    get
    {
        return LynxControlsUserOptions.sRotateRight;
    }
    set
    {
        LynxControlsUserOptions.sRotateRight.Value = value;
    }
}

public static string Up
{
    get
    {
        return LynxControlsUserOptions.sUp;
    }
    set
    {
        LynxControlsUserOptions.sUp.Value = value;
    }
}

public static string Down
{
    get
    {
        return LynxControlsUserOptions.sDown;
    }
    set
    {
        LynxControlsUserOptions.sDown.Value = value;
    }
}

public static string Forward
{
    get
    {
        return LynxControlsUserOptions.sForward;
    }
    set
    {
        LynxControlsUserOptions.sForward.Value = value;
    }
}

public static string Left
{
    get
    {
        return LynxControlsUserOptions.sLeft;
    }
    set
    {
        LynxControlsUserOptions.sLeft.Value = value;
    }
}

public static string Backward
{
    get
    {
        return LynxControlsUserOptions.sBackward;
    }
    set
    {
        LynxControlsUserOptions.sBackward.Value = value;
    }
}

public static string Right
{
    get
    {
        return LynxControlsUserOptions.sRight;
    }
    set
    {
        LynxControlsUserOptions.sRight.Value = value;
    }
}

public static string Interact
{
    get
    {
        return LynxControlsUserOptions.sInteract;
    }
    set
    {
        LynxControlsUserOptions.sInteract.Value = value;
    }
}

public static string Push
{
    get
    {
        return LynxControlsUserOptions.sPush;
    }
    set
    {
        LynxControlsUserOptions.sPush.Value = value;
    }
}

public static string LeftGrab
{
    get
    {
        return LynxControlsUserOptions.sLeftGrab;
    }
    set
    {
        LynxControlsUserOptions.sLeftGrab.Value = value;
    }
}

public static string RightGrab
{
    get
    {
        return LynxControlsUserOptions.sRightGrab;
    }
    set
    {
        LynxControlsUserOptions.sRightGrab.Value = value;
    }
}

public static string Scanner
{
    get
    {
        return LynxControlsUserOptions.sScanner;
    }
    set
    {
        LynxControlsUserOptions.sScanner.Value = value;
    }
}

public static string WorkOrder
{
    get
    {
        return LynxControlsUserOptions.sWorkOrder;
    }
    set
    {
        LynxControlsUserOptions.sWorkOrder.Value = value;
    }
}

public static string Flashlight
{
    get
    {
        return LynxControlsUserOptions.sFlashlight;
    }
    set
    {
        LynxControlsUserOptions.sFlashlight.Value = value;
    }
}

public static string Brake
{
    get
    {
        return LynxControlsUserOptions.sBrake;
    }
    set
    {
        LynxControlsUserOptions.sBrake.Value = value;
    }
}

public static string ClearTethers
{
    get
    {
        return LynxControlsUserOptions.sClearTethers;
    }
    set
    {
        LynxControlsUserOptions.sClearTethers.Value = value;
    }
}

public static string CycleScanLeft
{
    get
    {
        return LynxControlsUserOptions.sCycleScanLeft;
    }
    set
    {
        LynxControlsUserOptions.sCycleScanLeft.Value = value;
    }
}

public static string CycleScanRight
{
    get
    {
        return LynxControlsUserOptions.sCycleScanRight;
    }
    set
    {
        LynxControlsUserOptions.sCycleScanRight.Value = value;
    }
}

public static string PlayAudioLog
{
    get
    {
        return LynxControlsUserOptions.sPlayAudioLog;
    }
    set
    {
        LynxControlsUserOptions.sPlayAudioLog.Value = value;
    }
}

public static string Unequip
{
    get
    {
        return LynxControlsUserOptions.sUnequip;
    }
    set
    {
        LynxControlsUserOptions.sUnequip.Value = value;
    }
}

public static string EquipGrapple
{
    get
    {
        return LynxControlsUserOptions.sEquipGrapple;
    }
    set
    {
        LynxControlsUserOptions.sEquipGrapple.Value = value;
    }
}

public static string EquipCutter
{
    get
    {
        return LynxControlsUserOptions.sEquipCutter;
    }
    set
    {
        LynxControlsUserOptions.sEquipCutter.Value = value;
    }
}

public static string ToggleFps
{
    get
    {
        return LynxControlsUserOptions.sToggleFps;
    }
    set
    {
        LynxControlsUserOptions.sToggleFps.Value = value;
    }
}

public static string PauseMenu
{
    get
    {
        return LynxControlsUserOptions.sPauseMenu;
    }
    set
    {
        LynxControlsUserOptions.sPauseMenu.Value = value;
    }
}

private const string kFire = "Fire";
private const string kFireDesc = " Fires your current equipment";

private const string kAltFire = "AltFire";
private const string kAltFireDesc = " Alt fires your current equipment";

private const string kRotateLeft = "RotateLeft";
private const string kRotateLeftDesc = " Rotates your body left";

private const string kRotateRight = "RotateRight";
private const string kRotateRightDesc = " Rotates your body right";

private const string kUp = "Up";
private const string kUpDesc = " Moves up";

private const string kDown = "Down";
private const string kDownDesc = " Moves down";

private const string kForward = "Forward";
private const string kForwardDesc = " Moves forward";

private const string kLeft = "Left";
private const string kLeftDesc = " Moves left";

private const string kBackward = "Backward";
private const string kBackwardDesc = " Moves backward";

private const string kRight = "Right";
private const string kRightDesc = " Moves right";

private const string kInteract = "Interact";
private const string kInteractDesc = " Interacts with object";

private const string kPush = "Push";
private const string kPushDesc = " Fires grapple push";

private const string kLeftGrab = "LeftGrab";
private const string kLeftGrabDesc = " Grabs with left hand";

private const string kRightGrab = "RightGrab";
private const string kRightGrabDesc = " Grabs with right hand";

private const string kScanner = "Scanner";
private const string kScannerDesc = " Activates scanner";

private const string kWorkOrder = "WorkOrder";
private const string kWorkOrderDesc = " Displays workorder";

private const string kFlashlight = "Flashlight";
private const string kFlashlightDesc = " Controls flashlight";

private const string kBrake = "Brake";
private const string kBrakeDesc = " Stops movement";

private const string kClearTethers = "ClearTethers";
private const string kClearTethersDesc = " Clears all tethers";

private const string kCycleScanLeft = "CycleScanLeft";
private const string kCycleScanLeftDesc = " Cycles scanner mode to the left";

private const string kCycleScanRight = "CycleScanRight";
private const string kCycleScanRightDesc = " Cycles scanner mode to the right";

private const string kPlayAudioLog = "PlayAudioLog";
private const string kPlayAudioLogDesc = " Plays an audio log";

private const string kUnequip = "Unequip";
private const string kUnequipDesc = " Puts away your current equipment";

private const string kEquipGrapple = "EquipGrapple";
private const string kEquipGrappleDesc = " Equips the grapple gun";

private const string kEquipCutter = "EquipCutter";
private const string kEquipCutterDesc = " Equips the cutter tool";

private const string kToggleFps = "ToggleFps";
private const string kToggleFpsDesc = " Toggles the fps stats";

private const string kPauseMenu = "PauseMenu";
private const string kPauseMenuDesc = " Pauses the game and brings up the menu";

private static readonly ConfigStringVar sFire = new ConfigStringVar("Controls", "Fire", " Fires your current equipment", "LeftButton", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sAltFire = new ConfigStringVar("Controls", "AltFire", " Alt fires your current equipment", "RightButton", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sRotateLeft = new ConfigStringVar("Controls", "RotateLeft", " Rotates your body left", "Q", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sRotateRight = new ConfigStringVar("Controls", "RotateRight", " Rotates your body right", "E", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sUp = new ConfigStringVar("Controls", "Up", " Moves up", "Space", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sDown = new ConfigStringVar("Controls", "Down", " Moves Down", "C", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sForward = new ConfigStringVar("Controls", "Forward", " Moves forward", "W", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sLeft = new ConfigStringVar("Controls", "Left", " Moves left", "A", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sBackward = new ConfigStringVar("Controls", "Backward", " Moves backward", "S", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sRight = new ConfigStringVar("Controls", "Right", " Moves right", "D", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sInteract = new ConfigStringVar("Controls", "Interact", " Interacts with object", "F", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sPush = new ConfigStringVar("Controls", "Push", " Fires grapple push", "F", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sLeftGrab = new ConfigStringVar("Controls", "LeftGrab", " Grabs with left hand", "Z", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sRightGrab = new ConfigStringVar("Controls", "RightGrab", " Grabs with right hand", "X", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sScanner = new ConfigStringVar("Controls", "Scanner", " Activates scanner", "T", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sWorkOrder = new ConfigStringVar("Controls", "WorkOrder", " Displays workorder", "Tab", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sFlashlight = new ConfigStringVar("Controls", "Flashlight", " Controls flashlight", "L", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sBrake = new ConfigStringVar("Controls", "Brake", " Stops movement", "Control", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sClearTethers = new ConfigStringVar("Controls", "ClearTethers", " Clears all tethers", "V", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sCycleScanLeft = new ConfigStringVar("Controls", "CycleScanLeft", " Cycles scanner mode to the left", "LeftButton", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sCycleScanRight = new ConfigStringVar("Controls", "CycleScanRight", " Cycles scanner mode to the right", "RightButton", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sPlayAudioLog = new ConfigStringVar("Controls", "PlayAudioLog", " Plays an audio log", "Tab", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sUnequip = new ConfigStringVar("Controls", "Unequip", " Puts away your current equipment", "Backspace", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sEquipGrapple = new ConfigStringVar("Controls", "EquipGrapple", " Equips the grapple gun", "Key1", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sEquipCutter = new ConfigStringVar("Controls", "EquipCutter", " Equips the cutter tool", "Key2", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sToggleFps = new ConfigStringVar("Controls", "ToggleFps", " Toggles the fps stats", "F4", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);
private static readonly ConfigStringVar sPauseMenu = new ConfigStringVar("Controls", "PauseMenu", " Pauses the game and brings up the menu", "Escape", new ConfigValueChangedDelegate(LynxControlsUserOptions.MarkAsDirty), LynxUserOptions.ConfigStore);

LynxControlsUserOptions.sFire.ClearToDefault();
LynxControlsUserOptions.sAltFire.ClearToDefault();
LynxControlsUserOptions.sRotateLeft.ClearToDefault();
LynxControlsUserOptions.sRotateRight.ClearToDefault();
LynxControlsUserOptions.sUp.ClearToDefault();
LynxControlsUserOptions.sDown.ClearToDefault();
LynxControlsUserOptions.sForward.ClearToDefault();
LynxControlsUserOptions.sLeft.ClearToDefault();
LynxControlsUserOptions.sBackward.ClearToDefault();
LynxControlsUserOptions.sRight.ClearToDefault();
LynxControlsUserOptions.sInteract.ClearToDefault();
LynxControlsUserOptions.sPush.ClearToDefault();
LynxControlsUserOptions.sLeftGrab.ClearToDefault();
LynxControlsUserOptions.sRightGrab.ClearToDefault();
LynxControlsUserOptions.sScanner.ClearToDefault();
LynxControlsUserOptions.sWorkOrder.ClearToDefault();
LynxControlsUserOptions.sFlashlight.ClearToDefault();
LynxControlsUserOptions.sBrake.ClearToDefault();
LynxControlsUserOptions.sClearTethers.ClearToDefault();
LynxControlsUserOptions.sCycleScanLeft.ClearToDefault();
LynxControlsUserOptions.sCycleScanRight.ClearToDefault();
LynxControlsUserOptions.sPlayAudioLog.ClearToDefault();
LynxControlsUserOptions.sUnequip.ClearToDefault();
LynxControlsUserOptions.sEquipGrapple.ClearToDefault();
LynxControlsUserOptions.sEquipCutter.ClearToDefault();
LynxControlsUserOptions.sToggleFps.ClearToDefault();
LynxControlsUserOptions.sPauseMenu.ClearToDefault();