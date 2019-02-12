//MIT, 2017-present, WinterDev
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using Util;

using Typography.OpenFont;
using Typography.Contours;

using DrawingGL;
using DrawingGL.Text;

using Tesselate;

namespace Test_WinForm_TessGlyph {
    public partial class FormTess : Form {
        private static readonly object mousePressLock = new object();
        private bool mousePressed;
        private Task task;

        private float[] _glyphPoints2;
        private int[] _contourEnds;

        private int xAdj;
        private int yAdj;
        private int speed;

        private string ttfPath;
        private char glyph;

        TessTool _tessTool = new TessTool();

        private static float[] TfmPoints(
            float[] xy, Matrix tfmMat, int xAdj = 0, int yAdj = 0) {
            var points = new List<PointF>();
            for (int i = 0; i < xy.Length; i += 2)
                points.Add(new PointF(xy[i], xy[i + 1]));
            var pointsArr = points.ToArray();

            tfmMat.TransformPoints(pointsArr);

            var tfmXy = new List<float>();
            foreach (var p in pointsArr) {
                tfmXy.Add(p.X + xAdj);
                tfmXy.Add(p.Y + yAdj);
            }
            return tfmXy.ToArray();
        }

        private async Task MouseAction(Action action) {
            while (true) {
                lock (mousePressLock) {
                    if (mousePressed)
                        action();
                    else
                        break;
                }
                await Task.Delay(100).ConfigureAwait(false);
            }
        }

        private void UpdateToolStripStatusLabelOffset() {
            toolStripStatusLabelOffset.Text = $"Offset: ({xAdj},{yAdj})";
        }

        private bool IsGlyphPointsAndCountoursDefined() {
            return _glyphPoints2 != null && _contourEnds != null;
        }

        private void ClearGlyphData() {
            _glyphPoints2 = null;
            _contourEnds = null;
        }

        private void InitGlyphPointsAndContourEnds(char c) {
            try {
                using (FileStream fs = File.OpenRead(ttfPath)) {
                    OpenFontReader reader = new OpenFontReader();
                    Typeface typeface = reader.Read(fs);

                    var builder = new GlyphPathBuilder(typeface);
                    builder.BuildFromGlyphIndex(typeface.LookupIndex(c), 300);

                    var txToPath = new GlyphTranslatorToPath();
                    var writablePath = new WritablePath();
                    txToPath.SetOutput(writablePath);
                    builder.ReadShapes(txToPath);

                    var curveFlattener = new SimpleCurveFlattener();
                    float[] flattenPoints = curveFlattener.Flatten(
                        writablePath._points, out _contourEnds);
                    _glyphPoints2 = flattenPoints;
                }
            }
            catch (Exception) {
                ClearGlyphData();
                pnlGlyph.Invalidate();
            }
        }

        private void PnlGlyph_Paint(
            object sender, PaintEventArgs e) {
            var graphics = e.Graphics;
            graphics.Clear(Color.White);
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                DrawOutput(graphics);
        }

        private void cmdDrawGlyph_Click(object sender, EventArgs e) {
            pnlGlyph.Invalidate();
        }

        private void chkInvert_CheckedChanged(object sender, EventArgs e) {
            pnlGlyph.Invalidate();
        }

        private void TextBoxTtf_KeyUp(object sender, KeyEventArgs e) {
            string path = textBoxTtf.Text.Trim();
            try {
                path = Path.GetFullPath(path);
                if (!File.Exists(path))
                    throw new FileNotFoundException();
            }
            catch (Exception) {
                ClearGlyphData();
                pnlGlyph.Invalidate();
                return; 
            }
            ttfPath = path;
            InitGlyphPointsAndContourEnds(glyph);
            pnlGlyph.Invalidate();
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e) {
            string text = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(text))
                return;
            glyph = text[0];
            InitGlyphPointsAndContourEnds(glyph);
            pnlGlyph.Invalidate();
        }

        private void TextSpeed_KeyUp(object sender, KeyEventArgs e) {
            string text = textSpeed.Text.Trim();
            try { speed = Int32.Parse(text); }
            catch (FormatException) {}
        }

        private void Up_MouseUp(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = false; }
            task.Wait();
        }

        private void Up_MouseDown(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = true; }
            task = MouseAction(() => {
                yAdj -= speed;
                pnlGlyph.Invalidate();
                UpdateToolStripStatusLabelOffset();
            });
        }

        private void Down_MouseUp(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = false; }
            task.Wait();
        }

        private void Down_MouseDown(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = true; }
            task = MouseAction(() => {
                yAdj += speed;
                pnlGlyph.Invalidate();
                UpdateToolStripStatusLabelOffset();
            });
        }

        private void Left_MouseUp(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = false; }
            task.Wait();
        }

        private void Left_MouseDown(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = true; }
            task = MouseAction(() => {
                xAdj -= speed;
                pnlGlyph.Invalidate();
                UpdateToolStripStatusLabelOffset();
            });
        }

        private void Right_MouseUp(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = false; }
            task.Wait();
        }

        private void Right_MouseDown(object sender, MouseEventArgs e) {
            lock (mousePressLock) { mousePressed = true; }
            task = MouseAction(() => {
                xAdj += speed;
                pnlGlyph.Invalidate();
                UpdateToolStripStatusLabelOffset();
            });
        }

        private void FormTess_Load(object sender, EventArgs e) { }

        private float[] GetPolygonData(out int[] endContours) {
            endContours = _contourEnds;
            return _glyphPoints2;
        }

        private void DrawOutline(
            Graphics graphics, float[] polygon1, int[] contourEndIndices) {
            using (Pen pen1 = new Pen(Color.LightGray, 6)) {
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
        }

        private void DrawTess(Graphics graphics, float[] polygon1) {
            if (!_tessTool.TessPolygon(polygon1, _contourEnds)) {
                return;
            }

            List<ushort> indexList = _tessTool.TessIndexList;
            List<TessVertex2d> tempVertexList = _tessTool.TempVertexList;
            int vertexCount = indexList.Count;

            int orgVertexCount = polygon1.Length / 2;
            float[] vtx = new float[vertexCount * 2];
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

        private void DrawOutput(Graphics graphics) {
            int[] contourEndIndices;

            if (!IsGlyphPointsAndCountoursDefined())
                return;

            float[] polygon1 = GetPolygonData(out contourEndIndices);
            var tfm = new Matrix();

            if (chkInvert.Checked) {
                tfm.Scale(1, -1, MatrixOrder.Append);
                tfm.Translate(0, pnlGlyph.Height, MatrixOrder.Append);
            }
            polygon1 = TfmPoints(polygon1, tfm, xAdj, yAdj);
            DrawOutline(graphics, polygon1, contourEndIndices);
            DrawTess(graphics, polygon1);
        }

        public FormTess() {
            mousePressed = false;
            task = null;
            xAdj = 0;
            yAdj = 0;
            speed = 5;
            ttfPath = Path.GetFullPath(Path.Combine(
                "..", "..", "..", "TestFonts", "Alef-Bold.ttf"));
            _glyphPoints2 = null;
            _contourEnds = null;
            InitializeComponent();
        }
    }
}
