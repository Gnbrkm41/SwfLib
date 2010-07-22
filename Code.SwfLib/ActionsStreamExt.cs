﻿using System;
using Code.SwfLib.Data.Actions;

namespace Code.SwfLib {
    public static class ActionsStreamExt {

        private static void AssertActionCode(this SwfStreamReader reader, ActionCode code, out ushort length) {
            var actual = (ActionCode)reader.ReadByte();
            if (actual != code) throw new InvalidOperationException("Expected " + code + " but was " + actual);
            if ((byte)code >= 0x80) {
                length = reader.ReadUInt16();
            } else {
                length = 0;
            }
        }

        public static ActionBase ReadAction(this SwfStreamReader reader) {
            var code = (ActionCode)reader.ReadByte();
            reader.GoBack(1);
            Console.WriteLine(code);
            switch (code) {
                case ActionCode.Pop:
                case ActionCode.Equals:
                case ActionCode.Less:
                case ActionCode.Not:
                case ActionCode.StringLength:
                case ActionCode.StringAdd:
                case ActionCode.StringExtract:
                case ActionCode.StringLess:
                case ActionCode.MBStringLength:
                case ActionCode.MBStringExtract:
                case ActionCode.ToInteger:
                case ActionCode.CharToAscii:
                case ActionCode.AsciiToChar:
                case ActionCode.MBCharToAscii:
                case ActionCode.MBAsciiToChar:
                case ActionCode.If:
                case ActionCode.SetVariable:
                case ActionCode.GetURL2:
                case ActionCode.GotoFrame2:
                case ActionCode.SetTarget2:
                case ActionCode.GetProperty:
                case ActionCode.SetProperty:
                case ActionCode.CloneSprite:
                case ActionCode.RemoveSprite:
                case ActionCode.GetTime:
                    throw new NotImplementedException(code.ToString());

                case ActionCode.Empty:
                    return null;
                case ActionCode.Add:
                    return reader.ReadActionAdd();
                case ActionCode.And:
                    return reader.ReadActionAnd();
                case ActionCode.Call:
                    return reader.ReadActionCall();
                case ActionCode.ConstantPool:
                    return reader.ReadActionConstantPool();
                case ActionCode.DefineFunction:
                    return reader.ReadActionDefineFunction();
                case ActionCode.Divide:
                    return reader.ReadActionDivide();
                case ActionCode.EndDrag:
                    return reader.ReadActionEndDrag();
                case ActionCode.GetURL:
                    return reader.ReadActionGetURL();
                case ActionCode.GetVariable:
                    return reader.ReadActionGetVariable();
                case ActionCode.GotoFrame:
                    return reader.ReadActionGotoFrame();
                case ActionCode.GoToLabel:
                    return reader.ReadActionGoToLabel();
                case ActionCode.Jump:
                    return reader.ReadActionJump();
                case ActionCode.Multiply:
                    return reader.ReadActionMultiply();
                case ActionCode.NextFrame:
                    return reader.ReadActionNextFrame();
                case ActionCode.Or:
                    return reader.ReadActionOr();
                case ActionCode.Play:
                    return reader.ReadActionPlay();
                case ActionCode.PreviousFrame:
                    return reader.ReadActionPreviousFrame();
                case ActionCode.Push:
                    return reader.ReadActionPush();
                case ActionCode.RandomNumber:
                    return reader.ReadActionRandomNumber();
                case ActionCode.SetMember:
                    return reader.ReadActionSetMember();
                case ActionCode.SetTarget:
                    return reader.ReadActionSetTarget();
                case ActionCode.StartDrag:
                    return reader.ReadActionStartDrag();
                case ActionCode.Stop:
                    return reader.ReadActionStop();
                case ActionCode.StopSounds:
                    return reader.ReadActionStopSounds();
                case ActionCode.StringEquals:
                    return reader.ReadActionStringEquals();
                case ActionCode.Substract:
                    return reader.ReadActionSubtract();
                case ActionCode.ToggleQuality:
                    return reader.ReadActionToggleQuality();
                case ActionCode.Trace:
                    return reader.ReadActionTrace();
                case ActionCode.WaitForFrame:
                    return reader.ReadActionWaitForFrame();
                case ActionCode.WaitForFrame2:
                    return reader.ReadActionWaitForFrame2();
                default:
                    throw new NotSupportedException("ActionCode is " + code);
            }
            //TODO: other actions (SWF 5-10)
        }

        public static ActionAdd ReadActionAdd(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Add, out length);
            return new ActionAdd();
        }

