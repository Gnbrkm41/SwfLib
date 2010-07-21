﻿namespace Code.SwfLib.Data.Actions {
    public class ActionIf : ActionBase {

        public override ActionCode ActionCode {
            get { return ActionCode.If;}
        }

        public override object AcceptVisitor(IActionVisitor visitor) {
            return visitor.Visit(this);
        }

    }
}
