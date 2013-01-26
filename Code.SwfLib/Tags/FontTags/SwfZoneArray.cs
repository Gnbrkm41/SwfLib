﻿using Code.SwfLib.Fonts;

namespace Code.SwfLib.Tags.FontTags {
    public class SwfZoneArray {

        public ZoneData[] Data;

        public SwfZoneArrayFlags Flags;

        public byte Reserved;

        public bool ZoneX {
            get {
                return (Flags & SwfZoneArrayFlags.ZoneX) != 0;
            }
            set {
                if (value) Flags |= SwfZoneArrayFlags.ZoneX;
                else Flags &= ~SwfZoneArrayFlags.ZoneX;
            }
        }

        public bool ZoneY {
            get {
                return (Flags & SwfZoneArrayFlags.ZoneY) != 0;
            }
            set {
                if (value) Flags |= SwfZoneArrayFlags.ZoneY;
                else Flags &= ~SwfZoneArrayFlags.ZoneY;
            }
        }

    }
}
