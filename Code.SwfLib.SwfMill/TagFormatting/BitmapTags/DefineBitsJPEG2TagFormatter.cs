﻿using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.BitmapTags;

namespace Code.SwfLib.SwfMill.TagFormatting.BitmapTags {
    public class DefineBitsJPEG2TagFormatter : DefineBitmapBaseTagFormatter<DefineBitsJPEG2Tag> {

        protected override void FormatTagElement(DefineBitsJPEG2Tag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.ImageData)));
        }

        protected override void AcceptTagElement(DefineBitsJPEG2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.ImageData = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
        }

        public override string TagName {
            get { return "DefineBitsJPEG2"; }
        }

        protected override ushort? GetObjectID(DefineBitsJPEG2Tag tag) {
            return tag.CharacterID;
        }

        protected override void SetObjectID(DefineBitsJPEG2Tag tag, ushort value) {
            tag.CharacterID = value;
        }
    }
}