﻿using System.Xml.Linq;
using Code.SwfLib.Tags.ShapeMorphingTags;
using SwfLib.SwfMill.TagFormatting;

namespace Code.SwfLib.SwfMill.TagFormatting.ShapeMorphingTags {
    public class DefineMorphShapeTagFormatter : TagFormatterBase<DefineMorphShapeTag> {
        protected override void FormatTagElement(DefineMorphShapeTag tag, XElement xTag) {
        }

        public override string TagName {
            get { return "DefineMorphShape"; }
        }
    }

}
