using System;
using System.Runtime.InteropServices;

using Starflow.Enums.Windows;
using System.Text;

namespace Starflow.OS
{
    public class Windows
    {
        /// <summary>
        /// Gets the current title of the game window.
        /// </summary>
        /// <returns>The current title the window is, will probably only be used for changing the window in ChangeWindowTitle()</returns>
        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = User32.GetForegroundWindow();

            if (User32.GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        /// <summary>
        /// Changes the game's window title.
        /// </summary>
        /// <param name="newTitle">The title the window will be changed to.</param>
        public static void ChangeWindowTitle(string newTitle)
        {
            var windowPtr = User32.FindWindow(null, GetActiveWindowTitle());
            User32.SetWindowText(windowPtr, newTitle);
        }

        #region Input

        /// <summary>
        /// Simulates a real key press passed in.
        /// </summary>
        public static void KeyPress(KeyCodeWin keyCode)
        {
            INPUT input = new INPUT
            {
                type = SendInputEventType.InputKeyboard,
                mkhi = new MOUSEANDKEYBOARDINPUT
                {
                    ki = new KEYBOARDINPUT
                    {
                        wVk = (ushort)keyCode,
                        wScan = 0,
                        dwFlags = 0, // if nothing, key down
                        time = 0,
                        dwExtraInfo = IntPtr.Zero,
                    }
                }
            };

            INPUT input2 = new INPUT
            {
                type = SendInputEventType.InputKeyboard,
                mkhi = new MOUSEANDKEYBOARDINPUT
                {
                    ki = new KEYBOARDINPUT
                    {
                        wVk = (ushort)keyCode,
                        wScan = 0,
                        dwFlags = 2, // key up
                        time = 0,
                        dwExtraInfo = IntPtr.Zero,
                    }
                }
            };

            INPUT[] inputs = new INPUT[] { input, input2 }; // Combined, it's a keystroke
            User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }


        /// <summary>
        /// Sets your mouse pointer.
        /// </summary>
        public static void ChangeCursor(WindowsCursor cursor)
        {
            User32.SetCursor(User32.LoadCursor(IntPtr.Zero, (int)cursor));
        }

        /// <summary>
        /// Immediately clicks the left mouse button.
        /// </summary>
        public static void ClickLeftMouseButton()
        {
            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENT_LEFTDOWN;
            User32.SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));

            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = SendInputEventType.InputMouse;
            mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENT_LEFTUP;
            User32.SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
        }

