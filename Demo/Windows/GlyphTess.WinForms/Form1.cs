//MIT, 2017-present, WinterDev
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

using Typography.OpenFont;

using DrawingGL;
using DrawingGL.Text;

using Tesselate;

namespace Test_WinForm_TessGlyph {
    public partial class FormTess : Form {
        private float[] _glyphPoints2;
        private int[] _contourEnds;

        TessTool _tessTool = new TessTool();

        private void PnlGlyph_Paint(
            object sender, System.Windows.Forms.PaintEventArgs e) {
            var graphics = e.Graphics;

            graphics.Clear(Color.White);

            string oneChar = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(oneChar))
                return;
            char selectedChar = oneChar[0];

            string testFont = Path.GetFullPath(Path.Combine(
                "..", "..", "..", "TestFonts", "Alef-Bold.ttf"));

            using (FileStream fs = File.OpenRead(testFont)) {
                OpenFontReader reader = new OpenFontReader();
                Typeface typeface = reader.Read(fs);

                var builder = new Typography.Contours.GlyphPathBuilder(typeface);
                builder.BuildFromGlyphIndex(typeface.LookupIndex(selectedChar), 300);

                var txToPath = new GlyphTranslatorToPath();
                var writablePath = new WritablePath();
                txToPath.SetOutput(writablePath);
                builder.ReadShapes(txToPath);

                var curveFlattener = new SimpleCurveFlattener();
                float[] flattenPoints = curveFlattener.Flatten(writablePath._points, out _contourEnds);
                _glyphPoints2 = flattenPoints;

                DrawOutput(graphics);
            }
        }

        private void cmdDrawGlyph_Click(object sender, EventArgs e) {
            pnlGlyph.Invalidate();
        }

        private void chkInvert_CheckedChanged(object sender, EventArgs e) {
            pnlGlyph.Invalidate();
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e) {
            pnlGlyph.Invalidate();
        }

        public FormTess() {
            InitializeComponent();
        }

        private void FormTess_Load(object sender, EventArgs e) { }

        float[] GetPolygonData(out int[] endContours) {
            endContours = _contourEnds;
            return _glyphPoints2;
        }

        void DrawOutput(Graphics graphics) {

            //for GDI+ only
            bool drawInvert = chkInvert.Checked;
            int viewHeight = this.pnlGlyph.Height;
            if (drawInvert) {
                graphics.ScaleTransform(1, -1, MatrixOrder.Append);
                graphics.TranslateTransform(0, viewHeight, MatrixOrder.Append);
            }

            //show tess
            int[] contourEndIndices;
            float[] polygon1 = GetPolygonData(out contourEndIndices);

            using (Pen pen1 = new Pen(Color.LightGray, 6)) {
                int nn = polygon1.Length;
                int a = 0;
                PointF p0;
                PointF p1;

                int contourCount = contourEndIndices.Length;
                int startAt = 3;
                for (int cnt_index = 0; cnt_index < contourCount; ++cnt_index) {
                    int endAt = contourEndIndices[cnt_index];
                    for (int m = startAt; m <= endAt;) {
                        p0 = new PointF(polygon1[m - 3], polygon1[m - 2]);
                        p1 = new PointF(polygon1[m - 1], polygon1[m]);
                        graphics.DrawLine(pen1, p0, p1);
                        graphics.DrawString(a.ToString(), this.Font, Brushes.Black, p0);
                        m += 2;
                        a++;
                    }
                    //close coutour 

                    p0 = new PointF(polygon1[endAt - 1], polygon1[endAt]);
                    p1 = new PointF(polygon1[startAt - 3], polygon1[startAt - 2]);
                    graphics.DrawLine(pen1, p0, p1);
                    graphics.DrawString(a.ToString(), this.Font, Brushes.Black, p0);

                    startAt = (endAt + 1) + 3;
                }
            }

            if (!_tessTool.TessPolygon(polygon1, _contourEnds)) {
                return;
            }

            //1.
            List<ushort> indexList = _tessTool.TessIndexList;

            //2.
            List<TessVertex2d> tempVertexList = _tessTool.TempVertexList;

            //3.
            int vertexCount = indexList.Count;

            int orgVertexCount = polygon1.Length / 2;
            float[] vtx = new float[vertexCount * 2];//***
            int n = 0;

            for (int p = 0; p < vertexCount; ++p) {
                ushort index = indexList[p];
                if (index >= orgVertexCount) {
                    //extra coord (newly created)
                    TessVertex2d extraVertex = tempVertexList[index - orgVertexCount];
                    vtx[n] = (float)extraVertex.x;
                    vtx[n + 1] = (float)extraVertex.y;
                }
                else {
                    //original corrd
                    vtx[n] = (float)polygon1[index * 2];
                    vtx[n + 1] = (float)polygon1[(index * 2) + 1];
                }
                n += 2;
            }

            //draw tess result
            int j = vtx.Length;
            for (int i = 0; i < j;) {
                var p0 = new PointF(vtx[i], vtx[i + 1]);
                var p1 = new PointF(vtx[i + 2], vtx[i + 3]);
                var p2 = new PointF(vtx[i + 4], vtx[i + 5]);

                graphics.DrawLine(Pens.Red, p0, p1);
                graphics.DrawLine(Pens.Red, p1, p2);
                graphics.DrawLine(Pens.Red, p2, p0);

                i += 6;
            }

            //for GDI+ only
            graphics.ResetTransform();
        }
    }
}
