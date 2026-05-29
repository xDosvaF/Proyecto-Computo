

namespace Presentation.Utilidades
{
    public class CustomToolStripRender : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                Color hoveColor = Color.FromArgb(0, 136, 255);
                e.Graphics.FillRectangle(new SolidBrush(hoveColor), e.Item.ContentRectangle);
                e.Item.ForeColor = Color.White;
            }
            else
            {
                Color hoveColor = Color.FromArgb(255, 255, 255);
                e.Graphics.FillRectangle(new SolidBrush(hoveColor), e.Item.ContentRectangle);
                e.Item.ForeColor = Color.Black;
            }
        }
    }
}
