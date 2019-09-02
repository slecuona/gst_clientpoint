using System;
using System.Windows.Forms;

namespace ClientPoint.UI.Forms {
    public partial class FrmBase : Telerik.WinControls.UI.RadForm {
        public Window Window;

        protected FrmBase() {
            InitializeComponent();

            this.Load += OnLoad;

            // Esto busca reducir el flickering entre ventanas
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint |
                          System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                          System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        private void OnLoad(object sender, EventArgs e) {
            this.TopMost = !Config.DebugMode;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        
        // Estos callbacks nos permiten configurar los formularios 
        // al momento de mostrarlos y ocultarlos
        public virtual void AfterHide() {}
        public virtual void AfterShow() {}

        public virtual void BeforeHide() { }
        public virtual void BeforeShow() {
            // No debe haber foco en ningun control
            this.ActiveControl = null;
        }

        protected void SafeInvoke(Action action) {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker) action.Invoke);
            else
                action.Invoke();
        }
    }
}
