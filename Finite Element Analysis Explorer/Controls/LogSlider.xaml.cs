using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class LogSlider : UserControl
    {
        public event EventHandler ValueChanged;
        public event EventHandler Checked;
        public event EventHandler Unchecked;

        public LogSlider()
        {
            this.InitializeComponent();
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                textBlock_Title.Content = title;
            }
        }

        private string displayValue;
        public string DisplayValue
        {
            get { return displayValue; }
            set
            {
                displayValue = value;
                textBlock_Value.Text = value;
            }
        }


        private bool BlockUpdate = false;


        internal void SetNewValue(float newValue)
        {
            BlockUpdate = true;

            if (newValue <= 0.000000000001f) { slider_Value.Value = 1; }
            else if (newValue <= 0.000000000002f) { slider_Value.Value = 2; }
            else if (newValue <= 0.000000000003f) { slider_Value.Value = 3; }
            else if (newValue <= 0.000000000004f) { slider_Value.Value = 4; }
            else if (newValue <= 0.000000000005f) { slider_Value.Value = 5; }
            else if (newValue <= 0.000000000006f) { slider_Value.Value = 6; }
            else if (newValue <= 0.000000000007f) { slider_Value.Value = 7; }
            else if (newValue <= 0.000000000008f) { slider_Value.Value = 8; }
            else if (newValue <= 0.000000000009f) { slider_Value.Value = 9; }
            else if (newValue <= 0.00000000001f) { slider_Value.Value = 10; }
            else if (newValue <= 0.00000000002f) { slider_Value.Value = 11; }
            else if (newValue <= 0.00000000003f) { slider_Value.Value = 12; }
            else if (newValue <= 0.00000000004f) { slider_Value.Value = 13; }
            else if (newValue <= 0.00000000005f) { slider_Value.Value = 14; }
            else if (newValue <= 0.00000000006f) { slider_Value.Value = 15; }
            else if (newValue <= 0.00000000007f) { slider_Value.Value = 16; }
            else if (newValue <= 0.00000000008f) { slider_Value.Value = 17; }
            else if (newValue <= 0.00000000009f) { slider_Value.Value = 18; }
            else if (newValue <= 0.0000000001f) { slider_Value.Value = 19; }
            else if (newValue <= 0.0000000002f) { slider_Value.Value = 20; }
            else if (newValue <= 0.0000000003f) { slider_Value.Value = 21; }
            else if (newValue <= 0.0000000004f) { slider_Value.Value = 22; }
            else if (newValue <= 0.0000000005f) { slider_Value.Value = 23; }
            else if (newValue <= 0.0000000006f) { slider_Value.Value = 24; }
            else if (newValue <= 0.0000000007f) { slider_Value.Value = 25; }
            else if (newValue <= 0.0000000008f) { slider_Value.Value = 26; }
            else if (newValue <= 0.0000000009f) { slider_Value.Value = 27; }
            else if (newValue <= 0.000000001f) { slider_Value.Value = 28; }
            else if (newValue <= 0.000000002f) { slider_Value.Value = 29; }
            else if (newValue <= 0.000000003f) { slider_Value.Value = 30; }
            else if (newValue <= 0.000000004f) { slider_Value.Value = 31; }
            else if (newValue <= 0.000000005f) { slider_Value.Value = 32; }
            else if (newValue <= 0.000000006f) { slider_Value.Value = 33; }
            else if (newValue <= 0.000000007f) { slider_Value.Value = 34; }
            else if (newValue <= 0.000000008f) { slider_Value.Value = 35; }
            else if (newValue <= 0.000000009f) { slider_Value.Value = 36; }
            else if (newValue <= 0.00000001f) { slider_Value.Value = 37; }
            else if (newValue <= 0.00000002f) { slider_Value.Value = 38; }
            else if (newValue <= 0.00000003f) { slider_Value.Value = 39; }
            else if (newValue <= 0.00000004f) { slider_Value.Value = 40; }
            else if (newValue <= 0.00000005f) { slider_Value.Value = 41; }
            else if (newValue <= 0.00000006f) { slider_Value.Value = 42; }
            else if (newValue <= 0.00000007f) { slider_Value.Value = 43; }
            else if (newValue <= 0.00000008f) { slider_Value.Value = 44; }
            else if (newValue <= 0.00000009f) { slider_Value.Value = 45; }
            else if (newValue <= 0.0000001f) { slider_Value.Value = 46; }
            else if (newValue <= 0.0000002f) { slider_Value.Value = 47; }
            else if (newValue <= 0.0000003f) { slider_Value.Value = 48; }
            else if (newValue <= 0.0000004f) { slider_Value.Value = 49; }
            else if (newValue <= 0.0000005f) { slider_Value.Value = 50; }
            else if (newValue <= 0.0000006f) { slider_Value.Value = 51; }
            else if (newValue <= 0.0000007f) { slider_Value.Value = 52; }
            else if (newValue <= 0.0000008f) { slider_Value.Value = 53; }
            else if (newValue <= 0.0000009f) { slider_Value.Value = 54; }
            else if (newValue <= 0.000001f) { slider_Value.Value = 55; }
            else if (newValue <= 0.000002f) { slider_Value.Value = 56; }
            else if (newValue <= 0.000003f) { slider_Value.Value = 57; }
            else if (newValue <= 0.000004f) { slider_Value.Value = 58; }
            else if (newValue <= 0.000005f) { slider_Value.Value = 59; }
            else if (newValue <= 0.000006f) { slider_Value.Value = 60; }
            else if (newValue <= 0.000007f) { slider_Value.Value = 61; }
            else if (newValue <= 0.000008f) { slider_Value.Value = 62; }
            else if (newValue <= 0.000009f) { slider_Value.Value = 63; }
            else if (newValue <= 0.00001f) { slider_Value.Value = 64; }
            else if (newValue <= 0.00002f) { slider_Value.Value = 65; }
            else if (newValue <= 0.00003f) { slider_Value.Value = 66; }
            else if (newValue <= 0.00004f) { slider_Value.Value = 67; }
            else if (newValue <= 0.00005f) { slider_Value.Value = 68; }
            else if (newValue <= 0.00006f) { slider_Value.Value = 69; }
            else if (newValue <= 0.00007f) { slider_Value.Value = 70; }
            else if (newValue <= 0.00008f) { slider_Value.Value = 71; }
            else if (newValue <= 0.00009f) { slider_Value.Value = 72; }
            else if (newValue <= 0.0001f) { slider_Value.Value = 73; }
            else if (newValue <= 0.0002f) { slider_Value.Value = 74; }
            else if (newValue <= 0.0003f) { slider_Value.Value = 75; }
            else if (newValue <= 0.0004f) { slider_Value.Value = 76; }
            else if (newValue <= 0.0005f) { slider_Value.Value = 77; }
            else if (newValue <= 0.0006f) { slider_Value.Value = 78; }
            else if (newValue <= 0.0007f) { slider_Value.Value = 79; }
            else if (newValue <= 0.0008f) { slider_Value.Value = 80; }
            else if (newValue <= 0.0009f) { slider_Value.Value = 81; }
            else if (newValue <= 0.001f) { slider_Value.Value = 82; }
            else if (newValue <= 0.002f) { slider_Value.Value = 83; }
            else if (newValue <= 0.003f) { slider_Value.Value = 84; }
            else if (newValue <= 0.004f) { slider_Value.Value = 85; }
            else if (newValue <= 0.005f) { slider_Value.Value = 86; }
            else if (newValue <= 0.006f) { slider_Value.Value = 87; }
            else if (newValue <= 0.007f) { slider_Value.Value = 88; }
            else if (newValue <= 0.008f) { slider_Value.Value = 89; }
            else if (newValue <= 0.009f) { slider_Value.Value = 90; }
            else if (newValue <= 0.01f) { slider_Value.Value = 91; }
            else if (newValue <= 0.02f) { slider_Value.Value = 92; }
            else if (newValue <= 0.03f) { slider_Value.Value = 93; }
            else if (newValue <= 0.04f) { slider_Value.Value = 94; }
            else if (newValue <= 0.05f) { slider_Value.Value = 95; }
            else if (newValue <= 0.06f) { slider_Value.Value = 96; }
            else if (newValue <= 0.07f) { slider_Value.Value = 97; }
            else if (newValue <= 0.08f) { slider_Value.Value = 98; }
            else if (newValue <= 0.09f) { slider_Value.Value = 99; }
            else if (newValue <= 0.1f) { slider_Value.Value = 100; }
            else if (newValue <= 0.2f) { slider_Value.Value = 101; }
            else if (newValue <= 0.3f) { slider_Value.Value = 102; }
            else if (newValue <= 0.4f) { slider_Value.Value = 103; }
            else if (newValue <= 0.5f) { slider_Value.Value = 104; }
            else if (newValue <= 0.6f) { slider_Value.Value = 105; }
            else if (newValue <= 0.7f) { slider_Value.Value = 106; }
            else if (newValue <= 0.8f) { slider_Value.Value = 107; }
            else if (newValue <= 0.9f) { slider_Value.Value = 108; }
            else if (newValue <= 1f) { slider_Value.Value = 109; }
            else if (newValue <= 2f) { slider_Value.Value = 110; }
            else if (newValue <= 3f) { slider_Value.Value = 111; }
            else if (newValue <= 4f) { slider_Value.Value = 112; }
            else if (newValue <= 5f) { slider_Value.Value = 113; }
            else if (newValue <= 6f) { slider_Value.Value = 114; }
            else if (newValue <= 7f) { slider_Value.Value = 115; }
            else if (newValue <= 8f) { slider_Value.Value = 116; }
            else if (newValue <= 9f) { slider_Value.Value = 117; }
            else if (newValue <= 10f) { slider_Value.Value = 118; }
            else if (newValue <= 20f) { slider_Value.Value = 119; }
            else if (newValue <= 30f) { slider_Value.Value = 120; }
            else if (newValue <= 40f) { slider_Value.Value = 121; }
            else if (newValue <= 50f) { slider_Value.Value = 122; }
            else if (newValue <= 60f) { slider_Value.Value = 123; }
            else if (newValue <= 70f) { slider_Value.Value = 124; }
            else if (newValue <= 80f) { slider_Value.Value = 125; }
            else if (newValue <= 90f) { slider_Value.Value = 126; }
            else if (newValue <= 100f) { slider_Value.Value = 127; }
            else if (newValue <= 200f) { slider_Value.Value = 128; }
            else if (newValue <= 300f) { slider_Value.Value = 129; }
            else if (newValue <= 400f) { slider_Value.Value = 130; }
            else if (newValue <= 500f) { slider_Value.Value = 131; }
            else if (newValue <= 600f) { slider_Value.Value = 132; }
            else if (newValue <= 700f) { slider_Value.Value = 133; }
            else if (newValue <= 800f) { slider_Value.Value = 134; }
            else if (newValue <= 900f) { slider_Value.Value = 135; }
            else if (newValue <= 1000f) { slider_Value.Value = 136; }
            else if (newValue <= 2000f) { slider_Value.Value = 137; }
            else if (newValue <= 3000f) { slider_Value.Value = 138; }
            else if (newValue <= 4000f) { slider_Value.Value = 139; }
            else if (newValue <= 5000f) { slider_Value.Value = 140; }
            else if (newValue <= 6000f) { slider_Value.Value = 141; }
            else if (newValue <= 7000f) { slider_Value.Value = 142; }
            else if (newValue <= 8000f) { slider_Value.Value = 143; }
            else if (newValue <= 9000f) { slider_Value.Value = 144; }
            else if (newValue <= 10000f) { slider_Value.Value = 145; }
            else if (newValue <= 20000f) { slider_Value.Value = 146; }
            else if (newValue <= 30000f) { slider_Value.Value = 147; }
            else if (newValue <= 40000f) { slider_Value.Value = 148; }
            else if (newValue <= 50000f) { slider_Value.Value = 149; }
            else if (newValue <= 60000f) { slider_Value.Value = 150; }
            else if (newValue <= 70000f) { slider_Value.Value = 151; }
            else if (newValue <= 80000f) { slider_Value.Value = 152; }
            else if (newValue <= 90000f) { slider_Value.Value = 153; }
            else if (newValue <= 100000f) { slider_Value.Value = 154; }
            else if (newValue <= 200000f) { slider_Value.Value = 155; }
            else if (newValue <= 300000f) { slider_Value.Value = 156; }
            else if (newValue <= 400000f) { slider_Value.Value = 157; }
            else if (newValue <= 500000f) { slider_Value.Value = 158; }
            else if (newValue <= 600000f) { slider_Value.Value = 159; }
            else if (newValue <= 700000f) { slider_Value.Value = 160; }
            else if (newValue <= 800000f) { slider_Value.Value = 161; }
            else if (newValue <= 900000f) { slider_Value.Value = 162; }
            else if (newValue <= 1000000f) { slider_Value.Value = 163; }
            else if (newValue <= 2000000f) { slider_Value.Value = 164; }
            else if (newValue <= 3000000f) { slider_Value.Value = 165; }
            else if (newValue <= 4000000f) { slider_Value.Value = 166; }
            else if (newValue <= 5000000f) { slider_Value.Value = 167; }
            else if (newValue <= 6000000f) { slider_Value.Value = 168; }
            else if (newValue <= 7000000f) { slider_Value.Value = 169; }
            else if (newValue <= 8000000f) { slider_Value.Value = 170; }
            else if (newValue <= 9000000f) { slider_Value.Value = 171; }
            else if (newValue <= 10000000f) { slider_Value.Value = 172; }
            else if (newValue <= 20000000f) { slider_Value.Value = 173; }
            else if (newValue <= 30000000f) { slider_Value.Value = 174; }
            else if (newValue <= 40000000f) { slider_Value.Value = 175; }
            else if (newValue <= 50000000f) { slider_Value.Value = 176; }
            else if (newValue <= 60000000f) { slider_Value.Value = 177; }
            else if (newValue <= 70000000f) { slider_Value.Value = 178; }
            else if (newValue <= 80000000f) { slider_Value.Value = 179; }
            else if (newValue <= 90000000f) { slider_Value.Value = 180; }
            else if (newValue <= 100000000f) { slider_Value.Value = 181; }
            else if (newValue <= 200000000f) { slider_Value.Value = 182; }
            else if (newValue <= 300000000f) { slider_Value.Value = 183; }
            else if (newValue <= 400000000f) { slider_Value.Value = 184; }
            else if (newValue <= 500000000f) { slider_Value.Value = 185; }
            else if (newValue <= 600000000f) { slider_Value.Value = 186; }
            else if (newValue <= 700000000f) { slider_Value.Value = 187; }
            else if (newValue <= 800000000f) { slider_Value.Value = 188; }
            else if (newValue <= 900000000f) { slider_Value.Value = 189; }
            else if (newValue <= 1000000000f) { slider_Value.Value = 190; }
            else if (newValue <= 2000000000f) { slider_Value.Value = 191; }
            else if (newValue <= 3000000000f) { slider_Value.Value = 192; }
            else if (newValue <= 4000000000f) { slider_Value.Value = 193; }
            else if (newValue <= 5000000000f) { slider_Value.Value = 194; }
            else if (newValue <= 6000000000f) { slider_Value.Value = 195; }
            else if (newValue <= 7000000000f) { slider_Value.Value = 196; }
            else if (newValue <= 8000000000f) { slider_Value.Value = 197; }
            else if (newValue <= 9000000000f) { slider_Value.Value = 198; }
            else if (newValue <= 10000000000f) { slider_Value.Value = 199; }
            else if (newValue <= 20000000000f) { slider_Value.Value = 200; }
            else if (newValue <= 30000000000f) { slider_Value.Value = 201; }
            else if (newValue <= 40000000000f) { slider_Value.Value = 202; }
            else if (newValue <= 50000000000f) { slider_Value.Value = 203; }
            else if (newValue <= 60000000000f) { slider_Value.Value = 204; }
            else if (newValue <= 70000000000f) { slider_Value.Value = 205; }
            else if (newValue <= 80000000000f) { slider_Value.Value = 206; }
            else if (newValue <= 90000000000f) { slider_Value.Value = 207; }
            else if (newValue <= 100000000000f) { slider_Value.Value = 208; }
            else if (newValue <= 200000000000f) { slider_Value.Value = 209; }
            else if (newValue <= 300000000000f) { slider_Value.Value = 210; }
            else if (newValue <= 400000000000f) { slider_Value.Value = 211; }
            else if (newValue <= 500000000000f) { slider_Value.Value = 212; }
            else if (newValue <= 600000000000f) { slider_Value.Value = 213; }
            else if (newValue <= 700000000000f) { slider_Value.Value = 214; }
            else if (newValue <= 800000000000f) { slider_Value.Value = 215; }
            else if (newValue <= 900000000000f) { slider_Value.Value = 216; }
            else if (newValue <= 1000000000000f) { slider_Value.Value = 217; }
            else if (newValue <= 2000000000000f) { slider_Value.Value = 218; }
            else if (newValue <= 3000000000000f) { slider_Value.Value = 219; }
            else if (newValue <= 4000000000000f) { slider_Value.Value = 220; }
            else if (newValue <= 5000000000000f) { slider_Value.Value = 221; }
            else if (newValue <= 6000000000000f) { slider_Value.Value = 222; }
            else if (newValue <= 7000000000000f) { slider_Value.Value = 223; }
            else if (newValue <= 8000000000000f) { slider_Value.Value = 224; }
            else { slider_Value.Value = 225; }


            BlockUpdate = false;
        }

        internal void SetNewValue_old(float newValue)
        {
            BlockUpdate = true;
            if (newValue <= 0.00001f) { slider_Value.Value = 1; }
            else if (newValue <= 0.00002f) { slider_Value.Value = 2; }
            else if (newValue <= 0.00003f) { slider_Value.Value = 3; }
            else if (newValue <= 0.00004f) { slider_Value.Value = 4; }
            else if (newValue <= 0.00005f) { slider_Value.Value = 5; }
            else if (newValue <= 0.00006f) { slider_Value.Value = 6; }
            else if (newValue <= 0.00007f) { slider_Value.Value = 7; }
            else if (newValue <= 0.00008f) { slider_Value.Value = 8; }
            else if (newValue <= 0.00009f) { slider_Value.Value = 9; }
            else if (newValue <= 0.0001f) { slider_Value.Value = 10; }
            else if (newValue <= 0.0002f) { slider_Value.Value = 11; }
            else if (newValue <= 0.0003f) { slider_Value.Value = 12; }
            else if (newValue <= 0.0004f) { slider_Value.Value = 13; }
            else if (newValue <= 0.0005f) { slider_Value.Value = 14; }
            else if (newValue <= 0.0006f) { slider_Value.Value = 15; }
            else if (newValue <= 0.0007f) { slider_Value.Value = 16; }
            else if (newValue <= 0.0008f) { slider_Value.Value = 17; }
            else if (newValue <= 0.0009f) { slider_Value.Value = 18; }
            else if (newValue <= 0.001f) { slider_Value.Value = 19; }
            else if (newValue <= 0.002f) { slider_Value.Value = 20; }
            else if (newValue <= 0.003f) { slider_Value.Value = 21; }
            else if (newValue <= 0.004f) { slider_Value.Value = 22; }
            else if (newValue <= 0.005f) { slider_Value.Value = 23; }
            else if (newValue <= 0.006f) { slider_Value.Value = 24; }
            else if (newValue <= 0.007f) { slider_Value.Value = 25; }
            else if (newValue <= 0.008f) { slider_Value.Value = 26; }
            else if (newValue <= 0.009f) { slider_Value.Value = 27; }
            else if (newValue <= 0.01f) { slider_Value.Value = 28; }
            else if (newValue <= 0.02f) { slider_Value.Value = 29; }
            else if (newValue <= 0.03f) { slider_Value.Value = 30; }
            else if (newValue <= 0.04f) { slider_Value.Value = 31; }
            else if (newValue <= 0.05f) { slider_Value.Value = 32; }
            else if (newValue <= 0.06f) { slider_Value.Value = 33; }
            else if (newValue <= 0.07f) { slider_Value.Value = 34; }
            else if (newValue <= 0.08f) { slider_Value.Value = 35; }
            else if (newValue <= 0.09f) { slider_Value.Value = 36; }
            else if (newValue <= 0.1f) { slider_Value.Value = 37; }
            else if (newValue <= 0.2f) { slider_Value.Value = 38; }
            else if (newValue <= 0.3f) { slider_Value.Value = 39; }
            else if (newValue <= 0.4f) { slider_Value.Value = 40; }
            else if (newValue <= 0.5f) { slider_Value.Value = 41; }
            else if (newValue <= 0.6f) { slider_Value.Value = 42; }
            else if (newValue <= 0.7f) { slider_Value.Value = 43; }
            else if (newValue <= 0.7f) { slider_Value.Value = 44; }
            else if (newValue <= 0.8f) { slider_Value.Value = 45; }
            else if (newValue <= 0.9f) { slider_Value.Value = 46; }
            else if (newValue <= 1f) { slider_Value.Value = 47; }
            else if (newValue <= 2f) { slider_Value.Value = 48; }
            else if (newValue <= 3f) { slider_Value.Value = 49; }
            else if (newValue <= 4f) { slider_Value.Value = 50; }
            else if (newValue <= 5f) { slider_Value.Value = 51; }
            else if (newValue <= 6f) { slider_Value.Value = 52; }
            else if (newValue <= 7f) { slider_Value.Value = 53; }
            else if (newValue <= 8f) { slider_Value.Value = 54; }
            else if (newValue <= 9f) { slider_Value.Value = 55; }
            else if (newValue <= 10f) { slider_Value.Value = 56; }
            else if (newValue <= 20f) { slider_Value.Value = 57; }
            else if (newValue <= 30f) { slider_Value.Value = 58; }
            else if (newValue <= 40f) { slider_Value.Value = 59; }
            else if (newValue <= 50f) { slider_Value.Value = 60; }
            else if (newValue <= 60f) { slider_Value.Value = 61; }
            else if (newValue <= 70f) { slider_Value.Value = 62; }
            else if (newValue <= 80f) { slider_Value.Value = 63; }
            else if (newValue <= 90f) { slider_Value.Value = 64; }
            else if (newValue <= 100f) { slider_Value.Value = 65; }
            else if (newValue <= 200f) { slider_Value.Value = 66; }
            else if (newValue <= 300f) { slider_Value.Value = 67; }
            else if (newValue <= 400f) { slider_Value.Value = 68; }
            else if (newValue <= 500f) { slider_Value.Value = 69; }
            else if (newValue <= 600f) { slider_Value.Value = 70; }
            else if (newValue <= 700f) { slider_Value.Value = 71; }
            else if (newValue <= 800f) { slider_Value.Value = 72; }
            else if (newValue <= 900f) { slider_Value.Value = 73; }
            else if (newValue <= 1000f) { slider_Value.Value = 74; }
            else if (newValue <= 2000f) { slider_Value.Value = 75; }
            else if (newValue <= 3000f) { slider_Value.Value = 76; }
            else if (newValue <= 4000f) { slider_Value.Value = 77; }
            else if (newValue <= 5000f) { slider_Value.Value = 78; }
            else if (newValue <= 6000f) { slider_Value.Value = 79; }
            else if (newValue <= 7000f) { slider_Value.Value = 80; }
            else if (newValue <= 8000f) { slider_Value.Value = 81; }
            else if (newValue <= 9000f) { slider_Value.Value = 82; }
            else if (newValue <= 10000f) { slider_Value.Value = 83; }
            else if (newValue <= 20000f) { slider_Value.Value = 84; }
            else if (newValue <= 30000f) { slider_Value.Value = 85; }
            else if (newValue <= 40000f) { slider_Value.Value = 86; }
            else if (newValue <= 50000f) { slider_Value.Value = 87; }
            else if (newValue <= 60000f) { slider_Value.Value = 88; }
            else if (newValue <= 70000f) { slider_Value.Value = 89; }
            else if (newValue <= 80000f) { slider_Value.Value = 90; }
            else if (newValue <= 90000f) { slider_Value.Value = 91; }
            else if (newValue <= 100000f) { slider_Value.Value = 92; }

            BlockUpdate = false;
        }
        private float theValue;
        public float TheValue
        {
            get { return theValue; }
            set { theValue = value; }
        }

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                textBlock_Title.IsChecked = value;
            }
        }


        private void slider_Value_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {



            switch ((int)slider_Value.Value)
            {
                case 1: theValue = 0.000000000001f; break;
                case 2: theValue = 0.000000000002f; break;
                case 3: theValue = 0.000000000003f; break;
                case 4: theValue = 0.000000000004f; break;
                case 5: theValue = 0.000000000005f; break;
                case 6: theValue = 0.000000000006f; break;
                case 7: theValue = 0.000000000007f; break;
                case 8: theValue = 0.000000000008f; break;
                case 9: theValue = 0.000000000009f; break;
                case 10: theValue = 0.00000000001f; break;
                case 11: theValue = 0.00000000002f; break;
                case 12: theValue = 0.00000000003f; break;
                case 13: theValue = 0.00000000004f; break;
                case 14: theValue = 0.00000000005f; break;
                case 15: theValue = 0.00000000006f; break;
                case 16: theValue = 0.00000000007f; break;
                case 17: theValue = 0.00000000008f; break;
                case 18: theValue = 0.00000000009f; break;
                case 19: theValue = 0.0000000001f; break;
                case 20: theValue = 0.0000000002f; break;
                case 21: theValue = 0.0000000003f; break;
                case 22: theValue = 0.0000000004f; break;
                case 23: theValue = 0.0000000005f; break;
                case 24: theValue = 0.0000000006f; break;
                case 25: theValue = 0.0000000007f; break;
                case 26: theValue = 0.0000000008f; break;
                case 27: theValue = 0.0000000009f; break;
                case 28: theValue = 0.000000001f; break;
                case 29: theValue = 0.000000002f; break;
                case 30: theValue = 0.000000003f; break;
                case 31: theValue = 0.000000004f; break;
                case 32: theValue = 0.000000005f; break;
                case 33: theValue = 0.000000006f; break;
                case 34: theValue = 0.000000007f; break;
                case 35: theValue = 0.000000008f; break;
                case 36: theValue = 0.000000009f; break;
                case 37: theValue = 0.00000001f; break;
                case 38: theValue = 0.00000002f; break;
                case 39: theValue = 0.00000003f; break;
                case 40: theValue = 0.00000004f; break;
                case 41: theValue = 0.00000005f; break;
                case 42: theValue = 0.00000006f; break;
                case 43: theValue = 0.00000007f; break;
                case 44: theValue = 0.00000008f; break;
                case 45: theValue = 0.00000009f; break;
                case 46: theValue = 0.0000001f; break;
                case 47: theValue = 0.0000002f; break;
                case 48: theValue = 0.0000003f; break;
                case 49: theValue = 0.0000004f; break;
                case 50: theValue = 0.0000005f; break;
                case 51: theValue = 0.0000006f; break;
                case 52: theValue = 0.0000007f; break;
                case 53: theValue = 0.0000008f; break;
                case 54: theValue = 0.0000009f; break;
                case 55: theValue = 0.000001f; break;
                case 56: theValue = 0.000002f; break;
                case 57: theValue = 0.000003f; break;
                case 58: theValue = 0.000004f; break;
                case 59: theValue = 0.000005f; break;
                case 60: theValue = 0.000006f; break;
                case 61: theValue = 0.000007f; break;
                case 62: theValue = 0.000008f; break;
                case 63: theValue = 0.000009f; break;
                case 64: theValue = 0.00001f; break;
                case 65: theValue = 0.00002f; break;
                case 66: theValue = 0.00003f; break;
                case 67: theValue = 0.00004f; break;
                case 68: theValue = 0.00005f; break;
                case 69: theValue = 0.00006f; break;
                case 70: theValue = 0.00007f; break;
                case 71: theValue = 0.00008f; break;
                case 72: theValue = 0.00009f; break;
                case 73: theValue = 0.0001f; break;
                case 74: theValue = 0.0002f; break;
                case 75: theValue = 0.0003f; break;
                case 76: theValue = 0.0004f; break;
                case 77: theValue = 0.0005f; break;
                case 78: theValue = 0.0006f; break;
                case 79: theValue = 0.0007f; break;
                case 80: theValue = 0.0008f; break;
                case 81: theValue = 0.0009f; break;
                case 82: theValue = 0.001f; break;
                case 83: theValue = 0.002f; break;
                case 84: theValue = 0.003f; break;
                case 85: theValue = 0.004f; break;
                case 86: theValue = 0.005f; break;
                case 87: theValue = 0.006f; break;
                case 88: theValue = 0.007f; break;
                case 89: theValue = 0.008f; break;
                case 90: theValue = 0.009f; break;
                case 91: theValue = 0.01f; break;
                case 92: theValue = 0.02f; break;
                case 93: theValue = 0.03f; break;
                case 94: theValue = 0.04f; break;
                case 95: theValue = 0.05f; break;
                case 96: theValue = 0.06f; break;
                case 97: theValue = 0.07f; break;
                case 98: theValue = 0.08f; break;
                case 99: theValue = 0.09f; break;
                case 100: theValue = 0.1f; break;
                case 101: theValue = 0.2f; break;
                case 102: theValue = 0.3f; break;
                case 103: theValue = 0.4f; break;
                case 104: theValue = 0.5f; break;
                case 105: theValue = 0.6f; break;
                case 106: theValue = 0.7f; break;
                case 107: theValue = 0.8f; break;
                case 108: theValue = 0.9f; break;
                case 109: theValue = 1f; break;
                case 110: theValue = 2f; break;
                case 111: theValue = 3f; break;
                case 112: theValue = 4f; break;
                case 113: theValue = 5f; break;
                case 114: theValue = 6f; break;
                case 115: theValue = 7f; break;
                case 116: theValue = 8f; break;
                case 117: theValue = 9f; break;
                case 118: theValue = 10f; break;
                case 119: theValue = 20f; break;
                case 120: theValue = 30f; break;
                case 121: theValue = 40f; break;
                case 122: theValue = 50f; break;
                case 123: theValue = 60f; break;
                case 124: theValue = 70f; break;
                case 125: theValue = 80f; break;
                case 126: theValue = 90f; break;
                case 127: theValue = 100f; break;
                case 128: theValue = 200f; break;
                case 129: theValue = 300f; break;
                case 130: theValue = 400f; break;
                case 131: theValue = 500f; break;
                case 132: theValue = 600f; break;
                case 133: theValue = 700f; break;
                case 134: theValue = 800f; break;
                case 135: theValue = 900f; break;
                case 136: theValue = 1000f; break;
                case 137: theValue = 2000f; break;
                case 138: theValue = 3000f; break;
                case 139: theValue = 4000f; break;
                case 140: theValue = 5000f; break;
                case 141: theValue = 6000f; break;
                case 142: theValue = 7000f; break;
                case 143: theValue = 8000f; break;
                case 144: theValue = 9000f; break;
                case 145: theValue = 10000f; break;
                case 146: theValue = 20000f; break;
                case 147: theValue = 30000f; break;
                case 148: theValue = 40000f; break;
                case 149: theValue = 50000f; break;
                case 150: theValue = 60000f; break;
                case 151: theValue = 70000f; break;
                case 152: theValue = 80000f; break;
                case 153: theValue = 90000f; break;
                case 154: theValue = 100000f; break;
                case 155: theValue = 200000f; break;
                case 156: theValue = 300000f; break;
                case 157: theValue = 400000f; break;
                case 158: theValue = 500000f; break;
                case 159: theValue = 600000f; break;
                case 160: theValue = 700000f; break;
                case 161: theValue = 800000f; break;
                case 162: theValue = 900000f; break;
                case 163: theValue = 1000000f; break;
                case 164: theValue = 2000000f; break;
                case 165: theValue = 3000000f; break;
                case 166: theValue = 4000000f; break;
                case 167: theValue = 5000000f; break;
                case 168: theValue = 6000000f; break;
                case 169: theValue = 7000000f; break;
                case 170: theValue = 8000000f; break;
                case 171: theValue = 9000000f; break;
                case 172: theValue = 10000000f; break;
                case 173: theValue = 20000000f; break;
                case 174: theValue = 30000000f; break;
                case 175: theValue = 40000000f; break;
                case 176: theValue = 50000000f; break;
                case 177: theValue = 60000000f; break;
                case 178: theValue = 70000000f; break;
                case 179: theValue = 80000000f; break;
                case 180: theValue = 90000000f; break;
                case 181: theValue = 100000000f; break;
                case 182: theValue = 200000000f; break;
                case 183: theValue = 300000000f; break;
                case 184: theValue = 400000000f; break;
                case 185: theValue = 500000000f; break;
                case 186: theValue = 600000000f; break;
                case 187: theValue = 700000000f; break;
                case 188: theValue = 800000000f; break;
                case 189: theValue = 900000000f; break;
                case 190: theValue = 1000000000f; break;
                case 191: theValue = 2000000000f; break;
                case 192: theValue = 3000000000f; break;
                case 193: theValue = 4000000000f; break;
                case 194: theValue = 5000000000f; break;
                case 195: theValue = 6000000000f; break;
                case 196: theValue = 7000000000f; break;
                case 197: theValue = 8000000000f; break;
                case 198: theValue = 9000000000f; break;
                case 199: theValue = 10000000000f; break;
                case 200: theValue = 20000000000f; break;
                case 201: theValue = 30000000000f; break;
                case 202: theValue = 40000000000f; break;
                case 203: theValue = 50000000000f; break;
                case 204: theValue = 60000000000f; break;
                case 205: theValue = 70000000000f; break;
                case 206: theValue = 80000000000f; break;
                case 207: theValue = 90000000000f; break;
                case 208: theValue = 100000000000f; break;
                case 209: theValue = 200000000000f; break;
                case 210: theValue = 300000000000f; break;
                case 211: theValue = 400000000000f; break;
                case 212: theValue = 500000000000f; break;
                case 213: theValue = 600000000000f; break;
                case 214: theValue = 700000000000f; break;
                case 215: theValue = 800000000000f; break;
                case 216: theValue = 900000000000f; break;
                case 217: theValue = 1000000000000f; break;
                case 218: theValue = 2000000000000f; break;
                case 219: theValue = 3000000000000f; break;
                case 220: theValue = 4000000000000f; break;
                case 221: theValue = 5000000000000f; break;
                case 222: theValue = 6000000000000f; break;
                case 223: theValue = 7000000000000f; break;
                case 224: theValue = 8000000000000f; break;
                case 225: theValue = 9000000000000f; break;

            }

            textBlock_Value.Text = "x" + theValue.ToString();

            if (!BlockUpdate)
            {
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }



        private void slider_Value_ValueChanged_old(object sender, RangeBaseValueChangedEventArgs e)
        {



            switch ((int)slider_Value.Value)
            {
                case 1: theValue = 0.00001f; break;
                case 2: theValue = 0.00002f; break;
                case 3: theValue = 0.00003f; break;
                case 4: theValue = 0.00004f; break;
                case 5: theValue = 0.00005f; break;
                case 6: theValue = 0.00006f; break;
                case 7: theValue = 0.00007f; break;
                case 8: theValue = 0.00008f; break;
                case 9: theValue = 0.00009f; break;
                case 10: theValue = 0.0001f; break;
                case 11: theValue = 0.0002f; break;
                case 12: theValue = 0.0003f; break;
                case 13: theValue = 0.0004f; break;
                case 14: theValue = 0.0005f; break;
                case 15: theValue = 0.0006f; break;
                case 16: theValue = 0.0007f; break;
                case 17: theValue = 0.0008f; break;
                case 18: theValue = 0.0009f; break;
                case 19: theValue = 0.001f; break;
                case 20: theValue = 0.002f; break;
                case 21: theValue = 0.003f; break;
                case 22: theValue = 0.004f; break;
                case 23: theValue = 0.005f; break;
                case 24: theValue = 0.006f; break;
                case 25: theValue = 0.007f; break;
                case 26: theValue = 0.008f; break;
                case 27: theValue = 0.009f; break;
                case 28: theValue = 0.01f; break;
                case 29: theValue = 0.02f; break;
                case 30: theValue = 0.03f; break;
                case 31: theValue = 0.04f; break;
                case 32: theValue = 0.05f; break;
                case 33: theValue = 0.06f; break;
                case 34: theValue = 0.07f; break;
                case 35: theValue = 0.08f; break;
                case 36: theValue = 0.09f; break;
                case 37: theValue = 0.1f; break;
                case 38: theValue = 0.2f; break;
                case 39: theValue = 0.3f; break;
                case 40: theValue = 0.4f; break;
                case 41: theValue = 0.5f; break;
                case 42: theValue = 0.6f; break;
                case 43: theValue = 0.7f; break;
                case 44: theValue = 0.7f; break;
                case 45: theValue = 0.8f; break;
                case 46: theValue = 0.9f; break;
                case 47: theValue = 1f; break;
                case 48: theValue = 2f; break;
                case 49: theValue = 3f; break;
                case 50: theValue = 4f; break;
                case 51: theValue = 5f; break;
                case 52: theValue = 6f; break;
                case 53: theValue = 7f; break;
                case 54: theValue = 8f; break;
                case 55: theValue = 9f; break;
                case 56: theValue = 10f; break;
                case 57: theValue = 20f; break;
                case 58: theValue = 30f; break;
                case 59: theValue = 40f; break;
                case 60: theValue = 50f; break;
                case 61: theValue = 60f; break;
                case 62: theValue = 70f; break;
                case 63: theValue = 80f; break;
                case 64: theValue = 90f; break;
                case 65: theValue = 100f; break;
                case 66: theValue = 200f; break;
                case 67: theValue = 300f; break;
                case 68: theValue = 400f; break;
                case 69: theValue = 500f; break;
                case 70: theValue = 600f; break;
                case 71: theValue = 700f; break;
                case 72: theValue = 800f; break;
                case 73: theValue = 900f; break;
                case 74: theValue = 1000f; break;
                case 75: theValue = 2000f; break;
                case 76: theValue = 3000f; break;
                case 77: theValue = 4000f; break;
                case 78: theValue = 5000f; break;
                case 79: theValue = 6000f; break;
                case 80: theValue = 7000f; break;
                case 81: theValue = 8000f; break;
                case 82: theValue = 9000f; break;
                case 83: theValue = 10000f; break;
                case 84: theValue = 20000f; break;
                case 85: theValue = 30000f; break;
                case 86: theValue = 40000f; break;
                case 87: theValue = 50000f; break;
                case 88: theValue = 60000f; break;
                case 89: theValue = 70000f; break;
                case 90: theValue = 80000f; break;
                case 91: theValue = 90000f; break;
                case 92: theValue = 100000f; break;
            }

            textBlock_Value.Text = "x" + theValue.ToString();

            if (!BlockUpdate)
            {
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        private void textBlock_Minus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (slider_Value.Value > 1) { slider_Value.Value = slider_Value.Value - 1; }
        }

        private void textBlock_Plus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (slider_Value.Value < 92) { slider_Value.Value = slider_Value.Value + 1; }
        }

        private void textBlock_Title_Checked(object sender, RoutedEventArgs e)
        {
            isChecked = true;
            Checked?.Invoke(this, new EventArgs());
        }

        private void textBlock_Title_Unchecked(object sender, RoutedEventArgs e)
        {
            isChecked = false;
            Unchecked?.Invoke(this, new EventArgs());
        }
    }
}

