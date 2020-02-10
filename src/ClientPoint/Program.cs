using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Api;
using ClientPoint.UI;
using ClientPoint.Utils;
using Telerik.WinControls;
using View = ClientPoint.UI.View;

namespace ClientPoint {
    static class Program {
        static readonly Mutex _mutex =
            new Mutex(true, "{6A6A0AC4-F9A5-45fd-A1CF-63D04E6BDE7C}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try {
                if (!_mutex.WaitOne(TimeSpan.Zero, true)) {
                    MessageBox.Show(
                        "Ya existe un proceso activo de ClientPoint.exe. " +
                        "Debe finalizar el proceso antes de iniciar otro.");
                    return;
                }

                if (!Strings.Init())
                    return;

                if (!CodArea.Init())
                    return;

                // Arranco el splash
                UIManager.StartSplash();
                
                // Inicializa logs
                Logger.Init();

                // Validar IdKiosk
                if (!InitKioskId()) {
                    UIManager.SafeExecOnActiveForm(owner =>
                        RadMessageBox.Show(owner,
                            $"Error al validar 'IdKiosk'. " +
                            $"Verifique su valor en el archivo de configuración."));
                    Environment.Exit(0);
                    return;
                }

                KillEvolisCenter();

                Status.Init();
                
                // Inicializa las ventanas que utiliza la app
                UIManager.Init();

                UIManager.StopSplash();

                //Op.TestBase64();

                UIManager.ShowView(View.MainMenu);
                //Thread.Sleep(1000);
                var frm = UIManager.GetActiveForm();
                frm?.Activate();

                UIManager.RefreshErrorIcon();

                // Pantalla principal / inicial (publicidades)
                Application.Run(frm);
                // Libero mutex
                _mutex.ReleaseMutex();
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                UIManager.SafeExecOnActiveForm(owner =>
                    RadMessageBox.Show(owner, $"Error: {ex.Message}"));
                Application.Exit();
            }
        }

        // Cerramos el Evolis Print Center
        // Asi evitamos los popups con el estado de impresion
        private static void KillEvolisCenter() {
            foreach (var process in Process.GetProcessesByName("PrinterManager")) {
                process.Kill();
            }
        }

        private static bool InitKioskId() {
            try {
                var res = ApiService.GetKiosk(Config.IdKiosk);
                Config.KioskName = res.Name;
                Config.KioskShortName = res.ShortName;
                var valid = res.IdKiosco != 0;
                var msg = $"IdKiosk: {Config.IdKiosk} => " +
                          $"[{(valid ? "OK" : "NOT OK")}]";
                Logger.Write(msg).Wait();
                UIManager.SplashStatus(msg);
                return valid;
            }
            catch (Exception e) {
                Logger.Exception(e);
                return false;
            }
        }
    }
}
