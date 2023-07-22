using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using System.Net;
using Set_Data;

namespace KartRider
{
    public static class GameSupport
    {
        public static void PcFirstMessage()
        {
            uint first_val = 3595571486;
            uint second_val = 2168420743;
            using (OutPacket outPacket = new OutPacket("PcFirstMessage"))
            {
                outPacket.WriteUShort(SessionGroup.usLocale);
                outPacket.WriteUShort(1);
                outPacket.WriteUShort(Program.Version);
                outPacket.WriteString("http://kartupdate.tiancity.cn/patch/ORZNEHDJGILEVRO");
                outPacket.WriteUInt(first_val);
                outPacket.WriteUInt(second_val);
                outPacket.WriteByte(SessionGroup.nClientLoc);
                outPacket.WriteString("+B1K8NAOvJd3cXFieRWTkRNj2rlv2qVmALSUdXFpNl0=");
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 0F 00 00 00 00 00 00 00 00 2E 31 2E 31 37 2E 36 00 00 00 00 00 00 00");
                outPacket.WriteString("TwKtPFLx+3AuKg5PFa021r3hKyFDK2sFBzQJJCI26wA=");
                RouterListener.MySession.Client.Send(outPacket);
            }
            RouterListener.MySession.Client._RIV = first_val ^ second_val;
            RouterListener.MySession.Client._SIV = first_val ^ second_val;
        }

        public static void OnDisconnect()
        {
            RouterListener.MySession.Client.Disconnect();
        }

