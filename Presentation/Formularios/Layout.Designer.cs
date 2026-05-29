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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            msMenu = new MenuStrip();
            mnUsuario = new ToolStripMenuItem();
            mnProducto = new ToolStripMenuItem();
            mnVenta = new ToolStripMenuItem();
            btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            panelControl = new FlowLayoutPanel();
            btnMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
            btnMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
            panelMain = new Panel();
            pnControl = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            guna2CustomGradientPanel3 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            pnLogoMariano = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            pctUMG = new PictureBox();
            msMenu.SuspendLayout();
            panelControl.SuspendLayout();
            pnControl.SuspendLayout();
            guna2CustomGradientPanel3.SuspendLayout();
            pnLogoMariano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctUMG).BeginInit();
            SuspendLayout();
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
            mnUsuario.Click += mnUsuario_Click;
            // 
            // mnProducto
            // 
            mnProducto.AutoSize = false;
            mnProducto.Name = "mnProducto";
            mnProducto.Size = new Size(143, 50);
            mnProducto.Text = "Producto";
            mnProducto.Click += mnProducto_Click;
            // 
            // mnVenta
            // 
            mnVenta.AutoSize = false;
            mnVenta.Name = "mnVenta";
            mnVenta.Size = new Size(143, 50);
            mnVenta.Text = "Venta";
            mnVenta.Click += mnVenta_Click;
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
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges1;
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
            btnMaximized.ShadowDecoration.CustomizableEdges = customizableEdges2;
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
            btnMinimized.ShadowDecoration.CustomizableEdges = customizableEdges3;
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
            // pnControl
            // 
            pnControl.Controls.Add(guna2CustomGradientPanel3);
            pnControl.Controls.Add(pnLogoMariano);
            pnControl.CustomizableEdges = customizableEdges8;
            pnControl.Dock = DockStyle.Left;
            pnControl.Location = new Point(0, 0);
            pnControl.Name = "pnControl";
            pnControl.ShadowDecoration.CustomizableEdges = customizableEdges9;
            pnControl.Size = new Size(150, 500);
            pnControl.TabIndex = 0;
            // 
            // guna2CustomGradientPanel3
            // 
            guna2CustomGradientPanel3.Controls.Add(msMenu);
            guna2CustomGradientPanel3.CustomizableEdges = customizableEdges4;
            guna2CustomGradientPanel3.Dock = DockStyle.Fill;
            guna2CustomGradientPanel3.Location = new Point(0, 137);
            guna2CustomGradientPanel3.Name = "guna2CustomGradientPanel3";
            guna2CustomGradientPanel3.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2CustomGradientPanel3.Size = new Size(150, 363);
            guna2CustomGradientPanel3.TabIndex = 1;
            // 
            // pnLogoMariano
            // 
            pnLogoMariano.Controls.Add(pctUMG);
            pnLogoMariano.CustomizableEdges = customizableEdges6;
            pnLogoMariano.Dock = DockStyle.Top;
            pnLogoMariano.Location = new Point(0, 0);
            pnLogoMariano.Name = "pnLogoMariano";
            pnLogoMariano.Padding = new Padding(0, 8, 0, 8);
            pnLogoMariano.ShadowDecoration.CustomizableEdges = customizableEdges7;
            pnLogoMariano.Size = new Size(150, 137);
            pnLogoMariano.TabIndex = 0;
            // 
            // pctUMG
            // 
            pctUMG.BackColor = Color.White;
            pctUMG.Dock = DockStyle.Fill;
            pctUMG.Image = Properties.Resources.Escudo_de_la_universidad_Mariano_Gálvez_Guatemala_svg;
            pctUMG.Location = new Point(0, 8);
            pctUMG.Name = "pctUMG";
            pctUMG.Size = new Size(150, 121);
            pctUMG.SizeMode = PictureBoxSizeMode.Zoom;
            pctUMG.TabIndex = 0;
            pctUMG.TabStop = false;
            // 
            // Layout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 217, 217);
            ClientSize = new Size(750, 500);
            Controls.Add(panelMain);
            Controls.Add(panelControl);
            Controls.Add(pnControl);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = msMenu;
            Name = "Layout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Layout";
            Load += Layout_Load;
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            panelControl.ResumeLayout(false);
            pnControl.ResumeLayout(false);
            guna2CustomGradientPanel3.ResumeLayout(false);
            guna2CustomGradientPanel3.PerformLayout();
            pnLogoMariano.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctUMG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private FlowLayoutPanel panelControl;
        private Guna.UI2.WinForms.Guna2CircleButton btnMaximized;
        private Guna.UI2.WinForms.Guna2CircleButton btnMinimized;
        private Panel panelMain;
        private MenuStrip msMenu;
        private ToolStripMenuItem mnUsuario;
        private ToolStripMenuItem mnProducto;
        private ToolStripMenuItem mnVenta;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnControl;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel3;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnLogoMariano;
        private PictureBox pctUMG;
    }
}