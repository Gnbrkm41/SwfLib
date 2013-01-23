﻿namespace Code.SwfLib.Data.Shapes {
    public class StyleChangeShapeRecord : ShapeRecord {

        public uint? FillStyle0;

        public uint? FillStyle1;

        public uint? LineStyle;

        public int MoveDeltaX;

        public int MoveDeltaY;

        public bool StateNewStyles;

        public override ShapeRecordType Type {
            get { return ShapeRecordType.StyleChangeRecord; }
        }

    }
}
