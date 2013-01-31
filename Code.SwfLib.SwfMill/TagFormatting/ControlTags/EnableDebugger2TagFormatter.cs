﻿using System;
using System.Xml.Linq;
using Code.SwfLib.SwfMill.Data;
using Code.SwfLib.Tags.ControlTags;

namespace Code.SwfLib.SwfMill.TagFormatting.ControlTags {
    public class EnableDebugger2TagFormatter : TagFormatterBase<EnableDebugger2Tag> {

        protected override void FormatTagElement(EnableDebugger2Tag tag, XElement xTag) {
            xTag.Add(new XElement("data", XBinary.ToXml(tag.Data)));
        }

        protected override bool AcceptTagElement(EnableDebugger2Tag tag, XElement element) {
            switch (element.Name.LocalName) {
                case "data":
                    tag.Data = XBinary.FromXml(element.Element("data"));
                    break;
                default:
                    return false;
            }
            return true;
        }

        public override string TagName {
            get { return "EnableDebugger2"; }
        }
    }
}