        /// <summary>
        /// Immediately clicks the right mouse button.
        /// </summary>
        public static void ClickRightMouseButton()
        {
            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENT_RIGHTDOWN;
            User32.SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));

            INPUT mouseUpInput = new INPUT();
            mouseUpInput.type = SendInputEventType.InputMouse;
            mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENT_RIGHTUP;
            User32.SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
        }

        /// <summary>
        /// Moves your cursor in the x and y params implemented, plus the current mouse pos.
        /// </summary>
        /// <param name="dx">Direction X</param>
        /// <param name="dy">Direction Y</param>
        public static void MouseMove(int dx, int dy)
        {
            INPUT mouseMove = new INPUT();
            mouseMove.type = SendInputEventType.InputMouse;
            mouseMove.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENT_MOVE;
            mouseMove.mkhi.mi.dx = dx;
            mouseMove.mkhi.mi.dy = dy;
            User32.SendInput(1, ref mouseMove, Marshal.SizeOf(new INPUT()));
        }
        #endregion

    }
    
    public enum KeyCodeWin : ushort
	{
		#region Media
		MEDIA_NEXT_TRACK = 0xb0,
		MEDIA_PREV_TRACK = 0xb1,
		MEDIA_STOP = 0xb2,
		MEDIA_PLAY_PAUSE = 0xb3,
		#endregion

		#region Math Functions
		MULTIPLY = 0x6a, // '*'
		ADD = 0x6b,
		SUBTRACT = 0x6d,
		DIVIDE = 0x6f,
		#endregion

		#region Browser
		BROWSER_BACK = 0xa6,
		BROWSER_FORWARD = 0xa7,
		BROWSER_REFRESH = 0xa8,
		BROWSER_STOP = 0xa9,
		BROWSER_SEARCH = 0xaa,
		BROWSER_FAVORITES = 0xab,
		BROWSER_HOME = 0xac,
		#endregion

		#region Numpad numbers
		NUMPAD0 = 0x60,
		NUMPAD1 = 0x61,
		NUMPAD2 = 0x62,
		NUMPAD3 = 0x63,
		NUMPAD4 = 0x64, // 100
		NUMPAD5 = 0x65,
		NUMPAD6 = 0x66,
		NUMPAD7 = 0x67,
		NUMPAD8 = 0x68,
		NUMPAD9 = 0x69,
		#endregion

		#region Function Keys
		F1 = 0x70,
		F2 = 0x71,
		F3 = 0x72,
		F4 = 0x73,
		F5 = 0x74,
		F6 = 0x75,
		F7 = 0x76,
		F8 = 0x77,
		F9 = 0x78,
		F10 = 0x79,
		F11 = 0x7a,
		F12 = 0x7b,
		F13 = 0x7c,
		F14 = 0x7d,
		F15 = 0x7e,
		F16 = 0x7f,
		F17 = 0x80,
		F18 = 0x81,
		F19 = 130,
		F20 = 0x83,
		F21 = 0x84,
		F22 = 0x85,
		F23 = 0x86,
		F24 = 0x87,
		#endregion

		#region Other 
		// see https://lists.w3.org/Archives/Public/www-dom/2010JulSep/att-0182/keyCode-spec.html
		OEM_COLON = 0xba, // OEM_1
		OEM_102 = 0xe2,
		OEM_2 = 0xbf,
		OEM_3 = 0xc0,
		OEM_4 = 0xdb,
		OEM_BACK_SLASH = 0xdc, // OEM_5
		OEM_6 = 0xdd,
		OEM_7 = 0xde,
		OEM_8 = 0xdf,
		OEM_CLEAR = 0xfe,
		OEM_COMMA = 0xbc,
		OEM_MINUS = 0xbd, // Underscore
		OEM_PERIOD = 0xbe,
		OEM_PLUS = 0xbb,
		#endregion

		#region KEYS
		KEY_0 = 0x30,
		KEY_1 = 0x31,
		KEY_2 = 0x32,
		KEY_3 = 0x33,
		KEY_4 = 0x34,
		KEY_5 = 0x35,
		KEY_6 = 0x36,
		KEY_7 = 0x37,
		KEY_8 = 0x38,
		KEY_9 = 0x39,
		KEY_A = 0x41,
		KEY_B = 0x42,
		KEY_C = 0x43,
		KEY_D = 0x44,
		KEY_E = 0x45,
		KEY_F = 0x46,
		KEY_G = 0x47,
		KEY_H = 0x48,
		KEY_I = 0x49,
		KEY_J = 0x4a,
		KEY_K = 0x4b,
		KEY_L = 0x4c,
		KEY_M = 0x4d,
		KEY_N = 0x4e,
		KEY_O = 0x4f,
		KEY_P = 0x50,
		KEY_Q = 0x51,
		KEY_R = 0x52,
		KEY_S = 0x53,
		KEY_T = 0x54,
		KEY_U = 0x55,
		KEY_V = 0x56,
		KEY_W = 0x57,
		KEY_X = 0x58,
		KEY_Y = 0x59,
		KEY_Z = 0x5a,
		#endregion

		#region volume
		VOLUME_MUTE = 0xad,
		VOLUME_DOWN = 0xae,
		VOLUME_UP = 0xaf,
		#endregion

		SNAPSHOT = 0x2c,
		RIGHT_CLICK = 0x5d,
		BACKSPACE = 8,
		CANCEL = 3,
		CAPS_LOCK = 20,
		CONTROL = 0x11,
		ALT = 18,
		DECIMAL = 110,
		DELETE = 0x2e,
		DOWN = 40,
		END = 0x23,
		ESC = 0x1b,
		HOME = 0x24,
		INSERT = 0x2d,
		LAUNCH_APP1 = 0xb6,
		LAUNCH_APP2 = 0xb7,
		LAUNCH_MAIL = 180,
		LAUNCH_MEDIA_SELECT = 0xb5,
		LCONTROL = 0xa2,
		LEFT = 0x25,
		LSHIFT = 0xa0,
		LWIN = 0x5b,
		PAGEDOWN = 0x22,
		NUMLOCK = 0x90,
		PAGE_UP = 0x21,
		RCONTROL = 0xa3,
		ENTER = 13,
		RIGHT = 0x27,
		RSHIFT = 0xa1,
		RWIN = 0x5c,
		SHIFT = 0x10,
		SPACE_BAR = 0x20,
		TAB = 9,
		UP = 0x26,
	}
}