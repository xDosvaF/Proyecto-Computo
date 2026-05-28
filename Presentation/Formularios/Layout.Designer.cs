namespace Presentation.Formularios
{
    partial class Layout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            panelControl = new FlowLayoutPanel();
            btnMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
            btnMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
            panelMain = new Panel();
            msMenu = new MenuStrip();
            mnUsuario = new ToolStripMenuItem();
            mnProducto = new ToolStripMenuItem();
            mnVenta = new ToolStripMenuItem();
            guna2CustomGradientPanel1.SuspendLayout();
            panelControl.SuspendLayout();
            msMenu.SuspendLayout();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(msMenu);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.Dock = DockStyle.Left;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(150, 500);
            guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.FromArgb(255, 56, 60);
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(561, 11);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnClose.Size = new Size(20, 20);
            btnClose.TabIndex = 0;
            btnClose.Text = "guna2CircleButton1";
            btnClose.Click += btnClose_Click;
            // 
            // panelControl
            // 
            panelControl.AutoSize = true;
            panelControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelControl.Controls.Add(btnClose);
            panelControl.Controls.Add(btnMaximized);
            panelControl.Controls.Add(btnMinimized);
            panelControl.Dock = DockStyle.Top;
            panelControl.FlowDirection = FlowDirection.RightToLeft;
            panelControl.Location = new Point(150, 0);
            panelControl.Margin = new Padding(8);
            panelControl.Name = "panelControl";
            panelControl.Padding = new Padding(8);
            panelControl.Size = new Size(600, 42);
            panelControl.TabIndex = 2;
            panelControl.WrapContents = false;
            // 
            // btnMaximized
            // 
            btnMaximized.DisabledState.BorderColor = Color.DarkGray;
            btnMaximized.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMaximized.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMaximized.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMaximized.FillColor = Color.FromArgb(255, 204, 0);
            btnMaximized.Font = new Font("Segoe UI", 9F);
            btnMaximized.ForeColor = Color.White;
            btnMaximized.Location = new Point(535, 11);
            btnMaximized.Name = "btnMaximized";
            btnMaximized.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnMaximized.Size = new Size(20, 20);
            btnMaximized.TabIndex = 1;
            btnMaximized.Text = "guna2CircleButton1";
            btnMaximized.Click += btnMaximized_Click;
            // 
            // btnMinimized
            // 
            btnMinimized.DisabledState.BorderColor = Color.DarkGray;
            btnMinimized.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMinimized.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMinimized.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMinimized.FillColor = Color.FromArgb(52, 199, 89);
            btnMinimized.Font = new Font("Segoe UI", 9F);
            btnMinimized.ForeColor = Color.White;
            btnMinimized.Location = new Point(509, 11);
            btnMinimized.Name = "btnMinimized";
            btnMinimized.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnMinimized.Size = new Size(20, 20);
            btnMinimized.TabIndex = 2;
            btnMinimized.Text = "guna2CircleButton1";
            btnMinimized.Click += btnMinimized_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(150, 42);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(600, 458);
            panelMain.TabIndex = 3;
            // 
            // msMenu
            // 
            msMenu.BackColor = Color.White;
            msMenu.Items.AddRange(new ToolStripItem[] { mnUsuario, mnProducto, mnVenta });
            msMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            msMenu.Location = new Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Size = new Size(150, 156);
            msMenu.TabIndex = 0;
            msMenu.Text = "menuStrip1";
            // 
            // mnUsuario
            // 
            mnUsuario.AutoSize = false;
            mnUsuario.Name = "mnUsuario";
            mnUsuario.Size = new Size(143, 50);
            mnUsuario.Text = "Usuario";
            // 
            // mnProducto
            // 
            mnProducto.AutoSize = false;
            mnProducto.Name = "mnProducto";
            mnProducto.Size = new Size(143, 50);
            mnProducto.Text = "Producto";
            // 
            // mnVenta
            // 
            mnVenta.AutoSize = false;
            mnVenta.Name = "mnVenta";
            mnVenta.Size = new Size(143, 50);
            mnVenta.Text = "Venta";
            // 
            // Layout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 217, 217);
            ClientSize = new Size(750, 500);
            Controls.Add(panelMain);
            Controls.Add(panelControl);
            Controls.Add(guna2CustomGradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = msMenu;
            Name = "Layout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Layout";
            Load += Layout_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            panelControl.ResumeLayout(false);
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private FlowLayoutPanel panelControl;
        private Guna.UI2.WinForms.Guna2CircleButton btnMaximized;
        private Guna.UI2.WinForms.Guna2CircleButton btnMinimized;
        private Panel panelMain;
        private MenuStrip msMenu;
        private ToolStripMenuItem mnUsuario;
        private ToolStripMenuItem mnProducto;
        private ToolStripMenuItem mnVenta;
    }
}