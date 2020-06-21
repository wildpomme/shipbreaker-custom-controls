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