        public static void SpRpLotteryPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpLotteryPacket"))
            {
                outPacket.WriteHexString("05 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetGameOption()
        {
            using (OutPacket outPacket = new OutPacket("PrGetGameOption"))
            {
                outPacket.WriteFloat(SetGameOption.Set_BGM);
                outPacket.WriteFloat(SetGameOption.Set_Sound);
                outPacket.WriteByte(SetGameOption.Main_BGM);
                outPacket.WriteByte(SetGameOption.Sound_effect);
                outPacket.WriteByte(SetGameOption.Full_screen);
                outPacket.WriteByte(SetGameOption.Unk1);
                outPacket.WriteByte(SetGameOption.Unk2);
                outPacket.WriteByte(SetGameOption.Unk3);
                outPacket.WriteByte(SetGameOption.Unk4);
                outPacket.WriteByte(SetGameOption.Unk5);
                outPacket.WriteByte(SetGameOption.Unk6);
                outPacket.WriteByte(SetGameOption.Unk7);
                outPacket.WriteByte(SetGameOption.Unk8);
                outPacket.WriteByte(SetGameOption.Unk9);
                outPacket.WriteByte(SetGameOption.Unk10);
                outPacket.WriteByte(SetGameOption.Unk11);
                outPacket.WriteByte(SetGameOption.BGM_Check);
                outPacket.WriteByte(SetGameOption.Sound_Check);
                outPacket.WriteByte(SetGameOption.Unk12);
                outPacket.WriteByte(SetGameOption.Unk13);
                outPacket.WriteByte(SetGameOption.GameType);
                outPacket.WriteByte(SetGameOption.SetGhost);
                outPacket.WriteByte(SetGameOption.SpeedType);
                outPacket.WriteByte(SetGameOption.Unk14);
                outPacket.WriteByte(SetGameOption.Unk15);
                outPacket.WriteByte(SetGameOption.Unk16);
                outPacket.WriteByte(SetGameOption.Unk17);
                outPacket.WriteBytes(new byte[80]);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRpEnterMyRoomPacket()
        {
            if (GameType.EnterMyRoomType == 0)
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString(SetRider.Nickname);
                    outPacket.WriteByte(0);
                    outPacket.WriteShort(SetMyRoom.MyRoom);
                    outPacket.WriteByte(SetMyRoom.MyRoomBGM);
                    outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(SetMyRoom.UseItemPwd);
                    outPacket.WriteByte(SetMyRoom.TalkLock);
                    outPacket.WriteString(SetMyRoom.RoomPwd);
                    outPacket.WriteString("");
                    outPacket.WriteString(SetMyRoom.ItemPwd);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
            else
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString("");
                    outPacket.WriteByte(GameType.EnterMyRoomType);
                    outPacket.WriteShort(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(1);
                    outPacket.WriteString("");//RoomPwd
                    outPacket.WriteString("");
                    outPacket.WriteString("");//ItemPwd 
                    outPacket.WriteShort(0);
                    outPacket.WriteShort(0);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
        }

        public static void RmNotiMyRoomInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmNotiMyRoomInfoPacket"))
            {
                outPacket.WriteShort(SetMyRoom.MyRoom);
                outPacket.WriteByte(SetMyRoom.MyRoomBGM);
                outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetMyRoom.UseItemPwd);
                outPacket.WriteByte(SetMyRoom.TalkLock);
                outPacket.WriteString(SetMyRoom.RoomPwd);
                outPacket.WriteString("");
                outPacket.WriteString(SetMyRoom.ItemPwd);
                outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetRiderInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteHexString("3C 9A 17 43");//2008.02.08
                for (int i = 1; i <= Program.MAX_EQP_P; i++)
                {
                    outPacket.WriteShort(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteString("");
                outPacket.WriteInt(SetRider.RP);
                outPacket.WriteInt(0);
                outPacket.WriteByte(6);//Licenses
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteBytes(new byte[17]);
                outPacket.WriteShort(SetRider.Emblem1);
                outPacket.WriteShort(SetRider.Emblem2);
                outPacket.WriteShort(0);
                outPacket.WriteString(SetRider.RiderIntro);
                outPacket.WriteInt(SetRider.Premium);
                outPacket.WriteByte(1);
                if (SetRider.Premium == 0)
                    outPacket.WriteInt(0);
                else if (SetRider.Premium == 1)
                    outPacket.WriteInt(10000);
                else if (SetRider.Premium == 2)
                    outPacket.WriteInt(30000);
                else if (SetRider.Premium == 3)
                    outPacket.WriteInt(60000);
                else if (SetRider.Premium == 4)
                    outPacket.WriteInt(120000);
                else if (SetRider.Premium == 5)
                    outPacket.WriteInt(200000);
                else
                    outPacket.WriteInt(0);
                if (SetRider.ClubMark_LOGO == 0)
                {
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                    outPacket.WriteString("");
                }
                else
                {
                    outPacket.WriteInt(SetRider.ClubCode);
                    outPacket.WriteInt(SetRider.ClubMark_LOGO);
                    outPacket.WriteInt(SetRider.ClubMark_LINE);
                    outPacket.WriteString(SetRider.ClubName);
                }
                outPacket.WriteInt(0);
                outPacket.WriteByte(SetRider.Ranker);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrCheckMyClubStatePacket()
        {
            using (OutPacket outPacket = new OutPacket("PrCheckMyClubStatePacket"))
            {
                if (SetRider.ClubMark_LOGO == 0)
                {
                    outPacket.WriteInt(0);
                    outPacket.WriteString("");
                    outPacket.WriteInt(0);
                    outPacket.WriteInt(0);
                }
                else
                {
                    outPacket.WriteInt(SetRider.ClubCode);
                    outPacket.WriteString(SetRider.ClubName);
                    outPacket.WriteInt(SetRider.ClubMark_LOGO);
                    outPacket.WriteInt(SetRider.ClubMark_LINE);
                }
                outPacket.WriteShort(5);//Grade
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteInt(1);//ClubMember
                outPacket.WriteByte(5);//Level
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRequestChStaticReplyPacket()
        {
            using (OutPacket outPacket = new OutPacket("ChRequestChStaticReplyPacket"))
            {
                outPacket.WriteHexString("01 16 03 00 00 53 01 D6 67 0C A8 E6 0D 00 00 78 DA A5 56 69 53 13 41 10 7D 72 24 24 21 BB D9 0D 44 83 78 1F A8 78 22 88 07 A0 72 24 C6 2A 2D 0B FC 6E 19 B2 20 C5 92 50 49 14 FD F7 76 77 18 B2 0B C3 CE 44 2B 55 BB 3B DD AF 5F 1F E9 99 E9 1A 80 F7 2E 3D 3A E8 22 C0 77 84 F4 FE 81 9A AC 0E E8 DD 44 03 7B C8 E4 05 72 48 C2 80 04 4A 5C 21 03 36 1C 62 86 BD 63 9B CF F4 3C 3A 61 F8 2A AC 07 18 3E 1F A2 D8 46 8A 46 16 E5 70 B4 68 64 53 D0 54 26 16 BA 62 4A 67 B4 19 8D E5 B5 68 45 96 2D 24 AA 03 79 E6 0A 89 C5 EA 81 C6 3D 0B A6 39 E4 3D 0B AE 39 38 93 C6 D2 F5 A4 75 42 05 70 27 8D E5 8B C2 0B AE 36 D6 28 C4 73 B5 71 46 21 3E 97 65 17 3F 69 11 8A 52 E7 BE 98 8D 81 FA 8C 13 0E 29 B6 A9 35 D9 F3 21 A9 5B E4 A2 83 4D 7A FF 91 B6 9D 4C 11 A0 4E 9F 5D FA 85 64 53 62 C1 0E E9 0F 88 2E 24 C5 C5 31 11 F0 E7 EE 49 12 97 A2 42 15 76 59 FF 0F F2 7B 87 DE 4D 09 7E 4A DF 0B 71 D0 E5 6C A4 D2 0A 52 25 A3 69 4F A3 D8 20 AB 5E 8E 4D D2 30 EC 4A 4E EB 84 55 57 DD C4 0E 62 C8 35 DF A2 C9 18 78 DD 91 B2 B7 C5 73 83 04 6D 8A ED 37 BE 9D 44 78 C3 3D 07 D0 67 BF 59 34 42 54 21 6F 99 A1 2A D6 DB 53 D6 AC F1 CA DF 29 1B 52 D2 F7 FD DD C1 CC 54 98 33 9E 74 5F 0B FB F4 E4 76 EB 7D 9F 66 BF 97 0C 53 6C F7 CB 5A D8 96 21 E5 07 26 33 7D 8F CE FA 96 DE 1E FA 96 FC 8F F4 A7 C1 96 B4 76 83 8C 8E F0 58 DF BD 51 C8 93 92 91 25 9E C8 D3 92 91 33 6E F0 2C 4D 06 A1 14 5F B1 CF F5 45 CA FE F9 78 64 AB 7E 3A 36 56 F8 79 9D 52 59 2E 70 40 5D 39 FD DA A4 E4 B3 89 B7 37 83 76 B5 2D FC C2 D6 40 79 58 9C 4E 34 48 EE F5 97 FF 62 AC 3C BF 4A 36 0E 05 C6 27 79 A0 E9 A4 D7 9C E7 2F 31 ED 10 A4 43 04 2D 52 04 E2 B5 07 59 93 93 BB 2E EB 00 6F BC 73 0C BE D0 AA 27 E3 70 97 46 E4 96 08 69 59 C7 B2 13 59 6C 52 34 DB E2 A0 5F C4 95 BC 16 A0 F2 7E CB 2D DA 26 3F DC 3C AB 04 6B 11 60 3F C6 F0 8E 5D 34 24 55 1E 9B FA 65 50 55 5A 2D 9C 99 AD CE 56 63 CD D7 DC 05 35 B9 03 82 E3 B3 A8 2B 06 EB D1 21 AA A6 2D D4 86 AB E1 8A 43 2A FA DB 2D 0E AA EA 6F B7 38 E8 C3 84 C5 3D C9 FF 54 9B 77 D8 84 C5 7D A9 C0 1F 9D 48 1A EB F4 07 B5 4E B9 E6 1B E4 02 CC C9 6E 10 02 19 98 27 18 CE 17 43 30 57 78 9D 81 C3 B0 A9 4F 95 A1 23 B0 A9 77 85 A1 A3 B0 19 3C F8 94 47 0A 36 E3 07 5F 9E 48 63 B0 E9 90 4B 8F 31 0C 36 23 72 DD 90 85 79 0C E4 8D 8C 1C 4E 4F 6B EC 0D E3 88 EE DF 25 16 E5 61 DA C5 CB 0C 73 90 BC 97 57 18 E4 22 E9 B0 9E 67 48 01 83 1E D9 0B 6C E6 E1 7F CE E1 45 A6 F0 61 37 42 CC 30 B8 08 DB 3B 7B 96 E1 7F 01 B5 F2 67 D7");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrDynamicCommand()
        {
            using (OutPacket outPacket = new OutPacket("PrDynamicCommand"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrQuestUX2ndPacket()
        {
            //questGroupIndex='2' seasonId='17' kartPassSetId='1' unk='0' id='13'
            //EX) 217010013
            int NormalQuest = 4;
            int KartPassQuest = 0;
            int All_Quest = NormalQuest + KartPassQuest;
            using (OutPacket outPacket = new OutPacket("PrQuestUX2ndPacket"))
            {
                outPacket.WriteInt(1);
                outPacket.WriteInt(1);
                outPacket.WriteInt(All_Quest);
                for (int i = 1372; i <= 1378; i++)
                {
                    if (i == 1372 || i == 1376 || i == 1377 || i == 1378)
                    {
                        outPacket.WriteInt(i);
                        outPacket.WriteInt(i);
                        outPacket.WriteInt(0);
                        outPacket.WriteInt(0);
                        outPacket.WriteInt(0);
                        outPacket.WriteInt(0);
                        outPacket.WriteInt(2);
                        outPacket.WriteInt(0);
                        outPacket.WriteByte(0);
                    }
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrLogin()
        {
            using (OutPacket outPacket = new OutPacket("PrLogin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteByte(2);
                outPacket.WriteByte(1);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(1415577599);
                outPacket.WriteUInt(SetRider.pmap);
                for (int i = 0; i < 11; i++)
                {
                    outPacket.WriteInt(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39311);
                outPacket.WriteEndPoint(IPAddress.Parse(RouterListener.forceConnect), 39312);
                outPacket.WriteInt(0);
                outPacket.WriteString("");
                outPacket.WriteInt(0);
                outPacket.WriteByte(1);
                outPacket.WriteString("content");
                outPacket.WriteInt(0);
                outPacket.WriteInt(1);
                outPacket.WriteString("cc");
                outPacket.WriteString(SessionGroup.Service);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetRider.IdentificationType);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}