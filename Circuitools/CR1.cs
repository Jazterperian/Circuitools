using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using System.IO;
using TouchTracking;
namespace Circuitools
{
    class CR1 : ContentPage
    {
        public ImageButton[] IBT = new ImageButton[15]; public Grid[] GR = new Grid[2]; public SKCanvas CV; public SKCanvasView SCV = new SKCanvasView { IsVisible = true, BackgroundColor = Color.White};
        public SKBitmap[] SBM = new SKBitmap[10]; public SKMatrix[] SKM = new SKMatrix[3]; public SKPath[] CB = new SKPath[135]; public SKPoint[] SKP = new SKPoint[4];
        public int[] K = new int[16]; public int[] P = new int[6]; public decimal[,,] CR = new decimal[9, 30, 4]; public string[] ST = new string[135];  public string[] AA = new string[7];
        public int[,] PT = new int[9, 30]; public double[] AX = new double[4]; public bool[] ES = new bool[10];
        public string[] SC = { "LV.png", "PL.png", "RNGI.png", "CB.png", "FV.png", "FC.png", "TR.png", "R.png", "Z.png", "VCV.png", "VCC.png", "CCV.png", "CCC.png", "RTR.png", "15BSR.png", "NT.png" };
        public SKPaint AP = new SKPaint { Style = SKPaintStyle.Fill, Color = SKColors.Black, TextSize = 30 };
        public SKPaint paint = new SKPaint { Style = SKPaintStyle.Stroke, Color = SKColors.Black, StrokeWidth = 5 };
        public Assembly[] AS = new Assembly[3];
        public TouchEffect T = new TouchEffect { Capture = true };
        List<TouchManipulationBitmap> BMCT = new List<TouchManipulationBitmap>(); Dictionary<long, TouchManipulationBitmap> BMDT = new Dictionary<long, TouchManipulationBitmap>();
        TouchManipulationBitmap[,] TMB = new TouchManipulationBitmap[10, 30]; public int[,] NDO = new int[9, 30];
        SKPoint ConvertToPixel(Point pt) { return new SKPoint((float)(SCV.CanvasSize.Width * pt.X / SCV.Width), (float)(SCV.CanvasSize.Height * pt.Y / SCV.Height)); }
        public CR1()
        {
            K[2] = 0; K[4] = 0; K[5] = 0; K[6] = 0; K[7] = 0; K[8] = 0; K[9] = 0; K[10] = 0; K[11] = 0; K[13] = 0; ES[0] = true; ES[1] = true; K[0] = 50;
            NavigationPage.SetHasNavigationBar(this, false);
            try { for (int K = 0; K < 15; K++) { IBT[K] = new ImageButton { WidthRequest = 60, BackgroundColor = Color.FromHex("#5d78fd"), Source = SC[K] }; } } catch (Exception a) { DisplayAlert("MSG", "ERROR\n" + a, "OK"); }
            GR[0] = new Grid { RowSpacing = 7, Padding = 5, BackgroundColor = Color.FromHex("#5d78fd"), RowDefinitions = { new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) }, new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) } } };
            GR[0].Children.Add(new ScrollView{Orientation= ScrollOrientation.Horizontal,Content= new StackLayout{Orientation=StackOrientation.Horizontal, Children = { IBT[0], IBT[1], IBT[2], IBT[13], IBT[14] } } }, 0, 0);
            GR[0].Children.Add(new Grid { Children = {SCV}, Effects = { T }, BackgroundColor = Color.White }, 0, 1);
            GR[0].Children.Add(new ScrollView{Orientation = ScrollOrientation.Horizontal,Content = new StackLayout{Orientation = StackOrientation.Horizontal, Children = { IBT[3], IBT[4], IBT[5], IBT[6], IBT[7], IBT[8], IBT[9], IBT[10], IBT[11], IBT[12]} }}, 0, 2);
            Content = GR[0]; SCV.PaintSurface += SCVPS;
            void SF()
            {
                if (ES[0] == true)
                {
                    for (int f = 0; f < 10; f++)
                    {
                        K[1] = 50; if (f < 9) { K[14] = 30; K[15] = 4; } else { K[14] = 1; K[15] = 6; }
                        try
                        {
                            AS[0] = GetType().GetTypeInfo().Assembly; using (Stream stream = AS[0].GetManifestResourceStream("Circuitools.MD." + SC[f + K[15]]))
                            {SBM[f] = SKBitmap.Decode(stream);
                                for (int g = 0; g < K[14]; g++) { BMCT.Add(new TouchManipulationBitmap(SBM[f]) { Matrix = SKMatrix.CreateTranslation(K[0], K[1]) }); K[1] += 10; TMB[f, g] = BMCT[K[11]]; K[11]++; } K[0] += 50;
                            }
                        } catch (Exception a) { DisplayAlert(".-.", ">:v\n" + a, "OK"); }
                    } ES[0] = false;
                } ES[1] = false; SCV.InvalidateSurface();
            }
            IBT[2].Clicked += (sender, e) =>
            {
                try
                {
                    SKBitmap fp = new SKBitmap(SBM[5].Width, SBM[5].Height); PT[P[0], P[1]]++;
                    using (SKCanvas canvas = new SKCanvas(fp)) { canvas.Clear(); canvas.RotateDegrees(-90, SBM[5].Width / 2, SBM[5].Height / 2); canvas.DrawBitmap(TMB[P[0], P[1]].bitmap, new SKPoint()); }
                    TMB[P[0], P[1]].bitmap = fp; SCV.InvalidateSurface(); if (PT[P[0], P[1]] == 4) { PT[P[0], P[1]] = 0; }
                }
                catch { }
            };
            IBT[3].Clicked += (sender, e) => { ES[1] = true; K[12] = 0; };
            IBT[4].Clicked += (sender, e) => { K[2]++; SF(); };
            IBT[5].Clicked += (sender, e) => { K[3]++; SF(); };
            IBT[6].Clicked += (sender, e) => { K[4]++; SF(); };
            IBT[7].Clicked += (sender, e) => { K[5]++; SF(); };
            IBT[8].Clicked += (sender, e) => { K[6]++; SF(); };
            IBT[9].Clicked += (sender, e) => { K[7]++; SF(); };
            IBT[10].Clicked += (sender, e) => { K[8]++; SF(); };
            IBT[11].Clicked += (sender, e) => { K[9]++; SF(); };
            IBT[12].Clicked += (sender, e) => { K[10]++; SF(); };
            IBT[13].Clicked += (sender, e) =>
            {
                try
                {
                    SKBitmap fp = new SKBitmap(SBM[5].Width, SBM[5].Height);
                    using (SKCanvas canvas = new SKCanvas(fp)) { canvas.Clear(); canvas.Scale(-1, 1, SBM[5].Width / 2, 0); canvas.DrawBitmap(TMB[P[0], P[1]].bitmap, new SKPoint()); }
                    TMB[P[0], P[1]].bitmap = fp; SCV.InvalidateSurface();
                } catch { }
            };
            T.TouchAction += T_TouchAction;
            IBT[14].Clicked += (sender, e) =>
            {
                try
                {
                    if (K[P[0] + 2] > (P[1] + 1))
                    {
                        for(int k = P[1]; k < K[P[0]+2]; k++) { TMB[P[0], k].bitmap = TMB[P[0], k+1].bitmap; TMB[P[0], k].Matrix.TransX = TMB[P[0], k + 1].Matrix.TransX; TMB[P[0], k].Matrix.TransY = TMB[P[0], k + 1].Matrix.TransY; }
                        TMB[P[0], K[P[0] + 2]].Matrix.TransX = 50; TMB[P[0], K[P[0] + 2]].Matrix.TransY = 50;
                    } K[P[0] + 2]--; SCV.InvalidateSurface();
                } catch (Exception a){ DisplayAlert("--",a.ToString(),"OK"); }
            };
        }
        void LN()
        {
            string AX = "";
            if (P[4] < 2 && P[5] < 2)
            {
                if (CR[P[2], P[3], 0] > CR[P[0], P[1], 0] && CR[P[2], P[3], 1] > CR[P[0], P[1], 1]) { AX = CR[P[2], P[3], 0] + " " + CR[P[0], P[1], 1]; }//MA-ME
                else if (CR[P[2], P[3], 0] > CR[P[0], P[1], 0] && CR[P[0], P[1], 1] > CR[P[2], P[3], 1]) { AX = CR[P[0], P[1], 0] + " " + CR[P[2], P[3], 1]; }//ME-ME
                else if (CR[P[0], P[1], 0] > CR[P[2], P[3], 0] && CR[P[2], P[3], 1] > CR[P[0], P[1], 1]) { AX = CR[P[2], P[3], 0] + " " + CR[P[0], P[1], 1]; }//ME-ME
                else if (CR[P[0], P[1], 0] > CR[P[2], P[3], 0] && CR[P[0], P[1], 1] > CR[P[2], P[3], 1]) { AX = CR[P[0], P[1], 0] + " " + CR[P[2], P[3], 1]; }//MA-ME
                ST[K[13]] = "M " + CR[P[2], P[3], 0] + " " + CR[P[2], P[3], 1] + " L " + AX + " " + CR[P[0], P[1], 0] + " " + CR[P[0], P[1], 1];
            }
            else if (P[4] > 1 && P[5] > 1)
            {
                if (CR[P[2], P[3], 2] > CR[P[0], P[1], 2] && CR[P[2], P[3], 3] > CR[P[0], P[1], 3]) { AX = CR[P[0], P[1], 2] + " " + CR[P[2], P[3], 3]; }//ME-MA
                else if (CR[P[2], P[3], 2] > CR[P[0], P[1], 2] && CR[P[0], P[1], 3] > CR[P[2], P[3], 3]) { AX = CR[P[2], P[3], 2] + " " + CR[P[0], P[1], 3]; }//MA-MA
                else if (CR[P[0], P[1], 2] > CR[P[2], P[3], 2] && CR[P[2], P[3], 3] > CR[P[0], P[1], 3]) { AX = CR[P[0], P[1], 2] + " " + CR[P[2], P[3], 3]; }//MA-MA
                else if (CR[P[0], P[1], 2] > CR[P[2], P[3], 2] && CR[P[0], P[1], 3] > CR[P[2], P[3], 3]) { AX = CR[P[2], P[3], 2] + " " + CR[P[0], P[1], 3]; }//ME-MA
                ST[K[13]] = "M " + CR[P[2], P[3], 2] + " " + CR[P[2], P[3], 3] + " L " + AX + " " + CR[P[0], P[1], 2] + " " + CR[P[0], P[1], 3];
            }
            else if (P[4] > 1 && P[5] < 2)
            {
                if (CR[P[2], P[3], 2] > CR[P[0], P[1], 0] && CR[P[2], P[3], 3] > CR[P[0], P[1], 1]) { AX = (((CR[P[2], P[3], 2] - CR[P[0], P[1], 0]) / 2) + CR[P[0], P[1], 0]) + " " + (CR[P[2], P[3], 3]) + " " + (((CR[P[2], P[3], 2] - CR[P[0], P[1], 0]) / 2) + CR[P[0], P[1], 0]) + " " + (CR[P[0], P[1], 1]); }//EXT-MA-EXT-ME
                else if (CR[P[2], P[3], 2] > CR[P[0], P[1], 0] && CR[P[0], P[1], 1] > CR[P[2], P[3], 3]) { AX = CR[P[0], P[1], 0] + " " + CR[P[2], P[3], 3]; }//ME-ME
                else if (CR[P[0], P[1], 0] > CR[P[2], P[3], 2] && CR[P[2], P[3], 3] > CR[P[0], P[1], 1]) { AX = (((CR[P[0], P[1], 0] - CR[P[2], P[3], 2]) / 2) + CR[P[2], P[3], 2]) + " " + (CR[P[2], P[3], 3]) + " " + (((CR[P[0], P[1], 0] - CR[P[2], P[3], 2]) / 2) + CR[P[2], P[3], 2]) + " " + (CR[P[0], P[1], 1]); }//EXT-MA-EXT-ME
                else if (CR[P[0], P[1], 0] > CR[P[2], P[3], 2] && CR[P[0], P[1], 1] > CR[P[2], P[3], 3]) { AX = CR[P[2], P[3], 2] + " " + CR[P[0], P[1], 1]; }//ME-MA
                ST[K[13]] = "M " + CR[P[2], P[3], 2] + " " + CR[P[2], P[3], 3] + " L " + AX + " " + CR[P[0], P[1], 0] + " " + CR[P[0], P[1], 1];
            }
            else if (P[4] < 2 && P[5] > 1)
            {
                if (CR[P[2], P[3], 0] > CR[P[0], P[1], 2] && CR[P[2], P[3], 1] > CR[P[0], P[1], 3]) { AX = CR[P[0], P[1], 2] + " " + CR[P[2], P[3], 1]; }//ME-MA
                else if (CR[P[2], P[3], 0] > CR[P[0], P[1], 2] && CR[P[0], P[1], 3] > CR[P[2], P[3], 1]) { AX = (((CR[P[2], P[3], 0] - CR[P[0], P[1], 2]) / 2) + CR[P[0], P[1], 2]) + " " + (CR[P[2], P[3], 1]) + " " + (((CR[P[2], P[3], 0] - CR[P[0], P[1], 2]) / 2) + CR[P[0], P[1], 2]) + " " + (CR[P[0], P[1], 3]); }//EXT-ME-EXT-MA
                else if (CR[P[0], P[1], 2] > CR[P[2], P[3], 0] && CR[P[2], P[3], 1] > CR[P[0], P[1], 3]) { AX = CR[P[2], P[3], 0] + " " + CR[P[0], P[1], 3]; }//ME-ME
                else if (CR[P[0], P[1], 2] > CR[P[2], P[3], 0] && CR[P[0], P[1], 3] > CR[P[2], P[3], 1]) { AX = (((CR[P[2], P[3], 0] - CR[P[0], P[1], 2]) / 2) + CR[P[0], P[1], 2]) + " " + (CR[P[2], P[3], 1]) + " " + (((CR[P[2], P[3], 0] - CR[P[0], P[1], 2]) / 2) + CR[P[0], P[1], 2]) + " " + (CR[P[0], P[1], 3]); }//EXT-ME-EXT-MA
                ST[K[13]] = "M " + CR[P[2], P[3], 0] + " " + CR[P[2], P[3], 1] + " L " + AX + " " + CR[P[0], P[1], 2] + " " + CR[P[0], P[1], 3];
            }
            CB[K[13]] = SKPath.ParseSvgPathData(ST[K[13]]); P[2] = 0; P[3] = 0; K[13]++; ES[1] = false; SCV.InvalidateSurface();
        }
        void NDR()
        {
            if (PT[P[0], P[1]] == 0) { AX[0] = 37.5; AX[1] = 0; AX[2] = 37.5; AX[3] = 75; }
            else if (PT[P[0], P[1]] == 1) { AX[0] = 0; AX[1] = 37.5; AX[2] = 75; AX[3] = 37.5; }
            else if (PT[P[0], P[1]] == 2) { AX[0] = 37.5; AX[1] = 75; AX[2] = 37.5; AX[3] = 0; }
            else if (PT[P[0], P[1]] == 3) { AX[0] = 75; AX[1] = 37.5; AX[2] = 0; AX[3] = 37.5; }
        }
        void hd(int a, int b, bool es)
        {
            try
            {
                if (es == true)
                {
                    AA[0] = Convert.ToString(CR[a, b, 0]); AA[1] = Convert.ToString(CR[a, b, 1]);
                    AA[2] = Convert.ToString(CR[a, b, 2]);AA[3] = Convert.ToString(CR[a, b, 3]);
                    AA[4] = "X1: " + AA[0] + ", Y1: " + AA[1]; AA[5] = "X2: " + AA[2] + ", Y2: " + AA[3]; AA[6] = "1";
                }
                else if (es == false)
                {
                    try
                    {
                        for (int c = 0; c < K[13]; c++)
                        {
                            ES[2] = ST[c].Contains(AA[0]); ES[3] = ST[c].Contains(AA[1]); ES[4] = ST[c].Contains(AA[2]); ES[5] = ST[c].Contains(AA[3]);
                            if(AA[0] == "0" || AA[1] == "0"|| AA[2] == "0" || AA[3] == "0") { ES[2] = false; ES[3] = false; ES[4] = false; ES[5] = false; }
                            else if (ES[2] == true && ES[3] == true) { ST[c] = ST[c].Replace(AA[0], Convert.ToString(CR[a, b, 0])).Replace(AA[1], Convert.ToString(CR[a, b, 1])); CB[c] = SKPath.ParseSvgPathData(ST[c]); AA[6] = "2"; ES[4] = false; ES[5] = false; }
                            else if (ES[4] == true && ES[5] == true) { ST[c] = ST[c].Replace(AA[2], Convert.ToString(CR[a, b, 2])).Replace(AA[3], Convert.ToString(CR[a, b, 3])); CB[c] = SKPath.ParseSvgPathData(ST[c]); AA[6] = "2"; ES[2] = false; ES[3] = false; }
                        }
                    }
                    catch { }
                }
            }
            catch {  }
        }
        private void T_TouchAction(object sender, TouchActionEventArgs args)
        {
            try
            {
                Point pt = args.Location; SKP[2] = new SKPoint((float)(SCV.CanvasSize.Width * pt.X / SCV.Width), (float)(SCV.CanvasSize.Height * pt.Y / SCV.Height));
                switch (args.Type)
                {
                    case TouchActionType.Pressed:
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < K[i + 2]; j++)
                            {
                                if (TMB[i, j].HitTest(SKP[2]))
                                {
                                    P[0] = i; P[1] = j; hd(P[0], P[1], true);
                                    if (ES[1] == false) { BMCT.Remove(TMB[i, j]); BMCT.Add(TMB[i, j]); BMDT.Add(args.Id, TMB[i, j]); TMB[i, j].ProcessTouchEvent(args.Id, args.Type, SKP[2]); SCV.InvalidateSurface(); break; }
                                    else
                                    {
                                        if (K[12] < 2)
                                        {
                                            NDR();
                                            if (PT[P[0], P[1]] == 0 && Convert.ToDecimal(ConvertToPixel(args.Location).Y) <= Convert.ToDecimal(37.5 + TMB[P[0], P[1]].Matrix.TransY)) { NDO[P[0], P[1]] = 1; }
                                            else if (PT[P[0], P[1]] == 2 && Convert.ToDecimal(ConvertToPixel(args.Location).Y) > Convert.ToDecimal(37.5 + TMB[P[0], P[1]].Matrix.TransY)) { NDO[P[0], P[1]] = 1; }
                                            else if (PT[P[0], P[1]] == 1 && Convert.ToDecimal(ConvertToPixel(args.Location).X) <= Convert.ToDecimal(37.5 + TMB[P[0], P[1]].Matrix.TransX)) { NDO[P[0], P[1]] = 1; }
                                            else if (PT[P[0], P[1]] == 3 && Convert.ToDecimal(ConvertToPixel(args.Location).X) > Convert.ToDecimal(37.5 + TMB[P[0], P[1]].Matrix.TransX)) { NDO[P[0], P[1]] = 1; }
                                            else { NDO[P[0], P[1]] = 2; }
                                            if (K[12] == 0) { P[2] = P[0]; P[3] = P[1]; }
                                            P[K[12] + 4] = NDO[P[0], P[1]];
                                            if (NDO[P[0], P[1]] == 1) { CR[P[0], P[1], 0] = Math.Round(Convert.ToDecimal(AX[0] + TMB[P[0], P[1]].Matrix.TransX), 2); CR[P[0], P[1], 1] = Math.Round(Convert.ToDecimal(AX[1] + TMB[P[0], P[1]].Matrix.TransY), 2); TMB[9, 0].Matrix.TransX = ((float)((float)CR[P[0], P[1], 0] - 37.5)); TMB[9, 0].Matrix.TransY = ((float)((float)CR[P[0], P[1], 1] - 37.5)); SCV.InvalidateSurface(); }
                                            else if (NDO[P[0], P[1]] >= 2) { CR[P[0], P[1], 2] = Math.Round(Convert.ToDecimal(AX[2] + TMB[P[0], P[1]].Matrix.TransX), 2); CR[P[0], P[1], 3] = Math.Round(Convert.ToDecimal(AX[3] + TMB[P[0], P[1]].Matrix.TransY), 2); TMB[9, 0].Matrix.TransX = ((float)((float)CR[P[0], P[1], 2] - 37.5)); TMB[9, 0].Matrix.TransY = ((float)((float)CR[P[0], P[1], 3] - 37.5)); SCV.InvalidateSurface(); }
                                            K[12]++;
                                        }
                                        if (K[12] >= 2) { LN(); }
                                    }
                                }
                            }
                        }
                        break;
                    case TouchActionType.Moved:
                        if (ES[1] == false) { if (BMDT.ContainsKey(args.Id)) { TouchManipulationBitmap TM = BMDT[args.Id]; TM.ProcessTouchEvent(args.Id, args.Type, SKP[2]); SCV.InvalidateSurface(); } }
                        break;
                    case TouchActionType.Released:
                    case TouchActionType.Cancelled:
                        if (ES[1] == false)
                        {
                            if (BMDT.ContainsKey(args.Id))
                            {
                                TouchManipulationBitmap TM = BMDT[args.Id]; TM.ProcessTouchEvent(args.Id, args.Type, SKP[2]); BMDT.Remove(args.Id); CR[P[0], P[1], 0] = Math.Round(Convert.ToDecimal(AX[0] + TMB[P[0], P[1]].Matrix.TransX), 2);
                                CR[P[0], P[1], 1] = Math.Round(Convert.ToDecimal(AX[1] + TMB[P[0], P[1]].Matrix.TransY), 2); CR[P[0], P[1], 2] = Math.Round(Convert.ToDecimal(AX[2] + TMB[P[0], P[1]].Matrix.TransX), 2);
                                CR[P[0], P[1], 3] = Math.Round(Convert.ToDecimal(AX[3] + TMB[P[0], P[1]].Matrix.TransY), 2); hd(P[0], P[1], false); SCV.InvalidateSurface();
                            }
                        }
                        break;
                }
            }
            catch { }
        }
        void SCVPS(object sender, SKPaintSurfaceEventArgs args)
        {
            CV = args.Surface.Canvas; CV.Clear(SKColors.White);
            if (ES[0] == false)
            {
                if(ES[1] == true) { TMB[9, 0].Paint(CV); }
                for (int c = 2; c < 11; c++) { if (K[c] > 0 && K[c] < 30) { for (int p = 0; p < K[c]; p++) { TMB[c - 2, p].Paint(CV); CV.DrawText("("+TMB[c - 2, p].Matrix.TransX.ToString()+", "+ TMB[c - 2, p].Matrix.TransY.ToString()+")", 80 + TMB[c - 2, p].Matrix.TransX, 50 + TMB[c - 2, p].Matrix.TransY, AP); } } }
                try { for (int c = 0; c < K[13]; c++) { CV.DrawPath(CB[c], paint); } } catch (Exception a) { DisplayAlert("--", a.ToString(), "OK"); }
                //try { CV.DrawText(ES[2].ToString(), 250, 50, AP ); CV.DrawText(ES[3].ToString(), 250, 80, AP); CV.DrawText(ES[4].ToString(), 250, 110, AP); CV.DrawText(ES[4].ToString(), 250, 140, AP); } catch { }
            }
        }
    }
}