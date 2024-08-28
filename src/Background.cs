using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace winST
{


    public class KeyboardHook
    {
        // 델리게이트와 이벤트 선언
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public event KeyEventHandler KeyDown;

        // WinAPI 함수 선언
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int hhk);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // 상수 정의
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        // 필드
        private int _hookID = 0;
        private HookProc _proc;

        // 생성자
        public KeyboardHook()
        {
            _proc = HookCallback;
        }

        // 훅을 설정하는 메서드
        public void SetHook()
        {
            IntPtr hInstance = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
            _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        // 훅을 해제하는 메서드
        public void Unhook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        // 훅 콜백 메서드
        private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                KeyDown?.Invoke(this, new KeyEventArgs(key));
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }

}