        public static ActionAnd ReadActionAnd(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.And, out length);
            return new ActionAnd();
        }

        public static ActionCall ReadActionCall(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Call, out length);
            return new ActionCall();
        }

        public static ActionConstantPool ReadActionConstantPool(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.ConstantPool, out length);
            ushort count = reader.ReadUInt16();
            var pool = new string[count];
            for (var i = 0; i < count; i++) {
                pool[i] = reader.ReadString();
            }
            return new ActionConstantPool { ConstantPool = pool };
        }

        public static ActionDivide ReadActionDivide(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Divide, out length);
            return new ActionDivide();
        }

        public static ActionEndDrag ReadActionEndDrag(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.EndDrag, out length);
            return new ActionEndDrag();
        }

        public static ActionDefineFunction ReadActionDefineFunction(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.DefineFunction, out length);
            string name = reader.ReadString();
            ushort count = reader.ReadUInt16();
            var parameters = new string[count];
            for (var i = 0; i < count; i++) {
                parameters[i] = reader.ReadString();
            }
            ushort bodySize = reader.ReadUInt16();
            return new ActionDefineFunction { FunctionName = name, Params = parameters, Body = reader.ReadBytes(bodySize) };
        }

        public static ActionGetURL ReadActionGetURL(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GetURL, out length);
            return new ActionGetURL { UrlString = reader.ReadString(), TargetString = reader.ReadString() };
        }

        public static ActionGetVariable ReadActionGetVariable(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GetVariable, out length);
            return new ActionGetVariable();
        }

        public static ActionGotoFrame ReadActionGotoFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GotoFrame, out length);
            return new ActionGotoFrame { Frame = reader.ReadUInt16() };
        }

        public static ActionGoToLabel ReadActionGoToLabel(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.GoToLabel, out length);
            return new ActionGoToLabel { Label = reader.ReadString() };
        }

        public static ActionJump ReadActionJump(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Jump, out length);
            return new ActionJump { BranchOffset = reader.ReadSInt16() };
        }

        public static ActionMultiply ReadActionMultiply(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Multiply, out length);
            return new ActionMultiply();
        }

        public static ActionNextFrame ReadActionNextFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.NextFrame, out length);
            return new ActionNextFrame();
        }

        public static ActionOr ReadActionOr(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Or, out length);
            return new ActionOr();
        }

        public static ActionPlay ReadActionPlay(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Play, out length);
            return new ActionPlay();
        }

        public static ActionPreviousFrame ReadActionPreviousFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.PreviousFrame, out length);
            return new ActionPreviousFrame();
        }

        public static ActionPush ReadActionPush(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Push, out length);
            var position = reader.BaseStream.Position;
            var action = new ActionPush();
            while (reader.BaseStream.Position - position < length) {
                var item = new ActionPushItem();
                var type = (ActionPushItemType)reader.ReadByte();
                Console.WriteLine(type);
                item.Type = type;
                switch (type) {
                    case ActionPushItemType.Boolean:
                        item.Boolean = reader.ReadByte();
                        break;
                    case ActionPushItemType.Constant8:
                        item.Constant8 = reader.ReadByte();
                        break;
                    case ActionPushItemType.Constant16:
                        item.Constant16 = reader.ReadUInt16();
                        break;
                    default:
                        throw new NotSupportedException("Unknown PushData type " + type);
                }
                action.Items.Add(item);
            }
            return action;
        }

        public static ActionRandomNumber ReadActionRandomNumber(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.RandomNumber, out length);
            return new ActionRandomNumber();
        }

        public static ActionSetMember ReadActionSetMember(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.SetMember, out length);
            return new ActionSetMember();
        }

        public static ActionSetTarget ReadActionSetTarget(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.SetTarget, out length);
            return new ActionSetTarget { TargetName = reader.ReadString() };
        }

        public static ActionStartDrag ReadActionStartDrag(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.SetTarget, out length);
            return new ActionStartDrag();
        }

        public static ActionStop ReadActionStop(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Stop, out length);
            return new ActionStop();
        }

        public static ActionStopSounds ReadActionStopSounds(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.StopSounds, out length);
            return new ActionStopSounds();
        }

        public static ActionStringEquals ReadActionStringEquals(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.StringEquals, out length);
            return new ActionStringEquals();
        }

        public static ActionSubtract ReadActionSubtract(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Substract, out length);
            return new ActionSubtract();
        }

        public static ActionToggleQuality ReadActionToggleQuality(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.ToggleQuality, out length);
            return new ActionToggleQuality();
        }

        public static ActionTrace ReadActionTrace(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.Trace, out length);
            return new ActionTrace();
        }

        public static ActionWaitForFrame ReadActionWaitForFrame(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.WaitForFrame, out length);
            return new ActionWaitForFrame { Frame = reader.ReadUInt16(), SkipCount = reader.ReadByte() };
        }

        public static ActionWaitForFrame2 ReadActionWaitForFrame2(this SwfStreamReader reader) {
            ushort length;
            AssertActionCode(reader, ActionCode.WaitForFrame2, out length);
            return new ActionWaitForFrame2 { SkipCount = reader.ReadByte() };
        }
    }
}
